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
    public partial class EndOfDayManager : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        public EndOfDayManager()
        {
            string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

            connection.ConnectionString = m_strDataBaseFilePath;

            InitializeComponent();

            ReturnThings();
        }

        public void ReturnThings()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            command.CommandText = @"SELECT * FROM Invoice ORDER BY InvoiceNumber";

            reader = command.ExecuteReader();

            string sLargeString = "";

            int iCount = 0;

            while (reader.Read())
            {
                if (reader["DPReturnYear"].ToString() != "To Pay")
                {
                    int iYear = 0;
                    int iMonth = 0;
                    int iDay = 0;

                    int.TryParse(reader["DPReturnYear"].ToString(), out iYear);
                    int.TryParse(reader["DPReturnMonth"].ToString(), out iMonth);
                    int.TryParse(reader["DPReturnDay"].ToString(), out iDay);

                    DateTime dt = new DateTime(iYear, iMonth, iDay, 12, 0, 0);

                    sLargeString += dt + "\r\n";
                }
                else
                {
                    sLargeString += "\r\n";
                }

                iCount++;
            }

            connection.Close();

            txt_returns.Text = sLargeString;
        }
    }
}