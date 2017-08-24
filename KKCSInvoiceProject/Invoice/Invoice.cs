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
        //3209
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private Button printButton = new Button();
        private PrintDocument printDocument1 = new PrintDocument();

        InvoiceManager invManager;

        private OleDbConnection connection = new OleDbConnection();

        Color LabelBackColour = Color.FromArgb(255, 192, 192);

        DateTime CurrentTime = new DateTime();

        DateTime dtDatePaid = DateTime.Now;

        InvoiceNotes iv;
        InvoiceAlerts ia;
        SearchByName sbn;

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
        private void Invoice_Load(object sender, EventArgs e)
        {
            this.FormClosing += chkbox_topay_Closing;

            FindFlightTimes();

            // Checks to see if opened from Invoice
            // If not, then it is a new Invoice
            if (!m_bIsFromCarReturns)
            {
                btn_datepaid.Visible = false;

                txt_flighttimes.SelectedIndex = 0;

                PopulateRegoBox();
                PopulateMakeModel();
                FindKeyNumber();
                FindInvoiceNumber();

                dtReturnDateOriginal = dt_returndate.Value;
                sReturnTimeOriginal = txt_flighttimes.Text;

                txt_firstname.BackColor = LabelBackColour;
                txt_lastname.BackColor = LabelBackColour;
                txt_ph.BackColor = LabelBackColour;
                cmb_makemodel.BackColor = LabelBackColour;
                cmb_rego.BackColor = LabelBackColour;

                CurrentTime = DateTime.Now;

                cmb_timeinhours.Text = CurrentTime.Hour.ToString("00");
                cmb_timeinminutes.Text = CurrentTime.Minute.ToString("00");

                cmb_paidstatus.SelectedIndex = 0;
                cmb_carstatus.SelectedIndex = 0;
                cmb_pickedup.SelectedIndex = 0;
                cmb_carlocation.SelectedIndex = 0;

                btn_addinv.Text = "Add Invoice " + txt_invoiceno.Text + " Note";

                txt_total.Text = "";
            }
        }

        // If opening form from Car Returns run this
        public void SetUpFromCarReturns(int _iInvoiceNumber, NewCarReturns _NewCarReturns)
        {
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
                cmb_makemodel.Text = reader["MakeModel"].ToString();
                cmb_rego.Text = reader["Rego"].ToString();

                // Inserts any notes or alerts
                txt_notes.Text = reader["Notes"].ToString();
                txt_alerts.Text = reader["Alerts"].ToString();

                if(txt_notes.Text != "")
                {
                    txt_notes.Visible = true;
                    btn_addinv.Text = "Delete " + txt_invoiceno.Text + " Note"; 
                }
                if (txt_alerts.Text != "")
                {
                    txt_alerts.Visible = true;
                    btn_addcustalert.Text = "Delete Customer Alert";
                }

                bool bIsUnknown = (bool)reader["UnknownDate"];

                if (!bIsUnknown)
                {
                    DateTime dtReturnDate = (DateTime)reader["DTReturnDate"];
                    dt_returndate.Value = dtReturnDate;
                }
                else
                {
                    DateTime dtReturnDate = DateTime.Now;
                    dt_returndate.Value = dtReturnDate;
                }

                if (reader["ReturnTime"].ToString() == "Unknown")
                {
                    DateTime dtReturnDate = DateTime.Now;

                    //chk_manual.Checked = true;

                    int iHours = dtReturnDate.Hour;
                    int iMinutes = dtReturnDate.Minute;

                    //cmb_returntimehours.Text = iHours.ToString("00");
                    //cmb_returntimeminutes.Text = iMinutes.ToString("00");

                }
                else
                {
                    // Checks to see if Flight or Manual time was used
                    bool FlightOrManual = (bool)reader["FlightOrManual"];

                    // It was flight
                    if (FlightOrManual)
                    {
                        txt_flighttimes.Text = reader["ReturnTime"].ToString();
                        //chk_flighttimes.Checked = true;
                    }
                    else
                    {
                        // Inserts the time the customer is picking up their car
                        string sReturnTimeHours = reader["ReturnTime"].ToString().Substring(0, 2);
                        string sReturnTimeMinutes = reader["ReturnTime"].ToString().Substring(2, 2);

                        //cmb_returntimehours.Text = sReturnTimeHours;
                        //cmb_returntimeminutes.Text = sReturnTimeMinutes;

                        //chk_manual.Checked = true;
                    }
                }

                // Popluates the paid status
                bIsOnAccount = PopulatePaidStatus(reader);

                // Inserts the amount paid
                //txt_total.Text = reader["TotalPay"].ToString();

                bool bPickedUp = (bool)reader["PickUp"];

                //if (bPickedUp)
                //{
                //    chk_pickedup.Checked = true;
                //    chk_carinyard.Checked = false;

                //    chk_pickedup.BackColor = Color.Lime;
                //}
                //else
                //{
                //    chk_pickedup.Checked = false;
                //    chk_carinyard.Checked = true;

                //    chk_carinyard.BackColor = Color.Lime;
                //}

                m_bCarPickedUp = (bool)reader["PickUp"];

                //if (m_bCarPickedUp)
                //{
                //    chk_pickedup.Checked = true;
                //}
                //else if (!m_bCarPickedUp)
                //{
                //    chk_carinyard.Checked = true;
                //}

                m_sCarLocation = reader["CarLocation"].ToString();

                //if (m_sCarLocation == "Front")
                //{
                //    chk_carlocationfront.Checked = true;
                //}
                //else if (m_sCarLocation == "Back")
                //{
                //    chk_carlocationback.Checked = true;
                //}

                m_bAlreadyPaid = (bool)reader["YNDatePaid"];

                dtDatePaid = (DateTime)reader["DTDatePaid"];

                //if (g_sPaidStatus != "To Pay")
                //{
                //    m_bAlreadyPaid = true;
                //}

                if (g_sPaidStatus == "To Pay")
                {
                    btn_datepaid.Visible = false;
                }
                else
                {
                    //DateTime dtDatePaid = (DateTime)reader["DTDatePaid"];
                    string sDatePaid = dtDatePaid.Day + "/" + dtDatePaid.Month + "/" + dtDatePaid.ToString("yy");

                    btn_datepaid.Text = "Date Paid: " + sDatePaid + "(Click to Change)";
                }
            }

            if(bIsOnAccount)
            {
                //chkbox_onaccount.Checked = true;
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

            //if (_reader["PaidStatus"].ToString() == "Cash")
            //{
            //    chkbox_cash.Checked = true;
            //}
            //else if (_reader["PaidStatus"].ToString() == "Eftpos")
            //{
            //    chkbox_eftpos.Checked = true;
            //}
            //else if (_reader["PaidStatus"].ToString() == "Credit Card")
            //{
            //    chk_credit.Checked = true;
            //}
            //else if (_reader["PaidStatus"].ToString() == "Internet")
            //{
            //    chkbox_internet.Checked = true;
            //}
            //else if (_reader["PaidStatus"].ToString() == "Cheque")
            //{
            //    chkbox_cheque.Checked = true;
            //}
            //else if (_reader["PaidStatus"].ToString() == "To Pay")
            //{
            //    chkbox_stilltopay.Checked = true;
            //}
            //else if (_reader["PaidStatus"].ToString() == "OnAcc")
            //{
            //    bIsAccount = true;
            //}
            //else if (_reader["PaidStatus"].ToString() == "N/C")
            //{
            //    chkbox_nocharge.Checked = true;
            //}

            return (bIsAccount);
        }

        void PopulatePaidStatusWarnings(string _sPaidStatus)
        {
            //if (_sPaidStatus == "Cash")
            //{
            //    chkbox_cash.Checked = true;
            //}
            //else if (_sPaidStatus == "Eftpos")
            //{
            //    chkbox_eftpos.Checked = true;
            //}
            //else if (_sPaidStatus == "Credit Card")
            //{
            //    chk_credit.Checked = true;
            //}
            //else if (_sPaidStatus == "Internet")
            //{
            //    chkbox_internet.Checked = true;
            //}
            //else if (_sPaidStatus == "Cheque")
            //{
            //    chkbox_cheque.Checked = true;
            //}
            //else if (_sPaidStatus == "To Pay")
            //{
            //    chkbox_stilltopay.Checked = true;
            //}
            //else if (_sPaidStatus == "OnAcc")
            //{
            //    chkbox_onaccount.Checked = true;
            //}
            //else if (_sPaidStatus == "N/C")
            //{
            //    chkbox_nocharge.Checked = true;
            //}
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

            txt_keyno.Text = (iFirstNumber + 1).ToString();

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
            DateTime dtOct30 = new DateTime(2017, 10, 30);
            DateTime dtToday = DateTime.Now;
            DateTime dtCompare = new DateTime(dtToday.Year, dtToday.Month, dtToday.Day);
            //dtCompare = new DateTime(2017, 11, 5);

            if (false)//dtOct30 <= dtCompare)
            {
                // Opens the connection to the database
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            else
            {
                //if(dtCompareToday.Month > 
                //string sMonth = dtCompareToday.Month.ToString();

                string sTodaysDay = dt_returndate.Value.DayOfWeek.ToString();

                txt_flighttimes.Items.Clear();

                string sTxtFileLocation = "";

                if (sTodaysDay == "Saturday")
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sat.txt";
                }
                else if (sTodaysDay == "Sunday")
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sun.txt";
                }
                else
                {
                    sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Mon To Fri.txt";
                }

                using (StreamReader sr = new StreamReader(sTxtFileLocation))
                {
                    txt_flighttimes.Items.AddRange(System.IO.File.ReadAllLines(sTxtFileLocation));
                }
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
            SetUpSave();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SetUpSave();
        }

        void SetUpSave()
        {
            bool bCheckUnknown = false;

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
            if (g_sPaidStatus == "")
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

                    // TODO: Fix Accounts
                    //if (chkbox_onaccount.Checked)
                    //{
                    //    InsertIntoAccounts();
                    //}

                    // TODO: Fix this
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
                bool bCheckKeyNumberBlank = true;// CheckKeyNumberIsBlank();

                if (bCheckKeyNumberBlank)
                {
                    WarningsStoreOriginalValues();

                    UpdateInvoice();

                    InsertIntoNumberPlates();

                    //if (chkbox_onaccount.Checked)
                    //{
                    //    InsertIntoAccounts();
                    //}

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

        /*
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
                        btn_datepaid.Visible = false;

                        dtDatePaid = new DateTime(2001, 1, 1, 12, 0, 0);
                    }
                    else
                    {
                        DateTime dtNow = DateTime.Now;
                        dtDatePaid = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);

                        string dateCustomerPaid = dtDatePaid.Day.ToString() + "/" + dtDatePaid.Month.ToString("00") + "/" + dtDatePaid.ToString("yy");

                        btn_datepaid.Text = "Date Paid: " + dateCustomerPaid + "(Click to Change)";
                    }
                }

                bool bUnknownDate = false;
                DateTime dtReturnDate = new DateTime();

                int iYearDateIn = dt_datein.Value.Year;
                int iMonthDateIn = dt_datein.Value.Month;
                int iDayDateIn = dt_datein.Value.Day;

                DateTime dtDateIn = new DateTime(iYearDateIn, iMonthDateIn, iDayDateIn, 12, 0, 0);

                int iTimeHours = 0;
                int iTimeMinutes = 0;

                Int32.TryParse(cmb_timeinhours.Text, out iTimeHours);
                Int32.TryParse(cmb_timeinminutes.Text, out iTimeMinutes);

                string sTimeIn = iTimeHours.ToString("00") + iTimeMinutes.ToString("00");

                string UpdateCommand = @"UPDATE CustomerInvoices SET
                                                                    KeyNumber = '" + txt_keyno.Text +
                                                                    "', Rego = '" + cmb_rego.Text +
                                                                    "', FirstName = '" + txt_firstname.Text +
                                                                    "', LastName = '" + txt_lastname.Text +
                                                                    "', PhoneNumber = '" + txt_ph.Text +
                                                                    "', MakeModel = '" + cmb_makemodel.Text +
                                                                    "', DTDateIn = '" + dtDateIn +
                                                                    "', TimeIn = '" + sTimeIn +
                                                                    "', DTDatePaid = '" + dtDatePaid +
                                                                    "', DTReturnDate = '" + dtReturnDate +
                                                                    "', ReturnTime = '" + tempReturnTimeHours +
                                                                    "', AccountHolder = '" + txt_account.Text +
                                                                    "', AccountParticulars = '" + txt_particulars.Text +
                                                                    "', TotalPay = '" + txt_total.Text +
                                                                    "', PaidStatus = '" + g_sPaidStatus +
                                                                    "', CarLocation = '" + m_sCarLocation +
                                                                    "', Notes = '" + txt_notes.Text +
                                                                    "', Alerts = '" + txt_alerts.Text +
                                                                    ", YNDatePaid  = " + m_bAlreadyPaid +
                                                                    ", PickUp  = " + m_bCarPickedUp +
                                                                    ", UnknownDate  = " + bUnknownDate +
                                                                    " WHERE InvoiceNumber = " + iInvoiceNumber + "";

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
        */

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
                        btn_datepaid.Visible = false;

                        dtDatePaid = new DateTime(2001, 1, 1, 12, 0, 0);
                    }
                    else
                    {
                        DateTime dtNow = DateTime.Now;
                        dtDatePaid = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);

                        string dateCustomerPaid = dtDatePaid.Day.ToString() + "/" + dtDatePaid.Month.ToString("00") + "/" + dtDatePaid.ToString("yy");

                        btn_datepaid.Text = "Date Paid: " + dateCustomerPaid + "(Click to Change)";
                    }
                }

                bool bUnknownDate = false;
                DateTime dtReturnDate = new DateTime();

                int iYearDateIn = dt_datein.Value.Year;
                int iMonthDateIn = dt_datein.Value.Month;
                int iDayDateIn = dt_datein.Value.Day;

                DateTime dtDateIn = new DateTime(iYearDateIn, iMonthDateIn, iDayDateIn, 12, 0, 0);

                int iTimeHours = 0;
                int iTimeMinutes = 0;

                Int32.TryParse(cmb_timeinhours.Text, out iTimeHours);
                Int32.TryParse(cmb_timeinminutes.Text, out iTimeMinutes);

                string sTimeIn = iTimeHours.ToString("00") + iTimeMinutes.ToString("00");

                string UpdateCommand = @"UPDATE CustomerInvoices SET
                                                                    KeyNumber = '" + txt_keyno.Text +
                                                                    "', Rego = '" + cmb_rego.Text +
                                                                    "', FirstName = '" + txt_firstname.Text +
                                                                    "', LastName = '" + txt_lastname.Text +
                                                                    "', PhoneNumber = '" + txt_ph.Text +
                                                                    "', MakeModel = '" + cmb_makemodel.Text +
                                                                    "', DTDateIn = '" + dtDateIn +
                                                                    "', TimeIn = '" + sTimeIn +
                                                                    "', DTDatePaid = '" + dtDatePaid +
                                                                    "', DTReturnDate = '" + dtReturnDate +
                                                                    "', ReturnTime = '" + tempReturnTimeHours +
                                                                    "', AccountHolder = '" + txt_account.Text +
                                                                    "', AccountParticulars = '" + txt_particulars.Text +
                                                                    "', TotalPay = '" + txt_total.Text +
                                                                    "', PaidStatus = '" + g_sPaidStatus +
                                                                    "', CarLocation = '" + m_sCarLocation +
                                                                    "', YNDatePaid  = " + m_bAlreadyPaid +
                                                                    ", PickUp  = " + m_bCarPickedUp +
                                                                    ", UnknownDate  = " + bUnknownDate +
                                                                    " WHERE InvoiceNumber = " + iInvoiceNumber + "";

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
                                                                cmb_makemodel.Text + "','" +
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
                                    "', MakeModel = '" + cmb_makemodel.Text +
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
            //PopulateRegoBox();
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

            //if (chk_manual.Checked)
            //{
            //    string tempReturnTimeHours = cmb_returntimehours.Text;
            //    string tempReturnTimeMinutes = cmb_returntimeminutes.Text;

            //    tempTimeCombined = tempReturnTimeHours + tempReturnTimeMinutes;
            //}
            //else
            //{
            //    tempTimeCombined = txt_flighttimes.Text;
            //}

            tempTimeCombined = txt_flighttimes.Text;

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
            try
            {
                //if (chkbox_onaccount.Checked)
                //{
                //    chkbox_onaccount.Checked = false;
                //}

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
                    cmb_makemodel.Text = reader["MakeModel"].ToString();
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

                //if (CheckIfAccount())
                //{
                //    chkbox_onaccount.Checked = true;
                //}
                //else
                //{
                //    lbl_particulars.Visible = false;
                //    txt_particulars.Visible = false;

                //    lbl_accountname.Visible = false;
                //    txt_account.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
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
                //txt_total.Text = "";
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            FindFlightTimes();

            SetUpPrice();

            lbl_pickreturn.Visible = false;

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

        private void cmb_makemodel_TextChanged(object sender, EventArgs e)
        {
            if (cmb_makemodel.Text == "")
            {
                cmb_makemodel.BackColor = LabelBackColour;
            }
            else
            {
                cmb_makemodel.BackColor = System.Drawing.Color.White;
            }

            //if (!m_bInitialSetUpFromCarReturns)
            //{
            //    WarningsChangesMade();
            //}
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
            if (cmb_makemodel.Text == "")
            {
                cmb_makemodel.BackColor = LabelBackColour;
            }
            else
            {
                cmb_makemodel.BackColor = System.Drawing.Color.White;
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

        private void chk_split_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_split.Checked)
            {
                pnl_splitpayment.Visible = true;
            }
            else
            {
                pnl_splitpayment.Visible = false;
            }
            
        }

        private void chk_overdue_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_overdue.Checked)
            {
                pnl_overdue.Visible = true;
            }
            else
            {
                pnl_overdue.Visible = false;
            }
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
                //txt_total.Text = "";
            }
            
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void chk_flighttimes_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_flighttimes.Checked)
            //{
            //    chk_manual.Checked = false;

            //    txt_flighttimes.Visible = true;

            //    cmb_returntimehours.Visible = false;
            //    cmb_returntimeminutes.Visible = false;
            //}
            //else
            //{
            //    chk_manual.Checked = true;
            //}
        }

        private void chk_manual_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_manual.Checked)
            //{
            //    chk_flighttimes.Checked = false;

            //    txt_flighttimes.Visible = false;

            //    cmb_returntimehours.Visible = true;
            //    cmb_returntimeminutes.Visible = true;
            //}
            //else
            //{
            //    chk_flighttimes.Checked = true;
            //}
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
            SetUpPrice();

            if (!bIsAlreadySaved)
            {
                //txt_total.Text = "";
                
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        #endregion

        #region ButtonClicks

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

            //if (chk_flighttimes.Checked == true)
            //{
            //    txt_flighttimes.Text = lstOriginalValues[17];
            //}
            //else
            //{
            //    cmb_returntimehours.Text = lstOriginalValues[17].Substring(0, 2);
            //    cmb_returntimeminutes.Text = lstOriginalValues[17].Substring(2, 2);
            //}

            txt_firstname.Text = lstOriginalValues[0];
            txt_lastname.Text = lstOriginalValues[1];
            txt_ph.Text = lstOriginalValues[2];
            cmb_makemodel.Text = lstOriginalValues[3];
            cmb_rego.Text = lstOriginalValues[4];
            txt_notes.Text = lstOriginalValues[5];
            txt_alerts.Text = lstOriginalValues[6];
            //txt_money7.Text = lstOriginalValues[7];
            //txt_money7plus.Text = lstOriginalValues[8];
            //txt_monthmoney.Text = lstOriginalValues[9];
            //txt_creditcharge.Text = lstOriginalValues[10];
            txt_total.Text = lstOriginalValues[11];

            g_sPaidStatus = lstOriginalValues[12];
            PopulatePaidStatusWarnings(g_sPaidStatus);

            //cmd_accountlist.Text = lstOriginalValues[13];
            //txt_particulars.Text = lstOriginalValues[14];

            string sCarPickedUp = lstOriginalValues[15];

            //if(sCarPickedUp == "True")
            //{
            //    chk_pickedup.Checked = true;
            //}
            //else if(sCarPickedUp == "False")
            //{
            //    chk_carinyard.Checked = true;
            //}

            m_sCarLocation = lstOriginalValues[16];

            //if(m_sCarLocation == "Front")
            //{
            //    chk_carlocationfront.Checked = true;
            //}
            //else if(m_sCarLocation == "Back")
            //{
            //    chk_carlocationback.Checked = true;
            //}

            m_bInitialSetUpFromCarReturns = false;

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        #endregion ButtonClicks

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

        private void PopulateMakeModel()
        {
            object[] a = new object[MyAppManager.MainMenuInstance.GetCmbMakeModelComboBox().Items.Count];
            MyAppManager.MainMenuInstance.GetCmbMakeModelComboBox().Items.CopyTo(a, 0);
            cmb_makemodel.Items.AddRange(a);
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

        #endregion

        #region Price

        public void SetUpPrice()
        {
            // Sets up the global days and times
            int iDays = 0;
            int iTimeInHours = 0;
            int iReturnTimeHours = 0;

            int iTotalMoney = 0;

            int iFirstDay = 15;
            int iDaysAfter = 12;
            int iDays7Plus = 10;
            int iMonth = 55;

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

            iReturnTimeHours = int.Parse(txt_flighttimes.Text.Substring(0, 2));

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
                else if (iDays == 0 || iDays == 1)
                {
                    iTotalMoney = 15;
                }

                // If they are staying between 2 to 7 days
                else if (iDays >= 2 && iDays <= 7)
                {
                    // Multiplies the price by the number of days
                    //int iCalculateTotal = (15 + (iDaysAfter * (iDays - 1)));
                    int iCalculateTotal = ((iDaysAfter * iDays) + 3);

                    // Puts in the price in to the box
                    iTotalMoney = iCalculateTotal;
                }

                else
                {
                    int iCalculateTotal = (87 + (iDays7Plus * (iDays -7)));

                    iTotalMoney = iCalculateTotal;
                }
            }
            // This calculates prices if the customer are staying over 1 month or more
            else if(iDays >= 28)
            {
                float fWorkOutWeeks = (float)iDays / 7;

                int iWorkOutWeeks = (int)decimal.Round((decimal)fWorkOutWeeks, 0, MidpointRounding.AwayFromZero);

                iTotalMoney = iMonth * iWorkOutWeeks;
            }

            // Adds the credit card fee if applicable
            if (g_sPaidStatus == "Credit Card")
            {
                float fTempCreditCardCharge = (float)iTotalMoney * 0.02f;

                float fTempTotalPrice = (float)iTotalMoney + fTempCreditCardCharge;
                txt_total.Text = fTempTotalPrice.ToString("N2");

                lbl_cccharges.Visible = true;
            }
            else
            {
                txt_total.Text = iTotalMoney.ToString();

                lbl_cccharges.Visible = false;

                txt_total.Text = iTotalMoney.ToString();
            }

            if(iDays > 1)
            {
                lbl_stay.Text =  iDays.ToString("0") + " Days";
            }
            else
            {
                lbl_stay.Text = iDays.ToString("0") + " Day";
            }

            txt_total.Text = "−2147483648";
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
            lstOriginalValues.Add(cmb_makemodel.Text);
            lstOriginalValues.Add(cmb_rego.Text);
            lstOriginalValues.Add(txt_notes.Text);
            lstOriginalValues.Add(txt_alerts.Text);
            //lstOriginalValues.Add(txt_money7.Text);
            //lstOriginalValues.Add(txt_money7plus.Text);
            //lstOriginalValues.Add(txt_monthmoney.Text);
            //lstOriginalValues.Add(txt_creditcharge.Text);
            lstOriginalValues.Add(txt_total.Text);
            lstOriginalValues.Add(g_sPaidStatus);
            //lstOriginalValues.Add(cmd_accountlist.Text);
            //lstOriginalValues.Add(txt_particulars.Text);
            lstOriginalValues.Add(m_bCarPickedUp.ToString());
            lstOriginalValues.Add(m_sCarLocation);

            //if (chk_flighttimes.Checked == true)
            //{
            //    lstOriginalValues.Add(txt_flighttimes.Text);
            //}
            //else
            //{
            //    lstOriginalValues.Add(cmb_returntimehours.Text + cmb_returntimeminutes.Text);
            //}
        }

        void WarningsChangesMade()
        {
            if (bIsAlreadySaved)
            {
                lstCheckValues = new List<string>();

                lstCheckValues.Add(txt_firstname.Text);
                lstCheckValues.Add(txt_lastname.Text);
                lstCheckValues.Add(txt_ph.Text);
                lstCheckValues.Add(cmb_makemodel.Text);
                lstCheckValues.Add(cmb_rego.Text);
                lstCheckValues.Add(txt_notes.Text);
                lstCheckValues.Add(txt_alerts.Text);
                //lstCheckValues.Add(txt_money7.Text);
                //lstCheckValues.Add(txt_money7plus.Text);
                //lstCheckValues.Add(txt_monthmoney.Text);
                //lstCheckValues.Add(txt_creditcharge.Text);
                lstCheckValues.Add(txt_total.Text);
                lstCheckValues.Add(g_sPaidStatus);
                //lstCheckValues.Add(cmd_accountlist.Text);
                //lstCheckValues.Add(txt_particulars.Text);
                lstCheckValues.Add(m_bCarPickedUp.ToString());
                lstCheckValues.Add(m_sCarLocation);

                //if (chk_flighttimes.Checked == true)
                //{
                //    lstCheckValues.Add(txt_flighttimes.Text);
                //}
                //else
                //{
                //    lstCheckValues.Add(cmb_returntimehours.Text + cmb_returntimeminutes.Text);
                //}

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

        private void cmb_paidstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_paidstatus.Text != "Please Pick...")
            {
                g_sPaidStatus = cmb_paidstatus.Text;
            }

            SetUpPrice();

            btn_cashcalc.Enabled = false;
            btn_cashcalc.Visible = false;

            switch (cmb_paidstatus.Text)
            {
                case "To Pay":
                    {
                        cmb_paidstatus.BackColor = Color.Yellow;

                        break;
                    }
                case "Cash": 
                    {
                        cmb_paidstatus.BackColor = Color.LightBlue;

                        CashChangeCalc ccc = new CashChangeCalc();

                        int iPrice = int.Parse(txt_total.Text);

                        btn_cashcalc.Enabled = true;
                        btn_cashcalc.Visible = true;

                        ccc.CashChangeCalculation(iPrice);

                        ccc.ShowDialog();

                        break;
                    }
                case "Credit Card":
                    {
                        cmb_paidstatus.BackColor = Color.LightBlue;

                        break;
                    }
                case "Eftpos": case "Internet": case "Cheque":
                    {
                        cmb_paidstatus.BackColor = Color.LightBlue;

                        break;
                    }
                case "On Account":
                
                    {
                        cmb_paidstatus.BackColor = Color.PaleVioletRed;

                        break;
                    }
                case "No Charge":
                    {
                        cmb_paidstatus.BackColor = Color.Orange;

                        break;
                    }
                default:
                    {
                        g_sPaidStatus = "";
                        cmb_paidstatus.BackColor = Color.White;
                        break;
                    }
            }
        }

        private void btn_addinv_Click(object sender, EventArgs e)
        {
            iv = new InvoiceNotes();
            iv.GetInvoiceNumber(iInvoiceNumber);
            iv.FormClosing += CloseInvoiceNotes;
            iv.ShowDialog();
        }

        private void CloseInvoiceNotes(object sender, CancelEventArgs e)
        {
            string sGetCurrentNotes = iv.GetCurrentNotes();

            if(sGetCurrentNotes != "")
            {
                txt_notes.Visible = true;
                txt_notes.Text = sGetCurrentNotes;
            }
        }

        private void CloseAlertNotes(object sender, CancelEventArgs e)
        {
            string sGetCurrentNotes = iv.GetCurrentNotes();

            if (sGetCurrentNotes != "")
            {
                txt_notes.Visible = true;
                txt_notes.Text = sGetCurrentNotes;
            }
        }

        private void CloseCustomerSearch(object sender, CancelEventArgs e)
        {
            string sCustomerID = sbn.GetCustomerID();

            if (sCustomerID != "")
            {
                bool bIsWithRego = sbn.GetIsWithRego();
                int iCustomerID = int.Parse(sCustomerID);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                string sQuery = @"SELECT * FROM NumberPlates WHERE ID = " + iCustomerID + "";

                command.CommandText = sQuery;

                OleDbDataReader reader = command.ExecuteReader();

                string sStoreRego = "";

                while (reader.Read())
                {
                    txt_firstname.Text = reader["ClientName"].ToString();
                    txt_lastname.Text = reader["LastName"].ToString();
                    txt_ph.Text = reader["Ph"].ToString();

                    if (bIsWithRego)
                    {
                        sStoreRego = reader["NumberPlates"].ToString();
                    }
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                cmb_rego.Text = sStoreRego;
            }
        }

        private void btn_namesearch_Click(object sender, EventArgs e)
        {
            sbn = new SearchByName();
            sbn.FormClosing += CloseCustomerSearch;
            sbn.ShowDialog();
        }

        private void btn_refund_Click(object sender, EventArgs e)
        {
            Refund r = new Refund();
            r.ShowDialog();
        }

        private void btn_cashcalc_Click(object sender, EventArgs e)
        {
            CashChangeCalc ccc = new CashChangeCalc();

            int iPrice = int.Parse(txt_total.Text);

            ccc.CashChangeCalculation(iPrice);

            ccc.ShowDialog();
        }

        private void btn_addcustalert_Click(object sender, EventArgs e)
        {
            ia = new InvoiceAlerts();
            ia.GetInvoiceNumber(iInvoiceNumber);
            ia.FormClosing += CloseAlertNotes;
            ia.ShowDialog();
        }
    }
