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
    public partial class DailyCarsStats : Form
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

        public DailyCarsStats()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            //Test();
        }

        void Test()
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart1.ChartAreas[0].AxisY.Title = "Money ($)";

            chart1.Series.Add(sSeries("Daily Cars", Color.Red));
            //chart1.Series.Add(sSeries("Cash23", Color.Black));

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtDate = DateTime.Today;
            
            dtDate = new DateTime(2017, 2, dtDate.Day, 12, 0, 0);

            string query = @"select * from CustomerInvoices WHERE year(DTDateIn) = year(@dtDate)
                            AND month(DTDateIn) = month(@dtDate) 
                            ORDER BY DTDateIn ASC";

            command.Parameters.AddWithValue("@dtDate", dtDate);
            command.CommandText = query;

            reader = command.ExecuteReader();

            int iCount = 0;

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            // Stores the time from the table
            double StoreTime = 0.0f;

            DateTime dt;
            string sDay;

            // Stores time at end to compare and see if a new time has shown
            double StoreTimeSecond = 0.0f;

            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            while (reader.Read())
            {
                // Gets the current time of the record
                //StoreTime = ((DateTime)reader["DTDateIn"]).Day;

                //string sDay = StoreTime.ToString() + ((DateTime)reader["DTDateIn"]).ToString("ddd");

                // Gets the current time of the record
                StoreTime = ((DateTime)reader["DTDateIn"]).Day;

                // Compares the 2 times together to see if they are different or not
                // Skips the first check
                if (StoreTime != StoreTimeSecond && !bSkipFirstCheck)
                {
                    dt = (DateTime)reader["DTDateIn"];
                    dt = dt.AddDays(-1);
                    sDay = (StoreTime - 1.0f).ToString() + " " + dt.ToString("ddd");

                    chart1.Series["Daily Cars"].Points.AddXY(sDay, iCount);

                    iCount = 0;
                }

                // Makes the Second time = the first time for comparision purposes
                StoreTimeSecond = StoreTime;

                //if(!bSkipFirstCheck)
                //{
                    iCount++;
                //}
                
                bSkipFirstCheck = false;

                // Makes the first check to false for using
                //bSkipFirstCheck = false;
                //string Invoice = reader["InvoiceNumber"].ToString();

                //DateTime DTReturn = (DateTime)reader["DTReturnDate"];
                //DateTime DTDateIn = (DateTime)reader["DTDateIn"];

                //int iDate = (((DateTime)reader["DTReturnDate"]) - ((DateTime)reader["DTDateIn"])).Days;

                //chart1.Series["Cash"].Points.AddXY(iTest, iDate);
                //chart1.Series["Cash23"].Points.AddXY(iTest, iDate - 4);
            }

            //dt = (DateTime)reader["DTDateIn"];
            //dt = dt.AddDays(-1);
            //sDay = (StoreTime - 1.0f).ToString() + " " + dt.ToString("ddd");

            //chart1.Series["Daily Cars"].Points.AddXY(sDay, iCount);

            connection.Close();

            //chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            //while (reader.Read())
            //{
            //    SetUpCollumns();

            //    iCount++;
            //}

            //AddingToChart(0);

            //lbl_cash.Text += " $" + iCashTotal;
            //lbl_eftpos.Text += " $" + iEftposTotal;
            //lbl_total.Text += " $" + iTotal;

            //connection.Close();
        }

        /*
        void Test()
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart1.ChartAreas[0].AxisY.Title = "Money ($)";

            chart1.Series.Add(sSeries("Cash", Color.Red));
            chart1.Series.Add(sSeries("Cash23", Color.Black));

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //command.CommandText = "SELECT * FROM CustomerInvoices ORDER BY ID";

            DateTime dtDate = DateTime.Today;
            ////string query = @"SELECT * FROM Invoice WHERE ReturnMonth = '" + 02 + "' AND ReturnYear = '" + 2017 + "' AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DateInInvisible DESC";
            dtDate = new DateTime(2017, 1, dtDate.Day, 12, 0, 0);

            //string query = "select * from CustomerInvoices WHERE year(DTReturnDate) = year(@dtDate) AND month(DTDatePaid) = month(@dtDate) AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DTDateIn ASC";
            string query = @"select * from CustomerInvoices WHERE year(DTReturnDate) = year(@dtDate) 
                            AND month(DTDatePaid) = month(@dtDate) 
                            ORDER BY DTDateIn ASC";

            command.Parameters.AddWithValue("@dtDate", dtDate);
            command.CommandText = query;

            reader = command.ExecuteReader();

            int iTest = 0;

            while (reader.Read())
            {
                string Invoice = reader["InvoiceNumber"].ToString();

                DateTime DTReturn = (DateTime)reader["DTReturnDate"];
                DateTime DTDateIn = (DateTime)reader["DTDateIn"];

                int iDate = (((DateTime)reader["DTReturnDate"]) - ((DateTime)reader["DTDateIn"])).Days;

                chart1.Series["Cash"].Points.AddXY(iTest, iDate);
                chart1.Series["Cash23"].Points.AddXY(iTest, iDate - 4);

                iTest++;

                if (iTest > 30)
                {
                    break;
                }
            }

            connection.Close();

            //chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            //while (reader.Read())
            //{
            //    SetUpCollumns();

            //    iCount++;
            //}

            //AddingToChart(0);

            //lbl_cash.Text += " $" + iCashTotal;
            //lbl_eftpos.Text += " $" + iEftposTotal;
            //lbl_total.Text += " $" + iTotal;

            //connection.Close();
        }
        */

        Series sSeries(string _sName, Color cColour)
        {
            Series Series = new Series
            {
                Name = _sName,
                Color = cColour,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            return (Series);
        }

        #region YTDReport

        void PrintYTDReport()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            printDocument.PrintPage += new PrintPageEventHandler(YTDReport);

            //printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            //printDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //printDocument.PrinterSettings.PrinterName = "CutePDF Writer";

            printDocument.Print();
        }

        void NextLine(int _iAmount)
        {
            m_iNextLineOffset = m_iNextLineOffset + ((int)m_fFontHeight * +_iAmount);
        }

        public void YTDReport(object sender, PrintPageEventArgs e)
        {
            m_iNextLineOffset = 30;

            graphic = e.Graphics;

            font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up
            fontBold = new Font("Courier New", 12, FontStyle.Bold);
            fontBoldUnderline = new Font("Courier New", 12, FontStyle.Bold | FontStyle.Underline);

            m_fFontHeight = font.GetHeight();

            // Heading Title
            graphic.DrawString("YTP Report - Kerikeri Car Storage - " + dtTodaysDate.ToString("yyy"), new Font("Courier New", 16), new SolidBrush(Color.Black), m_iStartX, m_iStartY);

            // Line underneith heading title
            graphic.DrawString("------------------------------------------------------------------------", font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(2);

            // All the till information
            string sTillTitle = "YTD Money:";
            graphic.DrawString(sTillTitle, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(2);
            YTDMoney();
            NextLine(3);

            // All the Eftpos information
            //string sEftposTitle = "Daily EFTPOS + Credit Card:";
            //graphic.DrawString(sEftposTitle, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            //NextLine(1);
            //DailyEftpos();
            //NextLine(3);

            //string sDailyTotalMoneyTitle = "Daily Total Money:";
            //graphic.DrawString(sDailyTotalMoneyTitle, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            //NextLine(2);
            //string sDailyTotalMoney = "Cash + EFTPOS + Credit Card: $" + ((float)iCashTotal + fEftposTotal).ToString("0.00");
            //graphic.DrawString(sDailyTotalMoney, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            //NextLine(3);

            //string sTillRunningTotal = "Daily Running Total:";
            //graphic.DrawString(sTillRunningTotal, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            //NextLine(1);
            //TillRunningTotal();
            //NextLine(3);

            //string sPlasticBoxRunningTotal = "Daily Plastic Box Running Total:";
            //graphic.DrawString(sPlasticBoxRunningTotal, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            //NextLine(1);
            //PlasticBoxRunningTotal();
            //NextLine(3);

            //string sTodaysPettyCash = "Todays Petty Cash:";
            //graphic.DrawString(sTodaysPettyCash, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            //NextLine(1);
            //DailyPettyCash();
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
            NextLine(1);
            string sEftposTotal = "YTD Eftpos Total: $" + fEftpos.ToString("N");
            graphic.DrawString(sEftposTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);
            string sCreditCardTotal = "YTD Credit Card Total: $" + fCreditCard.ToString("N");
            graphic.DrawString(sCreditCardTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);
            string sAccountTotal = "YTD Account Total: $" + fAccount.ToString("N");
            graphic.DrawString(sAccountTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(2);
            string sTotal = "YTD Total: $" + ((float)iCash + fEftpos + fCreditCard + fAccount).ToString("N");
            graphic.DrawString(sTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            //connection.Close();
        }

        #endregion YTPReport
    }
}