using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KKCSInvoiceProject
{
    public partial class AlertsAndNotes : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        // Creates the OleDbConnection
        private OleDbConnection connection = new OleDbConnection();

        // Creates the OleDb Items
        OleDbDataReader reader;

        // Sets up the main OleDb Command
        OleDbCommand command;

        public AlertsAndNotes(string _DatePicked)
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            Testing(_DatePicked);
        }

        void Testing(string _DatePicked)
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string g_strDatePicked = "";
            string PickedReturnValue = "ReturnDate";

            DateTime dt = DateTime.Today;

            //Testing
            dt = dt.AddDays(-2);

            g_strDatePicked = dt.DayOfWeek.ToString() + ", " +
            dt.Day.ToString() + " " +
            dt.ToString("MMMM") + " " +
            dt.Year.ToString();

            string query = @"select * from Invoice WHERE " + PickedReturnValue + " = '" + g_strDatePicked + "' ORDER BY DisplayedReturnDate,ReturnTime";

            command.CommandText = query;

            reader = command.ExecuteReader();

            label1.MaximumSize = new Size(1000, 0);
            label1.AutoSize = true;

            while (reader.Read())
            {
                string sStore = reader["Alerts"].ToString();

                if (sStore != "")
                {
                    label1.Text = sStore;
                }
            }

            connection.Close();
        }
    }
}
