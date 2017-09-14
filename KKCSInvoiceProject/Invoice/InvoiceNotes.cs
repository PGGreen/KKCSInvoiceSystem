using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace KKCSInvoiceProject
{
    public partial class InvoiceNotes : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        private OleDbConnection connection = new OleDbConnection();

        int g_iInoviceNumber = 0;

        public InvoiceNotes()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            cmb_worker.SelectedIndex = 0;
        }

        private void btn_addnote_Click(object sender, EventArgs e)
        {
            DeleteControls();

            if (cmb_worker.Text == "Please Pick...")
            {
                WarningSystem ws = new WarningSystem("Please pick Staff Memeber", false);
                ws.ShowDialog();
            }
            else
            {
                OpenDBCon();

                command = new OleDbCommand();

                command.Connection = connection;

                DateTime DTNow = DateTime.Now;

                string sNonQuery = @"INSERT INTO InvoiceNotes (Notes,StaffMember,DateAndTime,InvoiceNumber) values ('" + txt_newnote.Text +
                                                                                                        "', '" + cmb_worker.Text +
                                                                                                        "', '" + DTNow +
                                                                                                        "', " + g_iInoviceNumber + ")";

                command.CommandText = sNonQuery;

                command.ExecuteNonQuery();

                CloseDBCon();

                LoadNotes();
            }
        }

        private void LoadNotes()
        {
            OpenDBCon();

            command = new OleDbCommand();

            command.Connection = connection;

            string sQuery = @"SELECT * FROM InvoiceNotes WHERE InvoiceNumber = "+ g_iInoviceNumber + " ORDER BY DateAndTime DESC";

            command.CommandText = sQuery;

            reader = command.ExecuteReader();

            int iLocX = label4.Location.X;
            int iLocY = label4.Location.Y;

            int iButtonLocX = button1.Location.X;

            while (reader.Read())
            {
                DateTime dtNoteTime = (DateTime)reader["DateAndTime"];
                string sDate = dtNoteTime.Day.ToString() + "/" + dtNoteTime.Month + "/" + dtNoteTime.ToString("yy") + " - " + dtNoteTime.ToString("h:mm tt");

                Label lbl = new Label();
                Button btn = new Button();

                lbl.Location = new Point(iLocX, iLocY);
                lbl.Text = reader["Notes"].ToString() + "\r\n" + "-" + reader["StaffMember"].ToString() + " (" + sDate + ")";
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(400, 0);
                lbl.Font = label4.Font;

                btn.Location = new Point(iButtonLocX, iLocY);
                btn.Name = reader["ID"].ToString();
                btn.Text = "Delete";

                btn.Click += new EventHandler(InvoiceButton_Click);

                panel1.Controls.Add(lbl);
                panel1.Controls.Add(btn);

                iLocY += 100;
            }

            CloseDBCon();
        }

        private void InvoiceButton_Click(object sender, EventArgs e)
        {
            DeleteControls();

            Button btn = (Button)sender;

            OpenDBCon();

            command = new OleDbCommand();

            command.Connection = connection;

            string sQuery = @"DELETE * FROM InvoiceNotes WHERE ID = " + btn.Name + "";

            command.CommandText = sQuery;

            reader = command.ExecuteReader();

            CloseDBCon();

            LoadNotes();
        }

        void DeleteControls()
        {
            foreach (Label lbl in panel1.Controls.OfType<Label>().ToArray())
            {
                panel1.Controls.Remove(lbl);
            }

            foreach (Button lbl in panel1.Controls.OfType<Button>().ToArray())
            {
                panel1.Controls.Remove(lbl);
            }
        }

        private void OpenDBCon()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void CloseDBCon()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void GetInvoiceNumber(int _iInvoiceNumber)
        {
            g_iInoviceNumber = _iInvoiceNumber;

            lbl_invoice.Text = "Invoice " + _iInvoiceNumber.ToString() + " Notes";

            LoadNotes();
        }

        public string GetCurrentNotes()
        {
            return (label4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}