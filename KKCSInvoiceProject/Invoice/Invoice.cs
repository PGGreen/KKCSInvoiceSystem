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
using System.Xml;

namespace KKCSInvoiceProject
{
    public partial class Invoice : Form
    {
        #region GlobalVaribles

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private Button printButton = new Button();
        private PrintDocument printDocument1 = new PrintDocument();

        InvoiceManager invManager;
        LongTermReturn longTermReturn;

        //Color bcolor = Color.FromArgb(lbl_10per.BackColor.R, lbl_10per.BackColor.G, lbl_10per.BackColor.B);

        private OleDbConnection connection = new OleDbConnection();

        Color LabelBackColour = Color.FromArgb(255, 192, 192);

        DateTime CurrentTime = new DateTime();

        DateTime dtDatePaid = DateTime.Now;

        bool g_bIsAlreadyAccount = false;

        bool g_bManualPicked = false;

        InvoiceNotes iv;
        InvoiceAlerts ia;
        SearchByName sbn;
        DrivingBack db;
        ManualTime mt;

        private bool bIsAlreadySaved = false;

        string sStoreOriginalPrice = "";

        bool bIsPreBooked = false;
        int iPreBookID = 0;

        private int iTabNumberFromManager = 0;

        //bool PaidStatusPicked = false;

        private bool m_bAlreadyPaid = false;

        bool m_bIsFromCarReturns = false;
        bool m_bInitialSetUpFromCarReturns = false;

        float fTotalMoney = 0.0f;

        int iInvoiceNumber = 0;

        DateTime dtReturnDateOriginal;
        string sReturnTimeOriginal;

        //private string sTempStorePrice = "";

        private string m_sTempStoreRego = "";

        private string m_sCarLocation = "Front";

        private bool m_bCarPickedUp = false;

        //float m_fOriginalPriceBeforeCredit = 0.0f;
        float fRemainingCredit = 0.0f;

        NewCarReturns NewCarReturns;

        //bool sDatePaidBool = false;

        string g_sPaidStatus = "";

        #endregion

        #region OpenAndClose

        private void chkbox_topay_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Drive D\GITKKCSInvoiceSystem\KKCSInvoiceSystem\KKCSInvoiceProject\Resources\No.wav");
            //player.Play();

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
                        WipeCustomerShow();

                        DestroyInvUnsaved();

                        invManager.DeleteTab(iTabNumberFromManager);

                        DeleteNotesIfUnsaved();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                DeleteNotesIfFromCarReturns();

                WipeCustomerShow();

                Form fmCustomerShow = Application.OpenForms["NewCarReturns"];

