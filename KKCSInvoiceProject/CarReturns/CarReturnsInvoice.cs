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
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class CarReturnsInvoice : Form
    {
        #region GlobalVariables

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private Button printButton = new Button();
        private PrintDocument printDocument1 = new PrintDocument();

        private OleDbConnection connection = new OleDbConnection();

        Color LabelBackColour = Color.FromArgb(255, 192, 192);

        string sStoreOldRego = "";

        bool PaidStatusPicked = false;

        string m_sTempStoreRego = "";

        string m_sDatePaidInvisible = "";

        string sDatePaid = "";
        string sDatePaidInvisible = "";

        bool sDatePaidBool = false;

        CarReturns carReturns;

        // Sets up the main OleDb Command
        OleDbCommand command;

        OleDbDataReader reader;

        private string ssStoreKeyNumber = "";

        private string sTempStorePrice = "";

        string g_sPaidStatus = "";

        #endregion

        #region Closing

        private void chkbox_topay_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            carReturns.RefreshNewTable();
        }

        #endregion

        #region Load

        public void SetUpFromCarReturns(int _iInvoiceNumber)
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Invoice WHERE InvoiceNumber = " + _iInvoiceNumber + "";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Gets Invoice Number
                txt_invoiceno.Text = _iInvoiceNumber.ToString();
                txt_invoiceno.ReadOnly = true;

                // Inserts Key Number
                txt_keyno.Text = reader["KeyNumber"].ToString();
                txt_keyno.ReadOnly = true;

                // Checks for No Key/No Key Policy
                chk_nokey.Checked = (bool)reader["NoKey"];
                chk_nokey.AutoCheck = false;
                chk_keypolicy.Checked = (bool)reader["NoKeyPolicy"];
                chk_keypolicy.AutoCheck = false;

                // Gets Account Name
                txt_accountname.Text = reader["AccountHolder"].ToString();

                // Inserts the date the customer dropped the car off
                DateTime dtin = (DateTime)reader["DateInInvisible"];
                txt_datein.Value = dtin;
                //txt_datein.Enabled = false;

                // Inserts the time the customer dropped the car off
                cmb_timeinhours.Text = reader["TimeIn"].ToString().Substring(0, 2);
                cmb_timeinminutes.Text = reader["TimeIn"].ToString().Substring(2, 2);
                //cmb_timeinhours.Enabled = false;
                //cmb_timeinminutes.Enabled = false;

                // Inserts the date the customer paid if any
                m_sDatePaidInvisible = reader["DatePaidInvisible"].ToString();
                lbl_datepaid.Text = "Date Paid: ";
                lbl_datepaid.Text += m_sDatePaidInvisible;

                // Inserts Customer Data
                txt_clientname.Text = reader["ClientName"].ToString();
                txt_ph.Text = reader["Ph"].ToString();
                txt_makemodel.Text = reader["MakeModel"].ToString();
                cmb_rego.Text = reader["Rego"].ToString();
                m_sTempStoreRego = reader["Rego"].ToString();

                // Stores the rego if it needs to be changed
                sStoreOldRego = reader["Rego"].ToString();

                txt_returndate.Value = (DateTime)reader["ReturnDateInvisible"];

                // Gets the return date and time
                string sReturnDate = reader["ReturnDate"].ToString();
                string sReturnTime = reader["ReturnTime"].ToString();

                DateTime dtToday = DateTime.Now;

                if (sReturnDate == "Unknown")
                {
                    //txt_returndate.Value = dtToday;
                    txt_returndate.Value = (DateTime)reader["ReturnDateInvisible"];
                    cmb_returntimehours.Text = dtToday.Hour.ToString();
                    cmb_returntimeminutes.Text = dtToday.Minute.ToString();

                    chk_manual.Checked = true;
                }
                else
                {
                    DateTime dtreturn = (DateTime)reader["ReturnDateInvisible"];
                    DateTime dtOriginalComparison = new DateTime(dtreturn.Year, dtreturn.Month, dtreturn.Day);
                    DateTime dtTodayComparison = new DateTime(dtToday.Year, dtToday.Month, dtToday.Day);

                    int result = (int)(dtTodayComparison - dtOriginalComparison).TotalDays;

                    if (result >= 2)
                    {
                        //txt_returndate.Value = dtToday;
                        txt_returndate.Value = (DateTime)reader["ReturnDateInvisible"];
                        cmb_returntimehours.Text = dtToday.Hour.ToString();
                        cmb_returntimeminutes.Text = dtToday.Minute.ToString();

                        chk_manual.Checked = true;
                    }
                    else
                    {
                        //txt_returndate.Value = dtreturn;
                        txt_returndate.Value = (DateTime)reader["ReturnDateInvisible"];
                        bool FlightOrManual = (bool)reader["FlightOrManual"];

                        // Inserts the time the customer is picking up their car
                        string sReturnTimeHours = reader["ReturnTime"].ToString().Substring(0, 2);
                        string sReturnTimeMinutes = reader["ReturnTime"].ToString().Substring(2, 2);

                        if (FlightOrManual)
                        {
                            string sCombined = sReturnTimeHours + sReturnTimeMinutes;
                            txt_flighttimes.Text = sCombined;

                            chk_flighttimes.Checked = true;
                        }
                        else
                        {
                            cmb_returntimehours.Text = sReturnTimeHours;
                            cmb_returntimeminutes.Text = sReturnTimeMinutes;

                            chk_manual.Checked = true;
                        }

                        // Inserts the amount paid
                        txt_money7charge.Text = reader["SevenDaysRate"].ToString();
                        txt_money7.Text = reader["SevenDaysPay"].ToString();
                        txt_money7pluscharge.Text = reader["SevenDaysPlusRate"].ToString();
                        txt_money7plus.Text = reader["SevenDaysPlusPay"].ToString();
                        txt_total.Text = reader["TotalPay"].ToString();
                    }
                }

                if (sReturnTime == "Unknown")
                {
                    cmb_returntimehours.Text = dtToday.Hour.ToString();
                    cmb_returntimeminutes.Text = dtToday.Minute.ToString("00");

                    chk_manual.Checked = true;
                }

                // Inserts any notes or alerts
                txt_notes.Text = reader["Notes"].ToString();
                txt_alerts.Text = reader["Alerts"].ToString();

                chk_splitpay.Checked = (bool)reader["SplitPay"];
                txt_splitcash1.Text = reader["Split1"].ToString();
                txt_splitcash2.Text = reader["Split2"].ToString();
                cmb_split1.Text = reader["Split1Location"].ToString();
                cmb_split2.Text = reader["Split2Location"].ToString();

                // Popluates the paid status
                PopulatePaidStatus();
            }

            connection.Close();
        }

        void PopulatePaidStatus()
        {
            if (reader["PaidStatus"].ToString() == "Cash")
            {
                chkbox_cash.Checked = true;
            }
            else if (reader["PaidStatus"].ToString() == "Eftpos")
            {
                chkbox_eftpos.Checked = true;
            }
            else if (reader["PaidStatus"].ToString() == "Internet")
            {
                chkbox_internet.Checked = true;
            }
            else if (reader["PaidStatus"].ToString() == "Cheque")
            {
                chkbox_cheque.Checked = true;
            }
            else if (reader["PaidStatus"].ToString() == "To Pay")
            {
                chkbox_stilltopay.Checked = true;
            }
            else if (reader["PaidStatus"].ToString() == "OnAcc")
            {
                chkbox_onaccount.Checked = true;
            }
            else if (reader["PaidStatus"].ToString() == "N/C")
            {
                chkbox_nocharge.Checked = true;
            }
        }

        public CarReturnsInvoice(CarReturns _carReturns)
        {
            InitializeComponent();

            carReturns = _carReturns;

            this.FormClosing += chkbox_topay_Closing;

            connection.ConnectionString = m_strDataBaseFilePath;

            txt_flighttimes.SelectedIndex = 0;
        }

        #endregion

        public Label GetRefundGiven()
        {
            return (lbl_refundgiven);
        }

        public string MakeDisplayDate()
        {
            string storeDate = "";

            if (txt_returndate.Enabled == true)
            {
                string DisplayReturnDate = txt_returndate.Value.DayOfWeek.ToString();

                if (DisplayReturnDate == "Monday")
                {
                    storeDate = "MON";
                }
                else if (DisplayReturnDate == "Tuesday")
                {
                    storeDate = "TUE";
                }
                else if (DisplayReturnDate == "Wednesday")
                {
                    storeDate = "WED";
                }
                else if (DisplayReturnDate == "Thursday")
                {
                    storeDate = "THUR";
                }
                else if (DisplayReturnDate == "Friday")
                {
                    storeDate = "FRI";
                }
                else if (DisplayReturnDate == "Saturday")
                {
                    storeDate = "SAT";
                }
                else if (DisplayReturnDate == "Sunday")
                {
                    storeDate = "SUN";
                }

                storeDate = storeDate + ", " + txt_returndate.Value.ToString("dd-MM-yy");
            }
            else
            {
                storeDate = "Unknown";
            }

            return (storeDate);

        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (!PaidStatusPicked)
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "You have not picked a 'Paid Status' please select before saving";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else
            {
                SaveDataIntoDatabase();
            }
        }

        void SaveDataIntoDatabase()
        {
            labl_savedstatus.Text = "Saved";
            labl_savedstatus.ForeColor = System.Drawing.Color.Green;

            string sWarning = "WARNING";
            string sWarningMessage = "This Invoice has already been saved, do you wish to overwrite existing data?";

            DialogResult dialogResult = MessageBox.Show(sWarningMessage, sWarning, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                UpdateInvoice();
                //UpdateKeyBox();

                labl_savedstatus.Text = "Updated";
                labl_savedstatus.ForeColor = System.Drawing.Color.Purple;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txt_total.Text = "";
        }

        private void cmb_timeouthours_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_total.Text = "";
        }

        private void btn_updateprice_Click(object sender, EventArgs e)
        {
            SetUpPrice();

            txt_splitcash1.Text = "";
            txt_splitcash2.Text = "";
        }

        void UpdateKeyBox()
        {
            try
            {
                if (txt_keyno.Text == "NK")
                {
                    // Do Nothing
                }
                else
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();

                    command.Connection = connection;

                    string cmd1 = @"UPDATE KeyBox
                                SET [Rego] = '" + cmb_rego.Text + "' WHERE [KeyBoxNumber] = '" + txt_keyno.Text + "'";

                    command.CommandText = cmd1;

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        void UpdateInvoice()
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                string tempStringConvert = txt_invoiceno.Text;

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

                if (txt_returndate.Enabled == false)
                {
                    sReturnDate = "Unknown";
                }
                else
                {
                    sReturnDate = txt_returndate.Value.DayOfWeek.ToString() + ", " +
                    txt_returndate.Value.Day.ToString() + " " +
                    txt_returndate.Value.ToString("MMMM") + " " +
                    txt_returndate.Value.Year.ToString();
                }

                string sDateIn = txt_datein.Value.DayOfWeek.ToString() + ", " +
                txt_datein.Value.Day.ToString() + " " +
                txt_datein.Value.ToString("MMMM") + " " +
                txt_datein.Value.Year.ToString();

                if (g_sPaidStatus != "To Pay" && !sDatePaidBool)
                {
                    if (g_sPaidStatus == "N/C" || g_sPaidStatus == "OnAcc")
                    {
                        lbl_datepaid.Text = "Date Paid: N/A";
                        sDatePaid = "N/A";
                        sDatePaidInvisible = "N/A";
                    }
                    else // All others apart from "To Pay"
                    {
                        DateTime todaysDate = DateTime.Today;

                        // This function makes the date paid
                        string dateCustomerPaid = todaysDate.Day.ToString() + "/" + todaysDate.Month.ToString("00") + "/" + todaysDate.ToString("yy");

                        lbl_datepaid.Text = "Date Paid: " + dateCustomerPaid;

                        sDatePaid = todaysDate.DayOfWeek.ToString() + ", " +
                        todaysDate.Day.ToString() + " " +
                        todaysDate.ToString("MMMM") + " " +
                        todaysDate.Year.ToString();

                        sDatePaidInvisible = dateCustomerPaid;
                    }

                    sDatePaidBool = true;
                }
                else if (g_sPaidStatus == "To Pay")
                {
                    lbl_datepaid.Text = "Date Paid: To Pay";
                    sDatePaid = "To Pay";
                    sDatePaidInvisible = "To Pay";

                    sDatePaidBool = false;
                }
                else if (g_sPaidStatus == "N/C" || g_sPaidStatus == "OnAcc")
                {
                    lbl_datepaid.Text = "Date Paid: N/A";
                    sDatePaid = "N/A";
                    sDatePaidInvisible = "N/A";
                }

                int iInvoiceNumber = 0;
                Int32.TryParse(txt_invoiceno.Text, out iInvoiceNumber);

                string cmd1 = @"UPDATE Invoice SET 
                                                    DateIn = '" + sDateIn +
                                                    "', DatePaid  = '" + sDatePaid +
                                                    "', DatePaidInvisible  = '" + sDatePaidInvisible +
                                                    "', DateInInvisible = '" + txt_datein.Value +
                                                    "', TimeIn = '" + tempTimeInHours +
                                                    "', ClientName = '" + txt_clientname.Text +
                                                    "', Ph = '" + txt_ph.Text +
                                                    "', MakeModel = '" + txt_makemodel.Text +
                                                    "', Rego = '" + cmb_rego.Text +
                                                    "', ReturnDate = '" + sReturnDate +
                                                    "', ReturnDateInvisible = '" + txt_returndate.Value +
                                                    "', DisplayedReturnDate = '" + MakeDisplayDate() +
                                                    "', ReturnTime = '" + tempReturnTimeHours +
                                                    "', SevenDaysPay = '" + txt_money7.Text +
                                                    "', SevenDaysPlusPay = '" + txt_money7plus.Text +
                                                    "', TotalPay = '" + txt_total.Text +
                                                    "', Notes = '" + txt_notes.Text +
                                                    "', AccountHolder = '" + txt_accountname.Text +
                                                    "', KeyNumber = '" + txt_keyno.Text +
                                                    "', PaidStatus = '" + g_sPaidStatus +
                                                    "', Alerts = '" + txt_alerts.Text +
                                                    "', ReturnYear = '" + txt_returndate.Value.Year +
                                                    "', ReturnMonth = '" + txt_returndate.Value.Month +
                                                    "', ReturnDay = '" + txt_returndate.Value.Day +
                                                    "', SevenDaysRate = '" + txt_money7charge.Text +
                                                    "', SevenDaysPlusRate = '" + txt_money7pluscharge.Text +
                                                    "', Split1 = '" + txt_splitcash1.Text +
                                                    "', Split2 = '" + txt_splitcash2.Text +
                                                    "', Split1Location = '" + cmb_split1.Text +
                                                    "', Split2Location = '" + cmb_split2.Text +
                                                    "', NoKey = " + chk_nokey.Checked +
                                                    ", NoKeyPolicy = " + chk_keypolicy.Checked +
                                                    ", FlightOrManual  = " + chk_flighttimes.Checked +
                                                    ", SplitPay = " + chk_splitpay.Checked +
                                                    " WHERE InvoiceNumber = " + iInvoiceNumber + "";

                command.CommandText = cmd1;

                command.ExecuteNonQuery();

                //MessageBox.Show("Data Saved");

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        string ReturnTime()
        {
            string tempTimeCombined = "";

            if (chk_manual.Checked)
            {
                string tempReturnTimeHours = cmb_returntimehours.Text;
                string tempReturnTimeMinutes = cmb_returntimeminutes.Text;

                int x = 0;
                Int32.TryParse(tempReturnTimeHours, out x);

                if (x <= 9)
                {
                    tempReturnTimeHours = "0" + tempReturnTimeHours;
                }

                tempTimeCombined = tempReturnTimeHours + tempReturnTimeMinutes;
            }
            else
            {
                tempTimeCombined = txt_flighttimes.Text;
            }

            return (tempTimeCombined);
        }

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

        /*
        void UpdateInvoice()
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                int iInvoiceNumber = 0;
                Int32.TryParse(txt_invoiceno.Text, out iInvoiceNumber);

                string tempStringConvert = txt_invoiceno.Text;

                string tempReturnTimeHours = "";

                if (cmb_returntimehours.Enabled == false)
                {
                    tempReturnTimeHours = "Unknown";
                }

                string sReturnDate = "";

                if (txt_returndate.Enabled == false)
                {
                    sReturnDate = "Unknown";
                }
                else
                {
                    sReturnDate = txt_returndate.Value.DayOfWeek.ToString() + ", " +
                    txt_returndate.Value.Day.ToString() + " " +
                    txt_returndate.Value.ToString("MMMM") + " " +
                    txt_returndate.Value.Year.ToString();
                }

                string sDateIn = txt_datein.Value.DayOfWeek.ToString() + ", " +
                txt_datein.Value.Day.ToString() + " " +
                txt_datein.Value.ToString("MMMM") + " " +
                txt_datein.Value.Year.ToString();

                if(m_sDatePaidInvisible == "To Pay")
                {
                    DateTime dtTodaysDate = DateTime.Today;

                    m_sDatePaid = dtTodaysDate.DayOfWeek.ToString() + ", " +
                    dtTodaysDate.Day.ToString() + " " +
                    dtTodaysDate.ToString("MMMM") + " " +
                    dtTodaysDate.Year.ToString();

                    m_sDatePaidInvisible = dtTodaysDate.Day.ToString() + "/" + dtTodaysDate.Month.ToString("00") + "/" + dtTodaysDate.ToString("yy");

                    lbl_datepaid.Text = "Date Paid: ";
                    lbl_datepaid.Text += m_sDatePaidInvisible;
                }

                string cmd1 = @"UPDATE Invoice SET
                                                    DateIn = '" + sDateIn +
                                                    "', DateInInvisible = '" + txt_datein.Value +
                                                    "', DatePaid = '" + m_sDatePaid +
                                                    "', DatePaidInvisible = '" + m_sDatePaidInvisible +
                                                    "', ClientName = '" + txt_clientname.Text +
                                                    "', Ph = '" + txt_ph.Text +
                                                    "', MakeModel = '" + txt_makemodel.Text +
                                                    "', Rego = '" + cmb_rego.Text +
                                                    "', ReturnDate = '" + sReturnDate +
                                                    "', ReturnDateInvisible = '" + txt_returndate.Value +
                                                    "', DisplayedReturnDate = '" + MakeDisplayDate() +
                                                    "', ReturnTime = '" + tempReturnTimeHours +
                                                    "', SevenDaysPay = '" + txt_money7.Text +
                                                    "', SevenDaysPlusPay = '" + txt_money7plus.Text +
                                                    "', TotalPay = '" + txt_total.Text +
                                                    "', Notes = '" + txt_notes.Text +
                                                    "', AccountHolder = '" + txt_accountname.Text +
                                                    "', KeyNumber = '" + txt_keyno.Text +
                                                    "', PaidStatus = '" + g_sPaidStatus +
                                                    "', Alerts = '" + txt_alerts.Text +
                                                    "', ReturnYear = '" + txt_returndate.Value.Year +
                                                    "', ReturnMonth = '" + txt_returndate.Value.Month +
                                                    "', ReturnDay = '" + txt_returndate.Value.Day +
                                                    "', SevenDaysRate = '" + txt_money7charge.Text +
                                                    "', SevenDaysPlusRate = '" + txt_money7pluscharge.Text +
                                                    "', Split1 = '" + txt_splitcash1.Text +
                                                    "', Split2 = '" + txt_splitcash2.Text +
                                                    "', Split1Location = '" + cmb_split1.Text +
                                                    "', Split2Location = '" + cmb_split2.Text +
                                                    "', NoKey = " + chk_nokey.Checked +
                                                    ", NoKeyPolicy = " + chk_keypolicy.Checked +
                                                    ", SplitPay = " + chk_splitpay.Checked +
                                                    " WHERE InvoiceNumber = " + iInvoiceNumber + "";

                command.CommandText = cmd1;

                command.ExecuteNonQuery();

                connection.Close();


                
                connection.Open();

                OleDbCommand command2 = new OleDbCommand();

                command2.Connection = connection;

                string cmd2 = @"UPDATE KeyBox SET Rego = '" + cmb_rego.Text + "' WHERE Rego = " + sStoreOldRego + "";

                command2.CommandText = cmd2;

                command2.ExecuteNonQuery();

                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        */

        public void SetUpPrice()
        {
            if (txt_money7charge.Text == "")
            {
                txt_money7charge.Text = "10";
            }
            if (txt_money7pluscharge.Text == "")
            {
                txt_money7pluscharge.Text = "8";
            }

            int iDays = 0;
            int iTimeInHours = 0;
            int iReturnTimeHours = 0;

            iDays = txt_returndate.Value.DayOfYear - txt_datein.Value.DayOfYear;
            iTimeInHours = int.Parse(cmb_timeinhours.SelectedItem.ToString());
            iReturnTimeHours = int.Parse(cmb_returntimehours.SelectedItem.ToString());

            if (iReturnTimeHours - iTimeInHours > 4 && iDays != 0)
            {
                iDays += 1;
            }

            if (iDays < 0)
            {
                MessageBox.Show("ERROR: 'Return Date' Cannot Be Before 'Date In'");
            }
            else if (iDays == 0)
            {
                txt_money7plus.Text = "";

                int iMoneyCharge = int.Parse(txt_money7charge.Text.ToString());

                int iCalculateTotal = iMoneyCharge * (iDays + 1);

                txt_money7.Text = iCalculateTotal.ToString();

                txt_total.Text = iCalculateTotal.ToString();
            }
            else if (iDays >= 1 && iDays <= 7)
            {
                txt_money7.Text = "";
                txt_money7plus.Text = "";

                int iMoneyCharge = int.Parse(txt_money7charge.Text.ToString());

                int iCalculateTotal = iMoneyCharge * iDays;

                txt_money7.Text = iCalculateTotal.ToString();

                txt_total.Text = iCalculateTotal.ToString();
            }
            else if (iDays > 7)
            {
                txt_money7.Text = "";
                txt_money7plus.Text = "";

                /////////////////
                int iMoneyCharge = int.Parse(txt_money7charge.Text.ToString());

                int iCalculateTotal = iMoneyCharge * 7;

                txt_money7.Text = iCalculateTotal.ToString();
                /////////////////


                ///////////////
                int iRemainingDays = iDays - 7;

                int iMoney7PlusCharge = int.Parse(txt_money7pluscharge.Text.ToString());

                int iCalculatePlusTotal = iMoney7PlusCharge * iRemainingDays;

                txt_money7plus.Text = iCalculatePlusTotal.ToString();
                //////////////


                //////////////
                int TotalMoney = iCalculateTotal + iCalculatePlusTotal;

                txt_total.Text = TotalMoney.ToString();
                ///////////////
            }
        }

        private void HideDaysPlus()
        {
            label14.Visible = false;
            txt_money7pluscharge.Visible = false;
            label15.Visible = false;
            label21.Visible = false;
            txt_money7plus.Visible = false;
        }

        private void voidShowDaysPlus()
        {
            label14.Visible = true;
            txt_money7pluscharge.Visible = true;
            label15.Visible = true;
            label21.Visible = true;
            txt_money7plus.Visible = true;
        }

        void CheckBoxOnAccount(bool _bAccountStatus)
        {
            if (_bAccountStatus == true)
            {
                chkbox_onaccount.CheckState = CheckState.Checked;
                chkbox_onaccount.BackColor = System.Drawing.Color.LightPink;

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

        #region SeclectedTextChanges

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

        private void chkbox_onaccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_onaccount.Checked)
            {
                ChangeOtherPaidStatusToNull(chkbox_onaccount.Name);
            }
            else
            {
                chkbox_onaccount.BackColor = System.Drawing.Color.Transparent;
                g_sPaidStatus = "";
                PaidStatusPicked = false;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_nokey.Checked == true)
            {
                txt_keyno.Text = "NK";
                txt_keyno.Enabled = false;
                txt_keyno.Visible = false;

                chk_keypolicy.Visible = true;
                chk_keypolicy.Enabled = true;

                chk_keypolicy.BackColor = Color.PaleVioletRed;
            }
            else
            {
                txt_keyno.Text = ssStoreKeyNumber;
                txt_keyno.Enabled = true;
                txt_keyno.Visible = true;

                chk_keypolicy.Visible = false;
                chk_keypolicy.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_splitpay.Checked == true)
            {
                chkbox_cash.Enabled = false;
                chkbox_eftpos.Enabled = false;
                chkbox_cheque.Enabled = false;
                chkbox_internet.Enabled = false;
                chkbox_stilltopay.Enabled = false;
                chkbox_onaccount.Enabled = false;
                chkbox_nocharge.Enabled = false;

                chkbox_cash.Visible = false;
                chkbox_eftpos.Visible = false;
                chkbox_cheque.Visible = false;
                chkbox_internet.Visible = false;
                chkbox_stilltopay.Visible = false;
                chkbox_onaccount.Visible = false;
                chkbox_nocharge.Visible = false;

                txt_paidstatus.Visible = false;

                txt_splitcash1.Enabled = true;
                txt_splitcash2.Enabled = true;
                cmb_split1.Enabled = true;
                cmb_split2.Enabled = true;

                txt_splitcash1.Visible = true;
                txt_splitcash2.Visible = true;
                cmb_split1.Visible = true;
                cmb_split2.Visible = true;

                txt_splitpay.Visible = true;
                txt_splitsign1.Visible = true;
                txt_splitsign2.Visible = true;

                txt_splitpay.Enabled = true;
                txt_splitsign1.Enabled = true;
                txt_splitsign2.Enabled = true;

            }
            else
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

                txt_splitcash1.Enabled = false;
                txt_splitcash2.Enabled = false;
                cmb_split1.Enabled = false;
                cmb_split2.Enabled = false;

                txt_splitcash1.Visible = false;
                txt_splitcash2.Visible = false;
                cmb_split1.Visible = false;
                cmb_split2.Visible = false;

                txt_splitpay.Visible = false;
                txt_splitsign1.Visible = false;
                txt_splitsign2.Visible = false;

                txt_splitpay.Enabled = false;
                txt_splitsign1.Enabled = false;
                txt_splitsign2.Enabled = false;
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

        private void chk_keypolicy_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_keypolicy.Checked == true)
            {
                chk_keypolicy.BackColor = Color.LightGreen;
            }
            else
            {
                chk_keypolicy.BackColor = Color.PaleVioletRed;
            }
        }

        private void cmb_returntimeminutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_total.Text = "";
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
        }

        private void txt_splitcash1_TextChanged(object sender, EventArgs e)
        {
            if (txt_total.Text == "" && txt_splitcash1.Text != "")
            {
                MessageBox.Show("ERROR: Please Calculate Price First", "ERROR");
            }
            else
            {
                int iTotalPrice = 0;
                int iSplit1 = 0;
                int iRemainder = 0;

                Int32.TryParse(txt_splitcash1.Text, out iTotalPrice);
                Int32.TryParse(txt_total.Text, out iSplit1);

                iRemainder = iSplit1 - iTotalPrice;

                txt_splitcash2.Text = iRemainder.ToString();
            }
        }

        #endregion

        private void ChangeOtherPaidStatusToNull(string _name)
        {
            if (_name == "chkbox_cash")
            {
                chkbox_cash.BackColor = System.Drawing.Color.LightBlue;

                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Cash";
            }
            else if (_name == "chkbox_eftpos")
            {
                chkbox_eftpos.BackColor = System.Drawing.Color.LightBlue;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Eftpos";
            }
            else if (_name == "chkbox_cheque")
            {
                chkbox_cheque.BackColor = System.Drawing.Color.LightBlue;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_internet.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;

                g_sPaidStatus = "Cheque";
            }
            else if (_name == "chkbox_internet")
            {
                chkbox_internet.BackColor = System.Drawing.Color.LightBlue;

                chkbox_cash.CheckState = CheckState.Unchecked;
                chkbox_eftpos.CheckState = CheckState.Unchecked;
                chkbox_cheque.CheckState = CheckState.Unchecked;
                chkbox_stilltopay.CheckState = CheckState.Unchecked;
                chkbox_onaccount.CheckState = CheckState.Unchecked;
                chkbox_nocharge.CheckState = CheckState.Unchecked;

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

                g_sPaidStatus = "N/C";

                sTempStorePrice = txt_total.Text;
                txt_total.Text = "";
                txt_money7.Text = "";
                txt_money7plus.Text = "";

                txt_total.Enabled = false;
                txt_total.Visible = false;

                label13.Visible = false;
            }

            PaidStatusPicked = true;
        }

        private void EnableAllPaidStatusCheckBox()
        {
            chkbox_cash.Enabled = true;
            chkbox_eftpos.Enabled = true;
            chkbox_cheque.Enabled = true;
            chkbox_internet.Enabled = true;
            chkbox_stilltopay.Enabled = true;
            chkbox_onaccount.Enabled = true;
            chkbox_nocharge.Enabled = true;

            PaidStatusPicked = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            //Size s = new Size(this.Size.Width * 2, this.Size.Height * 2);
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
        System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.DefaultPageSettings.Color = false;
            printDocument1.DefaultPageSettings.Landscape = true;

            printDocument1.Print();
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

        private void btn_returns_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["CarReturns"];

            if (fm != null)
            {
                fm.BringToFront();

                if (fm.WindowState == FormWindowState.Minimized)
                {
                    fm.WindowState = FormWindowState.Maximized;
                }
            }
            else
            {
                CarReturns cr = new CarReturns();
                cr.Show();
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Refunds"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                Refunds refund = new Refunds(this);

                refund.SetDataToRefunds(txt_datein.Value, txt_returndate.Value, txt_total.Text, cmb_timeinhours.Text, cmb_returntimehours.Text, txt_invoiceno.Text, cmb_rego.Text);

                refund.Show();
            }
        }

        private void btn_prints_Click(object sender, EventArgs e)
        {
            bool bCheckUnknown = false;

            if (cmb_rego.Text == "")
            {
                string sPaidStatusWarning = "WARNING";
                string sPaidStatusWarningMessage = "Please at least set the Car Rego before printing receipt";

                MessageBox.Show(sPaidStatusWarningMessage, sPaidStatusWarning);
            }
            else if (txt_total.Text == "" && g_sPaidStatus != "N/C" && !bCheckUnknown && !chk_splitpay.Checked)
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
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //this prints the reciept
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 30;

            graphic.DrawString("BOI Airport Car Storage Receipt", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            offset = offset + (int)fontHeight; //make the spacing consistent

            graphic.DrawString("Ph: 09-401-6351", font, new SolidBrush(Color.Black), startX, startY + 25);
            //offset = offset + 25; //make the spacing consistent

            graphic.DrawString("---------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent

            string sTodaysDate = "Date: " + txt_datein.Value.Day + "th of " + txt_datein.Value.ToString("MMMM");
            graphic.DrawString(sTodaysDate, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            string sInvoiceNumber = "Invoice No: " + txt_invoiceno.Text;
            graphic.DrawString(sInvoiceNumber, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            string sClientName = "Name: " + txt_clientname.Text;
            graphic.DrawString(sClientName, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight * 2; //make the spacing consistent

            string sTotalPrice = "Total: $" + txt_total.Text + ".00";
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
    }
}