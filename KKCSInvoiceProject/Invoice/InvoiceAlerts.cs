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
    public partial class InvoiceAlerts : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        private OleDbConnection connection = new OleDbConnection();

        string g_sCarRego = "";

        public InvoiceAlerts()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            cmb_worker.SelectedIndex = 0;
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

                string sNonQuery = @"INSERT INTO Alerts (Rego,Alert,StaffMember,DateAndTime) values ('" + g_sCarRego +
                                                                                                        "', '" + txt_newalert.Text +
                                                                                                        "', '" + cmb_worker.Text +
                                                                                                        "', '" + DTNow + "')";

                command.CommandText = sNonQuery;

                command.ExecuteNonQuery();

                CloseDBCon();

                LoadAlerts();
            }
        }

        string blah = "";

        private void LoadAlerts()
        {
            OpenDBCon();

            command = new OleDbCommand();

            command.Connection = connection;

            string sQuery = @"SELECT * FROM Alerts WHERE Rego = '" + g_sCarRego + "' ORDER BY DateAndTime DESC";

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
                lbl.Text = reader["Alert"].ToString() + "\r\n" + "-" + reader["StaffMember"].ToString() + " (" + sDate + ")";
                blah += lbl.Text + "\r\n\r\n";
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(400, 0);
                lbl.Font = label4.Font;

                btn.Location = new Point(iButtonLocX, iLocY);
                btn.Name = reader["ID"].ToString();
                btn.Text = "Delete";

                btn.Click += new EventHandler(AlertDelete_Click);

                panel1.Controls.Add(lbl);
                panel1.Controls.Add(btn);

                iLocY += 100;
            }

            CloseDBCon();
        }

        private void AlertDelete_Click(object sender, EventArgs e)
        {
            DeleteControls();

            Button btn = (Button)sender;

            OpenDBCon();

            command = new OleDbCommand();

            command.Connection = connection;

            string sQuery = @"DELETE * FROM Alerts WHERE ID = " + btn.Name + "";

            command.CommandText = sQuery;

            reader = command.ExecuteReader();

            CloseDBCon();

            LoadAlerts();
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

        public void GetRego(string _sCarRego)
        {
            g_sCarRego = _sCarRego;

            //lbl_invoice.Text = "Invoice " + _iInvoiceNumber.ToString() + " Notes";

            LoadAlerts();
        }

        public string GetCurrentAlert()
        {
            return (blah);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}