using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace KKCSInvoiceProject
{
    public partial class NewCarReturns : Form
    {
        #region GlobalVariables

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        OleDbCommand command;

        Panel pnl;

        List<Panel> lstReturnPanels;
        List<Panel> lstUnknownPanels;
        List<Panel> lstBadDebot;

        string sList = "TodaysReturns";

        DateTime dtDate;

        Label lblTitle;

        //Checks to see if the car has already been picked up
        bool bPickedUp = false;
        bool bIsLongTerm = false;

        bool bFirstTimeDividier = false;
        int iNoMoreThan1Divider = 0;

        int iCars = 0;

        int iInitialPanelLocationY = 0;

        #endregion

        #region Load

        public NewCarReturns()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            PopulateRegoBox();
            PopulateAccountBox();

            cmb_searchby.SelectedIndex = 0;

            //button1.BackgroundImage = Properties.Resources.NA;

            RefreshReturnDate();
        }

        #endregion

        #region CreatePanels

        void RefreshReturnDate()
        {
            // Set the initial location for the title
            iInitialPanelLocationY = pnl_template.Location.Y;

            lstReturnPanels = new List<Panel>();
            lstUnknownPanels = new List<Panel>();
            lstBadDebot = new List<Panel>();

            // Creates the Title Header
            TitleHeaders(0);

            // Create todays date for the query
            DateTime now = dt_timepicked.Value;
            //now = now.AddDays(-2);
            dtDate = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);

            sList = "TodaysReturns";

            // Creates a query for todays returns
            string sTodaysQuerys = @"select * from CustomerInvoices WHERE DTReturnDate = @dtDate ORDER BY ReturnTime,KeyNumber ASC";
            CreateReturns(sTodaysQuerys);

            iInitialPanelLocationY += 50;

            // Creates the Title Header
            TitleHeaders(1);

            sList = "UnknownReturns";

            string sUnknownQuerys = "select * from CustomerInvoices WHERE (DTReturnDate < @dtDate AND PickUp = false) ORDER BY dtReturnDate,ReturnTime,KeyNumber ASC";
            CreateReturns(sUnknownQuerys);

            iInitialPanelLocationY += 10;

            Label lblBlank = new Label();
            lblBlank.Location = new Point(0, iInitialPanelLocationY);
            Controls.Add(lblBlank);
        }

        void RefreshCarBroughtIn()
        {
            // Set the initial location for the title
            iInitialPanelLocationY = pnl_template.Location.Y;

            // Creates the Title Header
            TitleHeaders(2);

            // Create todays date for the query
            DateTime now = dt_timepicked.Value;
            //now = now.AddDays(-1);
            dtDate = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);

            // Creates a query for todays returns
            string sTodaysQuerys = "select * from CustomerInvoices WHERE DTDateIn = @dtDate ORDER BY TimeIn ASC";
            CreateReturns(sTodaysQuerys);

            iInitialPanelLocationY += 10;

            Label lblBlank = new Label();
            lblBlank.Name = "lbl_blank";
            lblBlank.Location = new Point(0, iInitialPanelLocationY);
            Controls.Add(lblBlank);
        }

        void RefreshDatePaid()
        {
            // Set the initial location for the title
            iInitialPanelLocationY = pnl_template.Location.Y;

            // Creates the Title Header
            TitleHeaders(3);

            // Create todays date for the query
            DateTime now = dt_timepicked.Value;
            //now = now.AddDays(-1);
            dtDate = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);

            // Creates a query for todays returns
            string sTodaysQuerys = "select * from CustomerInvoices WHERE DTDatePaid = @dtDate ORDER BY TimePaid ASC";
            CreateReturns(sTodaysQuerys);

            iInitialPanelLocationY += 10;

            Label lblBlank = new Label();
            lblBlank.Name = "lbl_blank";
            lblBlank.Location = new Point(0, iInitialPanelLocationY);
            Controls.Add(lblBlank);
        }

        void RefreshBadDebots()
        {
            // Set the initial location for the title
            iInitialPanelLocationY = pnl_template.Location.Y;

            // Creates the Title Header
            TitleHeaders(3);

            sList = "BadDebtor";

            // Create todays date for the query
            DateTime now = dt_timepicked.Value;
            //now = now.AddDays(-1);
            dtDate = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);

            // Creates a query for todays returns
            string sTodaysQuerys = "select * from CustomerInvoices WHERE PickUp = true AND PaidStatus = 'To Pay' ORDER BY DTReturnDate ASC";
            CreateReturns(sTodaysQuerys);

            iInitialPanelLocationY += 10;

            Label lblBlank = new Label();
            lblBlank.Name = "lbl_blank";
            lblBlank.Location = new Point(0, iInitialPanelLocationY);
            Controls.Add(lblBlank);
        }

        void CreateReturns(string _sQuery)
        {
            // Opens and creates the connection for the database
            connection.Open();

            // Make new OleDbCommand object
            command = new OleDbCommand();

            // Create the connection
            command.Connection = connection;

            command.CommandText = _sQuery;
            command.Parameters.AddWithValue("@dtDate", dtDate);

            reader = command.ExecuteReader();

            // Moves the location down for the first panel
            iInitialPanelLocationY += 50;

            CreatePanels();

            connection.Close();
        }

        void TitleHeaders(int _iPickTitle)
        {
            DateTime now = dt_timepicked.Value;

            lblTitle = new Label();
            lblTitle.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);

            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.Size = new Size(1520, 40);
            lblTitle.BringToFront();

            string g_strDatePicked = now.DayOfWeek.ToString() + ", " +
            now.Day.ToString() + " " +
            now.ToString("MMMM") + " " +
            now.Year.ToString();

            if (_iPickTitle == 0)
            {
                lblTitle.BackColor = System.Drawing.Color.LightBlue;
                lblTitle.ForeColor = System.Drawing.Color.Black;

                lblTitle.Name = "lbl_returndate";

                g_strDatePicked += " - Return Date";

                lblTitle.Text = g_strDatePicked;
            }
            else if (_iPickTitle == 1)
            {

                lblTitle.BackColor = System.Drawing.Color.LightSalmon;
                lblTitle.ForeColor = System.Drawing.Color.Black;

                lblTitle.Name = "lbl_unknown";

                lblTitle.Text = "Unknown/Overdue";
            }
            else if (_iPickTitle == 2)
            {
                lblTitle.BackColor = System.Drawing.Color.LightBlue;
                lblTitle.ForeColor = System.Drawing.Color.Black;

                lblTitle.Name = "lbl_title";

                g_strDatePicked += " - Date Car Left In Yard";

                lblTitle.Text = g_strDatePicked;
            }
            else if (_iPickTitle == 3)
            {
                lblTitle.BackColor = System.Drawing.Color.LightBlue;
                lblTitle.ForeColor = System.Drawing.Color.Black;

                lblTitle.Name = "lbl_title";

                g_strDatePicked += " - Date Customer Paid";

                lblTitle.Text = g_strDatePicked;
            }

            Controls.Add(lblTitle);
        }

        void CreatePanels()
        {
            // Stores the time from the table
            string StoreTime = "";

            // Stores time at end to compare and see if a new time has shown
            string StoreTimeSecond = "";

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            iCars = 0;
            int iTotalCars = 0;

            while (reader.Read())
            {
                // Gets the current time of the record
                if (chk_datebroughtin.Checked || chk_datepaid.Checked)
                {
                    //StoreTime = reader["TimeIn"].ToString();
                }
                else
                {
                    StoreTime = reader["ReturnTime"].ToString();
                }

                // Compares the 2 times together to see if they are different or not
                // Skips the first check
                if (StoreTime != StoreTimeSecond && !bSkipFirstCheck)
                {
                    AmountOfCars(iCars);

                    iCars = 0;

                    iInitialPanelLocationY += 50;

                    if (sList == "TodaysReturns" && bFirstTimeDividier && iNoMoreThan1Divider < 1)
                    {
                        Panel pnl = new Panel();
                        pnl.Name = "pnlDivider";
                        lstReturnPanels.Add(pnl);

                        iNoMoreThan1Divider++;
                    }

                    if (sList == "UnknownReturns" & bFirstTimeDividier && iNoMoreThan1Divider < 1)
                    {
                        Panel pnl = new Panel();
                        pnl.Name = "pnlDivider";
                        lstUnknownPanels.Add(pnl);

                        iNoMoreThan1Divider++;
                    }

                    if (sList == "BadDebtor" & bFirstTimeDividier && iNoMoreThan1Divider < 1)
                    {
                        Panel pnl = new Panel();
                        pnl.Name = "pnlDivider";
                        lstBadDebot.Add(pnl);

                        iNoMoreThan1Divider++;
                    }
                }


                // Creates the labels for that record
                CreateIndividualPanel();

                // Makes the Second time = the first time for comparision purposes
                StoreTimeSecond = StoreTime;

                iCars++;
                iTotalCars++;

                // Makes the first check to false for using
                bSkipFirstCheck = false;
            }

            AmountOfCars(iCars);

            lblTitle.Text += "                                                                        Total Cars: " + iTotalCars;
        }

        void AmountOfCars(int _iCars)
        {
            Label lbls = new Label();
            lbls.Location = new Point(lbl_amountofcars.Location.X, iInitialPanelLocationY - 7);
            lbls.Font = lbl_amountofcars.Font;
            lbls.Size = lbl_amountofcars.Size;
            lbls.Name = "lbl_NumberOfCars";
            lbls.BackColor = lbl_amountofcars.BackColor;

            if (_iCars == 1)
            {
                lbls.Text = _iCars.ToString("0") + " Car";
            }
            else
            {
                lbls.Text = _iCars.ToString("0") + " Cars";
            }

            Controls.Add(lbls);
        }

        void CreateIndividualPanel()
        {
            pnl = new Panel();
            pnl.Name = reader["InvoiceNumber"].ToString();

            pnl.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);
            iInitialPanelLocationY += 50;

            pnl.Size = pnl_template.Size;
            pnl.BackColor = pnl_template.BackColor;
            pnl.BorderStyle = pnl_template.BorderStyle;

            // Checks to see if the car has been picked up or not already
            bPickedUp = (bool)reader["PickUp"];

            bIsLongTerm = (bool)reader["IsLongTerm"];
            
            // Handles the controls within the panel
            foreach (Control p in pnl_template.Controls)
            {
                // Handles all the button controls
                if (p.GetType() == typeof(Button))
                {
                    ControlButtons(p);
                }
                // Handles all the Label Controlls
                if (p.GetType() == typeof(Label))
                {
                    ControlLabels(p);
                }
            }

            ExtraLabelsForPrinting();

            if (sList == "TodaysReturns")
            {
                if (!bPickedUp)
                {
                    lstReturnPanels.Add(pnl);

                    bFirstTimeDividier = true;

                    iNoMoreThan1Divider = 0;
                }
            }
            else if (sList == "UnknownReturns")
            {
                lstUnknownPanels.Add(pnl);

                bFirstTimeDividier = true;

                iNoMoreThan1Divider = 0;
            }
            else if(sList == "BadDebtor")
            {
                lstBadDebot.Add(pnl);

                bFirstTimeDividier = true;

                iNoMoreThan1Divider = 0;
            }

            Controls.Add(pnl);
        }

        void ControlButtons(Control _p)
        {
            // Creates a new button
            Button btn = new Button();

            // Is it the Picked Up Button
            if (_p.Name == "btn_pickedup")
            {
                // The car has already been picked up
                if (bPickedUp)
                {
                    btn.Text = "Yes";
                    btn.BackColor = Color.Green;
                    pnl.BackColor = Color.LightGreen;
                }
                // The car has not been picked up
                else
                {
                    btn.Text = "No";
                    btn.BackColor = Color.Red;

                    btn.Click += new EventHandler(PickUpStatus_Click);
                }

                btn.Name = reader["InvoiceNumber"].ToString();
            }

            // Is it the Invoice No Button
            if (_p.Name == "btn_invno")
            {
                if(bIsLongTerm)
                {
                    btn.Text = reader["KeyNumber"].ToString();
                    btn.BackColor = Color.LightBlue;

                    //btn.Name = reader["InvoiceNumber"].ToString();

                    //btn.Click += new EventHandler(InvoiceButton_Click);
                }
                else
                {
                    btn.Text = reader["InvoiceNumber"].ToString();
                    btn.BackColor = _p.BackColor;

                    btn.Name = reader["InvoiceNumber"].ToString();

                    btn.Click += new EventHandler(InvoiceButton_Click);
                }
            }

            if(_p.Name == "btn_notesalerts")
            {
                btn.Visible = false;

                if((bool)reader["IsNotes"] && (bool)reader["IsAlerts"])
                {
                    btn.Visible = true;
                    btn.BackgroundImage = Properties.Resources.NA;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    string sInvoiceNumber = reader["InvoiceNumber"].ToString();
                    string sRego = reader["Rego"].ToString();

                    btn.Click += (sender, EventArgs) => { NoteAndAlertButton_Click(sender, EventArgs, sInvoiceNumber, sRego); };
                }
                else if((bool)reader["IsNotes"])
                {
                    btn.Visible = true;
                    btn.BackgroundImage = Properties.Resources.N;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    btn.Name = reader["InvoiceNumber"].ToString();

                    btn.Click += new EventHandler(NotesButton_Click);
                }
                else if((bool)reader["IsAlerts"])
                {
                    btn.Visible = true;
                    btn.BackgroundImage = Properties.Resources.A;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    btn.Name = reader["Rego"].ToString();

                    btn.Click += new EventHandler(AlertsButton_Click);
                }
            }


            btn.Location = _p.Location;
            btn.Size = _p.Size;
            pnl.Controls.Add(btn);
        }

        void ControlLabels(Control _p)
        {
            Label lbl = new Label();

            lbl.Name = _p.Name;

            if (_p.Name == "lbl_no")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = (iCars+1).ToString() + ".";
            }

            // Handles the customer name
            if (_p.Name == "lbl_customername")
            {
                string sStoreName = "";
                string sFirstName = reader["FirstName"].ToString();
                string sLastName = reader["LastName"].ToString();

                if (sFirstName == "")
                {
                    sStoreName = sLastName;
                }
                else if(sLastName == "")
                {
                    sStoreName = sFirstName;
                }
                else
                {
                    sStoreName = sFirstName + " " + sLastName;
                }
                
                if (sStoreName.Length > 16)
                {
                    lbl.Font = new Font(_p.Font.FontFamily, 8);
                    lbl.Size = new Size(_p.Size.Width, _p.Size.Height + 10);

                    if (sFirstName == "")
                    {
                        sStoreName = sLastName;
                    }
                    else if (sLastName == "")
                    {
                        sStoreName = sFirstName;
                    }
                    else
                    {
                        sStoreName = reader["FirstName"].ToString() + "\r\n" + reader["LastName"].ToString();
                    }

                    lbl.Text = sStoreName;
                }
                else
                {
                    lbl.Font = _p.Font;
                    lbl.Size = _p.Size;

                    lbl.Text = sStoreName;
                }

                if (bPickedUp)
                {
                    lbl.BackColor = Color.LightGreen;
                }
            }

            if (_p.Name == "lbl_rego")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["Rego"].ToString();
            }

            if (_p.Name == "lbl_keyno")
            {
                if(bIsLongTerm)
                {
                    lbl.Font = _p.Font;
                    lbl.Size = _p.Size;
                    lbl.BackColor = Color.LightBlue;

                    lbl.Text = reader["KeyNumber"].ToString();
                }
                else
                {
                    lbl.Font = _p.Font;
                    lbl.Size = _p.Size;
                    lbl.BackColor = _p.BackColor;

                    lbl.Text = reader["KeyNumber"].ToString();
                }
            }

            if (_p.Name == "lbl_amount")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;
                lbl.BackColor = _p.BackColor;

                float fTotalPay = 0.0f;
                float.TryParse(reader["TotalPay"].ToString(), out fTotalPay);

                string sPaidStatus = reader["PaidStatus"].ToString();

                if (fTotalPay == 0.0f && sPaidStatus != "N/C" && !bIsLongTerm)
                {
                    lbl.BackColor = Color.Red;
                    lbl.Text = "To Calc";
                }
                else if (fTotalPay == 0.0f && sPaidStatus == "N/C" || bIsLongTerm)
                {
                    lbl.BackColor = Color.Orange;
                    lbl.Text = "N/C";
                }
                else
                {
                    lbl.Text = "$" + fTotalPay.ToString("0.00");
                }

                // Makes the background colour of the label green to fit with the panel colour
                if (bPickedUp)
                {
                    lbl.BackColor = Color.LightGreen;
                }
            }

            if (_p.Name == "lbl_paidstatus")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                string sPaidStatus = reader["PaidStatus"].ToString();

                if (sPaidStatus == "To Pay")
                {
                    lbl.BackColor = Color.Yellow;
                }
                else if (sPaidStatus == "OnAcc" || sPaidStatus == "N/A")
                {
                    lbl.BackColor = Color.Violet;
                }
                else if (sPaidStatus == "N/C")
                {
                    lbl.BackColor = Color.Orange;
                }
                else if(sPaidStatus == "LT")
                {
                    lbl.BackColor = Color.LightYellow;
                }
                else
                {
                    lbl.BackColor = _p.BackColor;
                }

                 lbl.Text = reader["PaidStatus"].ToString();
            }

            if (_p.Name == "lbl_returntime")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                // Makes the background colour of the label green to fit with the panel colour
                if (bPickedUp)
                {
                    lbl.BackColor = Color.LightGreen;
                }

                lbl.Text = reader["ReturnTime"].ToString();

                if (chk_returndate.Checked)
                {
                    lbl.Text = reader["ReturnTime"].ToString();
                    lbl_returntimeheader.Text = "Return Time";
                }
                else if (chk_datebroughtin.Checked)
                {
                    lbl.Text = reader["TimeIn"].ToString();
                    lbl_returntimeheader.Text = "Time In";
                }
                else if (chk_datepaid.Checked)
                {
                    lbl.Text = reader["TimePaid"].ToString();
                    lbl_returntimeheader.Text = "Time Paid";
                }
            }

            if (_p.Name == "lbl_returndate")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                DateTime dt = new DateTime();

                if (chk_returndate.Checked)
                {
                    dt = (DateTime)reader["DTReturnDate"];
                    lbl_returndateheader.Text = "Return Date";
                }
                else if (chk_datebroughtin.Checked)
                {
                    dt = (DateTime)reader["DTDateIn"];
                    lbl_returndateheader.Text = "Date In";
                }
                else if (chk_datepaid.Checked)
                {
                    dt = (DateTime)reader["DTDatePaid"];
                    lbl_returndateheader.Text = "Date Paid";
                }

                bool bIsUnknown = (bool)reader["UnknownDate"];

                if (!bIsUnknown)
                {
                    string Date = dt.ToString("ddd").ToUpper() + ", " +
                    dt.Day.ToString() + "-" +
                    dt.ToString("MM") + "-" +
                    dt.ToString("yy");

                    lbl.Text = Date;
                }
                else
                {
                    lbl.Text = "Unknown";
                }

                if ((bool)reader["DrivingBack"])
                {
                    lbl.Text = "Driving Back/Bus";
                    lbl.BackColor = Color.Red;

                    lbl.Size = new Size(_p.Size.Width-20, _p.Size.Height);
                }
            }

            if (_p.Name == "lbl_ph")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                if (bPickedUp)
                {
                    lbl.BackColor = Color.LightGreen;
                }

                lbl.Text = reader["PhoneNumber"].ToString();
            }

            if (_p.Name == "lbl_make")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["MakeModel"].ToString();

                // Makes the background colour of the label green to fit with the panel colour
                if (bPickedUp)
                {
                    lbl.BackColor = Color.LightGreen;
                }
            }

            if (_p.Name == "lbl_location")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["CarLocation"].ToString();

                if (reader["CarLocation"].ToString() == "Front")
                {
                    lbl.BackColor = Color.GreenYellow;
                }
                else
                {
                    lbl.BackColor = Color.Red;
                }
            }

            if(_p.Name == "lbl_staffmember")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                string sStaffMember = reader["StaffMember"].ToString();

                lbl.Text = reader["StaffMember"].ToString();

                if (sStaffMember == "")
                {
                    lbl.Text = "Unknown";
                } 
            }

            lbl.Location = _p.Location;

            pnl.Controls.Add(lbl);
        }

        void ExtraLabelsForPrinting()
        {
            Label lblNotesAndAlerts = new Label();
            lblNotesAndAlerts.Name = "lbl_NotesAndAlerts";
            if ((bool)reader["IsNotes"] && (bool)reader["IsAlerts"])
            {
                lblNotesAndAlerts.Text = "N/A";
            }
            else if ((bool)reader["IsNotes"])
            {
                lblNotesAndAlerts.Text = "N";

            }
            else if ((bool)reader["IsAlerts"])
            {
                lblNotesAndAlerts.Text = "A";
            }
            lblNotesAndAlerts.Location = new Point(-100, -100);
            pnl.Controls.Add(lblNotesAndAlerts);

            Label lblInvNo = new Label();
            lblInvNo.Name = "lbl_InvNo";
            lblInvNo.Text = reader["InvoiceNumber"].ToString();
            lblInvNo.Location = new Point(-100, -100);
            pnl.Controls.Add(lblInvNo);

            Label lblDateIn = new Label();
            lblDateIn.Name = "lbl_DateIn";
            lblDateIn.Location = new Point(-100, -100);

            Label lblReturnDate = new Label();
            lblReturnDate.Name = "lbl_ReturnDate";
            lblReturnDate.Location = new Point(-100, -100);

            DateTime dtDateIn = (DateTime)reader["DTDateIn"];
            DateTime dtReturnTime = (DateTime)reader["DTReturnDate"];

            string sTimeIn = reader["TimeIn"].ToString();
            string sReturnTime = reader["ReturnTime"].ToString();

            lblDateIn.Text = dtDateIn.Day + "/" + dtDateIn.Month + "/" + dtDateIn.ToString("yy") + " - " + sTimeIn;

            string sReturnDate = lblReturnDate.Text = dtReturnTime.Day + "/" + dtReturnTime.Month + "/" + dtReturnTime.ToString("yy");

            if(sReturnDate == "1/1/01")
            {
                lblReturnDate.Text = "Unknown";
            }
            else
            {
                lblReturnDate.Text = sReturnDate + " - " + sReturnTime;
            }
            
            pnl.Controls.Add(lblDateIn);
            pnl.Controls.Add(lblReturnDate);
        }

        #endregion

        #region ButtonClicks

        int m_iInvoiceNumber = 0;

        #region PickUp
        private void PickUpStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            m_iInvoiceNumber = 0;
            Int32.TryParse(btn.Name, out m_iInvoiceNumber);

            if (btn.Text == "No")
            {
                SetPickUp();
            }
        }

        public void MinimiseForm()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void SetPickUp()
        {
            string sTabsStillOpen = "";
            sTabsStillOpen = "Has the car being picked up,\r\nand do you wish to release the keybox number?";

            WarningSystem ws = new WarningSystem(sTabsStillOpen, true);
            ws.ShowDialog();

            if (ws.DialogResult == DialogResult.OK)
            {
                connection.Open();

                command = new OleDbCommand();

                command.Connection = connection;

                command.CommandText = @"UPDATE CustomerInvoices
                                        SET [PickUp] = True
                                        WHERE [InvoiceNumber] = " + m_iInvoiceNumber + "";

                command.ExecuteNonQuery();

                connection.Close();

                Form fm = Application.OpenForms["MainMenu"];
                MainMenu mm = (MainMenu)fm;
                mm.UpdateAmountOfCars();

                ReloadPageFromInvoice();
            }
        }

        public void ReloadPageFromInvoice()
        {
            // Stores the original position of the scroll bar to restore after refreshing
            int iOriPosOfScrollBar = VerticalScroll.Value;

            if (chk_returndate.Checked)
            {
                DeleteControls();

                RefreshReturnDate();
            }
            else if (chk_datebroughtin.Checked)
            {
                DeleteControls();

                RefreshCarBroughtIn();
            }
            else if (chk_datepaid.Checked)
            {
                DeleteControls();

                RefreshDatePaid();
            }

            // Restores the original location of the vertical scroll bar
            VerticalScroll.Value = iOriPosOfScrollBar;
        }

        #endregion

        #region AlertAndNotesButton

        private void AlertsButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            ShowNotesAlerts sna = new ShowNotesAlerts();
            sna.LoadAlerts(btn.Name);
            sna.ShowDialog();
        }

        private void NotesButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            ShowNotesAlerts sna = new ShowNotesAlerts();
            sna.LoadNotes(btn.Name);
            sna.ShowDialog();
        }

        private void NoteAndAlertButton_Click(object sender, EventArgs e, string _iInvoiceNumber, string _sRego)
        {
            Button btn = (Button)sender;

            ShowNotesAlerts sna = new ShowNotesAlerts();
            sna.LoadAlerts(_sRego);
            sna.LoadNotes(_iInvoiceNumber);
            sna.ShowDialog();
        }

        #endregion

        #region InvoiceButton
        private void InvoiceButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            Invoice inv = new Invoice(true);

            inv.SetUpFromCarReturns(x, this);

            inv.Show();
        }
        #endregion

        #endregion

        #region ButtonsOthers

        private void btn_left_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dt_timepicked.Value;

            dtStore = dtStore.AddDays(-1);

            dt_timepicked.Value = dtStore;
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dt_timepicked.Value;

            dtStore = dtStore.AddDays(1);

            dt_timepicked.Value = dtStore;
        }

        public void LoadBadDebots()
        {
            DeleteControls();

            RefreshBadDebots();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift) && ModifierKeys.HasFlag(Keys.Control) && ModifierKeys.HasFlag(Keys.Alt))
            {
                WarningSystem ws = new WarningSystem("Would you like to sort the return list by bad debtors?", true);
                ws.ShowDialog();

                if (ws.DialogResult == DialogResult.OK)
                {
                    DeleteControls();

                    RefreshBadDebots();
                }
            }
            else
            {
                if (chk_returndate.Checked)
                {
                    DeleteControls();

                    RefreshReturnDate();
                }
                else if (chk_datebroughtin.Checked)
                {
                    DeleteControls();

                    RefreshCarBroughtIn();
                }
                else if (chk_datepaid.Checked)
                {
                    DeleteControls();

                    RefreshDatePaid();
                }
            }
        }

        #endregion

        #region CheckBoxes

        private void chk_returndate_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_returndate.Checked == true)
            {
                chk_datebroughtin.Checked = false;
                chk_datepaid.Checked = false;

                DeleteControls();

                RefreshReturnDate();
            }
        }

        private void chk_datebroughtin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_datebroughtin.Checked == true)
            {
                chk_returndate.Checked = false;
                chk_datepaid.Checked = false;

                DeleteControls();

                RefreshCarBroughtIn();
            }
        }

        private void chk_datepaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_datepaid.Checked == true)
            {
                chk_returndate.Checked = false;
                chk_datebroughtin.Checked = false;

                DeleteControls();

                RefreshDatePaid();
            }
        }

        #endregion

        void DeleteControls()
        {
            foreach (Panel pnl in this.Controls.OfType<Panel>().ToArray())
            {
                if (pnl.Name == "pnl_template")
                {
                    // Do Nothing
                }
                else
                {
                    Controls.Remove(pnl);
                }
            }

            foreach (Label lbl in this.Controls.OfType<Label>().ToArray())
            {
                if (lbl.Text == "Unknown/Overdue" || lbl.Name == "lbl_blank" || lbl.Name == "lbl_returndate"
                    || lbl.Name == "lbl_unknown" || lbl.Name == "lbl_title" || lbl.Name == "lbl_NumberOfCars")
                {
                    Controls.Remove(lbl);
                }
            }
        }

        private void dt_timepicked_ValueChanged(object sender, EventArgs e)
        {
            if (chk_returndate.Checked)
            {
                DeleteControls();

                RefreshReturnDate();
            }
            else if (chk_datebroughtin.Checked)
            {
                DeleteControls();

                RefreshCarBroughtIn();
            }
            else if (chk_datepaid.Checked)
            {
                DeleteControls();

                RefreshDatePaid();
            }
        }

        #region ButtonShortcuts

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

        private void btn_invoice_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["InvoiceManager"];

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
                InvoiceManager ip = new InvoiceManager();
                ip.Show();
            }
        }

        #endregion

        /*
            while (reader.Read())
            {
                // Gets the current time of the record
                StoreTime = reader["ReturnTime"].ToString();

                // Compares the 2 times together to see if they are different or not
                // Skips the first check
                if (StoreTime != StoreTimeSecond && !bSkipFirstCheck)
                {
                    iInitialPanelLocationY += 50;
                }

                // Creates the labels for that record
                CreateIndividualPanel();

                // Makes the Second time = the first time for comparision purposes
                StoreTimeSecond = StoreTime;

                // Makes the first check to false for using
                bSkipFirstCheck = false;
            }
        */

        #region Printing

        #region GlobalVariablesPrinting

        int iLocationY = 50;
        int iItemsPerPage = 0;

        int iListCount = 0;

        int iPageNumber = 1;

        Brush blackBrush = new SolidBrush(Color.Black);

        Brush _bPrintBrush = new SolidBrush(Color.White);

        #endregion

        #region PrintNotes

        public void PrintNotes(int _iPrinterPicked)
        {
            lstInvoiceNotes = new List<string>();
            lstGeneralNotes = new List<string>();
            lstHighPriorityNotes = new List<string>();
            lstAlertNotes = new List<string>();

            m_iPrinterPicked = _iPrinterPicked;

            bOnlyOnce = false;

            iLocationY = 50;
            iItemsPerPage = 0;

            iListCount = 0;
            iListNotes = 0;
            iListAlerts = 0;
            iListGeneral = 0;

            iPageNumber = 1;

            pnl_printtitles.Visible = true;

            PrintDocument PrintDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            PrintDocument.DefaultPageSettings.PaperSize = ps;

            //PrintDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            if (m_iPrinterPicked == 0)
            {
                PrintDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";
            }
            else if (m_iPrinterPicked == 1)
            {
                PrintDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            }
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            //printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            //PrintDocument.PrinterSettings.PrinterName = "Adobe PDF";
            PrintDocument.OriginAtMargins = false;
            PrintDocument.DefaultPageSettings.Landscape = true;
            PrintDocument.PrintPage += new PrintPageEventHandler(doc_PrintNotesPage);

            PrintDocument.Print();

            pnl_printtitles.Visible = false;
        }

        bool bOnlyOnce = false;
        int iListNotes = 0;
        int iListAlerts = 0;
        int iListGeneral = 0;

        int iMaxItems = 5;

        private void doc_PrintNotesPage(object sender, PrintPageEventArgs e)
        {
            #region TodaysDate
            // Creates Todays Date
            DateTime dtTodaysDate = DateTime.Now;
            string g_strDatePicked = dtTodaysDate.Day.ToString() + "/" + dtTodaysDate.Month.ToString() + "/" + dtTodaysDate.Year.ToString();

            g_strDatePicked = "Notes (" + g_strDatePicked + ") - Page " + iPageNumber.ToString();

            e.Graphics.FillRectangle(Brushes.LightGreen, 5, 7, 1100, 40);
            e.Graphics.DrawString(g_strDatePicked, new Font("Courier New", 26, FontStyle.Bold), new SolidBrush(Color.Black), 350, 7);
            #endregion

            iPageNumber++;

            //NewPrintHeader(e);

            if(!bOnlyOnce)
            {
                FindInvoiceNumbersNotesAlerts();

                LoadInvoiceNotes(e);

                LoadInvoiceAlerts(e);

                LoadGeneralNotes(e);

                LoadHighPriorityNotes(e);

                bOnlyOnce = true;
            }

            while (iListGeneral < lstGeneralNotes.Count)
            {
                DrawNotesStrings(e, lstGeneralNotes[iListGeneral], false);

                iListGeneral++;

                if (iItemsPerPage < iMaxItems)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    iItemsPerPage = 0;
                    e.HasMorePages = true;

                    iLocationY = 50;

                    return;
                }
            }

            while (iListNotes < lstInvoiceNotes.Count)
            {
                DrawNotesStrings(e, lstInvoiceNotes[iListNotes], false);

                iListNotes++;

                if (iItemsPerPage < iMaxItems)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    iItemsPerPage = 0;
                    e.HasMorePages = true;

                    iLocationY = 50;

                    return;
                }
            }

            while (iListAlerts < lstAlertNotes.Count)
            {
                DrawNotesStrings(e, lstAlertNotes[iListAlerts], false);

                iListAlerts++;

                if (iItemsPerPage < iMaxItems)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    if(iListAlerts != lstAlertNotes.Count)
                    {
                        iItemsPerPage = 0;
                        e.HasMorePages = true;

                        iLocationY = 50;

                        return;
                    }
                }
            }
        }

        List<string> lstInvoice;
        List<string> lstRego;

        List<string> lstInvoiceNotes;
        List<string> lstAlertNotes;
        List<string> lstGeneralNotes;
        List<string> lstHighPriorityNotes;

        void FindInvoiceNumbersNotesAlerts()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            lstInvoice = new List<string>();
            lstRego = new List<string>();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            string query = @"select * from CustomerInvoices WHERE DTReturnDate = @dt AND (IsNotes = True OR IsAlerts = True)";
            query += " OR (DTReturnDate < @dt AND PickUp = False) AND (IsNotes = True OR IsAlerts = True)";

            command.Parameters.AddWithValue("@dt", dt);
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lstInvoice.Add(reader["InvoiceNumber"].ToString());
                lstRego.Add(reader["Rego"].ToString());
            }

            //int iStop = 0;

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadInvoiceNotes(PrintPageEventArgs _e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string sInvoiceNumber = "";

            for (int i = 0; i < lstInvoice.Count; i++)
            {
                sInvoiceNumber += lstInvoice[i] + ",";
            }

            string query = "select * from InvoiceNotes WHERE InvoiceNumber IN (" + sInvoiceNumber + ") ORDER BY DateAndTime DESC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                string sNote = "";

                sNote = reader["Rego"].ToString() +
                    " (" + reader["InvoiceNumber"].ToString() + "): " + reader["Notes"].ToString();

                lstInvoiceNotes.Add(sNote);

                //DrawNotesStrings(_e, sNote);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadInvoiceAlerts(PrintPageEventArgs _e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            //int iNumber = 0;
            //int.TryParse(lstInvoice[0], out iNumber);

            string sRego = "";

            for (int i = 0; i < lstRego.Count; i++)
            {
                sRego += "'" + lstRego[i] + "',";
            }

            string query = "select * from Alerts WHERE Rego IN (" + sRego + ")";

            //string query = "select * from InvoiceNotes WHERE InvoiceNumber IN (7196, 6937, 6916)";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string sAlert = "";

                sAlert = reader["Alert"].ToString();

                lstAlertNotes.Add(sAlert);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadGeneralNotes(PrintPageEventArgs _e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from Notes WHERE IsClosed = False";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string sGeneralNote = "";

                sGeneralNote = reader["Notes"].ToString();

                lstGeneralNotes.Add(sGeneralNote);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadHighPriorityNotes(PrintPageEventArgs _e)
        {

        }

        void DrawNotesStrings(PrintPageEventArgs _e, string _sNote, bool _bRed)
        {
            //PrintHorizontalLine(_e, 0);

            PointF pf = new PointF(0.0f, iLocationY);// new PointF(_Label.Bounds.Location.X, _pReturns.Bounds.Location.Y + iLocationY);
            Font f = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            Color color = Color.Red;

            if (!_bRed)
            {
                color = Color.FromArgb(224, 253, 255);
            }

            SizeF sf = _e.Graphics.MeasureString(_sNote, f, 800);

            _e.Graphics.FillRectangle(new SolidBrush(color), new RectangleF(new PointF(0.0f, iLocationY), sf));
            _e.Graphics.DrawString(_sNote, f, Brushes.Black, new RectangleF(new PointF(0.0f, iLocationY), sf), StringFormat.GenericTypographic);

            iLocationY += 50 + (int)sf.Height;

            //PrintHorizontalLine(_e, 40);
        }

        #endregion PrintNotes

        #region PrintReturns

        int m_iPrinterPicked = 0;

        public void PrintReturns(int _iPrinterPicked)
        {
            m_iPrinterPicked = _iPrinterPicked;

            //PrintNotes(_iPrinterPicked);
            
            iLocationY = 50;
            iItemsPerPage = 0;

            iListCount = 0;

            iPageNumber = 1;

            pnl_printtitles.Visible = true;

            PrintDocument PrintDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            PrintDocument.DefaultPageSettings.PaperSize = ps;

            //PrintDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            if(m_iPrinterPicked == 0)
            {
                PrintDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";
            }
            else if(m_iPrinterPicked == 1)
            {
                PrintDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            }
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            //printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            PrintDocument.OriginAtMargins = false;
            PrintDocument.DefaultPageSettings.Landscape = true;
            PrintDocument.PrintPage += new PrintPageEventHandler(doc_PrintReturnsPage);

            PrintDocument.Print();

            pnl_printtitles.Visible = false;

            PrintUnknowns();
            
            
        }

        private void doc_PrintReturnsPage(object sender, PrintPageEventArgs e)
        {
            #region TodaysDate
            // Creates Todays Date
            DateTime dtTodaysDate = DateTime.Now;
            string g_strDatePicked = "";

            g_strDatePicked = dtTodaysDate.DayOfWeek.ToString() + ", " +
            dtTodaysDate.Day.ToString() + " " +
            dtTodaysDate.ToString("MMMM") + " " +
            dtTodaysDate.Year.ToString();

            g_strDatePicked += " - Page " + iPageNumber.ToString();

            e.Graphics.FillRectangle(Brushes.LightBlue, 5, 7, 1150, 40);
            e.Graphics.DrawString(g_strDatePicked, new Font("Courier New", 26, FontStyle.Bold), new SolidBrush(Color.Black), 350, 7);
            #endregion

            iPageNumber++;

            NewPrintHeader(e);

            PrintLines(e);

            while (iListCount < lstReturnPanels.Count)
            {
                PrintingPanels(e, iListCount);

                iListCount++;

                if (iItemsPerPage < 16)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    iItemsPerPage = 0;
                    e.HasMorePages = true;

                    iLocationY = 50;

                    return;
                }
            }

            e.Graphics.FillRectangle(Brushes.White, 0, iLocationY + 2, 4000, 4000);
        }

        void NewPrintHeader(PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(pnl_printtitles.Width, pnl_printtitles.Height, pnl_printtitles.CreateGraphics());
            pnl_printtitles.DrawToBitmap(bmp, new Rectangle(0, 0, pnl_printtitles.Width, pnl_printtitles.Height));

            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);

            float fSize = 1.4f;

            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top + iLocationY, bounds.Width * fSize, factor * (bounds.Width * fSize));

            iLocationY += 40;
        }

        int iCountTotal = 0;

        void PrintingPanels(PrintPageEventArgs e, int _iReturnPanel)
        {
            if (lstReturnPanels[_iReturnPanel].Name == "pnlDivider")
            {
                e.Graphics.FillRectangle(Brushes.White, 0, iLocationY + 2, 1200, 40);

                iLocationY += 40;

                iCountTotal = 0;
            }
            else
            {
                foreach (Control pReturns in lstReturnPanels[_iReturnPanel].Controls)
                {
                    _bPrintBrush = new SolidBrush(Color.White);

                    switch (pReturns.Name)
                    {
                        //case "lbl_no":
                        //    DrawString(e, pReturns, lbl_printname, false, false, pReturns.Text);
                        //    break;
                        case "lbl_customername":
                            DrawString(e, pReturns, lbl_printname, true, false, (iCountTotal+1).ToString() + ". " + pReturns.Text);
                            break;
                        case "lbl_rego":
                            DrawString(e, pReturns, lbl_printrego, false, false, pReturns.Text);
                            break;
                        case "lbl_make":
                            DrawString(e, pReturns, lbl_printmake, true, false, pReturns.Text);
                            break;
                        case "lbl_location":
                            bool _bPrintColourLocation = false;
                            if (pReturns.Text == "Back")
                            {
                                _bPrintBrush = new SolidBrush(Color.Red);
                                _bPrintColourLocation = true;
                            }
                            DrawString(e, pReturns, lbl_printlocation, false, _bPrintColourLocation, pReturns.Text);
                            break;
                        case "lbl_InvNo":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printinvno, false, false, pReturns.Text);
                            break;
                        case "lbl_keyno":
                            bool _bPrintColourKeyNo = false;

                            int iNumber = 0;
                            bool bIsNumber = int.TryParse(pReturns.Text, out iNumber);

                            if(!bIsNumber)
                            {
                                _bPrintBrush = new SolidBrush(Color.LightPink);
                                _bPrintColourKeyNo = true;
                            }
                            else
                            {
                                _bPrintBrush = new SolidBrush(Color.Yellow);
                                _bPrintColourKeyNo = true;
                            }

                            DrawString(e, pReturns, lbl_printkeyno, false, _bPrintColourKeyNo, pReturns.Text);
                            break;
                        case "lbl_amount":
                            DrawString(e, pReturns, lbl_printamount, false, false, pReturns.Text);
                            break;
                        case "lbl_paidstatus":
                            bool _bPrintColourPaidStatus = false;
                            if(pReturns.Text == "To Pay")
                            {
                                _bPrintBrush = new SolidBrush(Color.Yellow);
                                _bPrintColourPaidStatus = true;
                            }
                            else if(pReturns.Text == "OnAcc")
                            {
                                _bPrintBrush = new SolidBrush(Color.Violet);
                                _bPrintColourPaidStatus = true;
                            }
                            else if(pReturns.Text == "N/C")
                            {
                                _bPrintBrush = new SolidBrush(Color.Orange);
                                _bPrintColourPaidStatus = true;
                            }
                            DrawString(e, pReturns, lbl_printpaid, true, _bPrintColourPaidStatus, pReturns.Text);
                            break;
                        case "lbl_ph":
                            DrawString(e, pReturns, lbl_printphone, false, false, pReturns.Text);
                            break;
                        case "lbl_DateIn":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printdatein, false, false, pReturns.Text);
                            break;
                        case "lbl_ReturnDate":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printreturndate, false, false, pReturns.Text);
                            break;
                        case "lbl_staffmember":
                            DrawString(e, pReturns, lbl_staff, false, false, pReturns.Text);
                            break;
                        case "lbl_NotesAndAlerts":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            bool _bPrintColourNA = false;
                            if (pReturns.Text == "N")
                            {
                                _bPrintBrush = new SolidBrush(Color.LightBlue);
                                _bPrintColourNA = true;
                            }
                            else if(pReturns.Text == "A")
                            {
                                _bPrintBrush = new SolidBrush(Color.Red);
                                _bPrintColourNA = true;
                            }
                            else if(pReturns.Text == "N/A")
                            {
                                _bPrintBrush = new SolidBrush(Color.MediumPurple);
                                _bPrintColourNA = true;
                            }
                            DrawString(e, pReturns, lbl_notesalerts, false, _bPrintColourNA, pReturns.Text);
                            break;

                        default:
                            break;
                    }
                }

                iLocationY += 40;
                iCountTotal++;
            }
        }

        void DrawString(PrintPageEventArgs _e, Control _pReturns, Label _Label, bool _bCheckFontSize, bool _bPrintColour, string _sText)
        {
            if(_bPrintColour && m_iPrinterPicked == 0)
            {
                //Brush _bPrintBrush = new SolidBrush(Color.Yellow);
                _e.Graphics.FillRectangle(_bPrintBrush, _Label.Bounds.Location.X, iLocationY + 2, _Label.Bounds.Width - 2, 40);
            }

            PrintHorizontalLine(_e, 0);

            PointF pf = new PointF(_Label.Bounds.Location.X, _pReturns.Bounds.Location.Y + iLocationY);
            Font f = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            if (_bCheckFontSize)
            {
                if (_pReturns.Text.Length > 6)
                {
                    f = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                }
            }
            //blackBrush = new SolidBrush(Color.White);
            _e.Graphics.DrawString(_sText, f, blackBrush, pf);

            PrintHorizontalLine(_e, 40);
        }

        void PrintLineLocations(int _iX1, int _iY1, int _iX2, int _iY2, PrintPageEventArgs _e)
        {
            Pen blackPen = new Pen(Color.Black);
            blackPen.Width = 1.5f;

            PointF line = new PointF(_iX1, _iY1);
            PointF line2 = new PointF(_iX2, _iY2);

            _e.Graphics.DrawLine(blackPen, line, line2);
        }

        void PrintLines(PrintPageEventArgs _e)
        {
            PrintLineLocations(10, 90, 10, 1600, _e);
            PrintLineLocations(150, 90, 150, 1600, _e);

            PrintLineLocations(230, 90, 230, 1600, _e);
            PrintLineLocations(320, 90, 320, 1600, _e);

            PrintLineLocations(375, 90, 375, 1600, _e);
            PrintLineLocations(425, 90, 425, 1600, _e);

            PrintLineLocations(455, 90, 455, 1600, _e);
            PrintLineLocations(528, 90, 528, 1600, _e);

            PrintLineLocations(600, 90, 600, 1600, _e);
            PrintLineLocations(725, 90, 725, 1600, _e);

            PrintLineLocations(850, 90, 850, 1600, _e);
            PrintLineLocations(960, 90, 960, 1600, _e);

            PrintLineLocations(1025, 90, 1025, 1600, _e);
            PrintLineLocations(1120, 90, 1120, 1600, _e);
        }

        void PrintHorizontalLine(PrintPageEventArgs _e, float _iMove)
        {
            Pen blackPen = new Pen(Color.Black);
            blackPen.Width = 1.5f;

            PointF line = new PointF(10, iLocationY + _iMove);
            PointF line2 = new PointF(1120, iLocationY + _iMove);

            _e.Graphics.DrawLine(blackPen, line, line2);
        }

        #endregion

        #region PrintUnknowns

        void PrintUnknowns()
        {
            iLocationY = 50;
            iItemsPerPage = 0;

            iListCount = 0;

            iPageNumber = 1;

            pnl_printtitles.Visible = true;

            PrintDocument PrintDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            //PrintDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            if (m_iPrinterPicked == 0)
            {
                PrintDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";
            }
            else if (m_iPrinterPicked == 1)
            {
                PrintDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            }
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";

            PrintDocument.DefaultPageSettings.PaperSize = ps;

            PrintDocument.OriginAtMargins = false;
            PrintDocument.DefaultPageSettings.Landscape = true;
            PrintDocument.PrintPage += new PrintPageEventHandler(doc_PrintUnknownsPage);

            PrintDocument.Print();

            pnl_printtitles.Visible = false;
        }

        private void doc_PrintUnknownsPage(object sender, PrintPageEventArgs e)
        {
            string g_strDatePicked = "Unknown/Overdue - Page " + iPageNumber.ToString();

            e.Graphics.FillRectangle(Brushes.Orange, 5, 7, 1150, 40);
            e.Graphics.DrawString(g_strDatePicked, new Font("Courier New", 26, FontStyle.Bold), new SolidBrush(Color.Black), 500, 7);

            iPageNumber++;

            NewPrintHeader(e);

            PrintLines(e);

            while (iListCount < lstUnknownPanels.Count)
            {
                PrintingUnknownPanels(e, iListCount);

                iListCount++;

                if (iItemsPerPage < 16)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    iItemsPerPage = 0;
                    e.HasMorePages = true;

                    iLocationY = 50;

                    return;
                }
            }

            e.Graphics.FillRectangle(Brushes.White, 0, iLocationY + 2, 4000, 4000);
        }

        void PrintingUnknownPanels(PrintPageEventArgs e, int _iReturnPanel)
        {
            if (lstUnknownPanels[_iReturnPanel].Name == "pnlDivider")
            {
                e.Graphics.FillRectangle(Brushes.White, 0, iLocationY + 2, 1200, 40);

                iLocationY += 40;
            }
            else
            {
                foreach (Control pReturns in lstUnknownPanels[_iReturnPanel].Controls)
                {
                    switch (pReturns.Name)
                    {
                        case "lbl_customername":
                            DrawString(e, pReturns, lbl_printname, true, false, pReturns.Text);
                            break;
                        case "lbl_rego":
                            DrawString(e, pReturns, lbl_printrego, false, false, pReturns.Text);
                            break;
                        case "lbl_make":
                            DrawString(e, pReturns, lbl_printmake, true, false, pReturns.Text);
                            break;
                        case "lbl_location":
                            bool _bPrintColourLocation = false;
                            if (pReturns.Text == "Back")
                            {
                                _bPrintBrush = new SolidBrush(Color.Red);
                                _bPrintColourLocation = true;
                            }
                            DrawString(e, pReturns, lbl_printlocation, false, _bPrintColourLocation, pReturns.Text);
                            break;
                        case "lbl_InvNo":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printinvno, false, false, pReturns.Text);
                            break;
                        case "lbl_keyno":
                            bool _bPrintColourKeyNo = false;

                            _bPrintBrush = new SolidBrush(Color.Yellow);
                            _bPrintColourKeyNo = true;

                            DrawString(e, pReturns, lbl_printkeyno, false, _bPrintColourKeyNo, pReturns.Text);
                            break;
                        case "lbl_amount":
                            DrawString(e, pReturns, lbl_printamount, false, false, pReturns.Text);
                            break;
                        case "lbl_paidstatus":
                            bool _bPrintColourPaidStatus = false;
                            if (pReturns.Text == "To Pay")
                            {
                                _bPrintBrush = new SolidBrush(Color.Yellow);
                                _bPrintColourPaidStatus = true;
                            }
                            else if (pReturns.Text == "OnAcc")
                            {
                                _bPrintBrush = new SolidBrush(Color.Violet);
                                _bPrintColourPaidStatus = true;
                            }
                            else if (pReturns.Text == "N/C")
                            {
                                _bPrintBrush = new SolidBrush(Color.Orange);
                                _bPrintColourPaidStatus = true;
                            }
                            DrawString(e, pReturns, lbl_printpaid, true, _bPrintColourPaidStatus, pReturns.Text);
                            break;
                        case "lbl_ph":
                            DrawString(e, pReturns, lbl_printphone, false, false, pReturns.Text);
                            break;
                        case "lbl_DateIn":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printdatein, false, false, pReturns.Text);
                            break;
                        case "lbl_ReturnDate":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printreturndate, false, false, pReturns.Text);
                            break;
                        case "lbl_staffmember":
                            DrawString(e, pReturns, lbl_staff, false, false, pReturns.Text);
                            break;
                        case "lbl_NotesAndAlerts":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            bool _bPrintColourNA = false;
                            if (pReturns.Text == "N")
                            {
                                _bPrintBrush = new SolidBrush(Color.LightBlue);
                                _bPrintColourNA = true;
                            }
                            else if (pReturns.Text == "A")
                            {
                                _bPrintBrush = new SolidBrush(Color.Red);
                                _bPrintColourNA = true;
                            }
                            else if (pReturns.Text == "N/A")
                            {
                                _bPrintBrush = new SolidBrush(Color.MediumPurple);
                                _bPrintColourNA = true;
                            }
                            DrawString(e, pReturns, lbl_notesalerts, false, _bPrintColourNA, pReturns.Text);
                            break;

                        default:
                            break;
                    }
                }

                iLocationY += 40;
            }
        }

        #endregion PrintUnknowns

        #region BadDebotors

        public void PrintBadDebt()
        {
            RefreshBadDebots();

            iLocationY = 50;
            iItemsPerPage = 0;

            iListCount = 0;

            iPageNumber = 1;

            pnl_printtitles.Visible = true;

            PrintDocument PrintDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            //PrintDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            if (m_iPrinterPicked == 0)
            {
                PrintDocument.PrinterSettings.PrinterName = "Brother MFC-665CW USB Printer";
            }
            else if (m_iPrinterPicked == 1)
            {
                PrintDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            }
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";

            PrintDocument.DefaultPageSettings.PaperSize = ps;

            PrintDocument.OriginAtMargins = false;
            PrintDocument.DefaultPageSettings.Landscape = true;
            PrintDocument.PrintPage += new PrintPageEventHandler(doc_PrintBadDebtPage);

            PrintDocument.Print();

            pnl_printtitles.Visible = false;
        }

        private void doc_PrintBadDebtPage(object sender, PrintPageEventArgs e)
        {
            string g_strDatePicked = "Bad Debtors - Page " + iPageNumber.ToString();

            e.Graphics.FillRectangle(Brushes.LightBlue, 5, 7, 1150, 30);
            e.Graphics.DrawString(g_strDatePicked, new Font("Courier New", 20), new SolidBrush(Color.Black), 500, 7);

            iPageNumber++;

            NewPrintHeader(e);

            PrintLines(e);

            while (iListCount < lstBadDebot.Count)
            {
                PrintingBadDebtPanels(e, iListCount);

                iListCount++;

                if (iItemsPerPage < 16)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    iItemsPerPage = 0;
                    e.HasMorePages = true;

                    iLocationY = 50;

                    return;
                }
            }

            e.Graphics.FillRectangle(Brushes.White, 0, iLocationY + 2, 4000, 4000);
        }

        void PrintingBadDebtPanels(PrintPageEventArgs e, int _iReturnPanel)
        {
            if (lstBadDebot[_iReturnPanel].Name == "pnlDivider")
            {
                e.Graphics.FillRectangle(Brushes.White, 0, iLocationY + 2, 1200, 40);

                iLocationY += 40;
            }
            else
            {
                foreach (Control pReturns in lstBadDebot[_iReturnPanel].Controls)
                {
                    switch (pReturns.Name)
                    {
                        case "lbl_customername":
                            DrawString(e, pReturns, lbl_printname, true, false, pReturns.Text);
                            break;
                        case "lbl_rego":
                            DrawString(e, pReturns, lbl_printrego, false, false, pReturns.Text);
                            break;
                        case "lbl_make":
                            DrawString(e, pReturns, lbl_printmake, true, false, pReturns.Text);
                            break;
                        case "lbl_location":
                            bool _bPrintColourLocation = false;
                            if (pReturns.Text == "Back")
                            {
                                _bPrintBrush = new SolidBrush(Color.Red);
                                _bPrintColourLocation = true;
                            }
                            DrawString(e, pReturns, lbl_printlocation, false, _bPrintColourLocation, pReturns.Text);
                            break;
                        case "lbl_InvNo":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printinvno, false, false, pReturns.Text);
                            break;
                        case "lbl_keyno":
                            bool _bPrintColourKeyNo = false;

                            _bPrintBrush = new SolidBrush(Color.Yellow);
                            _bPrintColourKeyNo = true;

                            DrawString(e, pReturns, lbl_printkeyno, false, _bPrintColourKeyNo, pReturns.Text);
                            break;
                        case "lbl_amount":
                            DrawString(e, pReturns, lbl_printamount, false, false, pReturns.Text);
                            break;
                        case "lbl_paidstatus":
                            bool _bPrintColourPaidStatus = false;
                            if (pReturns.Text == "To Pay")
                            {
                                _bPrintBrush = new SolidBrush(Color.Yellow);
                                _bPrintColourPaidStatus = true;
                            }
                            else if (pReturns.Text == "OnAcc")
                            {
                                _bPrintBrush = new SolidBrush(Color.Violet);
                                _bPrintColourPaidStatus = true;
                            }
                            else if (pReturns.Text == "N/C")
                            {
                                _bPrintBrush = new SolidBrush(Color.Orange);
                                _bPrintColourPaidStatus = true;
                            }
                            DrawString(e, pReturns, lbl_printpaid, true, _bPrintColourPaidStatus, pReturns.Text);
                            break;
                        case "lbl_ph":
                            DrawString(e, pReturns, lbl_printphone, false, false, pReturns.Text);
                            break;
                        case "lbl_DateIn":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printdatein, false, false, pReturns.Text);
                            break;
                        case "lbl_ReturnDate":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            DrawString(e, pReturns, lbl_printreturndate, false, false, pReturns.Text);
                            break;
                        case "lbl_staffmember":
                            DrawString(e, pReturns, lbl_staff, false, false, pReturns.Text);
                            break;
                        case "lbl_NotesAndAlerts":
                            pReturns.Location = new Point(pReturns.Location.X, 10);
                            bool _bPrintColourNA = false;
                            if (pReturns.Text == "N")
                            {
                                _bPrintBrush = new SolidBrush(Color.LightBlue);
                                _bPrintColourNA = true;
                            }
                            else if (pReturns.Text == "A")
                            {
                                _bPrintBrush = new SolidBrush(Color.Red);
                                _bPrintColourNA = true;
                            }
                            else if (pReturns.Text == "N/A")
                            {
                                _bPrintBrush = new SolidBrush(Color.MediumPurple);
                                _bPrintColourNA = true;
                            }
                            DrawString(e, pReturns, lbl_notesalerts, false, _bPrintColourNA, pReturns.Text);
                            break;

                        default:
                            break;
                    }
                }

                iLocationY += 40;
            }
        }

        #endregion BadDebotors

        #endregion

        #region Search

        ComboBox cmbRego;
        ComboBox cmbAccount;

        private void PopulateRegoBox()
        {
            object[] a = new object[MyAppManager.MainMenuInstance.GetCmbRegoComboBox().Items.Count];
            MyAppManager.MainMenuInstance.GetCmbRegoComboBox().Items.CopyTo(a, 0);
            cmbRego = new ComboBox();
            cmbRego.Size = cmb_items.Size;
            cmbRego.Font = cmb_items.Font;
            cmbRego.Location = cmb_items.Location;
            cmbRego.Items.AddRange(a);
            cmbRego.Visible = false;

            Controls.Add(cmbRego);
        }

        private void PopulateAccountBox()
        {
            object[] a = new object[MyAppManager.MainMenuInstance.GetCmbAccountsComboBox().Items.Count];
            MyAppManager.MainMenuInstance.GetCmbAccountsComboBox().Items.CopyTo(a, 0);
            cmbAccount = new ComboBox();
            cmbAccount.Size = cmb_items.Size;
            cmbAccount.Font = cmb_items.Font;
            cmbAccount.Location = cmb_items.Location;
            cmbAccount.Items.AddRange(a);
            cmbAccount.Visible = false;

            Controls.Add(cmbAccount);
        }

        private void cmb_searchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBy();
        }

        void SearchBy()
        {
            cmbRego.Visible = false;
            cmbAccount.Visible = false;
            cmb_items.Visible = false;

            cmb_items.Text = "";

            if (cmb_searchby.Text == "Invoice No")
            {
                cmb_items.Visible = true;
                cmb_items.Items.Clear();
            }
            else if (cmb_searchby.Text == "Car Rego")
            {
                cmbRego.Visible = true;
            }
            else if (cmb_searchby.Text == "Account")
            {
                cmbAccount.Visible = true;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cmb_items.Text == "Admin" || cmb_items.Text == "ADMIN" || cmb_items.Text == "-1")
            {
                cmb_items.Text = "";
                AdministratorPassword adp = new AdministratorPassword();
                adp.Show();
            }
            else
            {
                SearchParameters();
            }
        }

        void SearchParameters()
        {
            if (cmb_items.Text == "" && cmb_searchby.Text == "Invoice No")
            {
                return;
            }

            if (cmb_searchby.Text == "Invoice No")
            {
                int iCheckIfNumber = 0;
                bool bCheckIfNumber = int.TryParse(cmb_items.Text, out iCheckIfNumber);

                if (!bCheckIfNumber)
                {
                    WarningSystem ws = new WarningSystem("Please only enter an Invoice Number", false);
                    ws.ShowDialog();

                    return;
                }
            }

            DeleteControls();

            // Set the initial location for the title
            iInitialPanelLocationY = pnl_template.Location.Y;

            // Creates the Title Header
            TitleHeaders(2);

            // Create todays date for the query
            DateTime now = dt_timepicked.Value;
            //now = now.AddDays(-1);
            dtDate = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);

            // Creates a query for todays returns
            //string sTodaysQuerys = "select * from CustomerInvoices WHERE DTDateIn = @dtDate ORDER BY TimeIn ASC";
            string sTodaysQuerys = "";

            if (cmb_searchby.Text == "Invoice No")
            {
                sTodaysQuerys = "select * from CustomerInvoices WHERE InvoiceNumber = " + cmb_items.Text + "";
            }
            else if(cmb_searchby.Text == "Car Rego")
            {
                sTodaysQuerys = "select * from CustomerInvoices WHERE Rego = '" + cmbRego.Text + "' ORDER BY DtReturnDate DESC";
            }
            else if (cmb_searchby.Text == "Account")
            {
                sTodaysQuerys = "select * from CustomerInvoices WHERE AccountHolder = '" + cmbAccount.Text + "' AND PaidStatus = 'OnAcc' ORDER BY DtReturnDate DESC";
            }

            CreateReturns(sTodaysQuerys);
        }

        #endregion Search
    }
}