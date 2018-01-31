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
    public partial class ShowNotesAlerts : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbCommand command;

        OleDbDataReader reader;

        public ShowNotesAlerts()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            lbl_notes.Text = "";

            lbl_alerts.Text = "";

            //MoneyInSeptember();
        }

        void MoneyInSeptember()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            DateTime dt = new DateTime(2016, 9, 1);

            //Testing

            //

            string query = "SELECT * FROM CustomerInvoices WHERE year(DTDatePaid) = year(@dt) AND month(DTDatePaid) = month(@dt)";


            command.CommandText = query;
            command.Parameters.AddWithValue("@dt", dt);

            reader = command.ExecuteReader();

            float fPrice = 0.0f;

            while (reader.Read())
            {
                float fTempPrice = 0.0f;
                float.TryParse(reader["TotalPay"].ToString(), out fTempPrice);

                fPrice += fTempPrice;
            }

            lbl_sep.Text = fPrice.ToString();

            connection.Close();
        }

        public void LoadNotes(string _iInvoiceNumber)
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            int x = 0;
            Int32.TryParse(_iInvoiceNumber, out x);

            string query = @"SELECT * FROM InvoiceNotes
                             WHERE InvoiceNumber = " + x + "";

            command.CommandText = query;

            reader = command.ExecuteReader();

            string tempStr = "";

            while (reader.Read())
            {
                DateTime dtNoteTime = (DateTime)reader["DateAndTime"];
                string sDate = dtNoteTime.Day.ToString() + "/" + dtNoteTime.Month + "/" + dtNoteTime.ToString("yy") + " - " + dtNoteTime.ToString("h:mm tt");

                tempStr += reader["Notes"].ToString() + "\r\n" + "-" + reader["StaffMember"].ToString() + " (" + sDate + ")";

                tempStr += "\r\n\r\n";
            }

            lbl_notes.Text = tempStr;

            connection.Close();
        }

        public void LoadAlerts(string _iRego)
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Alerts
                             WHERE Rego = '" + _iRego + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            string tempStr = "";

            while (reader.Read())
            {
                DateTime dtNoteTime = (DateTime)reader["DateAndTime"];
                string sDate = dtNoteTime.Day.ToString() + "/" + dtNoteTime.Month + "/" + dtNoteTime.ToString("yy") + " - " + dtNoteTime.ToString("h:mm tt");

                tempStr += reader["Alert"].ToString() + "\r\n" + "-" + reader["StaffMember"].ToString() + " (" + sDate + ")";

                tempStr += "\r\n\r\n";
            }

            lbl_alerts.Text = tempStr;

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}