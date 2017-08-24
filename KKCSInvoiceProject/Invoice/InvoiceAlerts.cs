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

        int g_iInoviceNumber = 0;

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

            string sQuery = @"SELECT * FROM InvoiceNotes WHERE InvoiceNumber = " + g_iInoviceNumber + "";

            command.CommandText = sQuery;

            reader = command.ExecuteReader();

            string sNotes = "";
            txtbox_currentnotes.Text = "";

            while (reader.Read())
            {
                DateTime dtNoteTime = (DateTime)reader["DateAndTime"];
                string sDate = dtNoteTime.Day.ToString() + "/" + dtNoteTime.Month + "/" + dtNoteTime.ToString("yy") + " - " + dtNoteTime.ToString("h:mm tt");

                sNotes += reader["Notes"].ToString();

                sNotes += "\r\n" + "-" + reader["StaffMember"].ToString() + " (" + sDate + ")";

                sNotes += "\r\n\r\n";
            }

            txtbox_currentnotes.Text = sNotes;

            CloseDBCon();
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
            return (txtbox_currentnotes.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
