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
        string g_sRego = "";

        public InvoiceNotes()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            FindStaffMembers();

            cmb_worker.SelectedIndex = 0;
        }

        void FindStaffMembers()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from Staff";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            cmb_worker.Items.Add("Please Pick...");

            while (reader.Read())
            {
                cmb_worker.Items.Add(reader["StaffMember"].ToString());
            }

            connection.Close();
        }

        private void btn_addnote_Click(object sender, EventArgs e)
        {
            if (cmb_worker.Text == "Please Pick...")
            {
                WarningSystem ws = new WarningSystem("Please pick Staff Memeber", false);
                ws.ShowDialog();
            }
            else
            {
                DeleteControls();

                OpenDBCon();

                command = new OleDbCommand();

                command.Connection = connection;

                DateTime DTNow = DateTime.Now;

                string sNotes = txt_newnote.Text;

                sNotes = sNotes.Replace("'", "''");

                string sNonQuery = @"INSERT INTO InvoiceNotes (Notes,StaffMember,Rego,DateAndTime,InvoiceNumber) values ('" + sNotes +
                                                                                                        "', '" + cmb_worker.Text +
                                                                                                        "', '" + g_sRego +
                                                                                                        "', '" + DTNow +
                                                                                                        "', " + g_iInoviceNumber + ")";

                command.CommandText = sNonQuery;

                command.ExecuteNonQuery();

                CloseDBCon();

                LoadNotes();
            }
        }

        string blah = "";

        private void LoadNotes()
        {
            OpenDBCon();

            command = new OleDbCommand();

            command.Connection = connection;

            string sQuery = @"SELECT * FROM InvoiceNotes WHERE InvoiceNumber = "+ g_iInoviceNumber + " ORDER BY DateAndTime DESC";

            command.CommandText = sQuery;

            reader = command.ExecuteReader();

            blah = "";

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
                blah += lbl.Text + "\r\n\r\n";
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

        public void GetRego(string _sRego)
        {
            g_sRego = _sRego;
        }

        public string GetCurrentNotes()
        {
            return (blah);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}