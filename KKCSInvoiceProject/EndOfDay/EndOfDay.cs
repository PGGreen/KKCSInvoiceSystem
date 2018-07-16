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

        bool bTurnPrintingOff = false; // True = Off

        string EODDate = "";
        //string NextDayDate = "";

        //string g_strDatePicked = "";

        //string g_sTodaysPettyCashItems = "";

        //int g_iIsTherePettyCashToday = 0;
        //float g_fTotalPettyCashToday = 0.0f;
        //float g_fTotalPettyCashRemaning = 0.0f;

        Color defaultBackWindowColor;

        //float g_fTotalPettyCash = 0.0f;
        //int g_iRefunds = 0;
        //float fTotalForDay = 0.0f;
        //float fTomorrow = 0.0f;
        //float fTomorrowPlasticContainer = 0.0f;

        string sCombinedAccount = "";

        bool g_bSkipEODPickFirstTime = true;

        //////////////////////////////////////////
        OleDbCommand command;

        OleDbDataReader reader;

        DateTime dtTodaysDate = DateTime.Today;
        DateTime dtTomorrowsDate = DateTime.Today;

        string g_sTitleHeader = "";

        //bool g_bStepOneDailyTotalPrinted = false;
        //bool g_bStepTwoCash = false;
        //bool g_bStepThreeEftpos = false;
        //bool g_bStepFourConfirmation = false;

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

            defaultBackWindowColor = this.BackColor;

            FindStaffMembers();

            cmb_worker.SelectedIndex = 0;
            cmb_printerpicked1.SelectedIndex = 0;
            cmb_printerpicked2.SelectedIndex = 0;

            // Creates todays date for end of day
            dtTodaysDate = new DateTime(dtTodaysDate.Year, dtTodaysDate.Month, dtTodaysDate.Day, 12, 0, 0);

            SetUpEOD();

            g_bSkipEODPickFirstTime = false;

            CheckIfDayEnded();
        }

        void FindStaffMembers()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from Staff";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            cmb_worker.Items.Add("Please Pick...");

            while (reader.Read())
            {
                cmb_worker.Items.Add(reader["StaffMember"].ToString());
            }

            connection.Close();
        }

        void SetUpEOD()
        {
            // Creates the title
            g_sTitleHeader = dtTodaysDate.Day.ToString() + "/" + dtTodaysDate.Month.ToString() + "/" + dtTodaysDate.Year.ToString();

            // Creates the top title
            txt_eodheader.Text = "End of Day - " + g_sTitleHeader + " (" + dtTodaysDate.ToString("ddd") + ")";

            // Step Two - Calculate Todays Cash
            GetCashTotal();
            GetCashRefunds();
            TotalCash();

            // Step Three - Calculate Todays Eftpos
            GetEftposTotal();
        }

        void CheckIfDayEnded()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtDatePicked = new DateTime(dt_eodpick.Value.Year, dt_eodpick.Value.Month, dt_eodpick.Value.Day, 12, 0, 0);

            string query = @"SELECT * FROM EndOfDay WHERE DTEODDate = @dtDatePicked";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtDatePicked", dtDatePicked);

            reader = command.ExecuteReader();

            this.BackColor = defaultBackWindowColor;

            while (reader.Read())
            {
                string SODTill = reader["IsDayEnded"].ToString();
                string SODPlasticBox = reader["IsDayEnded"].ToString();
                string EODPlasticBox = reader["IsDayEnded"].ToString();
                string EODTill = reader["IsDayEnded"].ToString();
                string staffMember = reader["IsDayEnded"].ToString();
                string Notes = reader["IsDayEnded"].ToString();
                bool bIsDayEnded = (bool)reader["IsDayEnded"];
                bool bIsCashCorrect = (bool)reader["IsDayEnded"];
                bool bIsEftposCorrect = (bool)reader["IsDayEnded"];
                
                if (bIsDayEnded)
                {
                    this.BackColor = Color.LightGreen;

                    //Step 1
                    btn_printdailytotal.Text = "Print Again";
                    btn_printdailytotal.BackColor = Color.Green;

                    pnl_steptwo.Enabled = true;

                    //Step2
                    if(bIsEftposCorrect)
                    {
                        //cmb_Steptwo
                        cmb_Steptwo.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_Steptwo.SelectedIndex = 1;
                    }

                    chk_eftposreset.Checked = true;

                    if (bIsCashCorrect)
                    {
                        //cmb_Steptwo
                        cmb_stepthree.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_stepthree.SelectedIndex = 1;
                    }

                    cmb_worker.Text = staffMember;

                    btn_printconfirmation.Text = "Print Again";
                    btn_printconfirmation.BackColor = Color.Green;

                    chk_signedform.Enabled = true;
                    chk_signedform.Checked = true;


                }
            }

            connection.Close();
        }

        private void dt_eodpick_ValueChanged(object sender, EventArgs e)
        {
            if (!g_bSkipEODPickFirstTime)
            {
                g_iTotalCash = 0;
                g_fTotalEftpos = 0.0f;

                dtTodaysDate = new DateTime(dt_eodpick.Value.Year, dt_eodpick.Value.Month, dt_eodpick.Value.Day, 12, 0, 0);

                SetUpEOD();
            }

            CheckIfDayEnded();
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
            if(!bTurnPrintingOff)
            {
                PrintTodaysReport();
            }
            
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

                lbl_eftpostotals.Enabled = true;
                chk_eftposreset.Enabled = true;
            }
            else if (cmb_Steptwo.Text == "Incorrect")
            {
                cmb_Steptwo.BackColor = Color.Red;

                lbl_eftpostotals.Enabled = true;
                chk_eftposreset.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_eftposreset.Checked)
            {
                pnl_stepsthree.Enabled = true;
            }
        }

        #endregion StepTwoEftposCounting

        #region StepThreeTillCounting

        //int iSODTillCash = 0;

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
            else if (cmb_stepthree.Text == "Incorrect")
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
                if (!bTurnPrintingOff)
                {
                    PrintConfirmationSheet();
                }
                
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

        void AccountsEmail()
        {
            command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtDate = new DateTime(dt_eodpick.Value.Year, dt_eodpick.Value.Month, dt_eodpick.Value.Day, 12, 0, 0);

            string query = "select * from CustomerInvoices WHERE year(DTReturnDate) = year(@dtDate) AND month(DTDatePaid) = month(@dtDate) AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DTDateIn ASC";
            command.Parameters.AddWithValue("@dtDate", dtDate);

            command.CommandText = query;

            reader = command.ExecuteReader();

            string sMonth = dtDate.ToString("MMMM");
            string sYear = dtDate.ToString("yyy");

            sTitle = "BOI Car Storage Yard - " + sMonth + " " + sYear + " Accounts";

            string StoreAccountName1 = "";
            string StoreAccountName2 = "";

            string sLineBreak = "-------------------------------------------------------------------------------------------------------------------------";
            string sNextLine = "\r\n";

            bool bFirstTimeOnly = false;
            
            //int iPadLength = 25;

            sCombinedAccount = "Dropped Car In".PadRight(15) + "Picked Car Up".PadRight(15) + "Name".PadRight(35)
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

        WarningSystemEmail test = new WarningSystemEmail("Please Wait... \r\nSending Account Emails");

        void SendAccountsEmail()
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
                //msg.CC.Add("deborah.green@hertz.com");
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
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            //string sTrue = "True";

            string query = "";

            bool bIsDayEnded = true;
            bool bIsCashCorrect = true;
            bool bIsEftposCorrect = true;
            string sStaffMember = cmb_worker.Text;
            string sNotes = txtbox_notes.Text;

            DateTime dtNow = dtTodaysDate;
                                           
            query = @"INSERT INTO EndOfDay (DTEODDate,StaffMember,Notes,IsDayEnded,CashCorrect,EftposCorrect) 
                            values ('" + dtNow + 
                            "', '" + sStaffMember +
                            "', '" + sNotes +
                            "', " + bIsDayEnded +
                            ", " + bIsCashCorrect +
                            ", " + bIsEftposCorrect +
                            ")";

            command.CommandText = query;

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion

        #region Printing

        void PrintConfirmationSheet()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new PrintPageEventHandler(CreateReceipt);

            int m_iPrinterPicked = cmb_printerpicked2.SelectedIndex;

            if (m_iPrinterPicked == 0)
            {
                printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            }
            else if (m_iPrinterPicked == 1)
            {
                printDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";
            }

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            //printDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";

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
            graphic.DrawString("End of Day Money Confirmation Sheet - " + g_sTitleHeader, new Font("Courier New", 18), new SolidBrush(Color.Black), m_iStartX, m_iStartY);

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

            int m_iPrinterPicked = cmb_printerpicked1.SelectedIndex;

            if (m_iPrinterPicked == 0)
            {
                printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            }
            else if (m_iPrinterPicked == 1)
            {
                printDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";
            }

            //printDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";
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

        float DailyAccounts()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE DTDatePaid = @dtTodaysDate AND PaidStatus = 'OnAcc'";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            float fCashTotal = 0;

            while (reader.Read())
            {
                float fAccount = 0;
                float.TryParse(reader["TotalPay"].ToString(), out fAccount);

                fCashTotal += fAccount;
            }

            connection.Close();

            return (fCashTotal);
        }

        float DailyCheque()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE DTDatePaid = @dtTodaysDate AND PaidStatus = 'Cheque'";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            float fCashTotal = 0;

            while (reader.Read())
            {
                float fAccount = 0;
                float.TryParse(reader["TotalPay"].ToString(), out fAccount);

                fCashTotal += fAccount;
            }

            connection.Close();

            return (fCashTotal);
        }

        float DailyInternet()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE DTDatePaid = @dtTodaysDate AND PaidStatus = 'Internet'";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            float fCashTotal = 0;

            while (reader.Read())
            {
                float fAccount = 0;
                float.TryParse(reader["TotalPay"].ToString(), out fAccount);

                fCashTotal += fAccount;
            }

            connection.Close();

            return (fCashTotal);
        }

        int DailyCarsIN()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE DTDateIn = @dtTodaysDate";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            int iTotalCars = 0;

            while (reader.Read())
            {
                iTotalCars++;
            }

            connection.Close();

            return (iTotalCars);
        }

        int DailyCarsOUT()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE DTReturnDate = @dtTodaysDate AND PickUp = True";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            int iTotalCars = 0;

            while (reader.Read())
            {
                iTotalCars++;
            }

            connection.Close();

            return (iTotalCars);
        }

        int TotalCars()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from CustomerInvoices WHERE PickUp = False";

            command.CommandText = query;
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            reader = command.ExecuteReader();

            int iTotalCars = 0;

            while (reader.Read())
            {
                iTotalCars++;
            }

            connection.Close();

            return (iTotalCars);
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

        int _i0600 = 0;
        int _i0920 = 0;
        int _i1340 = 0;
        int _i1720 = 0;

        void CarInReport()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            //DateTime _dtTodaysDateSunday = new DateTime(2017, 11, 12);
            //DateTime _dtSevenDaysAgo = new DateTime(2017, 11, _dtTodaysDateSunday.Day - 7);

            DateTime _dtFirst = new DateTime(2016, 11, 1);
            DateTime _dtDateBeforeFlightChanges = new DateTime(2017, 10, 31);

            //TimeSpan _tsDays = _dtDateBeforeFlightChanges - _dtFirst;

            //string query = "select * from CustomerInvoices WHERE (month(DTDateIn) = month(@_dtTodaysDateSunday) OR " +
            //    "month(DTDateIn) = month(@_dtSevenDaysAgo)) AND (day(DTDateIn) <= day(@_dtTodaysDateSunday) AND day(DTDateIn) >= day(@_dtSevenDaysAgo)) " +
            //    "AND (year(DTDateIn) = year(@_dtTodaysDateSunday) OR year(DTDateIn) = year(@_dtSevenDaysAgo)) " +
            //    "ORDER BY TimeIn ASC";
            string query = "select * from CustomerInvoices WHERE ((DTDateIn < @_dtDateBeforeFlightChanges) AND (DTDateIn > @_dtFirst)) ORDER BY DTDateIn,TimeIn ASC";

            //command.Parameters.AddWithValue("@_dtTodaysDateSunday", _dtTodaysDateSunday);
            //command.Parameters.AddWithValue("@_dtSevenDaysAgo", _dtSevenDaysAgo);
            command.Parameters.AddWithValue("@_dtDateBeforeFlightChanges", _dtDateBeforeFlightChanges);
            command.Parameters.AddWithValue("@_dtFirst", _dtFirst);

            command.CommandText = query;

            reader = command.ExecuteReader();

            //string sTest = "";

            DateTime dtFirst = new DateTime();
            DateTime dtSecond = new DateTime();

            bool bSkipFirstTime = true;

            string _sStats = "";

            while (reader.Read())
            {
                dtFirst = (DateTime)reader["DTDateIn"];

                if(dtFirst.Month != dtSecond.Month && !bSkipFirstTime)
                {
                    _sStats += StringTimesNov16ToSep17(dtSecond);

                    _i0600 = 0;
                    _i0920 = 0;
                    _i1340 = 0;
                    _i1720 = 0;

                }

                string _sTimeIn = reader["TimeIn"].ToString();


                FlightTimesNov16ToSep17(_sTimeIn);

                dtSecond = dtFirst;

                bSkipFirstTime = false;
            }

            _sStats += StringTimesNov16ToSep17(dtSecond);

            textBox1.Text = _sStats;

            connection.Close();
        }

        string StringTimesNov16ToSep17(DateTime dtSecond)
        {
            string _sStats = "";

            _sStats += dtSecond.ToString("MMMM") + " " + dtSecond.ToString("yyy") + "\r\n";

            _sStats += "0600 Flight: " + _i0600.ToString() + " Cars \r\n";
            _sStats += "0920 Flight: " + _i0920.ToString() + " Cars \r\n";
            _sStats += "1340 Flight: " + _i1340.ToString() + " Cars \r\n";
            _sStats += "1720 Flight: " + _i1720.ToString() + " Cars \r\n\r\n";
            _sStats += "Total For Month: " + (_i0600 + _i0920 + _i1340 + _i1720).ToString() + " Cars \r\n";

            _sStats += "\r\n\r\n";

            return (_sStats);
        }

        void FlightTimesNov16ToSep17(string _sTimeIn)
        {
            int _iTimeIn = 0;
            int.TryParse(_sTimeIn, out _iTimeIn);

            if (_iTimeIn >= 430 && _iTimeIn <= 630)
            {
                _i0600++;
            }
            else if (_iTimeIn >= 730 && _iTimeIn <= 1030)
            {
                _i0920++;
            }
            else if (_iTimeIn >= 1200 && _iTimeIn <= 1430)
            {
                _i1340++;
            }
            else if (_iTimeIn >= 1500 && _iTimeIn <= 1800)
            {
                _i1720++;
            }
        }


        // Nov Onwards
        int _iNovOn0600 = 0;
        int _iNovOn0920 = 0;
        int _iNovOn1215 = 0;
        int _iNovOn1440 = 0;
        int _iNovOn1720 = 0;

        void CarInReportNovOnwards()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            DateTime _dtDate = new DateTime(2017, 11, 1);

            string query = "select * from CustomerInvoices WHERE DTDateIn >= @_dtDate ORDER BY DTDateIn,TimeIn ASC";

            command.Parameters.AddWithValue("@_dtFirst", _dtDate);

            command.CommandText = query;

            reader = command.ExecuteReader();

            //string sTest = "";

            DateTime dtFirst = new DateTime();
            DateTime dtSecond = new DateTime();

            bool bSkipFirstTime = true;

            string _sStats = "";

            while (reader.Read())
            {
                dtFirst = (DateTime)reader["DTDateIn"];

                if (dtFirst.Month != dtSecond.Month && !bSkipFirstTime)
                {
                    _sStats += StringTimesNov17Onwards(dtSecond);

                    _iNovOn0600 = 0;
                    _iNovOn0920 = 0;
                    _iNovOn1215 = 0;
                    _iNovOn1440 = 0;
                    _iNovOn1720 = 0;
                }

                string _sTimeIn = reader["TimeIn"].ToString();


                FlightTimesNov17Onwards(_sTimeIn);

                dtSecond = dtFirst;

                bSkipFirstTime = false;
            }

            _sStats += StringTimesNov17Onwards(dtSecond);

            textBox1.Text += _sStats;

            connection.Close();
        }

        string StringTimesNov17Onwards(DateTime dtSecond)
        {
            string _sStats = "";

            _sStats += "(Please Note new Flight times started on the 1st of November 2017)\r\n";
            _sStats += "1215 flight was added, and the 1340 flight has been replaced with the new 1440 flight \r\n\r\n";

            _sStats += dtSecond.ToString("MMMM") + " " + dtSecond.ToString("yyy") + " (Current to the 15th) \r\n";

            _sStats += "0600 Flight: " + _iNovOn0600.ToString() + " Cars \r\n";
            _sStats += "0920 Flight: " + _iNovOn0920.ToString() + " Cars \r\n";
            _sStats += "1215 Flight: " + _iNovOn1215.ToString() + " Cars \r\n";
            _sStats += "1440 Flight: " + _iNovOn1440.ToString() + " Cars \r\n";
            _sStats += "1720 Flight: " + _iNovOn1720.ToString() + " Cars \r\n\r\n";
            _sStats += "Total For Month: " + (_iNovOn0600 + _iNovOn0920 + _iNovOn1215 + _iNovOn1440 + _iNovOn1720).ToString() + " Cars \r\n";

            _sStats += "\r\n\r\n";

            return (_sStats);
        }

        void FlightTimesNov17Onwards(string _sTimeIn)
        {
            int _iTimeIn = 0;
            int.TryParse(_sTimeIn, out _iTimeIn);

            if (_iTimeIn >= 430 && _iTimeIn <= 630)
            {
                _iNovOn0600++;
            }
            else if (_iTimeIn >= 730 && _iTimeIn <= 1030)
            {
                _iNovOn0920++;
            }
            else if (_iTimeIn >= 1100 && _iTimeIn <= 1300)
            {
                _iNovOn1215++;
            }
            else if (_iTimeIn >= 1330 && _iTimeIn <= 1500)
            {
                _iNovOn1440++;
            }
            else if (_iTimeIn >= 1530 && _iTimeIn <= 1800)
            {
                _iNovOn1720++;
            }
        }


        #endregion CarInReport

        #region Buttons

        private void btn_endday_Click(object sender, EventArgs e)
        {
            string sEndDay = "Do you wish to end the day?";

            WarningSystem ws = new WarningSystem(sEndDay, true);
            ws.ShowDialog();

            DateTime dtTomorrowsDateCompare = dt_eodpick.Value.AddDays(1);

            if (ws.DialogResult == DialogResult.OK)
            {
                if (dt_eodpick.Value.Month != dtTomorrowsDateCompare.Month)
                {
                    connection.Open();

                    AccountsEmail();

                    SendAccountsEmail();

                    connection.Close();
                }

                ChangePriceAugust2018();

                this.BackColor = Color.LightGreen;

                btn_endday.BackColor = Color.Green;
                btn_endday.Text = "Day Ended";
                lbl_dayend.Text = "Day Is Closed";
                lbl_dayend.BackColor = Color.White;

                SendEndOfDayToDatabase();

                ReportsEmail();
            }
        }

        void ChangePriceAugust2018()
        {
            DateTime dtJulyLastDay = new DateTime(2018, 7, 31, 12, 0, 0);
            DateTime dtToday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            if (dtJulyLastDay == dtToday)
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                string UpdateCommand = @"UPDATE CarYardPricing
                                    SET One = '18', TwoToSeven = '15', EightPlus = '12',
                                        MonthPlus = '66' WHERE ID=1";

                command.CommandText = UpdateCommand;

                command.ExecuteNonQuery();

                connection.Close();

                Form fmCustomerShow = Application.OpenForms["CustomerShow"];

                CustomerShow objCustomerShow = (CustomerShow)fmCustomerShow;
                objCustomerShow.UpdatePricing();
            }
        }

        private void btn_accountemail_Click(object sender, EventArgs e)
        {
            connection.Open();

            AccountsEmail();

            SendAccountsEmail();

            connection.Close();
        }

        #endregion Buttons

        #region HertzInfo

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            SendHertzHoursEmail();

            connection.Close();
        }

        float CSKKHours = 0.0f;
        float CSRHours = 0.0f;
        float VSAHours = 0.0f;
        float REPOHours = 0.0f;
        float LMHours = 0.0f;

        float CSKKTotalHours = 0.0f;
        float CSRTotalHours = 0.0f;
        float VSATotalHours = 0.0f;
        float REPOTotalHours = 0.0f;
        float LMTotalHours = 0.0f;

        string HertzHours()
        {
            command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from HertzHoursData ORDER BY DTDateTime";

            command.CommandText = query;

            reader = command.ExecuteReader();

            //string StoreAccountName1 = "";
            //string StoreAccountName2 = "";

            //string sLineBreak = "-------------------------------------------------------------------------------------------------------------------------";
            //string sNextLine = "\r\n";

            //bool bFirstTimeOnly = false;

            DateTime dtFirst = new DateTime();
            DateTime dtSecond = new DateTime();

            bool bSkipFirstTime = true;

            string sHourData = "<p style='color:red;'>";

            while (reader.Read())
            {
                dtFirst = (DateTime)reader["DTDateTime"];

                if(dtFirst.Month != dtSecond.Month && !bSkipFirstTime)
                {
                    sHourData += "---------------------------------<br>";
                    sHourData += "| Car Storage          | " + CSKKHours + "hrs |<br>";
                    sHourData += "---------------------------------<br>";
                    sHourData += "| CSR                  | " + CSRHours + "hrs |<br>";
                    sHourData += "---------------------------------<br>";
                    sHourData += "| VSA                  | " + VSAHours + "hrs |<br>";
                    sHourData += "---------------------------------<br>";
                    sHourData += "| Repositioning        | " + REPOHours + "hrs |<br>";
                    sHourData += "---------------------------------<br>";
                    sHourData += "| Location Manager     | " + REPOHours + "hrs |<br>";
                    sHourData += "---------------------------------<br>";
                    sHourData += "| <b>Total</b>                | " + REPOHours + "hrs |<br>";
                    sHourData += "---------------------------------<br><br><br>";

                    CSKKHours = 0.0f;
                    CSRHours = 0.0f;
                    VSAHours = 0.0f;
                    REPOHours = 0.0f;
                }

                string sDept = reader["Role"].ToString();
                string sHours = reader["Hours"].ToString();

                CountHours(sDept, sHours);

                bSkipFirstTime = false;

                dtSecond = dtFirst;
            }

            sHourData += "</p>";

            return (sHourData);
        }

        void CountHours(string _sDept, string _sHours)
        {
            float fHours = 0.0f;
            float.TryParse(_sHours, out fHours);



            // Location Manager
            // NZ Delivery
            // NZ Repo Maintenance 
            // NZ Repo Branch to Branch


            switch (_sDept)
            {

                case "Car Storage attendant KeriKeri":
                    {
                        CSKKHours += fHours;
                        CSKKTotalHours += fHours;
                        break;
                    }
                case "CSR NZ Casual":
                case "CSR NZ F/T":
                case "CSR NZ P/T":
                    {
                        CSRHours += fHours;
                        CSRTotalHours += fHours;
                        break;
                    }
                case "NZ VSA  P/T":
                case "NZ VSA Casual":
                case "NZ VSA F/T":
                    {
                        VSAHours += fHours;
                        VSATotalHours += fHours;
                        break;
                    }
                case "NZ Delivery":
                case "NZ Repo Maintenance":
                case "NZ Repo Branch to Branch":
                    {
                        REPOHours += fHours;
                        REPOTotalHours += fHours;
                        break;
                    }
                case "":
                    {
                        LMHours += fHours;
                        LMTotalHours += fHours;

                        break;
                    }
            }
        }

        void SendHertzHoursEmail()
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
                msg.IsBodyHtml = true;
                msg.To.Add("peter.george.green@gmail.com");
                //msg.To.Add("kerikericarstorage@gmail.com");
                //msg.To.Add("ar.boiairportcarstorage@outlook.com");
                //msg.CC.Add("peter.george.green@gmail.com");
                //msg.CC.Add("deborah.green@hertz.com");
                msg.From = new MailAddress("pg8472@hotmail.com");
                msg.Subject = "Test";
                msg.Body = HertzHours();
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

        #endregion HertzInfo

        #region Reports

        string sSubjectLine = "";
        string sEL = "\r\n";
        string sLine = "---------------------------";

        string DailyReports()
        {
            string sDailyReport = "";

            DateTime dtTodaysDate = DateTime.Now;
            string sDateTime = dtTodaysDate.ToString("dd") + "/" + dtTodaysDate.ToString("MM") + "/" + dtTodaysDate.ToString("yyyy");

            sSubjectLine = "CAR STORAGE - DAILY REPORT - " + sDateTime;

            sDailyReport += "--Finances (Cash & Eftpos)--" + sEL;
            sDailyReport += sLine + sLine + sEL;
            sDailyReport += "Cash: " + lbl_total.Text + " " + cmb_Steptwo.Text + sEL;
            sDailyReport += "Eftpos + Credit Card: " + lbl_eftposin.Text + " " + cmb_stepthree.Text + sEL;
            sDailyReport += "Staff Member: " + cmb_worker.Text + sEL;

            if(txtbox_notes.Text != "")
            {
                sDailyReport += "Notes: " + txtbox_notes.Text + sEL;
            }
            
            sDailyReport += sLine + sLine + sEL + sEL;

            sDailyReport += "--Finances (Other)--" + sEL;
            sDailyReport += sLine + sLine + sEL;
            sDailyReport += "Accounts: $" + DailyAccounts().ToString("0.00") + "; Cheque: $" + DailyCheque().ToString("0.00") + "; Internet: $" + DailyInternet().ToString("0.00") + sEL;
            sDailyReport += sLine + sLine + sEL + sEL;

            float fCashTotals = 0;
            float.TryParse(lbl_total.Text.Substring(1), out fCashTotals);

            float fEftposTotals = 0;
            float.TryParse(lbl_eftposin.Text.Substring(1), out fEftposTotals);

            float fTotal = fCashTotals + fEftposTotals + DailyAccounts() + DailyCheque() + DailyInternet();

            sDailyReport += "--Totals--" + sEL;
            sDailyReport += sLine + sLine + sEL;
            sDailyReport += "Total Income (" + sDateTime + "): $" + fTotal.ToString("0.00") + sEL;
            sDailyReport += sLine + sLine + sEL + sEL;

            /*
            sDailyReport += "--Refunds--" + sEL;
            sDailyReport += sLine + sLine + sEL;
            sDailyReport += "Refunds Cash: " + sEL;
            sDailyReport += "Refunds Eftpos/Credit Card: " + sEL;
            sDailyReport += sLine + sEL + sEL;

            sDailyReport += "--Banking--" + sEL;
            sDailyReport += sLine + sLine + sEL;
            sDailyReport += "Backing: " + sEL;
            sDailyReport += sLine + sLine + sEL + sEL;

            sDailyReport += "--Running Totals--" + sEL;
            sDailyReport += sLine + sLine + sEL;
            sDailyReport += "Plastic Box SOD: " + "--> " + "Plastic Box EOD: " + "" + sEL;
            sDailyReport += sLine + sLine + sEL + sEL;
            */

            sDailyReport += "--Car Report (" + sDateTime + ")--" + sEL;
            sDailyReport += sLine + sLine + sEL;
            sDailyReport += "Cars IN: " + DailyCarsIN() + sEL;
            sDailyReport += "Cars OUT: " + DailyCarsOUT() + sEL;
            sDailyReport += "Cars CURRENTLY IN YARD (as of End of Day): " + TotalCars() + sEL;
            sDailyReport += sLine + sLine;

            return (sDailyReport);
        }

        string WeeklyReports()
        {
            return ("");
        }

        string MonthlyReports()
        {
            return ("");
        }

        void ReportsEmail()
        {
            SmtpClient client = new SmtpClient("smtp.live.com");
            client.Port = 25;
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("pg8472@hotmail.com", "Voyger600!");
            MailMessage msg = new MailMessage();
            msg.To.Add("peter.george.green@gmail.com");
            //msg.To.Add("deborah.green@hertz.com");
            //msg.CC.Add("peter.george.green@gmail.com");
            msg.From = new MailAddress("pg8472@hotmail.com");
            msg.Body = DailyReports();
            msg.Subject = sSubjectLine;
            Object state = msg;
            client.SendAsync(msg, state);
        }

        #endregion Reports

        private void btn_dateleft_Click(object sender, EventArgs e)
        {
            dt_eodpick.Value = dt_eodpick.Value.AddDays(-1);
        }

        private void btn_dateright_Click(object sender, EventArgs e)
        {
            dt_eodpick.Value = dt_eodpick.Value.AddDays(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();

            AccountsEmail();

            connection.Close();
        }
    }
}