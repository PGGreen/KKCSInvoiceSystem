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
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class EndOfDay : Form
    {
        #region GlobalVariables

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        string EODDate = "";
        string NextDayDate = "";

        string g_strDatePicked = "";

        string g_sTodaysPettyCashItems = "";

        int g_iIsTherePettyCashToday = 0;
        float g_fTotalPettyCashToday = 0.0f;
        float g_fTotalPettyCashRemaning = 0.0f;

        //float g_fTotalPettyCash = 0.0f;
        int g_iRefunds = 0;
        float fTotalForDay = 0.0f;
        float fTomorrow = 0.0f;
        float fTomorrowPlasticContainer = 0.0f;

        string sCombinedAccount = "";

        //////////////////////////////////////////
        OleDbCommand command;

        OleDbDataReader reader;

        DateTime dtTodaysDate = DateTime.Today;
        DateTime dtTomorrowsDate = DateTime.Today;

        string g_sTitleHeader = "";

        bool g_bStepOneDailyTotalPrinted = false;
        bool g_bStepTwoCash = false;
        bool g_bStepThreeEftpos = false;
        bool g_bStepFourConfirmation = false;

        int g_iTotalCash = 0;

        float g_fTotalEftpos = 0.0f;
        //////////////////////////////////////////////////////

        #endregion

        #region Loading

        public EndOfDay()
        {
            // Initialises the end of day
            InitializeComponent();

            // Makes the connection string the database path
            connection.ConnectionString = m_strDataBaseFilePath;

            cmb_worker.SelectedIndex = 0;

            // Creates todays date for end of date
            dtTodaysDate = new DateTime(dtTodaysDate.Year, dtTodaysDate.Month, dtTodaysDate.Day, 12, 0, 0);
            //dtTodaysDate = new DateTime(2017, 9, 11, 12, 0, 0);

            // Creates the title for title
            g_sTitleHeader = dtTodaysDate.Day.ToString() + "/" + dtTodaysDate.Month.ToString() + "/" + dtTodaysDate.Year.ToString();

            // Creates the top title
            txt_eodheader.Text = "End of Day - " + g_sTitleHeader + " (" + dtTodaysDate.ToString("ddd") + ")";

            CarInReport();

            // Step Two - Calculate Todays Cash
            GetSODTill();
            GetCashTotal();
            GetCashRefunds();
            TotalCash();

            // Step Three - Calculate Todays Eftpos
            GetEftposTotal();
        }

        void EmailAccountsEndOfMonth()
        {
            connection.Open();

            //PrintYTDReport();

            //AccountsTest();

            //SendEmailTest();

            connection.Close();
        }

        #endregion

        #region StepOnePrintDailyTotals

        private void btn_printdailytotal_Click(object sender, EventArgs e)
        {
            PrintTodaysReport();

            btn_printdailytotal.Text = "Print Again";
            btn_printdailytotal.BackColor = Color.Green;

            pnl_steptwo.Enabled = true;
        }

        #endregion StepOnePrintDailyTotals

        #region StepTwoEftposCounting

        void GetEftposTotal()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select TotalPay from CustomerInvoices WHERE DTDatePaid = @dtTodaysDate AND (PaidStatus = 'Eftpos' OR PaidStatus = 'Credit Card')";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                float fTotalPay = 0.0f;
                float.TryParse(reader["TotalPay"].ToString(), out fTotalPay);

                g_fTotalEftpos += fTotalPay;
            }

            connection.Close();

            lbl_eftposin.Text = "$" + g_fTotalEftpos.ToString("0.00");
        }

        private void cmb_StepThree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Steptwo.Text == "Correct")
            {
                cmb_Steptwo.BackColor = Color.LightGreen;

                g_bStepThreeEftpos = true;
            }
            else if (cmb_Steptwo.Text == "Inccorect")
            {
                cmb_Steptwo.BackColor = Color.Red;

                g_bStepThreeEftpos = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_eftposreset.Checked == true)
            {
                pnl_stepsthree.Enabled = true;
            }
        }

        #endregion StepTwoEftposCounting

        #region StepThreeTillCounting

        int iSODTillCash = 0;

        void GetSODTill()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select TodaySODTill from EndOfDay WHERE DTEODDate = @dtTodaysDate";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                iSODTillCash = 0;
                int.TryParse(reader["TodaySODTill"].ToString(), out iSODTillCash);

                lbl_sod.Text = "$" + iSODTillCash.ToString("N");
            }

            connection.Close();
        }

        void GetCashTotal()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select TotalPay from CustomerInvoices WHERE DTDatePaid = @dtTodaysDate AND PaidStatus = 'Cash'";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                int iTotalPay = 0;
                Int32.TryParse(reader["TotalPay"].ToString(), out iTotalPay);

                g_iTotalCash += iTotalPay;
            }

            connection.Close();

            lbl_cashin.Text = "$" + g_iTotalCash.ToString("0.00");
        }

        void GetCashRefunds()
        {

        }

        void TotalCash()
        {
            lbl_total.Text = "$" + g_iTotalCash.ToString("0.00");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_stepthree.Text == "Correct")
            {
                pnl_stepfive.Enabled = true;
                cmb_stepthree.BackColor = Color.LightGreen;

                pnl_stepfour.Enabled = true;
            }
            else if (cmb_stepthree.Text == "Inccorect")
            {
                pnl_stepfive.Enabled = true;
                cmb_stepthree.BackColor = Color.Red;

                pnl_stepfour.Enabled = true;
            }
        }

        #endregion StepThreeTillCounting

        #region StepFourStaffMemeber

        private void cmb_worker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_worker.Text != "Please Pick...")
            {
                pnl_stepfive.Enabled = true;
            }
            else
            {
                pnl_stepfive.Enabled = false;
            }
        }

        #endregion StepFourStaffMember

        #region StepFivePrintConfirmation

        private void chk_signedform_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_signedform.Checked)
            {
                btn_endday.Visible = true;
                btn_endday.Enabled = true;
            }
        }

        private void btn_printconfirmation_Click(object sender, EventArgs e)
        {
            int iCountWarnings = 0;
            string sWarning = "You have selected 'No' for:\r\n";

            //if (cmb_Step2Correct.Text == "No")
            //{
            //    sWarning += "-Cash Totals\r\n";

            //    iCountWarnings++;
            //}

            if (cmb_Steptwo.Text == "No")
            {
                sWarning += "-Eftpos Totals\r\n";

                iCountWarnings++;
            }

            if (iCountWarnings > 0 && txtbox_notes.Text == "")
            {
                sWarning += "\r\nPlease write a note before printing confirmation sheet.";
                WarningSystem ws = new WarningSystem(sWarning, false);

                ws.ShowDialog();
            }
            else
            {
                PrintConfirmationSheet();

                btn_printconfirmation.Text = "Print Again";
                btn_printconfirmation.BackColor = Color.Green;

                //lbl_confirmationnotyetprinted.Text = "Printed";
                //lbl_confirmationnotyetprinted.ForeColor = Color.LightGreen;

                //lbl_haveyousigned.Visible = true;
                chk_signedform.Enabled = true;
            }
        }

        #endregion StepFivePrintConfirmation

        #region StepSixEndDay

        #endregion StepSixEndDay

        #region Emails

        string sTitle = "";

        void AccountsTest()
        {
            command = new OleDbCommand();

            command.Connection = connection;

            string sMonth = dtTodaysDate.Month.ToString("0");
            string sMonthDisplay = dtTodaysDate.ToString("MMMM");
            string sYear = dtTodaysDate.ToString("yyyy");

            DateTime dtDate = DateTime.Today;
            //string query = @"SELECT * FROM Invoice WHERE ReturnMonth = '" + 02 + "' AND ReturnYear = '" + 2017 + "' AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DateInInvisible DESC";
            dtDate = new DateTime(2017, 10, dtDate.Day, 12, 0, 0);

            string query = "select * from CustomerInvoices WHERE year(DTReturnDate) = year(@dtDate) AND month(DTDatePaid) = month(@dtDate) AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DTDateIn ASC";
            command.Parameters.AddWithValue("@dtDate", dtDate);

            command.CommandText = query;

            reader = command.ExecuteReader();

            string StoreAccountName1 = "";
            string StoreAccountName2 = "";

            string sLineBreak = "-------------------------------------------------------------------------------------------------------------------------";
            string sNextLine = "\r\n";

            bool bFirstTimeOnly = false;

            //sCombinedAccount += "Date In" + Padding.Left(5);

            //sTitle = "BOI Car Storage Yard - " + sMonthDisplay + " " + sYear + " Accounts";
            sTitle = "BOI Car Storage Yard - October 2017 Accounts";

            int iPadLength = 25;

            sCombinedAccount = "Date In".PadRight(15) + "Date Out".PadRight(15) + "Name".PadRight(35)
                                + "Rego".PadRight(25) + "Total" + sNextLine + sLineBreak + sNextLine + sNextLine;

            while (reader.Read())
            {
                if (!bFirstTimeOnly)
                {
                    StoreAccountName1 = reader["AccountHolder"].ToString();
                    StoreAccountName2 = StoreAccountName1;

                    bFirstTimeOnly = true;

                    sCombinedAccount += StoreAccountName1 + sNextLine + sLineBreak + sNextLine;
                }
                else
                {
                    StoreAccountName1 = reader["AccountHolder"].ToString();
                }

                if (StoreAccountName1 != StoreAccountName2)
                {
                    StoreAccountName1 = reader["AccountHolder"].ToString();

                    sCombinedAccount += sNextLine + sNextLine + StoreAccountName1 + sNextLine + sLineBreak + sNextLine;
                }

                DateTime dtDateIn = (DateTime)reader["DTDateIn"];
                DateTime dtReturnDate = (DateTime)reader["DTReturnDate"];

                sCombinedAccount += dtDateIn.ToString("dd") + " " + dtDateIn.ToString("MMM").PadRight(15);
                sCombinedAccount += dtReturnDate.ToString("dd") + " " + dtReturnDate.ToString("MMM").PadRight(15);

                string sClientName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();

                if(sClientName.Length < 20)
                {
                    int iTotal = 30 - sClientName.Length;

                    for(int i = 0; i < iTotal; i++)
                    {
                        sClientName += " ";
                    }

                    sClientName = sClientName.Substring(0, 20);

                    sCombinedAccount += sClientName.PadRight(35);
                }
                else if(sClientName.Length > 20)
                {
                    sClientName = sClientName.Substring(0, 20);

                    sCombinedAccount += sClientName.PadRight(35);
                }
                else
                {
                    sCombinedAccount += sClientName.PadRight(35);
                }

                sCombinedAccount += reader["Rego"].ToString().PadRight(25);

                int iPrice = 0;
                int.TryParse(reader["TotalPay"].ToString(), out iPrice);

                sCombinedAccount += "$" + iPrice.ToString("0.00");

                sCombinedAccount += sNextLine;

                StoreAccountName2 = reader["AccountHolder"].ToString();
            }
        }

        WarningSystem test = new WarningSystem("Please Wait... \r\nSending Account Emails", false);

        void SendEmailTest()
        {
            try
            {
                test.Show();

                SmtpClient client = new SmtpClient("smtp.live.com");
                client.Port = 25;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("pg8472@hotmail.com", "Voyger600!");
                MailMessage msg = new MailMessage();
                //msg.To.Add("peter.george.green@gmail.com");
                //msg.To.Add("kerikericarstorage@gmail.com");
                msg.To.Add("ar.boiairportcarstorage@outlook.com");
                msg.CC.Add("peter.george.green@gmail.com");
                msg.CC.Add("deborah.green@hertz.com");
                msg.From = new MailAddress("pg8472@hotmail.com");
                msg.Subject = sTitle;
                msg.Body = sCombinedAccount;
                //client.Send(msg);
                Object state = msg;
                client.SendAsync(msg, state);
                //MessageBox.Show("Accounts Email Sent Successfully", "Account Email");
                client.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            test.Close();
        }

        #endregion

        #region SendingToDatabase

        void SendEndOfDayToDatabase()
        {
            command = new OleDbCommand();

            command.Connection = connection;

            string sTrue = "True";

            //string query = @"INSERT INTO MoneyInYard (DateYard,TotalCashCorrect,EftposTotalPrinted,Reason,DayEnded) 
            //                values ('" + EODDate + "', '" + cmb_reciept.Text + "', " + chk_printed.Checked + ", '" + txtbox_reason.Text + "', True)";

            string query = @"UPDATE MoneyInYard SET 
                                    TotalCashCorrect = '" + sTrue +
                                    //"', EftposTotalPrinted = " + chk_printed.Checked + 
                                    "', Reason = '" + txtbox_notes.Text +
                                    "', DayEnded = " + sTrue +
                                    " WHERE DateYard = '" + EODDate + "'";


            command.CommandText = query;

            command.ExecuteNonQuery();
        }

        void SendNextDayToDatabase()
        {
            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"INSERT INTO MoneyInYard (DateYard,SOD,TinSOD)
                            values ('" + NextDayDate + "', '" + fTomorrow + "', '" + fTomorrowPlasticContainer + "')";

            command.CommandText = query;

            command.ExecuteNonQuery();
        }

        #endregion

        #region Printing

        void PrintConfirmationSheet()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new PrintPageEventHandler(CreateReceipt);

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            //printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            //printDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //printDocument.PrinterSettings.PrinterName = "CutePDF Writer";

            printDocument.Print();
        }

        // Print Member Variables
        int m_iStartX = 10;
        int m_iStartY = 10;
        int m_iNextLineOffset = 30;
        float m_fFontHeight = 0.0f;
        Font font;
        Font fontBold;
        Font fontBoldUnderline;

        Graphics graphic;

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_iNextLineOffset = 30;

            graphic = e.Graphics;

            font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up
            Font fontBold = new Font("Courier New", 12, FontStyle.Bold);

            m_fFontHeight = font.GetHeight();

            DateTime dtToday = DateTime.Today;
            EODDate = dtToday.Day.ToString() + "/" + dtToday.Month.ToString() + "/" + dtToday.Year.ToString();

            // Heading Title
            graphic.DrawString("End of Day Money Confirmation Sheet - " + EODDate, new Font("Courier New", 18), new SolidBrush(Color.Black), m_iStartX, m_iStartY);

            // Line underneith heading title
            graphic.DrawString("------------------------------------------------------------------------", font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);

            // Item and Confirmation titles in bold
            string sHeading = "Item/Location                                     Confirmation/Correct";
            graphic.DrawString(sHeading, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(2);

            // All the till information
            string sTillTitle = "Till:";
            graphic.DrawString(sTillTitle, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);
            string sTillTotal = "Total Cash Taken Today: " + g_iTotalCash.ToString("$0.00");
            graphic.DrawString(sTillTotal, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            graphic.DrawString(cmb_stepthree.Text, font, new SolidBrush(Color.Black), 620, m_iStartY + m_iNextLineOffset);
            NextLine(4);

            // All the Eftpos information
            string sEftposTitle = "EFTPOS:";
            graphic.DrawString(sEftposTitle, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);
            string sEftposTotal = "Total EFTPOS Taken Today: " + g_fTotalEftpos.ToString("$0.00");
            graphic.DrawString(sEftposTotal, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            graphic.DrawString(cmb_Steptwo.Text, font, new SolidBrush(Color.Black), 620, m_iStartY + m_iNextLineOffset);
            NextLine(4);

            if (txtbox_notes.Text != "")
            {
                NextLine(4);

                Notes();
            }

            NextLine(8);

            string sLine = "------------------------------        ------------------------------";
            graphic.DrawString(sLine, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            //offset = offset + (int)fontHeight * 1; //make the spacing consistent
            NextLine(1);

            string sSignature = "CSR Signature                         Manager Signature";
            graphic.DrawString(sSignature, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
        }

        void Notes()
        {
            string sNotesTitle = "Notes:";
            graphic.DrawString(sNotesTitle, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);

            int iTextBoxNotes = txtbox_notes.Text.Length;

            string sTempStoreText = "";

            for(int i = 0; i < iTextBoxNotes; i++)
            {
                sTempStoreText += txtbox_notes.Text.Substring(i, 1);
               
                if (i % 70 == 0 && i != 0)
                {
                    graphic.DrawString(sTempStoreText, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
                    NextLine(1);
                    sTempStoreText = "";
                }

                graphic.DrawString(sTempStoreText, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            }
        }

        void NextLine(int _iAmount)
        {
            m_iNextLineOffset = m_iNextLineOffset + ((int)m_fFontHeight * + _iAmount);
        }

        #endregion

        #region TodaysReport

        int iCashTotal = 0;
        float fEftposTotal = 0.0f;

        void PrintTodaysReport()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            printDocument.PrintPage += new PrintPageEventHandler(TodaysReport);

            //printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            //printDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //printDocument.PrinterSettings.PrinterName = "CutePDF Writer";

            printDocument.Print();
        }

        public void TodaysReport(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_iNextLineOffset = 30;

            graphic = e.Graphics;

            font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up
            fontBold = new Font("Courier New", 12, FontStyle.Bold);
            fontBoldUnderline = new Font("Courier New", 12, FontStyle.Bold | FontStyle.Underline);

            m_fFontHeight = font.GetHeight();

            // Heading Title
            graphic.DrawString("Daily Report - Kerikeri Car Storage - " + g_sTitleHeader + " (" + dtTodaysDate.ToString("ddd") + ")", new Font("Courier New", 16), new SolidBrush(Color.Black), m_iStartX, m_iStartY);

            // Line underneith heading title
            graphic.DrawString("------------------------------------------------------------------------", font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(2);

            // All the till information
            string sTillTitle = "Todays Cash:";
            graphic.DrawString(sTillTitle, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);
            DailyCash();
            NextLine(3);

            // All the Eftpos information
            string sEftposTitle = "Daily EFTPOS + Credit Card:";
            graphic.DrawString(sEftposTitle, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(1);
            DailyEftpos();
            NextLine(3);

            string sDailyTotalMoneyTitle = "Daily Total Money:";
            graphic.DrawString(sDailyTotalMoneyTitle, fontBoldUnderline, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(2);
            string sDailyTotalMoney = "Cash + EFTPOS + Credit Card: $" + ((float)iCashTotal + fEftposTotal).ToString("0.00");
            graphic.DrawString(sDailyTotalMoney, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            NextLine(3);

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
            //NextLine(4);

            string sPleaseAttach = "(Please Staple this form to the bottom of the confirmation sheet)";
            graphic.DrawString(sPleaseAttach, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

        }

        void DailyCash()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE DTDatePaid = @dtTodaysDate AND PaidStatus = 'Cash'";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            string sCash = "";
            iCashTotal = 0;

            while (reader.Read())
            {
                int iCash = 0;
                int.TryParse(reader["TotalPay"].ToString(), out iCash);

                iCashTotal += iCash;

                sCash = "Inv: " + reader["InvoiceNumber"].ToString() + " - Rego: " + reader["Rego"].ToString();
                sCash += " - Cash: $" + iCash.ToString("0.00");

                graphic.DrawString(sCash, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

                NextLine(1);
            }

            NextLine(1);

            string sCashTotal = "Cash Total: $" + iCashTotal.ToString("0.00");
            graphic.DrawString(sCashTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            connection.Close();
        }

        void DailyEftpos()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE DTDatePaid = @dtTodaysDate AND (PaidStatus = 'Eftpos' OR PaidStatus = 'Credit Card')";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            string sEftpos = "";
            fEftposTotal = 0.0f;

            while (reader.Read())
            {
                float fEftpos = 0.0f;
                float.TryParse(reader["TotalPay"].ToString(), out fEftpos);

                fEftposTotal += fEftpos;

                sEftpos = "Inv: " + reader["InvoiceNumber"].ToString() + " - Rego: " + reader["Rego"].ToString();

                if (reader["PaidStatus"].ToString() == "Eftpos")
                {
                    sEftpos += " - EFTPOS: $" + fEftpos.ToString("0.00");
                }
                else
                {
                    sEftpos += " - Credit Card: $" + fEftpos.ToString("0.00");
                }
                
                graphic.DrawString(sEftpos, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

                NextLine(1);
            }

            NextLine(1);

            string sEftposTotal = "EFTPOS + Credit Card Total: $" + fEftposTotal.ToString("0.00");
            graphic.DrawString(sEftposTotal, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            connection.Close();
        }

        void TillRunningTotal()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from EndOfDay WHERE DTEODDate = @dtTodaysDate";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                int iSOD = 0;
                int.TryParse(reader["TodaySODTill"].ToString(), out iSOD);
                string sSOD = "Till Start Of Day: $" + iSOD.ToString("0.00");
                graphic.DrawString(sSOD, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
                NextLine(1);

                string sCashTakenIn = "Cash Taken In: $" + iCashTotal.ToString("0.00");
                graphic.DrawString(sCashTakenIn, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
                NextLine(1);

                string sRefunds = "Less Refunds: -$0.00";// + iCashTotal.ToString("0.00");
                graphic.DrawString(sRefunds, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
                NextLine(2);

                string sTotalCashInTill = "Total Cash In Till: $" + (iSOD + iCashTotal).ToString("0.00");
                graphic.DrawString(sTotalCashInTill, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            }

            connection.Close();
        }

        void PlasticBoxRunningTotal()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from EndOfDay WHERE DTEODDate = @dtTodaysDate";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                int iSODPlasticBox = 0;
                int.TryParse(reader["TodaySODPlasticBox"].ToString(), out iSODPlasticBox);
                string sSOD = "Plastic Box Start Of Day: $" + iSODPlasticBox.ToString("0.00");
                graphic.DrawString(sSOD, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
                NextLine(1);

                string sCashTakenIn = "Cash Taken In: $" + iCashTotal.ToString("0.00");
                graphic.DrawString(sCashTakenIn, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
                NextLine(2);

                string sRefunds = "Plastic Box End Of Day: $" + (iSODPlasticBox + iCashTotal).ToString("0.00");
                graphic.DrawString(sRefunds, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);
            }

            connection.Close();
        }

        void DailyPettyCash()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from NewPettyCash WHERE DatePetty = @dtTodaysDate ORDER BY ID";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            float fRunningTotal = 0;

            while (reader.Read())
            {
                fRunningTotal = 0;
                float.TryParse(reader["PettyRunningTotal"].ToString(), out fRunningTotal);

                float fAmount = 0;
                float.TryParse(reader["Amount"].ToString(), out fAmount);

                string sPettyCash = "";

                if ((bool)reader["IsReimburse"])
                {
                    sPettyCash = "Item: Reimburse ";
                    sPettyCash += " - Amount: +$" + fAmount.ToString("0.00") + " -> Running Total: $" + fRunningTotal.ToString("0.00");
                }
                else
                {
                    sPettyCash = "Item: " + reader["Item"].ToString();
                    sPettyCash += " - Amount: -$" + fAmount.ToString("0.00") + " -> Running Total: $" + fRunningTotal.ToString("0.00");
                }

                graphic.DrawString(sPettyCash, font, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

                NextLine(1);
            }

            NextLine(1);

            string sPettyCashRemaning = "Petty Cash Remaining: $" + fRunningTotal.ToString("0.00");
            graphic.DrawString(sPettyCashRemaning, fontBold, new SolidBrush(Color.Black), m_iStartX, m_iStartY + m_iNextLineOffset);

            connection.Close();
        }

        #endregion TodaysReport

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
                switch(reader["PaidStatus"].ToString())
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

        #region CarInReport

        void CarInReport()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            DateTime _dtTodaysDateSunday = new DateTime(2017, 11, 12);
            DateTime _dtSevenDaysAgo = new DateTime(2017, 11, _dtTodaysDateSunday.Day - 7);

            //string query = "select * from CustomerInvoices WHERE month(DTDateIn) = month(@_dtTodaysDateSunday) OR " +
            //    "month(DTDateIn) = month(@_dtSevenDaysAgo) AND day(DTDateIn) <= day(@_dtTodaysDateSunday) OR day(DTDateIn) >= day(@_dtSevenDaysAgo) " +
            //    "ORDER BY TimeIn ASC";
            string query = "select * from CustomerInvoices WHERE month(DTDateIn) = month(@_dtTodaysDateSunday) OR " +
                "month(DTDateIn) = month(@_dtSevenDaysAgo) ORDER BY TimeIn ASC";
            command.Parameters.AddWithValue("@_dtTodaysDateSunday", _dtTodaysDateSunday);
            command.Parameters.AddWithValue("@_dtSevenDaysAgo", _dtSevenDaysAgo);

            command.CommandText = query;

            reader = command.ExecuteReader();

            string sTest = "";

            while(reader.Read())
            {
                sTest += reader["DTDateIn"].ToString() + "\r\n";
            }

            textBox1.Text = sTest;

            connection.Close();

            /*

            string StoreAccountName1 = "";
            string StoreAccountName2 = "";

            string sLineBreak = "-------------------------------------------------------------------------------------------------------------------------";
            string sNextLine = "\r\n";

            bool bFirstTimeOnly = false;

            //sCombinedAccount += "Date In" + Padding.Left(5);

            //sTitle = "BOI Car Storage Yard - " + sMonthDisplay + " " + sYear + " Accounts";
            sTitle = "BOI Car Storage Yard - October 2017 Accounts";

            int iPadLength = 25;

            sCombinedAccount = "Date In".PadRight(15) + "Date Out".PadRight(15) + "Name".PadRight(35)
                                + "Rego".PadRight(25) + "Total" + sNextLine + sLineBreak + sNextLine + sNextLine;

            while (reader.Read())
            {
                if (!bFirstTimeOnly)
                {
                    StoreAccountName1 = reader["AccountHolder"].ToString();
                    StoreAccountName2 = StoreAccountName1;

                    bFirstTimeOnly = true;

                    sCombinedAccount += StoreAccountName1 + sNextLine + sLineBreak + sNextLine;
                }
                else
                {
                    StoreAccountName1 = reader["AccountHolder"].ToString();
                }

                if (StoreAccountName1 != StoreAccountName2)
                {
                    StoreAccountName1 = reader["AccountHolder"].ToString();

                    sCombinedAccount += sNextLine + sNextLine + StoreAccountName1 + sNextLine + sLineBreak + sNextLine;
                }

                DateTime dtDateIn = (DateTime)reader["DTDateIn"];
                DateTime dtReturnDate = (DateTime)reader["DTReturnDate"];

                sCombinedAccount += dtDateIn.ToString("dd") + " " + dtDateIn.ToString("MMM").PadRight(15);
                sCombinedAccount += dtReturnDate.ToString("dd") + " " + dtReturnDate.ToString("MMM").PadRight(15);

                string sClientName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();

                if (sClientName.Length < 20)
                {
                    int iTotal = 30 - sClientName.Length;

                    for (int i = 0; i < iTotal; i++)
                    {
                        sClientName += " ";
                    }

                    sClientName = sClientName.Substring(0, 20);

                    sCombinedAccount += sClientName.PadRight(35);
                }
                else if (sClientName.Length > 20)
                {
                    sClientName = sClientName.Substring(0, 20);

                    sCombinedAccount += sClientName.PadRight(35);
                }
                else
                {
                    sCombinedAccount += sClientName.PadRight(35);
                }

                sCombinedAccount += reader["Rego"].ToString().PadRight(25);

                int iPrice = 0;
                int.TryParse(reader["TotalPay"].ToString(), out iPrice);

                sCombinedAccount += "$" + iPrice.ToString("0.00");

                sCombinedAccount += sNextLine;

                StoreAccountName2 = reader["AccountHolder"].ToString();
            }

            */

            int igffg = 0;
        }

        #endregion CarInReport

        #region Buttons

        private void btn_eod_Click(object sender, EventArgs e)
        {
            bool bCheckForAnyIncorrect = false;

            //if (cmb_Step1Correct.Text == "No" || cmb_Step2Correct.Text == "No" || cmb_Step3Correct.Text == "No")
            //{
            //    bCheckForAnyIncorrect = true;
            //}

            if (bCheckForAnyIncorrect && txtbox_notes.Text == "")
            {
                MessageBox.Show("As you have picked a 'No', please leave a note in the 'Notes' Section as to why");
            }
            else
            {
                string sWarningMessage = "Are you sure you want to end the day?";
                string sWarning = "End the Day";

                DialogResult dialogResult = MessageBox.Show(sWarningMessage, sWarning, MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (dtTodaysDate.Month != dtTomorrowsDate.Month)
                    {
                        connection.Open();

                        AccountsTest();

                        SendEmailTest();

                        connection.Close();

                        //lbl_lastdayofmonth.Visible = false;
                    }

                    //lbl_dayendstatus.Text = "Day Closed";
                    //lbl_dayendstatus.ForeColor = Color.Green;

                    txtbox_notes.ReadOnly = true;

                    //chk_printed.Checked = true;
                    //txt_tomorrow.ReadOnly = true;

                    btn_eod.Visible = false;
                    btn_eod.Enabled = false;
                    //cmb_Step2Correct.Enabled = false;
                    //chk_printed.Enabled = false;

                    connection.Open();

                    //SendEndOfDayToDatabase();
                    //SendNextDayToDatabase();

                    connection.Close();
                }
            }
        }

        private void btn_endday_Click(object sender, EventArgs e)
        {
            string sEndDay = "Do you wish to end the day?";

            WarningSystem ws = new WarningSystem(sEndDay, true);
            ws.ShowDialog();

            DateTime dtTodaysDateCompare = DateTime.Now;
            DateTime dtTomorrowsDateCompare = dtTodaysDateCompare.AddDays(1);

            if (ws.DialogResult == DialogResult.OK)
            {
                if (dtTodaysDateCompare.Month != dtTomorrowsDateCompare.Month)
                {
                    //WarningSystem test = new WarningSystem("F", false);
                    //test.Show();

                    connection.Open();

                    AccountsTest();

                    SendEmailTest();

                    connection.Close();

                    //lbl_lastdayofmonth.Visible = false;

                    //test.Close();
                }

                this.BackColor = Color.LightGreen;

                btn_endday.BackColor = Color.Green;
                btn_endday.Text = "Day Ended";
                //btn_endday.Enabled = false;
            }
        }

        #endregion Buttons

        private void btn_email_Click(object sender, EventArgs e)
        {
            connection.Open();

            AccountsTest();

            SendEmailTest();

            connection.Close();
        }
    }
}