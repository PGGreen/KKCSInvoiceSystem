using System;
using System.IO;
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
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class Invoice : Form
    {
        #region GlobalVaribles

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private Button printButton = new Button();
        private PrintDocument printDocument1 = new PrintDocument();

        InvoiceManager invManager;

        private OleDbConnection connection = new OleDbConnection();

        Color LabelBackColour = Color.FromArgb(255, 192, 192);

        DateTime CurrentTime = new DateTime();

        DateTime dtDatePaid = DateTime.Now;

        private bool bIsAlreadySaved = false;

        private int iTabNumberFromManager = 0;

        bool PaidStatusPicked = false;

        private bool m_bAlreadyPaid = false;

        bool m_bIsFromCarReturns = false;
        bool m_bInitialSetUpFromCarReturns = false;

        int iInvoiceNumber = 0;

        DateTime dtReturnDateOriginal;
        string sReturnTimeOriginal;

        private string sTempStorePrice = "";

        private string m_sTempStoreRego = "";

        private string m_sCarLocation = "Front";

        private bool m_bCarPickedUp = false;

        float m_fOriginalPriceBeforeCredit = 0.0f;

        NewCarReturns NewCarReturns;

        //bool sDatePaidBool = false;

        string g_sPaidStatus = "";

        #endregion

        #region OpenAndClose

        private void chkbox_topay_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!m_bIsFromCarReturns)
            {
                if (bIsAlreadySaved)
                {
                    invManager.DeleteTab(iTabNumberFromManager);
                }
                else
                {
                    string sTabsStillOpen = "This Invoice is Unsaved\r\n\r\nTHE DATA WILL BE LOST!\r\n\r\nAre you sure you want to exit?";

                    WarningSystem ws = new WarningSystem(sTabsStillOpen, true);
                    ws.ShowDialog();

                    if (ws.DialogResult == DialogResult.OK)
                    {
                        DestroyInvUnsaved();

                        invManager.DeleteTab(iTabNumberFromManager);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if(NewCarReturns != null)
                {
                    NewCarReturns.ReloadPageFromInvoice();
                }
            }
        }

        void DestroyInvUnsaved()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            //record doesnt exist
            // Make new command structure for database querys
            OleDbCommand command = new OleDbCommand();

            // Make the command equal the physical location of the database (connection)
            command.Connection = connection;

            // Insert the new Number Plate into the Database
            string cmd1 = @"DELETE * FROM CustomerInvoices WHERE InvoiceNumber = " + iInvoiceNumber + "";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            command.ExecuteNonQuery();

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            cmb_rego.Focus();
            base.OnShown(e);
        }

        #endregion

        #region Load

        // Initialises Invoice
        public Invoice(bool _bIsFromCarReturns)
        {
            InitializeComponent();

            m_bIsFromCarReturns = _bIsFromCarReturns;

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        // Loads Invoice Form
        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += chkbox_topay_Closing;
            //printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            FindFlightTimes();

            if (!m_bIsFromCarReturns)
            {
                lbl_datepaid.Text = "Date Paid: ";

                txt_flighttimes.SelectedIndex = 0;

                PopulateRegoBox();
                FindKeyNumber();
                FindInvoiceNumber();

                dtReturnDateOriginal = dt_returndate.Value;
                sReturnTimeOriginal = txt_flighttimes.Text;

                txt_money7charge.Text = "10";
                txt_money7pluscharge.Text = "8";
                txt_moneyMonthcharge.Text = "40";

                txt_firstname.BackColor = LabelBackColour;
                txt_lastname.BackColor = LabelBackColour;
                txt_ph.BackColor = LabelBackColour;
                txt_makemodel.BackColor = LabelBackColour;
                cmb_rego.BackColor = LabelBackColour;

                CurrentTime = DateTime.Now;

                cmb_timeinhours.Text = CurrentTime.Hour.ToString("00");
                cmb_timeinminutes.Text = CurrentTime.Minute.ToString("00");
            }
        }

        // If opening form from Car Returns run this
        public void SetUpFromCarReturns(int _iInvoiceNumber, NewCarReturns _NewCarReturns)
        {
            //PopulateAccountBox();

            m_bInitialSetUpFromCarReturns = true;

            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            NewCarReturns = _NewCarReturns;

            bIsAlreadySaved = true;

            btn_save.BackColor = Color.Green;
            btn_save.Text = "SAVED";
            this.BackColor = Color.LightGreen;

            OleDbCommand command = new OleDbCommand();

            OleDbDataReader reader;

            command.Connection = connection;

            string query = @"SELECT * FROM CustomerInvoices WHERE InvoiceNumber = " + _iInvoiceNumber + "";

            iInvoiceNumber = _iInvoiceNumber;

            command.CommandText = query;

            reader = command.ExecuteReader();

            bool bIsOnAccount = false;

            while (reader.Read())
            {
                // Gets Invoice Number
                txt_invoiceno.Text = _iInvoiceNumber.ToString();

                // Inserts Key Number
                txt_keyno.Text = reader["KeyNumber"].ToString();

                // Inserts the date the customer dropped the car off
                DateTime dtin = (DateTime)reader["DTDateIn"];
                dt_datein.Value = dtin;

                // Inserts the time the customer dropped the car off
                cmb_timeinhours.Text = reader["TimeIn"].ToString().Substring(0, 2);
                cmb_timeinminutes.Text = reader["TimeIn"].ToString().Substring(2, 2);

                // Inserts Customer Data
                txt_firstname.Text = reader["FirstName"].ToString();
                txt_lastname.Text = reader["LastName"].ToString();
                txt_ph.Text = reader["PhoneNumber"].ToString();
                txt_makemodel.Text = reader["MakeModel"].ToString();
                cmb_rego.Text = reader["Rego"].ToString();



                // Inserts any notes or alerts
                txt_notes.Text = reader["Notes"].ToString();
                txt_alerts.Text = reader["Alerts"].ToString();

                bool bIsUnknown = (bool)reader["UnknownDate"];

                if (!bIsUnknown)
                {
                    // Inserts the date the customer dropped the car off
                    DateTime dtReturnDate = (DateTime)reader["DTReturnDate"];
                    dt_returndate.Value = dtReturnDate;

                    // Checks to see if customer is owed a refund or if we owe them money
                    DateTime dtTodaysDate = DateTime.Now;

                    TimeSpan TimeDifference = dt_returndate.Value - dtTodaysDate;
                    int iDays = TimeDifference.Days;

                    if(false)//if(iDays > 0)
                    {
                        string sWarning = "Has this customer come back early?";
                        WarningSystem ws = new WarningSystem(sWarning, true);
                        ws.ShowDialog();

                        if (ws.DialogResult == DialogResult.OK)
                        {
                            sWarning = "Customer is owed a refund";
                            ws = new WarningSystem(sWarning, false);
                            ws.ShowDialog();

                            // Customer is back early
                            pnl_refund.Enabled = true;
                            pnl_refund.Visible = true;

                            int iPrice = iDays * 10;

                            lbl_daysearly.Text += " " + iDays.ToString();
                            txt_refundowed.Text = "$" + iPrice.ToString("0.00");
                        }
                    }
                }
                else
                {
                    DateTime dtReturnDate = DateTime.Now;
                    dt_returndate.Value = dtReturnDate;
                }

                if (reader["ReturnTime"].ToString() == "Unknown")
                {
                    DateTime dtReturnDate = DateTime.Now;

                    chk_manual.Checked = true;

                    int iHours = dtReturnDate.Hour;
                    int iMinutes = dtReturnDate.Minute;

                    cmb_returntimehours.Text = iHours.ToString("00");
                    cmb_returntimeminutes.Text = iMinutes.ToString("00");

                }
                else
                {
                    // Checks to see if Flight or Manual time was used
                    bool FlightOrManual = (bool)reader["FlightOrManual"];

                    // It was flight
                    if (FlightOrManual)
                    {
                        txt_flighttimes.Text = reader["ReturnTime"].ToString();
                        chk_flighttimes.Checked = true;
                    }
                    else
                    {
                        // Inserts the time the customer is picking up their car
                        string sReturnTimeHours = reader["ReturnTime"].ToString().Substring(0, 2);
                        string sReturnTimeMinutes = reader["ReturnTime"].ToString().Substring(2, 2);

                        cmb_returntimehours.Text = sReturnTimeHours;
                        cmb_returntimeminutes.Text = sReturnTimeMinutes;

                        chk_manual.Checked = true;
                    }
                }

                // Popluates the paid status
                bIsOnAccount = PopulatePaidStatus(reader);

                // Inserts the amount paid
                txt_money7.Text = reader["SevenDaysPay"].ToString();
                txt_money7plus.Text = reader["SevenDaysPlusPay"].ToString();
                txt_monthmoney.Text = reader["OneMonthPlusPay"].ToString();
                txt_creditcharge.Text = reader["CreditCardFeePay"].ToString();
                txt_total.Text = reader["TotalPay"].ToString();

                bool bPickedUp = (bool)reader["PickUp"];

                if (bPickedUp)
                {
                    chk_pickedup.Checked = true;
                    chk_carinyard.Checked = false;

                    chk_pickedup.BackColor = Color.Lime;
                }
                else
                {
                    chk_pickedup.Checked = false;
                    chk_carinyard.Checked = true;

                    chk_carinyard.BackColor = Color.Lime;
                }

                m_bCarPickedUp = (bool)reader["PickUp"];

                if (m_bCarPickedUp)
                {
                    chk_pickedup.Checked = true;
                }
                else if (!m_bCarPickedUp)
                {
                    chk_carinyard.Checked = true;
                }

                m_sCarLocation = reader["CarLocation"].ToString();

                if (m_sCarLocation == "Front")
                {
                    chk_carlocationfront.Checked = true;
                }
                else if (m_sCarLocation == "Back")
                {
                    chk_carlocationback.Checked = true;
                }

                m_bAlreadyPaid = (bool)reader["YNDatePaid"];

                dtDatePaid = (DateTime)reader["DTDatePaid"];

                //if (g_sPaidStatus != "To Pay")
                //{
                //    m_bAlreadyPaid = true;
                //}

                if (g_sPaidStatus == "To Pay")
                {
                    lbl_datepaid.Text = "Date Paid: To Pay";
                }
                else
                {
                    //DateTime dtDatePaid = (DateTime)reader["DTDatePaid"];
                    string sDatePaid = dtDatePaid.Day + "/" + dtDatePaid.Month + "/" + dtDatePaid.ToString("yy");

                    lbl_datepaid.Text = "Date Paid: " + sDatePaid;
                }
            }

            if(bIsOnAccount)
            {
                chkbox_onaccount.Checked = true;
            }
             
            WarningsStoreOriginalValues();

            m_bInitialSetUpFromCarReturns = false;

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        bool PopulatePaidStatus(OleDbDataReader _reader)
        {
            bool bIsAccount = false;

            if (_reader["PaidStatus"].ToString() == "Cash")
            {
                chkbox_cash.Checked = true;
            }
            else if (_reader["PaidStatus"].ToString() == "Eftpos")
            {
                chkbox_eftpos.Checked = true;
            }
            else if (_reader["PaidStatus"].ToString() == "Credit Card")
            {
                chk_credit.Checked = true;
            }
            else if (_reader["PaidStatus"].ToString() == "Internet")
            {
                chkbox_internet.Checked = true;
            }
            else if (_reader["PaidStatus"].ToString() == "Cheque")
            {
                chkbox_cheque.Checked = true;
            }
            else if (_reader["PaidStatus"].ToString() == "To Pay")
            {
                chkbox_stilltopay.Checked = true;
            }
            else if (_reader["PaidStatus"].ToString() == "OnAcc")
            {
                bIsAccount = true;
            }
            else if (_reader["PaidStatus"].ToString() == "N/C")
            {
                chkbox_nocharge.Checked = true;
            }

            return (bIsAccount);
        }

        void PopulatePaidStatusWarnings(string _sPaidStatus)
        {
            if (_sPaidStatus == "Cash")
            {
                chkbox_cash.Checked = true;
            }
            else if (_sPaidStatus == "Eftpos")
            {
                chkbox_eftpos.Checked = true;
            }
            else if (_sPaidStatus == "Credit Card")
            {
                chk_credit.Checked = true;
            }
            else if (_sPaidStatus == "Internet")
            {
                chkbox_internet.Checked = true;
            }
            else if (_sPaidStatus == "Cheque")
            {
                chkbox_cheque.Checked = true;
            }
            else if (_sPaidStatus == "To Pay")
            {
                chkbox_stilltopay.Checked = true;
            }
            else if (_sPaidStatus == "OnAcc")
            {
                chkbox_onaccount.Checked = true;
            }
            else if (_sPaidStatus == "N/C")
            {
                chkbox_nocharge.Checked = true;
            }
        }

        #endregion

        #region GetAndSetFunctions

        // Gets the reference to the invoice manager
        public void GetInvoiceManager(InvoiceManager _invManager)
        {
            invManager = _invManager;
        }

        // Sets this form to the correct tab in the invoice manager
        public void SetTabNumberFromManager(int _iTabNumberFromManager)
        {
            iTabNumberFromManager = _iTabNumberFromManager;
        }

        public void SetKeyNumberTextBox(string _KeyNumber)
        {
            //txt_keyno.Text = _KeyNumber;

            //ssStoreKeyNumber = _KeyNumber;

            //// Opens the connection to the database
            //if (connection.State == ConnectionState.Closed)
            //{
            //    connection.Open();
            //}

            //OleDbCommand command2 = new OleDbCommand();

            //command2.Connection = connection;

            //string temp = "-";

            //string cmd1 = @"UPDATE KeyBox SET [Rego] = '" + temp + "' WHERE [KeyBoxNumber] = '" + _KeyNumber + "'";

            //command2.CommandText = cmd1;

            //command2.ExecuteNonQuery();

            //// Closes the connection to the database
            //if (connection.State == ConnectionState.Open)
            //{
            //    connection.Close();
            //}
        }

        #endregion

        #region Find

        void FindKeyNumber()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string query = "select * from CustomerInvoices WHERE PickUp = False ORDER BY KeyNumber";

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            int iFirstNumber = 0;
            int iSecondNumber = 0;

            while (reader.Read())
            {
                int.TryParse(reader["KeyNumber"].ToString(), out iSecondNumber);

                int tempTestDifference = iSecondNumber - iFirstNumber;

                if (tempTestDifference >= 2)
                {
                    break;
                }

                int.TryParse(reader["KeyNumber"].ToString(), out iFirstNumber);
            }

            txt_keyno.Text = (iFirstNumber + 1).ToString("00");

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void FindInvoiceNumber()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT InvoiceNumber
                            FROM CustomerInvoices
                            ORDER BY InvoiceNumber ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            int iFirstNumber = 0;
            int iSecondNumber = 0;

            while (reader.Read())
            {
                iSecondNumber = (int)reader["InvoiceNumber"];

                int tempTestDifference = iSecondNumber - iFirstNumber;

                if (tempTestDifference >= 2)
                {
                    break;
                }

                iFirstNumber = (int)reader["InvoiceNumber"];
            }

            iInvoiceNumber = iFirstNumber + 1;

            txt_invoiceno.Text = iInvoiceNumber.ToString();

            // Makes sure the invoice doesn't already exist
            //MakeSureNoDuplicates();

            // Inserts Temporary Invoice for use
            TempInsertInv();

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void FindFlightTimes()
        {
            string sTodaysDay = dt_returndate.Value.DayOfWeek.ToString();

            txt_flighttimes.Items.Clear();

            // TODO: Delete Later, New Times
            DateTime dtNewStartDate = new DateTime(2016, 10, 29, 12, 0, 0);
            DateTime dtReturnDate = dt_returndate.Value;
            int result = 1;// DateTime.Compare(dtNewStartDate, dtReturnDate);

            string sTxtFileLocation = "";

            if (sTodaysDay == "Saturday")
            {
                if (result > 0)
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sat.txt";
                }
                else if (result == 0 || result < 0)
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sat - NOV 16.txt";
                }

            }
            else if (sTodaysDay == "Sunday")
            {
                if (result > 0)
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sun.txt";
                }
                else if (result == 0 || result < 0)
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sun - NOV 16.txt";
                }

            }
            else
            {
                if (result > 0)
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Mon To Fri.txt";
                }
                else if (result == 0 || result < 0)
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Mon To Fri - NOV 16.txt";
                }
            }

            using (StreamReader sr = new StreamReader(sTxtFileLocation))
            {
                txt_flighttimes.Items.AddRange(System.IO.File.ReadAllLines(sTxtFileLocation));
            }
        }

        void MakeSureNoDuplicates()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            // Checks to see if the NumberPlate already exists
            string cmdStr = @"SELECT COUNT(*) FROM Invoice
                        WHERE InvoiceNumber = " + iInvoiceNumber + "";

            // Runs the command from above to search the database
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            int count = (int)cmd.ExecuteScalar();

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            // Record Already exists
            if (count > 0)
            {
                FindInvoiceNumber();
            }
        }

        void TempInsertInv()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            //record doesnt exist
            // Make new command structure for database querys
            OleDbCommand command = new OleDbCommand();

            // Make the command equal the physical location of the database (connection)
            command.Connection = connection;
            
            // Insert the new Number Plate into the Database
            string cmd1 = @"INSERT into CustomerInvoices (InvoiceNumber,KeyNumber) values (" + iInvoiceNumber + ",'" + txt_keyno.Text + "')";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            command.ExecuteNonQuery();

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #endregion

        #region SavingToDatabase

        private void btn_save_Click(object sender, EventArgs e)
        {
            DateTime dtTimePicker = dt_returndate.Value;

            DateTime dtCompare = new DateTime(dtTimePicker.Year, dtTimePicker.Month, dtTimePicker.Day, 12, 0, 0);
            DateTime dtFeb11 = new DateTime(2017, 2, 11, 12, 0, 0);

            int iTimeIn = 0;
            int.TryParse(ReturnTime(), out iTimeIn);
            
            if (dtFeb11 == dtCompare && (iTimeIn > 1430 || chkbox_uknowntime.Checked))
            {
                string strWS = "PLEASE NOTE:\r\nOn Saturday 11th of February we will be closed for the 1720 flight.\r\n";
                strWS += "Please make other arrangements if coming in or out at this time.\r\n\r\n";
                strWS += "We are sorry for the inconvenience this may cause.";
                WarningSystem ws = new WarningSystem(strWS, false);
                ws.ShowDialog();
            }
            else
            {
                SetUpSave();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SetUpSave();
        }

        void SetUpSave()
        {
            bool bCheckUnknown = false;

            if (chkbox_uknowndate.Checked == true || chkbox_uknowntime.Checked == true && g_sPaidStatus == "To Pay")
            {
                bCheckUnknown = true;
            }

            string sWarning = "";
            string sEndLine = "\r\n";

            int iIsThereWarnings = 0;

            if (cmb_rego.Text == "")
            {
                sWarning += "-Please set the Car Rego" + sEndLine;

                iIsThereWarnings++;
            }
            if (txt_total.Text == "" && g_sPaidStatus != "N/C" && !bCheckUnknown)
            {
                sWarning += "-Please Calculate the price" + sEndLine;

                iIsThereWarnings++;
            }
            if (!PaidStatusPicked)
            {
                sWarning += "-Please pick a 'Paid Status'" + sEndLine;

                iIsThereWarnings++;
            }

            if (iIsThereWarnings > 0)
            {
                WarningSystem ws = new WarningSystem(sWarning, false);

                ws.ShowDialog();
            }
            else
            {
                SaveDataIntoDatabase();

                if (!m_bIsFromCarReturns)
                {
                    invManager.ChangeColour(iTabNumberFromManager);
                }

                //btn_save.Enabled = false;
            }
        }

        void SaveDataIntoDatabase()
        {
            if (bIsAlreadySaved)
            {
                string sWarningMessage = "This Invoice has already been previously saved,\r\ndo you wish to overwrite existing data?";

                WarningSystem ws = new WarningSystem(sWarningMessage, true);
                ws.ShowDialog();

                if (ws.DialogResult == DialogResult.OK)
                {
                    UpdateInvoice();

                    InsertIntoNumberPlates();

                    if (chkbox_onaccount.Checked)
                    {
                        InsertIntoAccounts();
                    }

                    if (!m_bInitialSetUpFromCarReturns)
                    {
                        WarningsStoreOriginalValues();

                        WarningsChangesMade();
                    }
                }
                else
                {
                    ws.Close();
                }
            }
            else
            {
                // Insert First Time
                // TODO: Fix this
                bool bCheckKeyNumberBlank = true;// CheckKeyNumberIsBlank();

                if (bCheckKeyNumberBlank)
                {
                    WarningsStoreOriginalValues();

                    UpdateInvoice();

                    InsertIntoNumberPlates();

                    if (chkbox_onaccount.Checked)
                    {
                        InsertIntoAccounts();
                    }

                    bIsAlreadySaved = true;

                    btn_save.Enabled = false;

                    btn_save.BackColor = Color.Green;
                    btn_save.Text = "SAVED";
                    this.BackColor = Color.LightGreen;
                }
                else
                {
                    KeyAllocation ka = new KeyAllocation(this);
                    ka.Show();
                }
            }
        }

        bool CheckKeyNumberIsBlank()
        {
            //// Opens the connection to the database
            //if (connection.State == ConnectionState.Closed)
            //{
            //    connection.Open();
            //}

            //OleDbCommand errorcheckcommand = new OleDbCommand();

            //errorcheckcommand.Connection = connection;

            //string query = @"SELECT * FROM KeyBox WHERE KeyBoxNumber = '" + txt_keyno.Text + "'";

            //errorcheckcommand.CommandText = query;

            //OleDbDataReader reader = errorcheckcommand.ExecuteReader();

            //string sCheckIsBlank = "";

            //while (reader.Read())
            //{
            //    sCheckIsBlank = reader["Rego"].ToString();
            //}

            //// Closes the connection to the database
            //if (connection.State == ConnectionState.Open)
            //{
            //    connection.Close();
            //}

            //if (sCheckIsBlank != "" && sCheckIsBlank != "-")
            //{
            //    return (false);
            //}
            //else
            //{
            //    return (true);
            //}

            return (true);
        }

        void UpdateInvoice()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;


                //dtDatePaid = new DateTime(dtDatePaid.Year, dtDatePaid.Month, dtDatePaid.Day, 12, 0, 0);

                string tempReturnTimeHours = "";

                // If paid status is "To Pay", sets AlreadyPaid to false
                if (g_sPaidStatus == "To Pay")
                {
                    m_bAlreadyPaid = false;
                }

                // Checks to see if the customer has already paid or not
                // Goes in if the customer has not yet paid
                if (!m_bAlreadyPaid)
                {
                    if (g_sPaidStatus != "To Pay")
                    {
                        m_bAlreadyPaid = true;
                    }

                    if (g_sPaidStatus == "To Pay")
                    {
                        lbl_datepaid.Text = "Date Paid: To Pay";

                        dtDatePaid = new DateTime(2001, 1, 1, 12, 0, 0);
                    }
                    else
                    {
                        DateTime dtNow = DateTime.Now;
                        dtDatePaid = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);

                        string dateCustomerPaid = dtDatePaid.Day.ToString() + "/" + dtDatePaid.Month.ToString("00") + "/" + dtDatePaid.ToString("yy");

                        lbl_datepaid.Text = "Date Paid: " + dateCustomerPaid;
                    }
                }

                if (chkbox_uknowntime.Checked)
                {
                    tempReturnTimeHours = "Unknown";
                }
                else
                {
                    tempReturnTimeHours = ReturnTime();
                }

                bool bUnknownDate = false;
                DateTime dtReturnDate = new DateTime();

                if (chkbox_uknowndate.Checked)
                {
                    dtReturnDate = new DateTime(2001, 1, 1, 12, 0, 0);

                    bUnknownDate = true;
                }
                else
                {
                    int iYearReturnDate = dt_returndate.Value.Year;
                    int iMonthReturnDate = dt_returndate.Value.Month;
                    int iDayReturnDate = dt_returndate.Value.Day;

                    dtReturnDate = new DateTime(iYearReturnDate, iMonthReturnDate, iDayReturnDate, 12, 0, 0);
                }

                int iYearDateIn = dt_datein.Value.Year;
                int iMonthDateIn = dt_datein.Value.Month;
                int iDayDateIn = dt_datein.Value.Day;

                DateTime dtDateIn = new DateTime(iYearDateIn, iMonthDateIn, iDayDateIn, 12, 0, 0);

                int iTimeHours = 0;
                int iTimeMinutes = 0;

                Int32.TryParse(cmb_timeinhours.Text, out iTimeHours);
                Int32.TryParse(cmb_timeinminutes.Text, out iTimeMinutes);

                string sTimeIn = iTimeHours.ToString("00") + iTimeMinutes.ToString("00");

                #region OldCode
                /*
                // Gets the Time the Car Came In
                string tempTimeInHours = CreateTimeIn();

                string tempReturnTimeHours = "";

                if (cmb_returntimehours.Enabled == false || txt_flighttimes.Enabled == false)
                {
                    tempReturnTimeHours = "Unknown";
                }
                else
                {
                    tempReturnTimeHours = ReturnTime();
                }


                string sReturnDate = "";

                if (dt_returndate.Enabled == false)
                {
                    sReturnDate = "Unknown";
                }
                else
                {
                    sReturnDate = dt_returndate.Value.DayOfWeek.ToString() + ", " +
                    dt_returndate.Value.Day.ToString() + " " +
                    dt_returndate.Value.ToString("MMMM") + " " +
                    dt_returndate.Value.Year.ToString();
                }

                string sDateIn = dt_datein.Value.DayOfWeek.ToString() + ", " +
                dt_datein.Value.Day.ToString() + " " +
                dt_datein.Value.ToString("MMMM") + " " +
                dt_datein.Value.Year.ToString();

                string sDatePaidReturnYear = "";
                string sDatePaidReturnMonth = "";
                string sDatePaidReturnDay = "";

                DateTime dtDPInvisible = new DateTime();

                if (g_sPaidStatus != "To Pay" && !sDatePaidBool)
                {
                    if (g_sPaidStatus == "N/C" || g_sPaidStatus == "OnAcc")
                    {
                        lbl_datepaid.Text = "Date Paid: N/A";
                        sDatePaid = "N/A";
                        sDatePaidInvisible = "N/A";

                        sDatePaidReturnYear = dt_datein.Value.Year.ToString();
                        sDatePaidReturnMonth = dt_datein.Value.Month.ToString();
                        sDatePaidReturnDay = dt_datein.Value.Day.ToString();

                        dtDPInvisible = new DateTime(dt_datein.Value.Year, dt_datein.Value.Month, dt_datein.Value.Day, 12, 0, 0);
                    }
                    else // All others apart from "To Pay"
                    {
                        // This means they paid the day they dropped the car off into the yard
                        if (!m_bIsFromCarReturns)
                        {
                            // This function makes the date paid
                            string dateCustomerPaid = dt_datein.Value.Day.ToString() + "/" + dt_datein.Value.Month.ToString("00") + "/" + dt_datein.Value.ToString("yy");

                            sDatePaidReturnYear = dt_datein.Value.Year.ToString();
                            sDatePaidReturnMonth = dt_datein.Value.Month.ToString();
                            sDatePaidReturnDay = dt_datein.Value.Day.ToString();

                            dtDPInvisible = new DateTime(dt_datein.Value.Year, dt_datein.Value.Month, dt_datein.Value.Day, 12, 0, 0);

                            lbl_datepaid.Text = "Date Paid: " + dateCustomerPaid;

                            sDatePaid = dt_datein.Value.DayOfWeek.ToString() + ", " +
                            dt_datein.Value.Day.ToString() + " " +
                            dt_datein.Value.ToString("MMMM") + " " +
                            dt_datein.Value.Year.ToString();

                            sDatePaidInvisible = dateCustomerPaid;
                        }
                        // This means they paid the day they picked up the car from the yard
                        else
                        {
                            DateTime dtTodaysDate = DateTime.Now;

                            // This function makes the date paid
                            string dateCustomerPaid = dtTodaysDate.Day.ToString() + "/" + dtTodaysDate.Month.ToString("00") + "/" + dtTodaysDate.ToString("yy");

                            sDatePaidReturnYear = dtTodaysDate.Year.ToString();
                            sDatePaidReturnMonth = dtTodaysDate.Month.ToString();
                            sDatePaidReturnDay = dtTodaysDate.Day.ToString();

                            dtDPInvisible = new DateTime(dt_datein.Value.Year, dt_datein.Value.Month, dt_datein.Value.Day, 12, 0, 0);

                            lbl_datepaid.Text = "Date Paid: " + dateCustomerPaid;

                            sDatePaid = dtTodaysDate.DayOfWeek.ToString() + ", " +
                            dtTodaysDate.Day.ToString() + " " +
                            dtTodaysDate.ToString("MMMM") + " " +
                            dtTodaysDate.Year.ToString();

                            sDatePaidInvisible = dateCustomerPaid;
                        }

                        sDatePaidBool = true;
                    }
                }
                else if(g_sPaidStatus == "To Pay")
                {
                    lbl_datepaid.Text = "Date Paid: To Pay";
                    sDatePaid = "To Pay";
                    sDatePaidInvisible = "To Pay";

                    sDatePaidReturnYear = "To Pay";
                    sDatePaidReturnMonth = "To Pay";
                    sDatePaidReturnDay = "To Pay";

                    dtDPInvisible = new DateTime(2000, 1, 1, 12, 0, 0);

                    sDatePaidBool = false;
                }
                else if(g_sPaidStatus == "N/C" || g_sPaidStatus == "OnAcc")
                {
                    lbl_datepaid.Text = "Date Paid: N/A";
                    sDatePaid = "N/A";
                    sDatePaidInvisible = "N/A";

                    sDatePaidReturnYear = dt_datein.Value.Year.ToString();
                    sDatePaidReturnMonth = dt_datein.Value.Month.ToString();
                    sDatePaidReturnDay = dt_datein.Value.Day.ToString();

                    dtDPInvisible = new DateTime(dt_datein.Value.Year, dt_datein.Value.Month, dt_datein.Value.Day, 12, 0, 0);

                    sDatePaidBool = false;
                }
                */
                #endregion OldCode

                string UpdateCommand = @"UPDATE CustomerInvoices SET
                                                                    KeyNumber = '" + txt_keyno.Text +
                                                                    "', Rego = '" + cmb_rego.Text +
                                                                    "', FirstName = '" + txt_firstname.Text +
                                                                    "', LastName = '" + txt_lastname.Text +
                                                                    "', PhoneNumber = '" + txt_ph.Text +
                                                                    "', MakeModel = '" + txt_makemodel.Text +
                                                                    "', DTDateIn = '" + dtDateIn +
                                                                    "', TimeIn = '" + sTimeIn +
                                                                    "', DTDatePaid = '" + dtDatePaid +
                                                                    "', DTReturnDate = '" + dtReturnDate +
                                                                    "', ReturnTime = '" + tempReturnTimeHours +
                                                                    "', AccountHolder = '" + txt_account.Text +
                                                                    "', AccountParticulars = '" + txt_particulars.Text +
                                                                    "', SevenDaysPay = '" + txt_money7.Text +
                                                                    "', SevenDaysPlusPay = '" + txt_money7plus.Text +
                                                                    "', OneMonthPlusPay = '" + txt_monthmoney.Text +
                                                                    "', CreditCardFeePay = '" + txt_creditcharge.Text +
                                                                    "', TotalPay = '" + txt_total.Text +
                                                                    "', PaidStatus = '" + g_sPaidStatus +
                                                                    "', CarLocation = '" + m_sCarLocation +
                                                                    "', Notes = '" + txt_notes.Text +
                                                                    "', Alerts = '" + txt_alerts.Text +
                                                                    "', FlightOrManual  = " + chk_flighttimes.Checked +
                                                                    ", YNDatePaid  = " + m_bAlreadyPaid +
                                                                    ", PickUp  = " + m_bCarPickedUp +
                                                                    ", UnknownDate  = " + bUnknownDate +
                                                                    " WHERE InvoiceNumber = " + iInvoiceNumber + "";

                /*
                string cmd1 = @"UPDATE Invoice SET
                                                    DateIn = '" + sDateIn +
                                                    "', DatePaid  = '" + sDatePaid +
                                                    "', DatePaidInvisible  = '" + sDatePaidInvisible +
                                                    "', DateInInvisible = '" + dt_datein.Value +
                                                    "', TimeIn = '" + tempTimeInHours +
                                                    "', ClientName = '" + txt_firstname.Text +
                                                    "', LastName = '" + txt_lastname.Text +
                                                    "', Ph = '" + txt_ph.Text +
                                                    "', MakeModel = '" + txt_makemodel.Text +
                                                    "', Rego = '" + cmb_rego.Text +
                                                    "', ReturnDate = '" + sReturnDate +
                                                    "', ReturnDateInvisible = '" + dt_returndate.Value +
                                                    "', DisplayedReturnDate = '" + MakeDisplayDate() +
                                                    "', ReturnTime = '" + tempReturnTimeHours +
                                                    "', SevenDaysPay = '" + txt_money7.Text +
                                                    "', SevenDaysPlusPay = '" + txt_money7plus.Text +
                                                    "', TotalPay = '" + txt_total.Text +
                                                    "', Notes = '" + txt_notes.Text +
                                                    "', AccountHolder = '" + cmd_accountlist.Text +
                                                    "', AccountParticulars = '" + txt_particulars.Text +
                                                    "', KeyNumber = '" + txt_keyno.Text +
                                                    "', PaidStatus = '" + g_sPaidStatus +
                                                    "', Alerts = '" + txt_alerts.Text +
                                                    "', ReturnYear = '" + dt_returndate.Value.Year +
                                                    "', ReturnMonth = '" + dt_returndate.Value.Month +
                                                    "', ReturnDay = '" + dt_returndate.Value.Day +
                                                    "', DPReturnYear = '" + sDatePaidReturnYear +
                                                    "', DPReturnMonth = '" + sDatePaidReturnMonth +
                                                    "', DPReturnDay = '" + sDatePaidReturnDay +
                                                    "', DPInvisible = '" + dtDPInvisible +
                                                    "', SevenDaysRate = '" + txt_money7charge.Text +
                                                    "', SevenDaysPlusRate = '" + txt_money7pluscharge.Text +
                                                    "', FlightOrManual  = " + chk_flighttimes.Checked +
                                                    " WHERE InvoiceNumber = " + iInvoiceNumber + "";
                */
                command.CommandText = UpdateCommand;

                command.ExecuteNonQuery();

                // Closes the connection to the database
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        void InsertIntoNumberPlates()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            // Checks to see if the NumberPlate already exists
            string cmdStr = @"SELECT COUNT(*) FROM NumberPlates
                        WHERE NumberPlates = '" + m_sTempStoreRego + "'";

            // Runs the command from above to search the database
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            // Returns a number based on how many matches it finds
            // If 0 Number Plate does not exist (New Number Plate)
            // If 1 or Greater Number Plate Already Exists
            int count = (int)cmd.ExecuteScalar();

            // If there is no matches in database, insert the new Number Plate
            // If there is a match (count is greater than 0), skip this function completly
            if (count == 0)
            {
                //record doesnt exist
                // Make new command structure for database querys
                OleDbCommand command = new OleDbCommand();

                // Make the command equal the physical location of the database (connection)
                command.Connection = connection;

                // Insert the new Number Plate into the Database
                string cmd1 = @"INSERT into NumberPlates (NumberPlates,ClientName,LastName,MakeModel,Ph,
                                                            Alerts) values
                                                            ('" + cmb_rego.Text + "','" +
                                                                txt_firstname.Text + "','" +
                                                                txt_lastname.Text + "','" +
                                                                txt_makemodel.Text + "','" +
                                                                txt_ph.Text + "','" +
                                                                txt_alerts.Text +
                                                            "')";

                // Makes the command text equal the string
                command.CommandText = cmd1;

                // Run a NonQuery (Saves into Database instead of pulling data out)
                command.ExecuteNonQuery();
            }
            else
            {
                // record already exists
                // Make new command structure for database querys
                OleDbCommand command = new OleDbCommand();

                // Make the command equal the physical location of the database (connection)
                command.Connection = connection;

                string cmd1 = @"UPDATE NumberPlates SET
                                    NumberPlates = '" + cmb_rego.Text +
                                    "', ClientName = '" + txt_firstname.Text +
                                    "', LastName = '" + txt_lastname.Text +
                                    "', MakeModel = '" + txt_makemodel.Text +
                                    "', Ph = '" + txt_ph.Text +
                                    "', Alerts = '" + txt_alerts.Text +
                                    "' WHERE NumberPlates = '" + m_sTempStoreRego + "'";

                // Makes the command text equal the string
                command.CommandText = cmd1;

                // Run a NonQuery (Saves into Database instead of pulling data out)
                command.ExecuteNonQuery();
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            // Sets up the next Regastration combo box for next invoice
            MyAppManager.MainMenuInstance.SetUpRegoComboBox();

            // Populates the Regastration on the next invoice
            PopulateRegoBox();
        }

        void InsertIntoAccounts()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            // Checks to see if the NumberPlate already exists
            string cmdStr = @"SELECT COUNT(*) FROM Accounts
                        WHERE Rego = '" + cmb_rego.Text + "'";

            // Runs the command from above to search the database
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            // Returns a number based on how many matches it finds
            // If 0 Number Plate does not exist (New Number Plate)
            // If 1 or Greater Number Plate Already Exists
            int count = (int)cmd.ExecuteScalar();

            // If there is no matches in database, insert the new Number Plate
            // If there is a match (count is greater than 0), skip this function completly
            if (count == 0)
            {
                //record doesnt exist
                // Make new command structure for database querys
                OleDbCommand command = new OleDbCommand();

                // Make the command equal the physical location of the database (connection)
                command.Connection = connection;

                // Insert the new Number Plate into the Database
                string cmd1 = @"INSERT into Accounts (ClientName,Rego,Account,AccountParticulars) values
                                                            ('" + txt_firstname.Text + "','" +
                                                                cmb_rego.Text + "','" +
                                                                txt_account.Text + "','" +
                                                                txt_particulars.Text +
                                                            "')";

                // Makes the command text equal the string
                command.CommandText = cmd1;

                // Run a NonQuery (Saves into Database instead of pulling data out)
                command.ExecuteNonQuery();
            }
            else
            {
                // record already exists
                // Make new command structure for database querys
                OleDbCommand command = new OleDbCommand();

                // Make the command equal the physical location of the database (connection)
                command.Connection = connection;

                string sName = txt_firstname.Text + " " + txt_lastname.Text;

                string cmd1 = @"UPDATE Accounts SET 
                                    ClientName = '" + sName +
                                    "', Rego = '" + cmb_rego.Text +
                                    "', Account = '" + txt_account.Text +
                                    "', AccountParticulars = '" + txt_particulars.Text +
                                    "' WHERE Rego = '" + cmb_rego.Text + "'";

                // Makes the command text equal the string
                command.CommandText = cmd1;

                // Run a NonQuery (Saves into Database instead of pulling data out)
                command.ExecuteNonQuery();
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /*
        void SaveDataIntoDatabase()
        {
            InsertIntoNumberPlates();

            connection.Open();

            string cmdStr = @"SELECT COUNT(*) FROM Invoice
                            WHERE InvoiceNumber = " + txt_invoiceno.Text + "";

            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            int count = (int)cmd.ExecuteScalar();

            connection.Close();

            if (count == 0)
            {
                //record doesnt exist
                InsertIntoInvoice();
                InsertIntoKeyBox();

                bIsSaved = true;
                labl_savedstatus.Text = "Saved";
                labl_savedstatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                string sWarning = "WARNING";
                string sWarningMessage = "This Invoice has already been saved, do you wish to overwrite existing data?";

                DialogResult dialogResult = MessageBox.Show(sWarningMessage, sWarning, MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    UpdateInvoice();

                    labl_savedstatus.Text = "Updated";
                    labl_savedstatus.ForeColor = System.Drawing.Color.Purple;
                }
            }
        }
        */

        #endregion

        #region MakeTime

        string CreateTimeIn()
        {
            string tempTimeInHours = cmb_timeinhours.Text;
            string tempTimeInMinutes = cmb_timeinminutes.Text;

            int x = 0;
            Int32.TryParse(tempTimeInHours, out x);

            if (x <= 9)
            {
                tempTimeInHours = "0" + tempTimeInHours;
            }

            tempTimeInHours += tempTimeInMinutes;

            return (tempTimeInHours);
        }

        string ReturnTime()
        {
            string tempTimeCombined = "";

            if (chk_manual.Checked)
            {
                string tempReturnTimeHours = cmb_returntimehours.Text;
                string tempReturnTimeMinutes = cmb_returntimeminutes.Text;

                tempTimeCombined = tempReturnTimeHours + tempReturnTimeMinutes;
            }
            else
            {
                tempTimeCombined = txt_flighttimes.Text;
            }

            return (tempTimeCombined);
        }

        public string MakeDisplayDate()
        {
            string storeDate = "";

            if (dt_returndate.Enabled == true)
            {
                string DisplayReturnDate = dt_returndate.Value.DayOfWeek.ToString().Substring(0, 3).ToUpper();

                storeDate = DisplayReturnDate + ", " + dt_returndate.Value.ToString("dd-MM-yy");
            }
            else
            {
                storeDate = "Unknown";
            }

            return (storeDate);
        }

        #endregion

        #region SeclectedTextChanges

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SearchLongTerm())
            {
                try
                {
                    if (chkbox_onaccount.Checked)
                    {
                        chkbox_onaccount.Checked = false;
                    }

                    CurrentTime = DateTime.Now;

                    if (!m_bIsFromCarReturns)
                    {
                        cmb_timeinhours.Text = CurrentTime.Hour.ToString("00");
                        cmb_timeinminutes.Text = CurrentTime.Minute.ToString("00");
                    }

                    // Opens the connection to the database
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    OleDbCommand command = new OleDbCommand();

                    command.Connection = connection;

                    string query = @"select * from NumberPlates where NumberPlates= '" + cmb_rego.Text + "'";

                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        txt_firstname.Text = reader["ClientName"].ToString();
                        txt_lastname.Text = reader["LastName"].ToString();
                        txt_makemodel.Text = reader["MakeModel"].ToString();
                        txt_ph.Text = reader["Ph"].ToString();
                        txt_alerts.Text = reader["Alerts"].ToString();

                        m_sTempStoreRego = cmb_rego.Text;
                    }

                    this.Text = cmb_rego.Text;

                    // Closes the connection to the database
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                    //lbl_particulars.Visible = true;
                    //txt_particulars.Visible = true;

                    //lbl_accountname.Visible = true;
                    //txt_account.Visible = true;

                    if (CheckIfAccount())
                    {
                        chkbox_onaccount.Checked = true;
                    }
                    else
                    {
                        lbl_particulars.Visible = false;
                        txt_particulars.Visible = false;

                        lbl_accountname.Visible = false;
                        txt_account.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }

        private bool SearchLongTerm()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from LongTermAccounts
                            where Rego1= '" + cmb_rego.Text + "' OR Rego2 = '" + cmb_rego.Text + "'";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            bool bIsLongTerm = false;

            while (reader.Read())
            {
                int iLongTermKey = (int)reader["LongTermKey"];

                LongTermForm ltf = new LongTermForm();

                ltf.LongTermPick(iLongTermKey);

                ltf.Show();

                bIsLongTerm = true;
            }

            this.Text = cmb_rego.Text;

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            if (bIsLongTerm)
            {
                cmb_rego.Text = "";

                return (true);
            }
            else
            {
                return (false);
            }
        }

        private bool CheckIfAccount()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            bool m_bIsAccount = false;

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from Accounts where Rego = '" + cmb_rego.Text + "'";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                m_bIsAccount = true;
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return (m_bIsAccount);
        }

        private bool PopulateAccountBoxes()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            bool m_bIsAccount = false;

            string query = @"select * from Accounts where Rego = '" + cmb_rego.Text + "'";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //chkbox_onaccount.Checked = true;
                m_bIsAccount = true;

                txt_account.Text = reader["Account"].ToString();
                txt_particulars.Text = reader["AccountParticulars"].ToString();
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return (m_bIsAccount);
        }

        private void cmb_timeouthours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bIsAlreadySaved)
            {
                txt_total.Text = "";
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txt_total.Text = "";

            FindFlightTimes();

            txt_flighttimes.SelectedIndex = 0;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            m_sTempStoreRego = cmb_rego.Text;

            if (!bIsAlreadySaved)
            {
                CurrentTime = DateTime.Now;

                if (!m_bIsFromCarReturns)
                {
                    cmb_timeinhours.Text = CurrentTime.Hour.ToString("00");
                    cmb_timeinminutes.Text = CurrentTime.Minute.ToString("00");
                }
            }

            if (cmb_rego.Text == "")
            {
                cmb_rego.BackColor = LabelBackColour;
                invManager.ChangeTabText(iTabNumberFromManager, "UNUSED");
            }
            else
            {
                cmb_rego.BackColor = System.Drawing.Color.White;

                if (!m_bIsFromCarReturns)
                {
                    invManager.ChangeTabText(iTabNumberFromManager, m_sTempStoreRego);
                }
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_total_TextChanged(object sender, EventArgs e)
        {
            //if (m_bIsFromCarReturns && g_sPaidStatus != "To Pay" && g_sPaidStatus != "Credit Card" && !m_bInitialSetUpFromCarReturns)
            //{
            //    string sWarningMessage = "This invoice has already been paid for.";

            //    WarningSystem ws = new WarningSystem(sWarningMessage, false);
            //    ws.ShowDialog();

            //    RevertChanges();
            //}
            //else
            //{
                if (txt_total.Text == "")
                {
                    txt_total.BackColor = LabelBackColour;
                }
                else
                {
                    txt_total.BackColor = System.Drawing.Color.Yellow;
                }

                if (!m_bInitialSetUpFromCarReturns)
                {
                    WarningsChangesMade();
                }
            //}
        }

        private void txt_clientname_TextChanged(object sender, EventArgs e)
        {
            cmb_rego.Text = cmb_rego.Text.ToUpper();

            if (txt_firstname.Text == "")
            {
                txt_firstname.BackColor = LabelBackColour;
            }
            else
            {
                txt_firstname.BackColor = System.Drawing.Color.White;
                cmb_rego.Text = cmb_rego.Text.ToUpper();
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_lastname_TextChanged(object sender, EventArgs e)
        {
            cmb_rego.Text = cmb_rego.Text.ToUpper();

            if (txt_lastname.Text == "")
            {
                txt_lastname.BackColor = LabelBackColour;
            }
            else
            {
                txt_lastname.BackColor = System.Drawing.Color.White;
                cmb_rego.Text = cmb_rego.Text.ToUpper();
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_ph_TextChanged(object sender, EventArgs e)
        {
            if (txt_ph.Text == "")
            {
                txt_ph.BackColor = LabelBackColour;
            }
            else
            {
                txt_ph.BackColor = System.Drawing.Color.White;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_makemodel_TextChanged(object sender, EventArgs e)
        {
            if (txt_makemodel.Text == "")
            {
                txt_makemodel.BackColor = LabelBackColour;
            }
            else
            {
                txt_makemodel.BackColor = System.Drawing.Color.White;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_alerts_TextChanged(object sender, EventArgs e)
        {
            if (txt_alerts.Text == "")
            {
                txt_alerts.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txt_alerts.BackColor = System.Drawing.Color.PaleVioletRed;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_notes_TextChanged(object sender, EventArgs e)
        {
            if (txt_notes.Text == "")
            {
                txt_notes.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txt_notes.BackColor = System.Drawing.Color.LightBlue;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (chk_nokey.Checked == true)
            {
                txt_keyno.Text = "NK";
                //txt_keyno.Enabled = false;
                //txt_keyno.Visible = false;

            */
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            chkbox_cash.Enabled = true;
            chkbox_eftpos.Enabled = true;
            chkbox_cheque.Enabled = true;
            chkbox_internet.Enabled = true;
            chkbox_stilltopay.Enabled = true;
            chkbox_onaccount.Enabled = true;
            chkbox_nocharge.Enabled = true;

            chkbox_cash.Visible = true;
            chkbox_eftpos.Visible = true;
            chkbox_cheque.Visible = true;
            chkbox_internet.Visible = true;
            chkbox_stilltopay.Visible = true;
            chkbox_onaccount.Visible = true;
            chkbox_nocharge.Visible = true;

            txt_paidstatus.Visible = true;
        }

        private void chk_keypolicy_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (chk_keypolicy.Checked == true)
            {
                chk_keypolicy.BackColor = Color.LightGreen;
            }
            else
            {
                chk_keypolicy.BackColor = Color.PaleVioletRed;
            }
            */
        }

        private void cmb_returntimeminutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!bIsAlreadySaved)
            {
                txt_total.Text = "";
            }
            
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void chk_flighttimes_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_flighttimes.Checked)
            {
                chk_manual.Checked = false;

                txt_flighttimes.Visible = true;

                cmb_returntimehours.Visible = false;
                cmb_returntimeminutes.Visible = false;
            }
            else
            {
                chk_manual.Checked = true;
            }
        }

        private void chk_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_manual.Checked)
            {
                chk_flighttimes.Checked = false;

                txt_flighttimes.Visible = false;

                cmb_returntimehours.Visible = true;
                cmb_returntimeminutes.Visible = true;
            }
            else
            {
                chk_flighttimes.Checked = true;
            }
        }

        private void txt_money7_TextChanged(object sender, EventArgs e)
        {
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_money7plus_TextChanged(object sender, EventArgs e)
        {
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_monthmoney_TextChanged(object sender, EventArgs e)
        {
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_creditcharge_TextChanged(object sender, EventArgs e)
        {
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_flighttimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bIsAlreadySaved)
            {
                txt_total.Text = "";
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        #endregion

        #region ButtonClicks

        private void btn_calculateprice_Click(object sender, EventArgs e)
        {
            //if (m_bIsFromCarReturns && g_sPaidStatus != "To Pay")
            //{
            //    string sWarningMessage = "This invoice has already been paid for.";

            //    WarningSystem ws = new WarningSystem(sWarningMessage, false);
            //    ws.ShowDialog();

            //    RevertChanges();
            //}
            //else
            //{
                SetUpPrice();
            //}
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dt_returndate.Enabled = true;
            dt_returndate.Visible = true;

            if (chk_manual.Checked)
            {
                cmb_returntimehours.Enabled = true;
                cmb_returntimeminutes.Enabled = true;

                cmb_returntimehours.Visible = true;
                cmb_returntimeminutes.Visible = true;
            }
            else
            {
                txt_flighttimes.Enabled = true;
                txt_flighttimes.Visible = true;
            }

            chkbox_uknowndate.BackColor = System.Drawing.Color.Transparent;
            chkbox_uknowntime.BackColor = System.Drawing.Color.Transparent;

            chkbox_uknowndate.Checked = false;
            chkbox_uknowntime.Checked = false;

            txt_firstname.Text = "";
            txt_ph.Text = "";
            txt_makemodel.Text = "";
            cmb_rego.Text = "";
            txt_money7.Text = "";
            txt_money7plus.Text = "";
            txt_total.Text = "";

            chkbox_cash.Checked = false;
            chkbox_eftpos.Checked = false;
            chkbox_cheque.Checked = false;
            chkbox_internet.Checked = false;
            chkbox_stilltopay.Checked = false;
            chkbox_onaccount.Checked = false;
            chkbox_nocharge.Checked = false;

            cmb_rego.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_mainmenu_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["MainMenu"];

            if (fm.WindowState == FormWindowState.Minimized)
            {
                fm.WindowState = FormWindowState.Normal;
            }

            fm.BringToFront();
        }

        private void btn_keybox_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["KeyBox"];

            if (fm != null)
            {
                if (fm.WindowState == FormWindowState.Minimized)
                {
                    fm.WindowState = FormWindowState.Normal;
                }

                fm.BringToFront();
            }
            else
            {
                KeyBox kb = new KeyBox();
                kb.Show();
            }
        }

        private void btn_returns_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NewCarReturns"];

            if (fm != null)
            {
                if (fm.WindowState == FormWindowState.Minimized)
                {
                    fm.WindowState = FormWindowState.Maximized;
                }

                fm.BringToFront();
            }
            else
            {
                NewCarReturns cr = new NewCarReturns();
                cr.Show();
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            bool bCheckUnknown = false;

            if (chkbox_uknowndate.Checked == true || chkbox_uknowntime.Checked == true && g_sPaidStatus == "To Pay")
            {
                bCheckUnknown = true;
            }

            if (cmb_rego.Text == "")
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "Please at least set the Car Rego before printing receipt";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else if (txt_total.Text == "" && g_sPaidStatus != "N/C" && !bCheckUnknown)
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "Please calculate price before printing receipt";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else if (g_sPaidStatus == "")
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "You have not picked a 'Paid Status' please select one before printing a receipt";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                PaperSize oPS = new PaperSize();
                oPS.RawKind = (int)PaperKind.A5;
                PaperSource oPSource = new PaperSource();
                oPSource.RawKind = (int)PaperSourceKind.Lower;

                printDocument.PrinterSettings = new PrinterSettings();
                printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
                printDocument.DefaultPageSettings.PaperSize = oPS;
                printDocument.DefaultPageSettings.PaperSource = oPSource;
                
                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                // This is used for getting the printer tray names
                string sString = "";
                PaperSource pkSource;
                for (int i = 0; i < printDocument.PrinterSettings.PaperSources.Count; i++)
                {
                    pkSource = printDocument.PrinterSettings.PaperSources[i];
                    sString += pkSource.ToString() + "/r/n";
                }

                printDocument.Print();

                printDocument.Dispose();
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            bool bCheckUnknown = false;

            if (chkbox_uknowndate.Checked == true || chkbox_uknowntime.Checked == true && g_sPaidStatus == "To Pay")
            {
                bCheckUnknown = true;
            }

            if (cmb_rego.Text == "")
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "Please at least set the Car Rego before printing receipt";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else if (txt_total.Text == "" && g_sPaidStatus != "N/C" && !bCheckUnknown)
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "Please calculate price before printing receipt";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else if (g_sPaidStatus == "")
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "You have not picked a 'Paid Status' please select one before printing a receipt";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                printDocument.PrinterSettings.PrinterName = "Brother HL-1210W series";

                printDocument.Print();
            }

            //DialogResult result = printDialog.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}


            //Bitmap bmpScreenshot;

            //bmpScreenshot = new Bitmap(Screen.AllScreens[1].Bounds.Width,
            //                                           Screen.AllScreens[1].Bounds.Height,
            //                                           System.Drawing.Imaging.PixelFormat.Format32bppArgb);


            //Graphics.FromImage(bmpScreenshot).CopyFromScreen(Screen.AllScreens[1].Bounds.X,
            //                                         Screen.AllScreens[1].Bounds.Y,
            //                                         0,
            //                                         0,
            //                                         Screen.AllScreens[1].Bounds.Size,
            //                                         CopyPixelOperation.SourceCopy);

            //pictureBox1.Image = bmpScreenshot;
            //pictureBox1.Refresh();
        }

        private void btn_revertchanges_Click(object sender, EventArgs e)
        {
            string sWarningMessage = "Do you wish to revert the changes you have made?";

            WarningSystem ws = new WarningSystem(sWarningMessage, true);
            ws.ShowDialog();

            if (ws.DialogResult == DialogResult.OK)
            {
                RevertChanges();
            }
        }

        void RevertChanges()
        {
            m_bInitialSetUpFromCarReturns = true;

            if (chk_flighttimes.Checked == true)
            {
                txt_flighttimes.Text = lstOriginalValues[17];
            }
            else
            {
                cmb_returntimehours.Text = lstOriginalValues[17].Substring(0, 2);
                cmb_returntimeminutes.Text = lstOriginalValues[17].Substring(2, 2);
            }

            txt_firstname.Text = lstOriginalValues[0];
            txt_lastname.Text = lstOriginalValues[1];
            txt_ph.Text = lstOriginalValues[2];
            txt_makemodel.Text = lstOriginalValues[3];
            cmb_rego.Text = lstOriginalValues[4];
            txt_notes.Text = lstOriginalValues[5];
            txt_alerts.Text = lstOriginalValues[6];
            txt_money7.Text = lstOriginalValues[7];
            txt_money7plus.Text = lstOriginalValues[8];
            txt_monthmoney.Text = lstOriginalValues[9];
            txt_creditcharge.Text = lstOriginalValues[10];
            txt_total.Text = lstOriginalValues[11];

            g_sPaidStatus = lstOriginalValues[12];
            PopulatePaidStatusWarnings(g_sPaidStatus);

            //cmd_accountlist.Text = lstOriginalValues[13];
            //txt_particulars.Text = lstOriginalValues[14];

            string sCarPickedUp = lstOriginalValues[15];

            if(sCarPickedUp == "True")
            {
                chk_pickedup.Checked = true;
            }
            else if(sCarPickedUp == "False")
            {
                chk_carinyard.Checked = true;
            }

            m_sCarLocation = lstOriginalValues[16];

            if(m_sCarLocation == "Front")
            {
                chk_carlocationfront.Checked = true;
            }
            else if(m_sCarLocation == "Back")
            {
                chk_carlocationback.Checked = true;
            }

            m_bInitialSetUpFromCarReturns = false;

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        #endregion

        #region CheckBoxes

        private void chkbox_cash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_cash.Checked)
            {
                ChangeOtherPaidStatusToNull(chkbox_cash.Name);
            }
            else
            {
                chkbox_cash.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;
            }
        }

        private void chkbox_eftpos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_eftpos.Checked)
            {
                ChangeOtherPaidStatusToNull(chkbox_eftpos.Name);
            }
            else
            {
                chkbox_eftpos.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;
            }
        }

        private void chkbox_cheque_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_cheque.Checked)
            {
                ChangeOtherPaidStatusToNull(chkbox_cheque.Name);
            }
            else
            {
                chkbox_cheque.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;
            }
        }

        private void chkbox_internet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_internet.Checked)
            {
                ChangeOtherPaidStatusToNull(chkbox_internet.Name);
            }
            else
            {
                chkbox_internet.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;
            }
        }

        private void chkbox_stilltopay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_stilltopay.Checked)
            {
                ChangeOtherPaidStatusToNull(chkbox_stilltopay.Name);
            }
            else
            {
                chkbox_stilltopay.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;
            }
        }

        WarningNewAccount wna;

        void CloseNewAccount(object sender, CancelEventArgs e)
        {
            int iCount = 0;

            if(wna.sGetIsExistingAccount())
            {
                lbl_particulars.Visible = true;
                txt_particulars.Visible = true;

                lbl_accountname.Visible = true;
                txt_account.Visible = true;

                txt_account.Text = wna.sGetAccount();

                iCount++;
            }

            if(wna.sGetIsNewAccount())
            {
                lbl_particulars.Visible = true;
                txt_particulars.Visible = true;

                lbl_accountname.Visible = true;
                txt_account.Visible = true;

                iCount++;
            }

            if(iCount == 0)
            {
                chkbox_onaccount.Checked = false;
            }

        }

        private void chkbox_onaccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_onaccount.Checked)
            {
                ChangeOtherPaidStatusToNull(chkbox_onaccount.Name);

                if(!PopulateAccountBoxes())
                {
                    wna = new WarningNewAccount();
                    wna.FormClosing += CloseNewAccount;
                    wna.ShowDialog();
                }
                else
                {
                    lbl_particulars.Visible = true;
                    txt_particulars.Visible = true;

                    lbl_accountname.Visible = true;
                    txt_account.Visible = true;
                }
            }
            else
            {
                chkbox_onaccount.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;

                lbl_particulars.Visible = false;
                txt_particulars.Visible = false;

                lbl_accountname.Visible = false;
                txt_account.Visible = false;
            }
        }

        private void chkbox_nocharge_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_nocharge.Checked == true)
            {
                ChangeOtherPaidStatusToNull(chkbox_nocharge.Name);
            }
            else
            {
                chkbox_nocharge.BackColor = System.Drawing.Color.Transparent;

                txt_total.Enabled = true;
                txt_total.Visible = true;

                label13.Visible = true;

                g_sPaidStatus = "";
                PaidStatusPicked = false;
            }
        }

        private void chkbox_uknowndate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_uknowndate.Checked == true)
            {
                dt_returndate.Enabled = false;
                dt_returndate.Visible = false;

                if(g_sPaidStatus != "OnAcc")
                {
                    chkbox_stilltopay.CheckState = CheckState.Checked;
                }

                chkbox_uknowndate.BackColor = System.Drawing.Color.Orange;

                txt_total.Text = "";
            }
            else
            {
                dt_returndate.Enabled = true;
                dt_returndate.Visible = true;

                chkbox_uknowndate.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void chkbox_uknowntime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_uknowntime.Checked == true)
            {
                cmb_returntimehours.Enabled = false;
                cmb_returntimeminutes.Enabled = false;
                txt_flighttimes.Enabled = false;

                if (g_sPaidStatus != "OnAcc")
                {
                    chkbox_stilltopay.CheckState = CheckState.Checked;
                }

                cmb_returntimehours.Visible = false;
                cmb_returntimeminutes.Visible = false;
                txt_flighttimes.Visible = false;

                chkbox_uknowntime.BackColor = System.Drawing.Color.Orange;

                txt_total.Text = "";
            }
            else
            {
                cmb_returntimehours.Enabled = true;
                cmb_returntimeminutes.Enabled = true;
                txt_flighttimes.Enabled = true;

                if (chk_flighttimes.Checked)
                {
                    txt_flighttimes.Visible = true;
                }
                else
                {
                    cmb_returntimehours.Visible = true;
                    cmb_returntimeminutes.Visible = true;
                }

                chkbox_uknowntime.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void chk_drivingback_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_drivingback.Checked == true)
            {
                chk_drivingback.BackColor = System.Drawing.Color.Orange;

                DrivingBack db = new DrivingBack();
                db.ShowDialog();
            }
            else
            {
                chk_drivingback.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void btn_recalculatecredit_Click(object sender, EventArgs e)
        {
            if (chk_credit.Checked)
            {
                ChangeOtherPaidStatusToNull(chk_credit.Name);

                if (txt_total.Text != "")
                {
                    float fTempNewPrice = 0;

                    float fParse = 0.0f;
                    float.TryParse(txt_total.Text, out fParse);

                    m_fOriginalPriceBeforeCredit = fParse;

                    fTempNewPrice = fParse + (fParse * 0.02f);

                    txt_total.Text = fTempNewPrice.ToString("N2");
                }
            }
        }

        private void chk_credit_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_credit.Checked)
            {
                ChangeOtherPaidStatusToNull(chk_credit.Name);

                //btn_recalculatecredit.Visible = true;

                if (txt_total.Text != "")
                {
                    float fTempNewPrice = 0;

                    float fParse = 0.0f;
                    float.TryParse(txt_total.Text, out fParse);

                    m_fOriginalPriceBeforeCredit = fParse;

                    fTempNewPrice = fParse + (fParse * 0.02f);
                    
                    txt_total.Text = fTempNewPrice.ToString("N2");
                }
            }
            else
            {
                txt_total.Text = m_fOriginalPriceBeforeCredit.ToString();

                chk_credit.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;

                //SetUpPrice();
                //txt_total.Text = m_fTempCreditCard.ToString();
            }
        }

        private void chk_carinyard_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_carinyard.Checked)
            {
                chk_pickedup.BackColor = System.Drawing.Color.Transparent;
                chk_pickedup.Checked = false;

                chk_carinyard.BackColor = Color.Lime;

                m_bCarPickedUp = false;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void chk_pickedup_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_pickedup.Checked)
            {
                chk_carinyard.BackColor = System.Drawing.Color.Transparent;
                chk_carinyard.Checked = false;

                chk_pickedup.BackColor = Color.Lime;

                m_bCarPickedUp = true;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void chk_carlocationfront_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_carlocationfront.Checked)
            {
                chk_carlocationback.BackColor = System.Drawing.Color.Transparent;
                chk_carlocationback.Checked = false;

                chk_carlocationfront.BackColor = Color.Lime;

                m_sCarLocation = "Front";
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void chk_carlocationback_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_carlocationback.Checked)
            {
                chk_carlocationfront.BackColor = System.Drawing.Color.Transparent;
                chk_carlocationfront.Checked = false;

                chk_carlocationback.BackColor = Color.Red;

                m_sCarLocation = "Back";
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        #endregion

        #region Printing

        //Bitmap memoryImage;

        //private void CaptureScreen()
        //{
        //    Graphics myGraphics = this.CreateGraphics();
        //    Size s = this.Size;
        //    //Size s = new Size(this.Size.Width * 2, this.Size.Height * 2);
        //    memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        //    memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        //}

        //private void printDocument1_PrintPage(System.Object sender,
        //System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(memoryImage, 0, 0);
        //}

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 30;

            graphic.DrawString("BOI Airport Car Storage Receipt", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            offset = offset + (int)fontHeight; //make the spacing consistent

            graphic.DrawString("Ph: 09-401-6351", font, new SolidBrush(Color.Black), startX, startY + 25);

            graphic.DrawString("---------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent

            string sTodaysDate = "Date: " + dt_datein.Value.Day + "/" + dt_datein.Value.Month + "/" + dt_datein.Value.Year;
            sTodaysDate += " - " + cmb_timeinhours.Text + ":" + cmb_timeinminutes.Text;
            graphic.DrawString(sTodaysDate, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            string sInvoiceNumber = "Invoice No: " + txt_invoiceno.Text;
            graphic.DrawString(sInvoiceNumber, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            string sClientName = "Name: " + txt_firstname.Text + " " + txt_lastname.Text;
            graphic.DrawString(sClientName, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            float fPrice = 0.0f;
            float.TryParse(txt_total.Text, out fPrice);
            string sTotalPrice = "Total: $" + fPrice.ToString("0.00");
            graphic.DrawString(sTotalPrice, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            graphic.DrawString("GST No: 20-247-711", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            string BankAccount = @"Banking:
------------------------
Branch: BNZ 
Name: Hertz NZ Ltd
Number: 02-0800-0493229-00
------------------------";

            graphic.DrawString(BankAccount, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 7; //make the spacing consistent

            string PayingOnline = @"If paying online, please include Inv No: " + txt_invoiceno.Text + "\r\nand BOICS as references";

            graphic.DrawString(PayingOnline, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 3; //make the spacing consistent

            graphic.DrawString("Thank You for Parking with Us!", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            Font fontStencil = new Font("Stencil", 20);
            graphic.DrawString("Paid By: " + g_sPaidStatus, fontStencil, new SolidBrush(Color.Black), startX, startY + offset);

            //Create image
            // Work
            Image newImage = Image.FromFile("C:/Drive D/KKCS Invoice Project/KKCSInvoiceProject/KKCSInvoiceProject/KKCSInvoiceProject/Resources/Car Storage Logo.jpg");

            // Draw image to screen.
            graphic.DrawImage(newImage, 300.0f, 100.0f, 200.0f, 200.0f);

            offset = offset + (int)fontHeight; //make the spacing consistent

            offset = offset + (int)fontHeight + 5; //make the spacing consistent
        }

        #endregion

        #region Misc

        private void PopulateRegoBox()
        {
            object[] a = new object[MyAppManager.MainMenuInstance.GetCmbRegoComboBox().Items.Count];
            MyAppManager.MainMenuInstance.GetCmbRegoComboBox().Items.CopyTo(a, 0);
            cmb_rego.Items.AddRange(a);
        }

        void PopulateAccountBox()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Accounts ORDER BY Account ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            string sFirstName = "";
            string sSecondName = "";

            while (reader.Read())
            {
                sFirstName = reader["Account"].ToString();

                if(sFirstName != sSecondName)
                {
                    sSecondName = sFirstName;

                    //cmd_accountlist.Items.Add(sFirstName);
                }
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        

        /*
        void CheckBoxOnAccount(bool _bAccountStatus)
        {
            if (_bAccountStatus == true)
            {
                chkbox_onaccount.CheckState = CheckState.Checked;
                chkbox_onaccount.BackColor = System.Drawing.Color.LightPink;
                DisableOtherPaidStatusCheckBox(chkbox_onaccount.Name);

                g_sPaidStatus = "OnAcc";
            }
            else
            {
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_onaccount.BackColor = System.Drawing.Color.Transparent;
                EnableAllPaidStatusCheckBox();

                g_sPaidStatus = "";
            }
        }
        */

        private void ChangeOtherPaidStatusToNull(string _name)
        {
            if (_name == "chkbox_cash")
            {
                chkbox_cash.BackColor = System.Drawing.Color.DodgerBlue;

                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;
                chk_credit.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Cash";
            }
            else if (_name == "chkbox_eftpos")
            {
                chkbox_eftpos.BackColor = System.Drawing.Color.DodgerBlue;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;
                chk_credit.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Eftpos";
            }
            else if (_name == "chk_credit")
            {
                chk_credit.BackColor = System.Drawing.Color.DodgerBlue;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Credit Card";
            }
            else if (_name == "chkbox_cheque")
            {
                chkbox_cheque.BackColor = System.Drawing.Color.DodgerBlue;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;
                chk_credit.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Cheque";
            }
            else if (_name == "chkbox_internet")
            {
                chkbox_internet.BackColor = System.Drawing.Color.DodgerBlue;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;
                chk_credit.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Internet";
            }
            else if (_name == "chkbox_stilltopay")
            {
                chkbox_stilltopay.BackColor = System.Drawing.Color.Yellow;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;
                chk_credit.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "To Pay";
            }
            else if (_name == "chkbox_onaccount")
            {
                chkbox_onaccount.BackColor = System.Drawing.Color.LightPink;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;
                chk_credit.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "OnAcc";
            }
            else if (_name == "chkbox_nocharge")
            {
                chkbox_nocharge.BackColor = System.Drawing.Color.LightPink;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chk_credit.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "N/C";

                sTempStorePrice = txt_total.Text;
                txt_total.Text = "";
                txt_money7.Text = "";
                txt_money7plus.Text = "";

                txt_total.Enabled = false;
                txt_total.Visible = false;

                label13.Visible = false;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }

            PaidStatusPicked = true;
        }

        #endregion

        #region Price

        public void SetUpPrice()
        {
            // This function puts in the default charges if they are blank
            if (txt_money7charge.Text == "")
            {
                txt_money7charge.Text = "10";
            }
            if (txt_money7pluscharge.Text == "")
            {
                txt_money7pluscharge.Text = "8";
            }
            if (txt_moneyMonthcharge.Text == "")
            {
                txt_moneyMonthcharge.Text = "40";
            }

            lbl_monthweeks.Text = "per week (0 weeks)";

            // Sets up the global days and times
            int iDays = 0;
            int iTimeInHours = 0;
            int iReturnTimeHours = 0;

            int iTotalMoney = 0;

            // Works out how many days there are between the date the car was
            // brought in, and when they are returning
            TimeSpan TimeDifference = dt_returndate.Value - dt_datein.Value;

            // Put the difference of days into the variable
            iDays = TimeDifference.Days;

            // Works out if the hours are above 20. If they are, add 1 day to the price
            if (TimeDifference.Hours > 20)
            {
                iDays++;
            }
            
            // Gets the time the customer brought the car in
            iTimeInHours = int.Parse(cmb_timeinhours.Text);

            // Checks to see if Flight Times or Manual times has been selected
            if (chk_flighttimes.Checked)
            {
                // Gets the time in
                iReturnTimeHours = int.Parse(txt_flighttimes.Text.Substring(0, 2));
            }
            else if (chk_manual.Checked)
            {
                // Gets the time in
                iReturnTimeHours = int.Parse(cmb_returntimehours.SelectedItem.ToString());
            }
            // If there is a gap of more than 4 hours between dropping off and picking up, add another days pay
            if (iReturnTimeHours - iTimeInHours > 4 && iDays != 0)
            {
                iDays++;
            }

            // Checks to see if the pricing is within a month, or over

            // This means they are staying less than a month
            if(iDays < 28)
            {
                // If the days are less than 0, this is impossible so give an error
                if (iDays < 0)
                {
                    MessageBox.Show("ERROR: 'Return Date' Cannot Be Before 'Date In'");
                }

                // If they are only staying for 1 day
                else if (iDays == 0)
                {
                    // Sets the 7+ days to null
                    txt_money7plus.Text = "";

                    // Gets the daily charge (Default $10)
                    int iMoneyCharge = int.Parse(txt_money7charge.Text.ToString());

                    // Calculates the price for 1 day
                    int iCalculateTotal = iMoneyCharge * (iDays + 1);

                    // Puts the total into box
                    txt_money7.Text = iCalculateTotal.ToString();
                    iTotalMoney = iCalculateTotal;
                }

                // If they are staying between 2 to 7 days
                else if (iDays >= 1 && iDays <= 7)
                {
                    // Sets the money to blank
                    txt_money7.Text = "";
                    txt_money7plus.Text = "";

                    // Gets the money each day will be charged at (Default: $10 per day)
                    int iMoneyCharge = int.Parse(txt_money7charge.Text.ToString());

                    // Multiplies the price by the number of days
                    int iCalculateTotal = iMoneyCharge * iDays;

                    // Puts in the price in to the box
                    txt_money7.Text = iCalculateTotal.ToString();
                    iTotalMoney = iCalculateTotal;
                }

                // If they are staying more than 7 days, but less than a month+
                else if (iDays > 7)
                {
                    // Sets the money to blank
                    txt_money7.Text = "";
                    txt_money7plus.Text = "";

                    // Sets up the first 7 days price
                    /////////////////
                    int iMoneyCharge = int.Parse(txt_money7charge.Text.ToString());

                    int iCalculateTotal = iMoneyCharge * 7;

                    txt_money7.Text = iCalculateTotal.ToString();
                    /////////////////


                    // Sets up all the remaining days prices
                    ///////////////
                    int iRemainingDays = iDays - 7;

                    int iMoney7PlusCharge = int.Parse(txt_money7pluscharge.Text.ToString());

                    int iCalculatePlusTotal = iMoney7PlusCharge * iRemainingDays;

                    txt_money7plus.Text = iCalculatePlusTotal.ToString();
                    //////////////


                    // Adds the 2 prices together
                    //////////////
                    iTotalMoney = iCalculateTotal + iCalculatePlusTotal;
                    ///////////////
                }
            }
            // This calculates prices if the customer are staying over 1 month or more
            else if(iDays > 28)
            {
                float fWorkOutWeeks = (float)iDays / 7;

                int iWorkOutWeeks = (int)decimal.Round((decimal)fWorkOutWeeks, 0, MidpointRounding.AwayFromZero);
                lbl_monthweeks.Text = "per week (" + iWorkOutWeeks.ToString() + " weeks)";

                int iMonthCharge = int.Parse(txt_moneyMonthcharge.Text.ToString());
                iTotalMoney = iMonthCharge * iWorkOutWeeks;

                txt_monthmoney.Text = iTotalMoney.ToString();
            }

            // Adds the credit card fee if applicable
            if (chk_credit.Checked)
            {
                float fTempCreditCardCharge = (float)iTotalMoney * 0.02f;
                txt_creditcharge.Text = fTempCreditCardCharge.ToString("N2");

                float fTempTotalPrice = (float)iTotalMoney + fTempCreditCardCharge;
                txt_total.Text = fTempTotalPrice.ToString("N2");
            }
            else
            {
                txt_total.Text = iTotalMoney.ToString();
            }
        }

        #endregion

        #region Warnings

        List<string> lstOriginalValues = new List<string>();
        List<string> lstCheckValues = new List<string>();

        void WarningsStoreOriginalValues()
        {
            lstOriginalValues = new List<string>();

            lstOriginalValues.Add(txt_firstname.Text);
            lstOriginalValues.Add(txt_lastname.Text);
            lstOriginalValues.Add(txt_ph.Text);
            lstOriginalValues.Add(txt_makemodel.Text);
            lstOriginalValues.Add(cmb_rego.Text);
            lstOriginalValues.Add(txt_notes.Text);
            lstOriginalValues.Add(txt_alerts.Text);
            lstOriginalValues.Add(txt_money7.Text);
            lstOriginalValues.Add(txt_money7plus.Text);
            lstOriginalValues.Add(txt_monthmoney.Text);
            lstOriginalValues.Add(txt_creditcharge.Text);
            lstOriginalValues.Add(txt_total.Text);
            lstOriginalValues.Add(g_sPaidStatus);
            //lstOriginalValues.Add(cmd_accountlist.Text);
            //lstOriginalValues.Add(txt_particulars.Text);
            lstOriginalValues.Add(m_bCarPickedUp.ToString());
            lstOriginalValues.Add(m_sCarLocation);

            if (chk_flighttimes.Checked == true)
            {
                lstOriginalValues.Add(txt_flighttimes.Text);
            }
            else
            {
                lstOriginalValues.Add(cmb_returntimehours.Text + cmb_returntimeminutes.Text);
            }
        }

        void WarningsChangesMade()
        {
            if (bIsAlreadySaved)
            {
                lstCheckValues = new List<string>();

                lstCheckValues.Add(txt_firstname.Text);
                lstCheckValues.Add(txt_lastname.Text);
                lstCheckValues.Add(txt_ph.Text);
                lstCheckValues.Add(txt_makemodel.Text);
                lstCheckValues.Add(cmb_rego.Text);
                lstCheckValues.Add(txt_notes.Text);
                lstCheckValues.Add(txt_alerts.Text);
                lstCheckValues.Add(txt_money7.Text);
                lstCheckValues.Add(txt_money7plus.Text);
                lstCheckValues.Add(txt_monthmoney.Text);
                lstCheckValues.Add(txt_creditcharge.Text);
                lstCheckValues.Add(txt_total.Text);
                lstCheckValues.Add(g_sPaidStatus);
                //lstCheckValues.Add(cmd_accountlist.Text);
                //lstCheckValues.Add(txt_particulars.Text);
                lstCheckValues.Add(m_bCarPickedUp.ToString());
                lstCheckValues.Add(m_sCarLocation);

                if (chk_flighttimes.Checked == true)
                {
                    lstCheckValues.Add(txt_flighttimes.Text);
                }
                else
                {
                    lstCheckValues.Add(cmb_returntimehours.Text + cmb_returntimeminutes.Text);
                }

                int iCount = 0;

                for (int i = 0; i < lstCheckValues.Count; i++)
                {
                    if (lstOriginalValues[i] != lstCheckValues[i])
                    {
                        iCount++;
                    }
                }

                if(iCount > 0)
                {
                    this.BackColor = Color.Yellow;
                    lbl_changesmade.Visible = true;
                    btn_update.Visible = true;
                    btn_revertchanges.Visible = true;
                }
                else
                {
                    this.BackColor = Color.LightGreen;
                    lbl_changesmade.Visible = false;
                    btn_update.Visible = false;
                    btn_revertchanges.Visible = false;
                }
            }
        }

        #endregion

        private void btn_newaccount_Click(object sender, EventArgs e)
        {
            NewAccount nw = new NewAccount();
            nw.ShowDialog();
        }

        private void lbl_accountname_Click(object sender, EventArgs e)
        {

        }

        private void lbl_particulars_Click(object sender, EventArgs e)
        {

        }

        private void txt_account_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_particulars_TextChanged(object sender, EventArgs e)
        {

        }
    }
}