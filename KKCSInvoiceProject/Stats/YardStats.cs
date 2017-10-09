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

        float fYear2014 = 84205.0f;
        float fYear2015 = 111572.10f;
        float fYear2016 = 139034.52f;
        float fYear2017 = 66556.14f;

        float fYear2014JJ = 36651.0f;
        float fYear2015JJ = 50497.10f;
        float fYear2016JJ = 52697.00f;
        float fYear2017JJ = 66556.14f;

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

            //YTDMoney();

            MonthByMonthMoney();

            //TextYard();

            //CarStats();
        }

        void CarStats()
        {
            connection.Open();

            DateTime dtTodaysDate = new DateTime(2017, 1, 1, 12, 0, 0);

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from CustomerInvoices WHERE year(DTDateIn) = year(@dtTodaysDate) ORDER BY InvoiceNumber ASC";
            //string query = "select * from CustomerInvoices ORDER BY InvoiceNumber ASC";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            // Works out how many days there are between the date the car was
            // brought in, and when they are returning
            // Put the difference of days into the variable

            List<int> lstDays = new List<int>();

            int iDays = 0;
            
            while (reader.Read())
            {
                DateTime dtDateIn = (DateTime)reader["DTDateIn"];
                DateTime dtDateReturn = (DateTime)reader["DTReturnDate"];

                TimeSpan TimeDifference = dtDateReturn - dtDateIn;

                iDays = TimeDifference.Days;

                lstDays.Add(iDays);
            }

            lstDays.Sort();

            int iCount = 0;

            // Stores the time from the table
            int StoreDays = 0;

            // Stores time at end to compare and see if a new time has shown
            int StoreDaysSecond = 0;

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            lbl_money.Text = "";// lstDays[0].ToString() + "\r\n";

            int iAmountOfDaysCount = 0;

            while (iCount < lstDays.Count)
            {
                // Gets the current time of the record
                StoreDays = lstDays[iCount];

                if (StoreDays != StoreDaysSecond && !bSkipFirstCheck && StoreDays > 0)
                {
                    lbl_money.Text += StoreDays.ToString("00") + " Days = " + iAmountOfDaysCount.ToString() + "x" + "\r\n";

                    iAmountOfDaysCount = 0;
                }

                iAmountOfDaysCount++;

                // Makes the Second time = the first time for comparision purposes
                StoreDaysSecond = StoreDays;

                // Makes the first check to false for using
                bSkipFirstCheck = false;

                iCount++;
            }
        }

        void TextYard()
        {
            string sNL = "\r\n";

            string sMoney = "Kerikeri Car Storage Income 2014-2016" + sNL;
            sMoney += "----------------------------------------------------" + sNL;
            sMoney += "2014: $" + fYear2014.ToString("N") + " Total Income" + sNL;
            sMoney += "2015: $" + fYear2015.ToString("N") + " Total Income" + sNL;
            sMoney += "2016: $" + fYear2016.ToString("N") + " Total Income" + sNL;
            sMoney += "2017: $" + fYear2017.ToString("N") + " Current Jan-Jun Income";

            sMoney += sNL + sNL;

            sMoney += "2015: " + (((fYear2015 - fYear2014) / fYear2014) * 100.0f).ToString("N") + "% Growth Increase Over 2014";

            sMoney += sNL;

            sMoney += "2016: " + (((fYear2016 - fYear2015) / fYear2015) * 100.0f).ToString("N") + "% Growth Increase Over 2015";

            sMoney += sNL + sNL + sNL;

            sMoney += "Kerikeri Car Storage Jan-Jun 2014-2017" + sNL;
            sMoney += "----------------------------------------------------" + sNL;
            sMoney += "2014 Jan-Jun: $" + fYear2014JJ.ToString("N") + " Total Income" + sNL;
            sMoney += "2015 Jan-Jun: $" + fYear2015JJ.ToString("N") + " Total Income" + sNL;
            sMoney += "2016 Jan-Jun: $" + fYear2016JJ.ToString("N") + " Total Income" + sNL;
            sMoney += "2017 Jan-Jun: $" + fYear2017JJ.ToString("N") + " Total Income";

            sMoney += sNL + sNL;

            sMoney += "2015 Jan-Jun: " + (((fYear2016JJ - fYear2014JJ) / fYear2014JJ) * 100.0f).ToString("N") + "% Growth Increase Over 2014";

            sMoney += sNL;

            sMoney += "2016 Jan-Jun: " + (((fYear2016JJ - fYear2015JJ) / fYear2015JJ) * 100.0f).ToString("N") + "% Growth Increase Over 2015";

            sMoney += sNL;

            sMoney += "2017 Jan-Jun: " + (((fYear2017JJ - fYear2016JJ) / fYear2016JJ) * 100.0f).ToString("N") + "% Growth Increase Over 2016";

            lbl_money.Text = sMoney;
        }

        void YTDMoney()
        {
            connection.Open();

            DateTime dtTodaysDate = new DateTime(2017, 1, 1, 12, 0, 0);

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

            string sCashTotal = "YTD Cash Total: $" + iCash.ToString("N") + "\r\n";
            
            string sEftposTotal = "YTD Eftpos Total: $" + fEftpos.ToString("N") + "\r\n";

            string sCreditCardTotal = "YTD Credit Card Total: $" + fCreditCard.ToString("N") + "\r\n";

            string sAccountTotal = "YTD Account Total: $" + fAccount.ToString("N") + "\r\n";

            string sTotal = "YTD Total: $" + ((float)iCash + fEftpos + fCreditCard + fAccount).ToString("N") + "/r/n";

            lbl_money.Text = sCashTotal + sEftposTotal + sCreditCardTotal + sAccountTotal + sTotal;

            connection.Close();
        }

        void MonthByMonthMoney()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "SELECT * FROM CustomerInvoices ORDER BY DTDatePaid ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            float fTotalMonthly = 0.0f;

            DateTime DTStoreDate = new DateTime();
            DateTime DTStoreDateSecond = new DateTime();
            bool bSkipFirstTime = true;

            lbl_money.Text = "";
            lbl_daily.Text = "";

            while (reader.Read())
            {
                DTStoreDate = (DateTime)reader["DTDatePaid"];

                if (DTStoreDate.Month != DTStoreDateSecond.Month && !bSkipFirstTime)
                {
                    lbl_money.Text += DTStoreDate.ToString("MMM").ToUpper() + " " + DTStoreDate.ToString("yy") +":    $" + fTotalMonthly.ToString("00.00") + "\r\n";

                    lbl_daily.Text += "$" + (fTotalMonthly / 30).ToString("00.00") + " (Per Day)" + "\r\n";

                    fTotalMonthly = 0.0f;
                }


                float fTotal = 0.0f;
                float.TryParse(reader["TotalPay"].ToString(), out fTotal);

                if(fTotal < 0.0f)
                {
                    int fgh = 9;
                }

                fTotalMonthly += fTotal;

                bSkipFirstTime = false;

                DTStoreDateSecond = DTStoreDate;
            }

            lbl_money.Text += DTStoreDate.ToString("MMM").ToUpper() + " " + DTStoreDate.ToString("yy") + ":    $" + fTotalMonthly.ToString("00.00") + "\r\n";

            lbl_daily.Text += "$" + (fTotalMonthly / 30).ToString("00.00") + " (Per Day)" + "\r\n";

            //string sCashTotal = "YTD Cash Total: $" + iCash.ToString("N") + "\r\n";

            //string sEftposTotal = "YTD Eftpos Total: $" + fEftpos.ToString("N") + "\r\n";

            //string sCreditCardTotal = "YTD Credit Card Total: $" + fCreditCard.ToString("N") + "\r\n";

            //string sAccountTotal = "YTD Account Total: $" + fAccount.ToString("N") + "\r\n";

            //string sTotal = "YTD Total: $" + ((float)iCash + fEftpos + fCreditCard + fAccount).ToString("N") + "/r/n";

            //lbl_money.Text = sCashTotal + sEftposTotal + sCreditCardTotal + sAccountTotal + sTotal;

            connection.Close();
        }
    }
}
