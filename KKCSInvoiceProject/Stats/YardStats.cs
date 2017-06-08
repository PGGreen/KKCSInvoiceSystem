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
    public partial class YardStats : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        DateTime dtTodaysDate = DateTime.Today;

        // Print Member Variables
        int m_iStartX = 10;
        int m_iStartY = 10;
        int m_iNextLineOffset = 30;
        float m_fFontHeight = 0.0f;
        Font font;
        Font fontBold;
        Font fontBoldUnderline;

        Graphics graphic;

        private OleDbConnection connection = new OleDbConnection();

        public YardStats()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        void YTDMoney()
        {
            //connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from CustomerInvoices WHERE year(DTDatePaid) = year(@dtDate) AND PaidStatus <> 'To Pay' ORDER BY DTDatePaid ASC";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            int iCash = 0;
            float fEftpos = 0.0f;
            float fCreditCard = 0.0f;
            float fAccount = 0.0f;

            while (reader.Read())
            {
                switch (reader["PaidStatus"].ToString())
                {
                    case "Cash":
                        {
                            int iCashDatabase = 0;
                            int.TryParse(reader["TotalPay"].ToString(), out iCashDatabase);

                            iCash += iCashDatabase;
                            break;
                        }
                    case "Eftpos":
                        {
                            float fEftposDatabase = 0.0f;
                            float.TryParse(reader["TotalPay"].ToString(), out fEftposDatabase);

                            fEftpos += fEftposDatabase;
                            break;
                        }
                    case "Credit Card":
                        {
                            float fCreditCardDatabase = 0.0f;
                            float.TryParse(reader["TotalPay"].ToString(), out fCreditCardDatabase);

                            fCreditCard += fCreditCardDatabase;
                            break;
                        }
                    case "OnAcc":
                        {
                            float fAccountDatabase = 0.0f;
                            float.TryParse(reader["TotalPay"].ToString(), out fAccountDatabase);

                            fAccount += fAccountDatabase;
                            break;
                        }
                }
            }

            string sCashTotal = "YTD Cash Total: $" + iCash.ToString("N");
            graphic.DrawString(sCashTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            string sEftposTotal = "YTD Eftpos Total: $" + fEftpos.ToString("N");
            graphic.DrawString(sEftposTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            string sCreditCardTotal = "YTD Credit Card Total: $" + fCreditCard.ToString("N");
            graphic.DrawString(sCreditCardTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            string sAccountTotal = "YTD Account Total: $" + fAccount.ToString("N");
            graphic.DrawString(sAccountTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            string sTotal = "YTD Total: $" + ((float)iCash + fEftpos + fCreditCard + fAccount).ToString("N");
            graphic.DrawString(sTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            //connection.Close();
        }
    }
}
