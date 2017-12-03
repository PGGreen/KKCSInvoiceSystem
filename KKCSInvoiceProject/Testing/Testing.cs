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
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class Testing : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        private OleDbConnection connection = new OleDbConnection();

        public Testing()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            label1.Text = "";

            Test();
        }

        void Test()
        {
            connection.Open();

            DateTime dtTodaysDate = new DateTime(2017, 10, 7, 12, 0, 0);

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "SELECT * FROM CustomerInvoices WHERE year(DTDatePaid) = year(@dtTodaysDate) AND month(DTDatePaid) >= month(@dtTodaysDate) AND PaidStatus = 'Cash' ORDER BY DTDatePaid";
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            command.CommandText = query;

            reader = command.ExecuteReader();

            int iTotalPrice = 0;

            while (reader.Read())
            {
                DateTime dtDate = (DateTime)reader["DTDatePaid"];

                if (dtDate.Month == 11 && dtDate.Day > 17)
                {
                    break;
                }

                if (dtDate.Month == 10 && dtDate.Day >= 6)
                {
                    int iPrice = 0;
                    int.TryParse(reader["TotalPay"].ToString(), out iPrice);

                    iTotalPrice += iPrice;
                }


            }

            label1.Text = iTotalPrice.ToString();
        }
    }
}