                if (fmCustomerShow != null)
                {
                    if (NewCarReturns == null)
                    {
                        NewCarReturns = (NewCarReturns)fmCustomerShow;
                    }

                    NewCarReturns.ReloadPageFromInvoice();
                }
            }
        }

        void DeleteNotesIfFromCarReturns()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            bool bIsNotes = false;
            bool bIsAlerts = false;

            if (txt_notes.Text != "")
            {
                bIsNotes = true;
            }

            if (txt_alerts.Text != "")
            {
                bIsAlerts = true;
            }


            string UpdateCommand = @"UPDATE CustomerInvoices SET IsNotes  = " + bIsNotes + ",IsAlerts = " + bIsAlerts + " WHERE InvoiceNumber = " + iInvoiceNumber + "";

            command.CommandText = UpdateCommand;

            command.ExecuteNonQuery();

            connection.Close();
        }

        void DeleteNotesIfUnsaved()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            OleDbDataReader reader;

            command.Connection = connection;

            string sQuery = @"DELETE * FROM InvoiceNotes WHERE InvoiceNumber = " + iInvoiceNumber + "";

            command.CommandText = sQuery;

            reader = command.ExecuteReader();

            connection.Close();
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

            cmb_printerpicked.SelectedIndex = 0;

            m_bIsFromCarReturns = _bIsFromCarReturns;

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        // Loads Invoice Form
        private void Invoice_Load(object sender, EventArgs e)
        {
            this.FormClosing += chkbox_topay_Closing;

            // Checks to see if opened from Invoice
            // If not, then it is a new Invoice
            if (!m_bIsFromCarReturns)
            {
                //FindFlightTimesXML();
                FindFlightTimesXML();

                btn_datepaid.Visible = false;

                txt_flighttimes.SelectedIndex = 0;

                PopulateRegoBox();
                PopulateMakeModel();
                FindKeyNumber();
                FindInvoiceNumber();
                FindStaffMembers();

                cmb_worker.SelectedIndex = 0;

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
                cmb_returnstatus.SelectedIndex = 0;
                cmb_pickedup.SelectedIndex = 0;
                cmb_carlocation.SelectedIndex = 0;

                btn_addinv.Text = "Add/Edit Invoice " + txt_invoiceno.Text + " Note";

                txt_total.Text = "";
                lbl_stay.Text = "";

                UpdateCustomerShowPrice();

                UpdateDateAndTime();
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

                DateTime dtreturn = (DateTime)reader["DTReturnDate"];
                dt_returndate.Value = dtreturn;

                //txt_flighttimes.Text = reader["ReturnTime"].ToString();

                txt_flighttimes.Items.Add(reader["ReturnTime"].ToString());

                int iComboBoxCount = txt_flighttimes.Items.Count;
                txt_flighttimes.SelectedIndex = iComboBoxCount - 1;

                // Inserts the time the customer dropped the car off
                cmb_timeinhours.Text = reader["TimeIn"].ToString().Substring(0, 2);
                cmb_timeinminutes.Text = reader["TimeIn"].ToString().Substring(2, 2);

                txt_total.Text = reader["TotalPay"].ToString();
                sStoreOriginalPrice = txt_total.Text;

                cmb_paidstatus.Text = reader["PaidStatus"].ToString();

                if (cmb_paidstatus.Text == "OnAcc")
                {
                    cmb_paidstatus.Text = "On Account";

                    lbl_particulars.Visible = true;
                    txt_particulars.Visible = true;

                    lbl_accountname.Visible = true;
                    txt_account.Visible = true;

                    txt_account.Text = reader["AccountHolder"].ToString();
                    txt_particulars.Text = reader["6AccountParticulars"].ToString();
                }

                if(cmb_paidstatus.Text != "To Pay")
                {
                    lbl_customerowes.Text = "Customer Paid: $";
                }

                m_bCarPickedUp = (bool)reader["PickUp"];

                if (!m_bCarPickedUp)
                {
                    cmb_pickedup.SelectedIndex = 0;

                }
                else
                {
                    cmb_pickedup.SelectedIndex = 1;
                }

                cmb_carlocation.Text = reader["CarLocation"].ToString();
                cmb_worker.Text = reader["StaffMember"].ToString();
                cmb_returnstatus.Text = reader["FlightStatus"].ToString();
                lbl_stay.Text = reader["Stay"].ToString();

                //FindFlightTimesXML();

                for (int i = 0; i < txt_flighttimes.Items.Count; i++)
                {
                    txt_flighttimes.SelectedIndex = i;

                    if (txt_flighttimes.Text.Substring(0, 4) == reader["ReturnTime"].ToString())
                    {
                        break;
                    }
                }

                // Inserts Customer Data
                txt_firstname.Text = reader["FirstName"].ToString();
                txt_lastname.Text = reader["LastName"].ToString();
                txt_ph.Text = reader["PhoneNumber"].ToString();
                cmb_makemodel.Text = reader["MakeModel"].ToString();
                cmb_rego.Text = reader["Rego"].ToString();

                string sReturnTimeHours = reader["ReturnTime"].ToString().Substring(0, 2);
                string sReturnTimeMinutes = reader["ReturnTime"].ToString().Substring(2, 2);

                // Popluates the paid status
                bIsOnAccount = PopulatePaidStatus(reader);

                m_sCarLocation = reader["CarLocation"].ToString();

                m_bAlreadyPaid = (bool)reader["YNDatePaid"];

                dtDatePaid = (DateTime)reader["DTDatePaid"];
                dt_datepaidedit.Value = (DateTime)reader["DTDatePaid"];

                string sTimePaid = reader["TimePaid"].ToString();
                txt_timepaidedit.Text = sTimePaid;

                if (g_sPaidStatus == "To Pay")
                {
                    btn_datepaid.Visible = false;
                }
                else
                {
                    //DateTime dtDatePaid = (DateTime)reader["DTDatePaid"];
                    string dateCustomerPaid = dtDatePaid.Day.ToString() + "/" + dtDatePaid.Month.ToString("00") + "/" + dtDatePaid.ToString("yy");

                    btn_datepaid.Text = "Date Paid: " + dateCustomerPaid + " - " + sTimePaid + " (Click To Modify)";
                }
            }

            DateTime dtToday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            WarningsStoreOriginalValues();


            if (false)//dt_returndate.Value > dtToday)
            {
                WarningSystem ws = new WarningSystem("Has this customer come in early?", true);
                ws.ShowDialog();

                if (ws.DialogResult == DialogResult.OK)
                {
                    Refund r = new Refund();
                    string sTimeIn = cmb_timeinhours.Text + cmb_timeinminutes.Text;
                    r.LoadInfoFromInvoice(dt_datein.Value,
                                          dt_returndate.Value,
                                          sTimeIn,
                                          txt_flighttimes.Text,
                                          txt_total.Text,
                                          txt_invoiceno.Text,
                                          lbl_stay.Text,
                                          txt_firstname.Text,
                                          txt_lastname.Text,
                                          cmb_rego.Text,
                                          g_sPaidStatus,
                                          lbl_stay.Text);
                    r.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("No");
                }

            }


            cmb_worker.Enabled = false;

            btn_refund.Enabled = true;

            m_bInitialSetUpFromCarReturns = false;

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            iv = new InvoiceNotes();
            iv.GetInvoiceNumber(iInvoiceNumber);
            iv.FormClosing += CloseInvoiceNotes;
            IntPtr dummyInvoice = iv.Handle;
            iv.Close();

            ia = new InvoiceAlerts();
            ia.GetRego(cmb_rego.Text);
            ia.FormClosing += CloseAlertNotes;
            IntPtr dummyAlert = ia.Handle;
            ia.Close();
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
                if (reader["KeyNumber"].ToString() != "NK" && (bool)reader["IsLongTerm"] != true)
                {
                    int.TryParse(reader["KeyNumber"].ToString(), out iSecondNumber);

                    int tempTestDifference = iSecondNumber - iFirstNumber;

                    if (tempTestDifference >= 2)
                    {
                        break;
                    }

                    int.TryParse(reader["KeyNumber"].ToString(), out iFirstNumber);
                }
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
            DateTime dtDec17 = new DateTime(2017, 12, 17);
            DateTime dtToday = DateTime.Now;
            DateTime dtCompare = new DateTime(dtToday.Year, dtToday.Month, dtToday.Day);

            string sTodaysDay = dt_returndate.Value.DayOfWeek.ToString();

            txt_flighttimes.Items.Clear();

            string sTxtFileLocation = "";

            //if (dtCompare <= dtDec17)
            {
                switch (sTodaysDay)
                {
                    case "Monday":
                    case "Friday":
                    case "Sunday":
                        {
                            sTxtFileLocation = Directory.GetCurrentDirectory() +
                            @"\Data\Flight Times\01-11-17 - 17-12-17\MON-FRI-SUN.txt";

                            break;
                        }
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                        {
                            sTxtFileLocation = Directory.GetCurrentDirectory() +
                            @"\Data\Flight Times\01-11-17 - 17-12-17\TUE-WED-THUR.txt";

                            break;
                        }
                    case "Saturday":
                        {
                            sTxtFileLocation = Directory.GetCurrentDirectory() +
                            @"\Data\Flight Times\01-11-17 - 17-12-17\SAT.txt";
                            break;
                        }
                }

                using (StreamReader sr = new StreamReader(sTxtFileLocation))
                {
                    //txt_flighttimes.Items.Add("T")
                    txt_flighttimes.Items.AddRange(System.IO.File.ReadAllLines(sTxtFileLocation));

                    txt_flighttimes.SelectedIndex = 0;
                }
            }
        }

        void FindFlightTimesXML()
        {
            XmlReader xmlReader = XmlReader.Create("Data/XML/FlightTimes.xml");

            string sDatePicked = dt_returndate.Value.Year + "-" + dt_returndate.Value.Month + "-" + dt_returndate.Value.Day;

            txt_flighttimes.Items.Clear();

            txt_flighttimes.Items.Add("Please Pick...");

            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "FlightTimes"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        if (sDatePicked == (string)xmlReader.GetAttribute("date"))
                        {
                            string sFlightString = xmlReader.GetAttribute("flighttime") + " - NZ" + xmlReader.GetAttribute("flightno");
                            txt_flighttimes.Items.Add(sFlightString);
                        }
                    }
                }
            }

            if (txt_flighttimes.Items.Count <= 2)
            {
                string sDay = dt_returndate.Value.ToString("dddd");
                switch (sDay)
                {
                    case "Saturday":
                        {
                            txt_flighttimes.Items.Add("0920 - NZ8266");
                            txt_flighttimes.Items.Add("1215 - NZ8274");
                            txt_flighttimes.Items.Add("1720 - NZ8270");

                            break;
                        }
                    case "Sunday":
                    case "Monday":
                        {
                            txt_flighttimes.Items.Add("0920 - NZ8266");
                            txt_flighttimes.Items.Add("1440 - NZ8268");
                            txt_flighttimes.Items.Add("1720 - NZ8270");
                            txt_flighttimes.Items.Add("2025 - NZ8272");

                            break;
                        }
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                        {
                            txt_flighttimes.Items.Add("0920 - NZ8266");
                            txt_flighttimes.Items.Add("1440 - NZ8268");
                            txt_flighttimes.Items.Add("1720 - NZ8270");
                            txt_flighttimes.Items.Add("2025 - NZ8272");

                            break;
                        }
                    case "Friday":
                        {
                            txt_flighttimes.Items.Add("0920 - NZ8266");
                            txt_flighttimes.Items.Add("1440 - NZ8268");
                            txt_flighttimes.Items.Add("1720 - NZ8270");
                            txt_flighttimes.Items.Add("2025 - NZ8272");

                            break;
                        }
                }
            }

            txt_flighttimes.Items.Add("Manual Time");

            txt_flighttimes.SelectedIndex = 0;
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
            if (cmb_worker.Text == "Please Pick...")
            {
                sWarning += "-Please pick a 'Staff Member'" + sEndLine;

                iIsThereWarnings++;
            }
            if (txt_flighttimes.Text == "Please Pick..." && cmb_returnstatus.Text == "Standard - On Flight")
            {
                sWarning += "-Please pick a Return Time" + sEndLine;

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

                if (bIsPreBooked)
                {
                    ClearBooking();

                    bIsPreBooked = false;
                }

                WipeCustomerShow();

                Form fm = Application.OpenForms["MainMenu"];
                MainMenu mm = (MainMenu)fm;
                mm.UpdateAmountOfCars();

                if (!m_bIsFromCarReturns)
                {
                    invManager.ChangeColour(iTabNumberFromManager);
                }
            }
        }

        void ClearBooking()
        {
            // Closes the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            // Make the command equal the physical location of the database (connection)
            command.Connection = connection;

            //string sRemaining = "";

            string cmd1 = @"UPDATE Bookings SET BookingFinished = TRUE WHERE ID = " + iPreBookID + "";

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
                    UpdateInvoice();

                    WarningsStoreOriginalValues();

                    InsertIntoNumberPlates();

                    if (cmb_paidstatus.Text == "On Account")
                    {
                        InsertIntoAccounts();
                    }

                    bIsAlreadySaved = true;

                    btn_save.Enabled = false;

                    btn_save.BackColor = Color.Green;
                    btn_save.Text = "SAVED";
                    this.BackColor = Color.LightGreen;

                    btn_refund.Enabled = true;


                    // Check if car is coming back today
                    DateTime _dtNow = DateTime.Now;
                    DateTime _dtToday = new DateTime(_dtNow.Year, _dtNow.Month, _dtNow.Day, 12, 0, 0);

                    DateTime _dtReturnDate = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, 12, 0, 0);

                    if (_dtToday == _dtReturnDate && cmb_returnstatus.Text != "Unknown Date & Time" && cmb_returnstatus.Text != "Driving Back/Bus - Unknown")
                    {
                        ReminderAddToReturns ratr = new ReminderAddToReturns();
                        ratr.ShowDialog();
                    }
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

                string sTimePaid = "";

                //btn_datepaid.Visible = false;

                // Sets up Paid Status & Paid Time
                //--------------------------------------------------------------------------//
                // If paid status is "To Pay", sets AlreadyPaid to false and date to 2001
                if (g_sPaidStatus == "To Pay")
                {
                    m_bAlreadyPaid = false;

                    btn_datepaid.Visible = false;

                    sTimePaid = "";
                    txt_timepaidedit.Text = "";

                    dtDatePaid = new DateTime(2001, 1, 1, 12, 0, 0);

                    dt_datepaidedit.Value = new DateTime(2001, 1, 1, 12, 0, 0);
                }
                // Sets up the date the customer paid
                else if (!m_bAlreadyPaid)
                {
                    m_bAlreadyPaid = true;

                    btn_datepaid.Visible = true;

                    DateTime dtNow = DateTime.Now;
                    dtDatePaid = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);

                    dt_datepaidedit.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);

                    sTimePaid = dtNow.Hour.ToString("00") + dtNow.Minute.ToString("00");

                    txt_timepaidedit.Text = sTimePaid;

                    string dateCustomerPaid = dtDatePaid.Day.ToString() + "/" + dtDatePaid.Month.ToString("00") + "/" + dtDatePaid.ToString("yy");

                    btn_datepaid.Text = "Date Paid: " + dateCustomerPaid + " - " + sTimePaid + " (Click To Modify)";

                    btn_datepaid.Name = txt_invoiceno.Text;
                }
                else if (m_bAlreadyPaid)
                {
                    dtDatePaid = new DateTime(dt_datepaidedit.Value.Year, dt_datepaidedit.Value.Month, dt_datepaidedit.Value.Day, 12, 0, 0);

                    string dateCustomerPaid = dtDatePaid.Day.ToString() + "/" + dtDatePaid.Month.ToString("00") + "/" + dtDatePaid.ToString("yy");

                    sTimePaid = txt_timepaidedit.Text;

                    btn_datepaid.Text = "Date Paid: " + dateCustomerPaid + " - " + sTimePaid + " (Click To Modify)";

                    dt_datepaidedit.Visible = false;
                    txt_timepaidedit.Visible = false;
                }
                //--------------------------------------------------------------------------//

                string sTimeIn = "";
                string tempReturnTimeHours = "";
                DateTime dtDateIn = new DateTime();
                DateTime dtReturnDate = new DateTime();
                string sPrice = txt_total.Text;

                if (sPrice == "UNKNOWN")
                {
                    sPrice = "";
                }

                // Sets up Date Customer came in and time they came in
                //--------------------------------------------------------------------------//
                dtDateIn = new DateTime(dt_datein.Value.Year, dt_datein.Value.Month, dt_datein.Value.Day, 12, 0, 0);

                sTimeIn = cmb_timeinhours.Text + cmb_timeinminutes.Text;
                //--------------------------------------------------------------------------//

                bool bUnknownTime = false;
                bool bDrivingBack = false;

                switch (cmb_returnstatus.Text)
                {
                    case "Standard - On Flight":
                        {
                            // Sets up Return Date and Return Time
                            //--------------------------------------------------------------------------//
                            dtReturnDate = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, 12, 0, 0);

                            tempReturnTimeHours = txt_flighttimes.Text.Substring(0, 4);
                            //--------------------------------------------------------------------------//

                            break;
                        }
                    case "Unknown Date & Time":
                        {
                            dtReturnDate = new DateTime(2001, 1, 1, 12, 0, 0);

                            bUnknownTime = true;

                            tempReturnTimeHours = "Unknown";

                            break;
                        }
                    case "Unknown Time":
                        {
                            dtReturnDate = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, 12, 0, 0);

                            tempReturnTimeHours = "Unknown";

                            break;
                        }
                    case "Driving Back/Bus":
                        {
                            bDrivingBack = true;

                            dtReturnDate = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, 12, 0, 0);

                            tempReturnTimeHours = txt_flighttimes.Text.Substring(0, 4);

                            break;
                        }
                    case "Driving Back/Bus - Unknown":
                        {
                            bDrivingBack = true;

                            dtReturnDate = new DateTime(2001, 1, 1, 12, 0, 0);

                            bUnknownTime = true;

                            tempReturnTimeHours = "Unknown";

                            break;
                        }
                }



                // Checks if Notes and Alerts have text in them
                bool bIsNotes = false;
                bool bIsAlerts = false;

                if (txt_notes.Text != "")
                {
                    bIsNotes = true;
                }

                if (txt_alerts.Text != "")
                {
                    bIsAlerts = true;
                }

                string sTest = "Peter O'Ril'ey";

                sTest = sTest.Replace("'", "''");

                string sFName = txt_firstname.Text;
                string sLName = txt_lastname.Text;

                sFName = sFName.Replace("'", "''");
                sLName = sLName.Replace("'", "''");

                string UpdateCommand = @"UPDATE CustomerInvoices SET
                                                                    KeyNumber = '" + txt_keyno.Text +
                                                                    "', Rego = '" + cmb_rego.Text +
                                                                    "', FirstName = '" + sFName +
                                                                    "', LastName = '" + sLName +
                                                                    "', PhoneNumber = '" + txt_ph.Text +
                                                                    "', MakeModel = '" + cmb_makemodel.Text +
                                                                    "', DTDateIn = '" + dtDateIn +
                                                                    "', TimeIn = '" + sTimeIn +
                                                                    "', DTDatePaid = '" + dtDatePaid +
                                                                    "', TimePaid = '" + sTimePaid +
                                                                    "', DTReturnDate = '" + dtReturnDate +
                                                                    "', ReturnTime = '" + tempReturnTimeHours +
                                                                    "', AccountHolder = '" + txt_account.Text +
                                                                    "', AccountParticulars = '" + txt_particulars.Text +
                                                                    "', TotalPay = '" + sPrice +
                                                                    "', Stay = '" + lbl_stay.Text +
                                                                    "', FlightStatus = '" + cmb_returnstatus.Text +
                                                                    "', StaffMember = '" + cmb_worker.Text +
                                                                    "', PaidStatus = '" + g_sPaidStatus +
                                                                    "', CarLocation = '" + m_sCarLocation +
                                                                    "', YNDatePaid  = " + m_bAlreadyPaid +
                                                                    ", PickUp  = " + m_bCarPickedUp +
                                                                    ", UnknownDate = " + bUnknownTime +
                                                                    ", DrivingBack = " + bDrivingBack +
                                                                    ", IsNotes  = " + bIsNotes +
                                                                    ", IsAlerts  = " + bIsAlerts +
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

                string sFName = txt_firstname.Text;
                string sLName = txt_lastname.Text;

                sFName = sFName.Replace("'", "''");
                sLName = sLName.Replace("'", "''");

                // Insert the new Number Plate into the Database
                string cmd1 = @"INSERT into NumberPlates (NumberPlates,ClientName,LastName,MakeModel,Ph,
                                                            Alerts) values
                                                            ('" + cmb_rego.Text + "','" +
                                                                sFName + "','" +
                                                                sLName + "','" +
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

                string sRemaining = "";

                if (fRemainingCredit != 0.0f)
                {
                    sRemaining = fRemainingCredit.ToString();
                }
                else if (fRemainingCredit == 0.0f)
                {
                    sRemaining = "";
                }

                string sFName = txt_firstname.Text;
                string sLName = txt_lastname.Text;

                sFName = sFName.Replace("'", "''");
                sLName = sLName.Replace("'", "''");

                string cmd1 = @"UPDATE NumberPlates SET
                                    NumberPlates = '" + cmb_rego.Text +
                                    "', ClientName = '" + sFName +
                                    "', LastName = '" + sLName +
                                    "', MakeModel = '" + cmb_makemodel.Text +
                                    "', Ph = '" + txt_ph.Text +
                                    "', Alerts = '" + txt_alerts.Text +
                                    "', Credit = '" + sRemaining +
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

        #region CustomerShow

        void UpdateCustomerShow()
        {
            Form fmCustomerShow = Application.OpenForms["CustomerShow"];

            if (fmCustomerShow == null)
            {
                CustomerShow cs = new CustomerShow();
                cs.Show();

                fmCustomerShow = cs;
            }

            CustomerShow objCustomerShow = (CustomerShow)fmCustomerShow;

            string sName = "";

            if (txt_firstname.Text != "")
            {
                sName += txt_firstname.Text + " ";
            }

            if (txt_lastname.Text != "")
            {
                sName += txt_lastname.Text;
            }

            string sAccount = "";

            if (g_bIsAlreadyAccount)
            {
                sAccount = txt_account.Text;
            }

            objCustomerShow.UpdateInfo(sName, cmb_rego.Text, cmb_makemodel.Text, sAccount);
        }

        void UpdateCustomerShowPrice()
        {
            Form fmCustomerShow = Application.OpenForms["CustomerShow"];

            if (fmCustomerShow == null)
            {
                CustomerShow cs = new CustomerShow();
                cs.Show();

                fmCustomerShow = cs;
            }

            CustomerShow objCustomerShow = (CustomerShow)fmCustomerShow;

            objCustomerShow.UpdatePrice(txt_total.Text, g_sPaidStatus);
        }

        void UpdateDateAndTime()
        {
            Form fmCustomerShow = Application.OpenForms["CustomerShow"];

            if (fmCustomerShow == null)
            {
                CustomerShow cs = new CustomerShow();
                cs.Show();

                fmCustomerShow = cs;
            }

            CustomerShow objCustomerShow = (CustomerShow)fmCustomerShow;

            switch (cmb_returnstatus.Text)
            {
                case "Standard - On Flight":
                    {
                        string dateCustomerIn = dt_datein.Value.Day.ToString() + "/" + dt_datein.Value.Month.ToString("00") + "/" + dt_datein.Value.ToString("yy");
                        dateCustomerIn += " - " + cmb_timeinhours.Text + ":" + cmb_timeinminutes.Text;

                        string dateCustomerOut = dt_returndate.Value.Day.ToString() + "/" + dt_returndate.Value.Month.ToString("00") + "/" + dt_returndate.Value.ToString("yy");
                        dateCustomerOut += " - " + txt_flighttimes.Text;

                        objCustomerShow.UpdateDateAndTime(dateCustomerIn, dateCustomerOut, lbl_stay.Text);

                        break;
                    }
                case "Unknown Date & Time":
                    {
                        string dateCustomerIn = dt_datein.Value.Day.ToString() + "/" + dt_datein.Value.Month.ToString("00") + "/" + dt_datein.Value.ToString("yy");
                        dateCustomerIn += " - " + cmb_timeinhours.Text + ":" + cmb_timeinminutes.Text;

                        string dateCustomerOut = "UNKNOWN";

                        objCustomerShow.UpdateDateAndTime(dateCustomerIn, dateCustomerOut, lbl_stay.Text);

                        break;
                    }
                case "Unknown Time":
                    {
                        string dateCustomerIn = dt_datein.Value.Day.ToString() + "/" + dt_datein.Value.Month.ToString("00") + "/" + dt_datein.Value.ToString("yy");
                        dateCustomerIn += " - " + cmb_timeinhours.Text + ":" + cmb_timeinminutes.Text;

                        string dateCustomerOut = dt_returndate.Value.Day.ToString() + "/" + dt_returndate.Value.Month.ToString("00") + "/" + dt_returndate.Value.ToString("yy");
                        dateCustomerOut += " - UNKNOWN TIME";

                        objCustomerShow.UpdateDateAndTime(dateCustomerIn, dateCustomerOut, lbl_stay.Text);

                        break;
                    }
                case "Driving Back/Bus":
                    {


                        break;
                    }
            }

        }

        void WipeCustomerShow()
        {
            Form fmCustomerShow = Application.OpenForms["CustomerShow"];

            if (fmCustomerShow == null)
            {
                CustomerShow cs = new CustomerShow();
                cs.Show();

                fmCustomerShow = cs;
            }

            CustomerShow objCustomerShow = (CustomerShow)fmCustomerShow;

            objCustomerShow.WipeInformation();
        }

        #endregion CustomerShow

        #region SeclectedTextChanges

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bIsLongTerm = CheckIfLongTerm();

            txt_credit.Enabled = false;
            lbl_credit.Enabled = false;
            lbl_creditminus.Enabled = false;
            txt_credit.ReadOnly = true;

            if (!bIsLongTerm)
            {
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

                    txt_credit.Enabled = true;
                    lbl_credit.Enabled = true;
                    lbl_creditminus.Enabled = true;
                    txt_credit.ReadOnly = true;

                    string sCredit = reader["Credit"].ToString();
                    txt_credit.Text = "";

                    if (sCredit != "")
                    {
                        txt_credit.Text = "$" + sCredit + ".00 ($" + sCredit + ".00 Remaining)";
                    }
                }

                this.Text = cmb_rego.Text;

                // Closes the connection to the database
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                CheckIfAccount();

                CheckIfPreBookings();

                ia = new InvoiceAlerts();
                ia.GetRego(cmb_rego.Text);
                ia.FormClosing += CloseAlertNotes;
                IntPtr dummyAlert = ia.Handle;
                ia.Close();

                UpdateCustomerShow();
            }
        }

        private bool CheckIfLongTerm()
        {
            bool bIsLongTerm = false;

            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from LongTermAccounts where Rego1 = '" + cmb_rego.Text + "' OR Rego2 = '" + cmb_rego.Text + "'";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                longTermReturn = new LongTermReturn(cmb_rego.Text);
                longTermReturn.Show();

                bIsLongTerm = true;

                cmb_rego.Text = "";
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return (bIsLongTerm);
        }

        private void CheckIfAccount()
        {
            txt_account.Visible = false;
            txt_particulars.Visible = false;

            lbl_accountname.Visible = false;
            lbl_particulars.Visible = false;

            txt_particulars.Text = "";
            txt_account.Text = "";

            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from Accounts where Rego = '" + cmb_rego.Text + "'";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            g_bIsAlreadyAccount = false;

            while (reader.Read())
            {
                g_bIsAlreadyAccount = true;

                cmb_paidstatus.Text = "On Account";

                txt_account.Visible = true;
                txt_particulars.Visible = true;

                lbl_accountname.Visible = true;
                lbl_particulars.Visible = true;

                txt_account.Text = reader["Account"].ToString();
                txt_particulars.Text = reader["AccountParticulars"].ToString();
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void CheckIfPreBookings()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string cmdStr = @"SELECT COUNT(*) FROM Bookings
                        WHERE Rego = '" + cmb_rego.Text + "'";

            // Runs the command from above to search the database
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            int count = (int)cmd.ExecuteScalar();

            // Opens the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            if (count == 1)
            {
                // Opens the connection to the database
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                string query = @"select * from Bookings where Rego = '" + cmb_rego.Text + "' AND BookingFinished = FALSE";

                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();

                string sEL = "\r\n";

                string sFlightLeaving = "";
                string sFlightPickingUp = "";
                string sRego = "";
                string sFName = "";
                string sLName = "";
                string sPh = "";
                string sMake = "";
                string sAccount = "";
                string sAccountPart = "";
                string sNotes = "";

                DateTime dtDateLeaving = new DateTime();
                DateTime dtDatePickingUp = new DateTime();

                string sCombined = "";

                while (reader.Read())
                {
                    bIsPreBooked = true;
                    iPreBookID = (int)reader["ID"];
                    sRego = reader["Rego"].ToString();
                    sFName = reader["FName"].ToString();
                    sLName = reader["LName"].ToString();
                    sPh = reader["Ph"].ToString();
                    sMake = reader["Make"].ToString(); ;
                    sAccount = reader["Account"].ToString();
                    sAccountPart = reader["AccountPart"].ToString();
                    sNotes = reader["Notes"].ToString();
                    sFlightLeaving = reader["FlightTimeLeaving"].ToString();
                    sFlightPickingUp = reader["FlightTimePickingUp"].ToString();

                    dtDateLeaving = (DateTime)reader["DateCustomerLeaving"];
                    dtDatePickingUp = (DateTime)reader["DateCustomerPickingUp"];

                    sCombined += "Rego: " + sRego + sEL;
                    sCombined += "Make: " + sMake + sEL + sEL;

                    sCombined += "Date Picking Up: " + dtDatePickingUp.Day + "/" + dtDatePickingUp.Month + "/" + dtDatePickingUp.Year + " - " + sFlightPickingUp + sEL + sEL;

                    sCombined += "Name: " + sFName + " " + sLName + sEL;
                    sCombined += "Ph: " + sPh + sEL;
                    sCombined += "Account: " + sAccount + sEL;

                    if (sAccountPart != "")
                    {
                        sCombined += "Account Particulars: " + sAccountPart;
                    }

                    PreBooking preBooking = new PreBooking(sCombined);
                    preBooking.ShowDialog();

                    dt_returndate.Value = new DateTime(dtDatePickingUp.Year, dtDatePickingUp.Month, dtDatePickingUp.Day, 12, 0, 0);

                    //if(sFlightPickingUp != "Time Not Known")
                    //{
                    //    txt_flighttimes.Text = sFlightPickingUp;
                    //}
                }

                // Closes the connection to the database
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                if (sFlightPickingUp != "Time Not Known")
                {
                    txt_flighttimes.Text = sFlightPickingUp;
                }
            }
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
            DateTime dtNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            //if (m_bIsFromCarReturns && dtNow > dtDateIn && g_sPaidStatus != "To Pay" && !m_bInitialSetUpFromCarReturns)
            //{
            //    string sWarning = "You can not change the price on this Invoice as";
            //    sWarning += "\r\nIt has already been paid for";

            //    WarningSystem ws = new WarningSystem(sWarning, false);

            //    ws.ShowDialog();

            //    return;
            //}
            
            lbl_stay.Text = "";
            txt_total.Text = "";

            DateTime dtXmasDay = new DateTime(dt_returndate.Value.Year, 12, 25);
            DateTime dtXmasDayCompare = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day);

            if (dtXmasDay == dtXmasDayCompare)
            {
                string sXmasWarning = "Please advise customer we are closed on Christmas Day.\r\n\r\n";
                sXmasWarning += "If they wish to stay with us, they can pick up their car on Boxing Day (26th),\r\n";
                sXmasWarning += "or if they prefer they can park their car out in the public car park instead.";

                WarningSystem ws = new WarningSystem(sXmasWarning, false);

                ws.ShowDialog();

                dt_returndate.Value = DateTime.Now;

                return;
            }

            FindFlightTimesXML();

            UpdateDateAndTime();
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

            UpdateCustomerShow();

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

            UpdateCustomerShow();

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_total_TextChanged(object sender, EventArgs e)
        {
            /*
            if (txt_total.Text == "")
            {
                txt_total.BackColor = LabelBackColour;
            }
            else
            {
                txt_total.BackColor = System.Drawing.Color.Yellow;
            }

            UpdateCustomerShowPrice();

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
            */
            
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

            UpdateCustomerShow();
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

            UpdateCustomerShow();
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
            if (chk_split.Checked)
            {
                pnl_splitpayment.Visible = true;
            }
            else
            {
                pnl_splitpayment.Visible = false;
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
            if (!bIsAlreadySaved)
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
            if (txt_flighttimes.Text == "Manual Time" && !m_bInitialSetUpFromCarReturns)
            {
                mt = new ManualTime();
                mt.FormClosing += CloseManualTime;
                mt.ShowDialog();
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                //SetUpPrice();

                g_bManualPicked = false;
            }

            /*
            if (txt_flighttimes.Text == "2025")
            {
                DrivingBack db = new DrivingBack();
                db.SetText("Last Flight", iInvoiceNumber);
                db.ShowDialog();
            }
            */

            if (!bIsAlreadySaved)
            {
                //txt_total.Text = "";

            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
                txt_total.Text = "";
            }

            lbl_stay.Text = "";
            

            if (txt_flighttimes.Text != "Please Pick...")
            {
                GetAmountOfDays();
            }

            UpdateDateAndTime();
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
                Form fm = Application.OpenForms["MainMenu"];
                MainMenu mm = (MainMenu)fm;
                mm.MinimiseForm();

                if (!m_bIsFromCarReturns)
                {
                    Form fmcarreturns = Application.OpenForms["NewCarReturns"];

                    if (fmcarreturns != null)
                    {
                        NewCarReturns ncr = (NewCarReturns)fmcarreturns;
                        ncr.MinimiseForm();
                    }
                }

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                if (cmb_printerpicked.SelectedIndex == 0)
                {
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
                }
                else
                {
                    printDocument.PrinterSettings = new PrinterSettings();
                    printDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";

                    printDialog.Document = printDocument; //add the document to the dialog box...        

                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing
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
            offset = offset + (int)fontHeight - 20; //make the spacing consistent

            graphic.DrawString("Ph: 09-401-6351", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 4;
            graphic.DrawString("Cell: 027-292-2806", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 4;

            graphic.DrawString("----------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
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
            offset = offset + (int)fontHeight; //make the spacing consistent

            string sCarRego = "Car Registration: " + cmb_rego.Text;
            graphic.DrawString(sCarRego, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent

            string sMakeModel = "Make/Model: " + cmb_makemodel.Text;
            graphic.DrawString(sMakeModel, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            graphic.DrawString("GST No: 20-247-711", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            string BankAccount = @"Banking:
---------------------------
Branch: BNZ 
Name: Hertz NZ Ltd
Number: 02-0800-0493229-00
---------------------------";

            graphic.DrawString(BankAccount, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 7; //make the spacing consistent

            string PayingOnline = @"If paying online, please include Inv No: " + txt_invoiceno.Text + "\r\nand BOICS as references";

            graphic.DrawString(PayingOnline, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 3; //make the spacing consistent

            graphic.DrawString("Thank You for Parking with Us!", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            float fPrice = 0.0f;
            float.TryParse(txt_total.Text, out fPrice);
            string sTotalPrice = "Total: $" + fPrice.ToString("0.00");
            graphic.DrawString(sTotalPrice, new Font("Stencil", 20), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight + 10; //make the spacing consistent

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

                if (sFirstName != sSecondName)
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

        #region Pricing

        int iFirstDayRate = 15;
        int iDays2To7Rate = 12;
        int iDays7PlusRate = 10;
        int iMonthlyRate = 55;
        float fCreditCardFee = 2.0f;
        float fSuperCardDiscount = 10.0f;

        void GetPrices()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from CarYardPricing";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int.TryParse(reader["One"].ToString(), out iFirstDayRate);
                int.TryParse(reader["TwoToSeven"].ToString(), out iDays2To7Rate);
                int.TryParse(reader["EightPlus"].ToString(), out iDays7PlusRate);
                int.TryParse(reader["MonthPlus"].ToString(), out iMonthlyRate);
                float.TryParse(reader["CreditCardFee"].ToString(), out fCreditCardFee);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void SetUpPrice()
        {
            GetPrices();

            // Sets up the global days and times
            int iDays = 0;
            int iTimeInHours = 0;
            int iReturnTimeHours = 0;

            // Works out how many days there are between the date the car was
            // brought in, and when they are returning
            int iInHours = 0;
            int iInMinutes = 0;
            int iReturnHours = 0;
            int iReturnMinutes = 0;

            int.TryParse(cmb_timeinhours.Text, out iInHours);
            int.TryParse(cmb_timeinminutes.Text, out iInMinutes);

            int.TryParse(txt_flighttimes.Text.Substring(0, 2), out iReturnHours);
            int.TryParse(txt_flighttimes.Text.Substring(2, 2), out iReturnMinutes);

            DateTime dtDateIn = new DateTime(dt_datein.Value.Year, dt_datein.Value.Month, dt_datein.Value.Day, iInHours, iInMinutes, 0);
            DateTime dtReturnDate = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, iReturnHours, iReturnMinutes, 0);

            TimeSpan TimeDifference = dtReturnDate - dtDateIn;

            // Puts the difference of days into the variable
            iDays = TimeDifference.Days;

            // Works out if the hours are above 20. If they are, add 1 day to the price
            //if (TimeDifference.TotalHours > 20)
            //{
            //    iDays++;
            //}

            // Gets the time the customer brought the car in
            iTimeInHours = int.Parse(cmb_timeinhours.Text);

            iReturnTimeHours = int.Parse(txt_flighttimes.Text.Substring(0, 2));

            int iHoursDifference = TimeDifference.Hours;

            // If there is a gap of more than 4 hours between dropping off and picking up, add another days pay
            if (iHoursDifference >= 4 && iDays != 0)
            {
                iDays++;
            }

            // Checks to see if the pricing is within a month, or over

            // This means they are staying less than a month
            if (iDays < 28)
            {
                // If the days are less than 0, this is impossible so give an error
                if (iDays < 0)
                {
                    WarningSystem ws = new WarningSystem("'Return Date' Cannot Be Before 'Date In'", false);
                    ws.ShowDialog();

                    dt_returndate.Value = DateTime.Now;

                    txt_total.Text = "";
                    lbl_stay.Text = "";

                    return;
                }

                // If they are only staying for 1 day
                else if (iDays == 0 || iDays == 1)
                {
                    fTotalMoney = iFirstDayRate;
                }

                // If they are staying between 2 to 7 days
                else if (iDays >= 2 && iDays <= 7)
                {
                    // Multiplies the price by the number of days
                    // int iCalculateTotal = (15 + (iDaysAfter * (iDays - 1)));
                    //int iCalculateTotal = ((iDaysAfter * (iDays-1)));
                    int iCalculateTotal = iFirstDayRate + (iDays2To7Rate * (iDays - 1));

                    // Puts in the price in to the box
                    fTotalMoney = iCalculateTotal;
                }

                else
                {
                    int iFirstSevenDays = iFirstDayRate + (iDays2To7Rate * 6);
                    int iCalculateTotal = (iFirstSevenDays + (iDays7PlusRate * (iDays - 7)));

                    fTotalMoney = iCalculateTotal;
                }
            }
            // This calculates prices if the customer are staying over 1 month or more
            else if (iDays >= 28)
            {
                float fWorkOutWeeks = (float)iDays / 7;

                int iWorkOutWeeks = (int)decimal.Round((decimal)fWorkOutWeeks, 0, MidpointRounding.AwayFromZero);

                fTotalMoney = iMonthlyRate * iWorkOutWeeks;
            }

            if (chk_supercard.Checked)
            {
                float fTempCreditCardCharge = fTotalMoney * (fSuperCardDiscount / 100.0f);

                fTotalMoney = fTotalMoney - fTempCreditCardCharge;
            }

            if (cmb_rego.Text == "GNB404")
            {
                if (iDays == 0)
                {
                    fTotalMoney = 7;
                }
                else
                {
                    fTotalMoney = iDays * 7;
                }
            }

            // Adds the credit card fee if applicable
            if (g_sPaidStatus == "Credit Card")
            {
                float fTempCreditCardCharge = (float)fTotalMoney * (fCreditCardFee / 100.0f);

                fTotalMoney = fTotalMoney + fTempCreditCardCharge;
            }

            txt_total.Text = fTotalMoney.ToString("N2");

            if (g_sPaidStatus == "N/C" || g_sPaidStatus == "No Charge")
            {
                txt_total.Text = "";
            }

            if (txt_credit.Text != "")
            {
                float fNewTotal = 0.0f;

                float fTotal = 0.0f;
                float fCredit = 0.0f;

                float.TryParse(txt_total.Text, out fTotal);
                float.TryParse(txt_credit.Text.Substring(1, 5), out fCredit);

                fNewTotal = fTotal - fCredit;

                if (fNewTotal < 0)
                {
                    cmb_paidstatus.Text = "No Charge";
                    txt_credit.Text = "$" + fCredit + ".00 ($" + (fNewTotal * -1) + ".00 Remaining)";
                    txt_total.Text = "0";

                    fRemainingCredit = (fNewTotal * -1);
                }
                else if (fNewTotal >= 0)
                {
                    txt_credit.Text = "$" + fCredit + ".00 ($0.00 Remaining)";
                    txt_total.Text = fNewTotal.ToString();

                    fRemainingCredit = 0.0f;
                }
            }

            UpdateCustomerShowPrice();
        }

        void GetAmountOfDays()
        {
            int iDays = 0;

            // Works out how many days there are between the date the car was
            // brought in, and when they are returning
            int iInHours = 0;
            int iInMinutes = 0;
            int iReturnHours = 0;
            int iReturnMinutes = 0;

            int.TryParse(cmb_timeinhours.Text, out iInHours);
            int.TryParse(cmb_timeinminutes.Text, out iInMinutes);

            int.TryParse(txt_flighttimes.Text.Substring(0, 2), out iReturnHours);
            int.TryParse(txt_flighttimes.Text.Substring(2, 2), out iReturnMinutes);

            DateTime dtDateIn = new DateTime(dt_datein.Value.Year, dt_datein.Value.Month, dt_datein.Value.Day, iInHours, iInMinutes, 0);
            DateTime dtReturnDate = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, iReturnHours, iReturnMinutes, 0);

            TimeSpan TimeDifference = dtReturnDate - dtDateIn;

            // Puts the difference of days into the variable
            iDays = TimeDifference.Days;

            int iHoursDifference = TimeDifference.Hours;

            // If there is a gap of more than 4 hours between dropping off and picking up, add another days pay
            if (iHoursDifference > 4 && iDays != 0)
            {
                iDays++;
            }

            if (iDays > 1)
            {
                if (iDays == 7)
                {
                    float fDays = iDays;

                    lbl_stay.Text = (fDays / 7).ToString("0") + " Week (" + iDays.ToString("0") + " Days)";
                }
                else if (iDays >= 8)
                {
                    float fDays = iDays;

                    if (iDays % 7 == 0)
                    {
                        lbl_stay.Text = (fDays / 7).ToString("0") + " Weeks (" + iDays.ToString("0") + " Days)";
                    }
                    else
                    {
                        lbl_stay.Text = (fDays / 7).ToString("0.0") + " Weeks (" + iDays.ToString("0") + " Days)";
                    }
                }
                else
                {
                    lbl_stay.Text = iDays.ToString("0") + " Days";
                }

            }
            else if (iDays <= 1)
            {
                lbl_stay.Text = "1 Day";
            }
        }

        #endregion Pricing

        #region Warnings

        List<string> lstOriginalValues = new List<string>();
        List<string> lstCheckValues = new List<string>();

        void RevertChanges()
        {
            m_bInitialSetUpFromCarReturns = true;

            bool bPickedUp = false;
            bool.TryParse(lstOriginalValues[9], out bPickedUp);

            txt_firstname.Text = lstOriginalValues[0];
            txt_lastname.Text = lstOriginalValues[1];
            txt_ph.Text = lstOriginalValues[2];
            cmb_makemodel.Text = lstOriginalValues[3];
            cmb_rego.Text = lstOriginalValues[4];
            txt_account.Text = lstOriginalValues[5];
            txt_particulars.Text = lstOriginalValues[6];
            txt_total.Text = lstOriginalValues[7];
            g_sPaidStatus = lstOriginalValues[8];
            m_bCarPickedUp = bPickedUp;
            m_sCarLocation = lstOriginalValues[10];
            cmb_makemodel.Text = lstOriginalValues[11];
            txt_keyno.Text = lstOriginalValues[14];

            m_bInitialSetUpFromCarReturns = false;

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        void WarningsStoreOriginalValues()
        {
            lstOriginalValues = new List<string>();

            lstOriginalValues.Add(txt_firstname.Text);
            lstOriginalValues.Add(txt_lastname.Text);
            lstOriginalValues.Add(txt_ph.Text);
            lstOriginalValues.Add(cmb_makemodel.Text);
            lstOriginalValues.Add(cmb_rego.Text);
            lstOriginalValues.Add(txt_account.Text);
            lstOriginalValues.Add(txt_particulars.Text);
            //lstOriginalValues.Add(btn_datepaid.Text);
            lstOriginalValues.Add(txt_total.Text);
            lstOriginalValues.Add(g_sPaidStatus);
            lstOriginalValues.Add(cmb_pickedup.Text);
            lstOriginalValues.Add(m_sCarLocation);
            lstOriginalValues.Add(cmb_makemodel.Text);
            lstOriginalValues.Add(dt_datepaidedit.Value.Year.ToString() + dt_datepaidedit.Value.Month.ToString() + dt_datepaidedit.Value.Day.ToString());
            lstOriginalValues.Add(txt_timepaidedit.Text);
            lstOriginalValues.Add(txt_keyno.Text);
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
                lstCheckValues.Add(txt_account.Text);
                lstCheckValues.Add(txt_particulars.Text);
                //lstCheckValues.Add(btn_datepaid.Text);
                lstCheckValues.Add(txt_total.Text);
                lstCheckValues.Add(g_sPaidStatus);
                lstCheckValues.Add(cmb_pickedup.Text);
                lstCheckValues.Add(m_sCarLocation);
                lstCheckValues.Add(cmb_makemodel.Text);
                lstCheckValues.Add(dt_datepaidedit.Value.Year.ToString() + dt_datepaidedit.Value.Month.ToString() + dt_datepaidedit.Value.Day.ToString());
                lstCheckValues.Add(txt_timepaidedit.Text);
                lstCheckValues.Add(txt_keyno.Text);

                //dt_datein

                int iCount = 0;

                for (int i = 0; i < lstCheckValues.Count; i++)
                {
                    if (lstOriginalValues[i] != lstCheckValues[i])
                    {
                        iCount++;
                    }
                }

                if (iCount > 0)
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
            //txt_total.Text = fTotalMoney.ToString("N2");

            if (cmb_paidstatus.Text != "Please Pick...")
            {
                g_sPaidStatus = cmb_paidstatus.Text;
            }

            if (!m_bInitialSetUpFromCarReturns && cmb_returnstatus.Text == "Standard - On Flight")
            {
                //SetUpPrice();
            }

            lbl_particulars.Visible = false;
            txt_particulars.Visible = false;

            lbl_accountname.Visible = false;
            txt_account.Visible = false;

            txt_particulars.Text = "";
            txt_account.Text = "";

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
                        if(!m_bInitialSetUpFromCarReturns)
                        {
                            txt_total.Text = sStoreOriginalPrice;
                        }
                        
                        cmb_paidstatus.BackColor = Color.LightBlue;

                        if (!m_bInitialSetUpFromCarReturns)
                        {
                            CashChangeCalc ccc = new CashChangeCalc();

                            float fPrice = 0;// int.TryParse(txt_total.Text);
                            float.TryParse(txt_total.Text, out fPrice);

                            ccc.CashChangeCalculation(fPrice);

                            ccc.ShowDialog();
                        }

                        btn_cashcalc.Enabled = true;
                        btn_cashcalc.Visible = true;

                        break;
                    }
                case "Credit Card":
                    {
                        if (txt_total.Text != "" && !m_bInitialSetUpFromCarReturns)
                        {
                            GetPrices();

                            //sOriginalPreCCPrice = txt_total.Text;

                            float fPrice = 0.0f;
                            float.TryParse(txt_total.Text, out fPrice);

                            float fTempCreditCardCharge = fPrice * (fCreditCardFee / 100.0f);

                            fPrice = fPrice + fTempCreditCardCharge;

                            txt_total.Text = fPrice.ToString("N2");
                        }
                        else if(txt_total.Text != "" && m_bInitialSetUpFromCarReturns)
                        {
                            cmb_paidstatus.BackColor = Color.LightBlue;
                        }

                        break;
                    }
                case "Eftpos":
                case "Internet":
                case "Cheque":
                    {
                        if (!m_bInitialSetUpFromCarReturns)
                        {
                            txt_total.Text = sStoreOriginalPrice;
                        }

                        cmb_paidstatus.BackColor = Color.LightBlue;

                        break;
                    }
                case "On Account":
                    {
                        if (!m_bInitialSetUpFromCarReturns)
                        {
                            txt_total.Text = sStoreOriginalPrice;
                        }

                        g_sPaidStatus = "OnAcc";

                        cmb_paidstatus.BackColor = Color.PaleVioletRed;

                        if (!g_bIsAlreadyAccount && !m_bInitialSetUpFromCarReturns)
                        {
                            SetUpNewAccount();
                        }

                        break;
                    }
                case "No Charge":
                    {
                        txt_total.Text = "0.00";

                        g_sPaidStatus = "N/C";
                        cmb_paidstatus.BackColor = Color.Orange;

                        break;
                    }
                default: // No Paid Status Picked
                    {
                        g_sPaidStatus = "";
                        cmb_paidstatus.BackColor = Color.White;

                        txt_total.Text = "";

                        break;
                    }
            }

            Form fmCustomerShow = Application.OpenForms["CustomerShow"];
            CustomerShow objCustomerShow = (CustomerShow)fmCustomerShow;

            objCustomerShow.UpdatePaidStatus(cmb_paidstatus.Text);

            //if (chk_supercard.Checked)
            //{
            //    SuperCardDiscount();
            //}

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        WarningNewAccount wna;

        private void SetUpNewAccount()
        {
            wna = new WarningNewAccount();
            wna.FormClosing += CloseNewAccount;
            wna.ShowDialog();
        }

        void CloseNewAccount(object sender, CancelEventArgs e)
        {
            int iCount = 0;

            if (wna.sGetIsExistingAccount())
            {
                lbl_particulars.Visible = true;
                txt_particulars.Visible = true;

                lbl_accountname.Visible = true;
                txt_account.Visible = true;

                txt_account.Text = wna.sGetAccount();

                iCount++;
            }

            if (wna.sGetIsNewAccount())
            {
                lbl_particulars.Visible = true;
                txt_particulars.Visible = true;

                lbl_accountname.Visible = true;
                txt_account.Visible = true;

                iCount++;
            }
        }

        private void btn_addinv_Click(object sender, EventArgs e)
        {
            iv = new InvoiceNotes();
            iv.GetInvoiceNumber(iInvoiceNumber);
            iv.GetRego(cmb_rego.Text);
            iv.FormClosing += CloseInvoiceNotes;
            iv.ShowDialog();
        }

        private void btn_addcustalert_Click(object sender, EventArgs e)
        {
            ia = new InvoiceAlerts();
            ia.GetRego(cmb_rego.Text);
            ia.FormClosing += CloseAlertNotes;
            ia.ShowDialog();
        }

        private void CloseManualTime(object sender, CancelEventArgs e)
        {
            g_bManualPicked = mt.GetPickedManual();

            if (g_bManualPicked)
            {
                txt_flighttimes.Items.Add(mt.GetTime());

                int iComboBoxCount = txt_flighttimes.Items.Count;
                txt_flighttimes.SelectedIndex = iComboBoxCount - 1;
            }
            else
            {
                txt_flighttimes.SelectedIndex = 0;

                g_bManualPicked = false;
            }
        }

        private void CloseInvoiceNotes(object sender, CancelEventArgs e)
        {
            string sGetCurrentNotes = iv.GetCurrentNotes();

            txt_notes.Text = sGetCurrentNotes;

            if (sGetCurrentNotes != "")
            {
                txt_notes.Visible = true;
            }
            else
            {
                txt_notes.Visible = false;
            }
        }

        private void CloseUnknownForm(object sender, CancelEventArgs e)
        {
            UpdateDateAndTime();
        }

        private void CloseAlertNotes(object sender, CancelEventArgs e)
        {
            string sGetCurrentNotes = ia.GetCurrentAlert();

            txt_alerts.Text = sGetCurrentNotes;

            if (sGetCurrentNotes != "")
            {
                txt_alerts.Visible = true;
            }
            else
            {
                txt_alerts.Visible = false;
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

                if (bIsWithRego)
                {
                    cmb_rego.Text = sStoreRego;
                }
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
            string sTimeIn = cmb_timeinhours.Text + cmb_timeinminutes.Text;
            //r.LoadInfoFromInvoice(dt_datein.Value, dt_returndate.Value, txt_total.Text, txt_invoiceno.Text, sTimeIn, txt_flighttimes.Text, lbl_stay.Text);
            r.ShowDialog();
        }

        private void btn_cashcalc_Click(object sender, EventArgs e)
        {
            CashChangeCalc ccc = new CashChangeCalc();

            float fPrice = 0;// int.TryParse(txt_total.Text);
            float.TryParse(txt_total.Text, out fPrice);

            ccc.CashChangeCalculation(fPrice);

            ccc.ShowDialog();
        }

        private void cmb_returnstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new DrivingBack();

            btn_warningagain.Visible = true;
            dt_returndate.Visible = true;
            txt_flighttimes.Visible = true;

            lbl_returndate.Text = "RETURN DATE:";
            lbl_flighttime.Text = "RETURN FLIGHT:";
            lbl_staytext.Text = "STAY:";



            switch (cmb_returnstatus.Text)
            {
                case "Standard - On Flight":
                    {
                        btn_warningagain.Visible = false;

                        break;
                    }
                case "Unknown Date & Time":
                    {
                        dt_returndate.Visible = false;
                        txt_flighttimes.Visible = false;

                        if (!m_bInitialSetUpFromCarReturns)
                        {
                            db.SetText("Unknown", iInvoiceNumber);
                            db.FormClosing += CloseUnknownForm;
                            db.ShowDialog();
                        }

                        lbl_returndate.Text += " UNKNOWN";
                        lbl_flighttime.Text += " UNKNOWN";
                        lbl_staytext.Text += " UNKNOWN";
                        txt_total.Text = "UNKNOWN";

                        if(cmb_paidstatus.Text != "On Account" && cmb_paidstatus.Text != "No Charge")
                        {
                            cmb_paidstatus.Text = "To Pay";
                        }

                        if (cmb_paidstatus.Text == "No Charge")
                        {
                            txt_total.Text = "";
                        }
                        
                        break;
                    }
                case "Unknown Time":
                    {
                        txt_flighttimes.Visible = false;

                        if (!m_bInitialSetUpFromCarReturns)
                        {
                            db.SetText("Unknown", iInvoiceNumber);
                            db.FormClosing += CloseUnknownForm;
                            db.ShowDialog();
                        }

                        lbl_flighttime.Text += " UNKNOWN";
                        lbl_staytext.Text += " UNKNOWN";
                        txt_total.Text = "UNKNOWN";

                        if (cmb_paidstatus.Text != "On Account" && cmb_paidstatus.Text != "No Charge")
                        {
                            cmb_paidstatus.Text = "To Pay";
                        }

                        if (cmb_paidstatus.Text == "No Charge")
                        {
                            txt_total.Text = "";
                        }

                        break;
                    }
                case "Driving Back/Bus":
                    {
                        if (!m_bInitialSetUpFromCarReturns)
                        {
                            db.SetText("Driving Back", iInvoiceNumber);
                            db.FormClosing += CloseUnknownForm;
                            db.ShowDialog();
                        }

                        break;
                    }
                case "Driving Back/Bus - Unknown":
                    {
                        dt_returndate.Visible = false;
                        txt_flighttimes.Visible = false;

                        if (!m_bInitialSetUpFromCarReturns)
                        {
                            db.SetText("Driving Back", iInvoiceNumber);
                            db.FormClosing += CloseUnknownForm;
                            db.ShowDialog();
                        }

                        lbl_returndate.Text += " UNKNOWN";
                        lbl_flighttime.Text += " UNKNOWN";
                        lbl_staytext.Text += " UNKNOWN";
                        txt_total.Text = "UNKNOWN";

                        if (cmb_paidstatus.Text != "On Account" && cmb_paidstatus.Text != "No Charge")
                        {
                            cmb_paidstatus.Text = "To Pay";
                        }

                        if (cmb_paidstatus.Text == "No Charge")
                        {
                            txt_total.Text = "";
                        }

                        break;
                    }
            }
        }

        private void btn_warningagain_Click(object sender, EventArgs e)
        {
            DrivingBack db = new DrivingBack();
            db.ShowDialog();
        }

        private void cmb_pickedup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_pickedup.BackColor = Color.FromArgb(192, 192, 255);

            if (cmb_pickedup.SelectedIndex == 0)
            {
                m_bCarPickedUp = false;
            }
            else
            {
                cmb_pickedup.BackColor = Color.LightGreen;

                m_bCarPickedUp = true;
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void cmb_carlocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_carlocation.BackColor = Color.LightGreen;

            if (cmb_carlocation.SelectedIndex == 0)
            {
                m_sCarLocation = "Front";
            }
            else
            {
                cmb_carlocation.BackColor = Color.Red;

                m_sCarLocation = "Back";
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void dt_dateleft_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dt_returndate.Value;

            dtStore = dtStore.AddDays(-1);

            dt_returndate.Value = dtStore;
        }

        private void dt_dateright_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dt_returndate.Value;

            dtStore = dtStore.AddDays(1);

            dt_returndate.Value = dtStore;
        }

        private void chk_nokey_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_nokey.Checked)
            {
                txt_keyno.Text = "NK";
                txt_keyno.BackColor = Color.PaleVioletRed;
                txt_keyno.ForeColor = Color.White;
            }
            else
            {
                FindKeyNumber();
                txt_keyno.BackColor = Color.FromArgb(255, 255, 128);
                txt_keyno.ForeColor = Color.Black;
            }
        }

        private void cmb_printerpicked_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_makemodel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_datepaid_Click(object sender, EventArgs e)
        {
            dt_datepaidedit.Visible = !dt_datepaidedit.Visible;
            txt_timepaidedit.Visible = !txt_timepaidedit.Visible;
        }

        private void dt_datepaid_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_timepaid_TextChanged(object sender, EventArgs e)
        {
            int iNumber = 0;
            bool bIsNumber = int.TryParse(txt_timepaidedit.Text, out iNumber);

            if(txt_timepaidedit.Text.Length == 4 && !bIsNumber)
            {
                string sTimeWarning = "Please make sure Time Paid is in the\r\nformat of 24hr time only. e.g. 0920";

                WarningSystem ws = new WarningSystem(sTimeWarning, false);
                ws.ShowDialog();

                txt_timepaidedit.Text = lstOriginalValues[13];
            }

            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void txt_keyno_TextChanged(object sender, EventArgs e)
        {
            if (!m_bInitialSetUpFromCarReturns)
            {
                WarningsChangesMade();
            }
        }

        private void btn_price_Click(object sender, EventArgs e)
        {
            if (txt_flighttimes.Text == "Please Pick...")
            {
                string sWarningText = "-Please pick a return flight\r\n";

                WarningSystem ws = new WarningSystem(sWarningText, false);
                ws.ShowDialog();

                return;
            }

            SetUpPrice();

            sStoreOriginalPrice = txt_total.Text;
        }

        private void pic_supercard_Click(object sender, EventArgs e)
        {
            chk_supercard.Checked = !chk_supercard.Checked;
        }

        string sOriginalPrice = "";
        string sOriginalPreCCPrice = "";

        string sOriginalSuperCardPrice = "";

        private void chk_supercard_CheckedChanged_1(object sender, EventArgs e)
        {
            lbl_10per.BackColor = Color.White;

            if (chk_supercard.Checked)
            {
                lbl_10per.BackColor = Color.LightGreen;
            }

            if (chk_supercard.Checked && txt_total.Text != "")
            {
                SuperCardDiscount();
            }
            else if (!chk_supercard.Checked && txt_total.Text != "")
            {
                txt_total.Text = sStoreOriginalPrice;
            }
        }

        void SuperCardDiscount()
        {
            GetPrices();

            sOriginalPrice = txt_total.Text;

            float fPrice = 0.0f;
            float.TryParse(txt_total.Text, out fPrice);

            float fTempCreditCardCharge = fPrice * (fSuperCardDiscount / 100.0f);

            fPrice = fPrice - fTempCreditCardCharge;

            txt_total.Text = fPrice.ToString("N2");
            fTotalMoney = fPrice;


        }
    }
}