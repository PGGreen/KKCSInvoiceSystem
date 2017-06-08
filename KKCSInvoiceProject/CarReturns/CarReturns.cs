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

namespace KKCSInvoiceProject
{
    public partial class CarReturns : Form
    {
        #region GlobalVariables
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        // Creates the OleDbConnection
        private OleDbConnection connection = new OleDbConnection();

        // Creates the OleDb Items
        OleDbDataReader reader;

        int iMoveXPosition = 150;

        // Sets up the main OleDb Command
        OleDbCommand command;

        // Initial location of labels
        int g_intLabelLocationX = 20;
        int g_intLabelLocationY = 60;

        int g_intLabelName = 0;

        string[] g_strArrTableHeaders;
        string[] g_strArrTableContents;

        string g_strDatePicked = "";

        bool g_bDispalyDateFirst = true;

        #endregion

        #region Load

        public CarReturns()
        {
            // Initialises the main Windows Form Component
            InitializeComponent();

            // Initialises the connection to the file path
            connection.ConnectionString = m_strDataBaseFilePath;

            // Creates the Array for Text
            CreateQueryArray();

            g_strDatePicked = dateTimePicker1.Value.DayOfWeek.ToString() + ", " +
            dateTimePicker1.Value.Day.ToString() + " " +
            dateTimePicker1.Value.ToString("MMMM") + " " +
            dateTimePicker1.Value.Year.ToString();

            RefreshNewTable();

            //LoadAlertsAndNotesPage();
        }

        void LoadAlertsAndNotesPage()
        {
            AlertsAndNotes aan = new AlertsAndNotes(g_strDatePicked);
            aan.ShowDialog();
            //aan.TopMost = true;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            g_strDatePicked = dateTimePicker1.Value.DayOfWeek.ToString() + ", " +
            dateTimePicker1.Value.Day.ToString() + " " +
            dateTimePicker1.Value.ToString("MMMM") + " " +
            dateTimePicker1.Value.Year.ToString();

            RefreshNewTable();
        }

        void CreateQueryArray()
        {
            // Sets the names for the Table Headers
            g_strArrTableHeaders = new string[] { "Picked Up", "Customer", "Rego", "Vehicle", "Inv No.", "Key No.", "Amount",
            "Paid Status", "Return Date", "Return Time", "Notes" };

            // Sets up the array for pulling information out of the database
            g_strArrTableContents = new string[] { "PickUp", "ClientName", "Rego", "MakeModel", "InvoiceNumber", "KeyNumber",
            "TotalPay", "PaidStatus", "DisplayedReturnDate", "ReturnTime", "Notes"};
        }

        #endregion

        #region Tables

        public void RefreshNewTable()
        {
            // Stores the original position of the scroll bar to restore after refreshing
            int iOriPosOfScrollBar = VerticalScroll.Value;

            g_bDispalyDateFirst = true;

            // Resets the Label Location
            g_intLabelLocationY = 150;

            // Creates the Table
            CreateTable();

            g_intLabelLocationY += 100;

            CreateTimeHeader();

            // Moves the label location down for the first line
            g_intLabelLocationY += 40;

            if (chk_datebroughtin.Checked == false)
            {
                // Creates the line divider
                CreateLineDivider();

                // Sets up the first label 30 below the first divider
                g_intLabelLocationY += 25;

                // Creates the UnknownLate Table
                CreateUnknownLateTable();
            }

            // Restores the original location of the vertical scroll bar
            VerticalScroll.Value = iOriPosOfScrollBar;
        }

        public string FilterSelection()
        {
            string sFilters = "";

            string sCash = "PaidStatus = ''";
            string sEftpos = "PaidStatus = ''";
            string sInternet = "PaidStatus = ''";
            string sCheque = "PaidStatus = ''";
            string sToPay = "PaidStatus = ''";
            string sOnAccount = "PaidStatus = ''";
            string sNoCharge = "PaidStatus = ''";
            string sCreditCard = "PaidStatus = ''";
            
            if (chkbox_cash.Checked)
            {
                sCash = "PaidStatus = 'Cash'";
            }

            if (chkbox_eftpos.Checked)
            {
                sEftpos = "PaidStatus = 'Eftpos'";
            }

            if (chkbox_creditcard.Checked)
            {
                sCreditCard = "PaidStatus = 'Credit Card'";
            }

            if (chkbox_internet.Checked)
            {
                sInternet = "PaidStatus = 'Internet'";
            }

            if (chkbox_cheque.Checked)
            {
                sCheque = "PaidStatus = 'Cheque'";
            }

            if (chkbox_stilltopay.Checked)
            {
                sToPay = "PaidStatus = 'To Pay'";
            }

            if (chkbox_onaccount.Checked)
            {
                sOnAccount = "PaidStatus = 'OnAcc'";
            }

            if (chkbox_nocharge.Checked)
            {
                sNoCharge = "PaidStatus = 'N/C'";
            }

            //AND(PaidStatus = 'Cash' OR PaidStatus = 'To Pay')

            sFilters = "AND("+ sCash + " OR "+ sEftpos + " OR " + sCreditCard + " OR " + sInternet + " OR "+ sCheque + " OR "+ sToPay + " OR "+ sOnAccount + " OR "+ sNoCharge + ")";

            return (sFilters);
        }

        void CreateTable()
        {
            // Opens and creates the connection for the database
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string PickedReturnValue = "ReturnDate";
            
            if(chk_returndate.Checked == true)
            {
                PickedReturnValue = "ReturnDate";

                g_strArrTableHeaders[8] = "Return Date";
            }
            else if(chk_datebroughtin.Checked == true)
            {
                PickedReturnValue = "DateIn";

                g_strArrTableHeaders[8] = "Date In";
            }
            else if (chk_datepaid.Checked == true)
            {
                PickedReturnValue = "DatePaid";

                g_strArrTableHeaders[8] = "Date Paid";
            }

            string query = @"select * from Invoice WHERE " + PickedReturnValue + " = '" + g_strDatePicked + "' "+ FilterSelection() + " ORDER BY DisplayedReturnDate,ReturnTime";

            command.CommandText = query;

            reader = command.ExecuteReader();

            // Wipes all the labels for refrehsing or setting up new table
            foreach (Label lb in this.Controls.OfType<Label>().ToArray())
            {
                if (lb.Name == "lbl_carreturns" || lb.Name == "lbl_pickdate" || lb.Name == "lbl_2" || lb.Name == "lbl_filters")
                {
                    // Do Nothing
                }
                else
                {
                    lb.Text = string.Empty;
                    Controls.Remove(lb);
                }
            }

            // Deletes all the buttons in the table apart from the Load button
            foreach (Button bt in this.Controls.OfType<Button>().ToArray())
            {
                if (bt.Name == "btn_load" || bt.Name == "btn_invoice" || bt.Name == "btn_mainmenu" || bt.Name == "btn_keybox"
                    || bt.Name == "btn_left" || bt.Name == "btn_right")
                {
                    // Do Nothing
                }
                else
                {
                    bt.Text = string.Empty;
                    Controls.Remove(bt);
                }
            }

            // Creates the headers at the top
            CreateTableHeaders();

            // Stores the time from the table
            string StoreTime = "";

            // Stores time at end to compare and see if a new time has shown
            string StoreTimeSecond = "";

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            while (reader.Read())
            {
                // Gets the current time of the record
                StoreTime = reader[g_strArrTableContents[9]].ToString();

                // Compares the 2 times together to see if they are different or not
                // Skips the first check
                if (StoreTime != StoreTimeSecond && !bSkipFirstCheck)
                {
                    // If the 2 times are different, makes the gap between them
                    g_intLabelLocationY += 30;

                    CreateLineDivider();

                    // If the 2 times are different, makes the gap between them
                    g_intLabelLocationY += 30;
                }

                // Creates the labels for that record
                CreateTableLabels();

                // Makes the Second time = the first time for comparision purposes
                StoreTimeSecond = StoreTime;

                // Makes the first check to false for using
                bSkipFirstCheck = false;
            }

            // Closes the connection
            connection.Close();
        }

        void CreateUnknownLateTable()
        {
            // Opens and creates the connection for the database
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select ID,ClientName,Rego,MakeModel,InvoiceNumber,KeyNumber,
                            TotalPay,PaidStatus,AccountHolder,PickUp,DisplayedReturnDate,ReturnTime,Notes,ReturnYear,ReturnMonth,ReturnDay,ReturnDate,Alerts,DatePaid
                            from Invoice WHERE ReturnDate <> '" + g_strDatePicked + "' AND PickUp = False ORDER BY DisplayedReturnDate";

            command.CommandText = query;

            reader = command.ExecuteReader();

            // Stores the time from the table
            string StoreTime = "";

            // Stores time at end to compare and see if a new time has shown
            string StoreTimeSecond = "";

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            while (reader.Read())
            {
                DateTime d1 = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);

                int ReturnYear = 0;
                Int32.TryParse(reader["ReturnYear"].ToString(), out ReturnYear);

                int ReturnMonth = 0;
                Int32.TryParse(reader["ReturnMonth"].ToString(), out ReturnMonth);

                int ReturnDay = 0;
                Int32.TryParse(reader["ReturnDay"].ToString(), out ReturnDay);

                DateTime d2 = new DateTime(ReturnYear, ReturnMonth, ReturnDay);

                int result = DateTime.Compare(d2, d1);

                string s = reader["Rego"].ToString();

                if (result < 0 || reader["ReturnDate"].ToString() == "Unknown")
                {
                    // Gets the current time of the record
                    StoreTime = reader[g_strArrTableContents[9]].ToString();

                    // Compares the 2 times together to see if they are different or not
                    // Skips the first check
                    if (StoreTime != StoreTimeSecond && !bSkipFirstCheck)
                    {
                        // If the 2 times are different, makes the gap between them
                        g_intLabelLocationY += 30;

                        CreateLineDivider();

                        // If the 2 times are different, makes the gap between them
                        g_intLabelLocationY += 30;
                    }

                    // Creates the labels for that record
                    CreateTableLabels();

                    // Makes the Second time = the first time for comparision purposes
                    StoreTimeSecond = StoreTime;

                    // Makes the first check to false for using
                    bSkipFirstCheck = false;
                }
            }

            // Closes the connection
            connection.Close();
        }

        void CreateTableHeaders()
        {
            // Resets location and counter back to the start
            g_intLabelName = 0;
            g_intLabelLocationX = 5;

            for (int i = 0; i < g_strArrTableHeaders.Length; i++)
            {
                // Sets up new label for the header
                Label tempLabel = new Label();
                tempLabel.Text = g_strArrTableHeaders[i];
                tempLabel.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                tempLabel.Size = new Size(150, 20);
                tempLabel.Name = "Header" + g_intLabelName.ToString();

                // Moves the next header along by 150 pixels
                g_intLabelLocationX += iMoveXPosition;

                // Adds the label to the controls
                Controls.Add(tempLabel);

                // Increments the label name
                g_intLabelName += 1;
            }

            // Moves the label location down ready for Time Header
            g_intLabelLocationY += 40;

            // Sets the X location back to 60 for the first line divider
            g_intLabelLocationX = 5;

            // Creates the Time Header
            CreateTimeHeader();

            // Moves the label location down for the first line
            g_intLabelLocationY += 40;

            // Creates the line divider
            CreateLineDivider();

            // Sets up the first label 30 below the first divider
            g_intLabelLocationY += 25;
        }

        void CreateTimeHeader()
        {
            // Creates new label for the time header
            Label tempLabelLine = new Label();

            // Sets up the line using header
            if (g_bDispalyDateFirst)
            {
                tempLabelLine.Text = g_strDatePicked;
                tempLabelLine.BackColor = System.Drawing.Color.LightBlue;
                tempLabelLine.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                if(chk_datebroughtin.Checked == false)
                {
                    tempLabelLine.Text = "Unknown/Overdue";
                    tempLabelLine.BackColor = System.Drawing.Color.LightSalmon;
                    tempLabelLine.ForeColor = System.Drawing.Color.Black;
                }
            }

            // Sets up the header controls
            tempLabelLine.Font = new Font("Arial", 20, FontStyle.Bold);
            tempLabelLine.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
            tempLabelLine.Size = new Size(1600, 40);
            tempLabelLine.BringToFront();

            // Adds the header to the controls
            Controls.Add(tempLabelLine);

            // Sets Displayed Text First to false
            g_bDispalyDateFirst = false;
        }

        void CreateLineDivider()
        {
            // Creates new label for the line
            Label tempLabelLine = new Label();

            // Sets up the line using text
            tempLabelLine.Text = @"-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

            //Sets up the line controls
            tempLabelLine.Font = new Font("Arial", 12, FontStyle.Regular);
            tempLabelLine.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
            tempLabelLine.Size = new Size(2000, 20);
            tempLabelLine.BringToFront();

            // Adds the line to the controls
            Controls.Add(tempLabelLine);
        }

        void CreateTableLabels()
        {
            //   0           1           2         3              4              5           6            7                  8                 9           10
            //"PickUp", "ClientName", "Rego", "MakeModel", "InvoiceNumber", "KeyNumber", "TotalPay", "PaidStatus", "DisplayedReturnDate", "ReturnTime", "Notes"};

            // Sets the X position back to start the first line
            g_intLabelLocationX = 5;

            // Iterates through each label
            for (int i = 0; i < g_strArrTableContents.Length; i++)
            {
                // Creates a new label for use for each part of the table
                Label tempLabel = new Label();

                // Creates a new button for use for each part of the table
                Button tempButton = new Button();

                // Sets up the button for the picked up status
                if (i == 0)
                {
                    //Button tempButton = new Button();

                    // Sets the button name to the same as the Invoice Number
                    tempButton.Name = reader[g_strArrTableContents[4]].ToString();

                    // Sets up where the button is located and size
                    tempButton.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                    tempButton.Size = new Size(100, 20);

                    // Sends the button to the front
                    tempButton.BringToFront();

                    // Sets the Text of the button to yes or no
                    if (reader[g_strArrTableContents[i]].ToString() == "False")
                    {
                        Color LabelBackColour = Color.FromArgb(255, 85, 0);

                        tempButton.Text = "No";
                        tempButton.BackColor = LabelBackColour;
                        tempButton.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        tempButton.Text = "Yes";
                        tempButton.BackColor = System.Drawing.Color.LightGreen;
                    }

                    // Adds the button to the controls
                    Controls.Add(tempButton);

                    // Adds the click event to the event handler
                    tempButton.Click += new EventHandler(PickUpStatus_Click);
                }
                // Sets up the Invoice Number
                else if (i == 4)
                {
                    // Sets the button name to the invoice number
                    tempButton.Text = reader[g_strArrTableContents[i]].ToString();

                    // Sets the name of the button for use
                    tempButton.Name = reader[g_strArrTableContents[i]].ToString();

                    // Sets up where the button is located and size
                    tempButton.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                    tempButton.Size = new Size(100, 20);

                    // Sends the button to the front
                    tempButton.BringToFront();

                    // Adds the button to the controls
                    Controls.Add(tempButton);

                    tempButton.Click += new EventHandler(InvoiceButton_Click);
                }
                // Sets up the key number
                else if (i == 5)
                {
                    // Sets up the text for the Key
                    tempLabel.Text = reader[g_strArrTableContents[i]].ToString();

                    // Sets up the Button
                    tempLabel.Font = new Font("Arial", 12, FontStyle.Bold);

                    if(reader[g_strArrTableContents[0]].ToString() == "True")
                    {
                        tempLabel.BackColor = System.Drawing.Color.LightGreen;

                        tempLabel.Text = "(" + reader[g_strArrTableContents[i]].ToString() + ")P/Up";
                        //tempLabel.Text = "P/Up";
                    }
                    else if (tempLabel.Text != "" && tempLabel.Text != "NK")
                    {
                        tempLabel.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (tempLabel.Text == "NK")
                    {
                        tempLabel.BackColor = System.Drawing.Color.LightPink;
                    }

                    tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                    tempLabel.Size = new Size(80, 20);
                    tempLabel.SendToBack();
                    tempLabel.TextAlign = ContentAlignment.MiddleCenter;

                    // Adds the button to the controls
                    Controls.Add(tempLabel);
                }
                // Sets up the amount owed/paid
                else if (i == 6)
                {
                    string sPaidStatus = reader[g_strArrTableContents[7]].ToString();

                    if (sPaidStatus == "N/C")
                    {
                        tempLabel.Text = sPaidStatus;

                        tempLabel.BackColor = System.Drawing.Color.Pink;

                        tempLabel.Size = new Size(45, 20);
                    }
                    else if(sPaidStatus == "To Pay")
                    {
                        string sGetPrice = reader[g_strArrTableContents[i]].ToString();

                        if(sGetPrice == "")
                        {
                            tempLabel.Text = "Calculate";
                            tempLabel.BackColor = System.Drawing.Color.Red;
                            tempLabel.Size = new Size(75, 20);
                        }
                        else
                        {
                            float fParse = 0.0f;
                            float.TryParse(reader[g_strArrTableContents[i]].ToString(), out fParse);

                            tempLabel.Text = "$" + fParse.ToString("N2");
                            tempLabel.Size = new Size(150, 20);

                            tempLabel.BackColor = System.Drawing.Color.Yellow;
                        }
                    }
                    else
                    {
                        // Sets up the text for how much money is owed or is paid
                        string sGetPrice = reader[g_strArrTableContents[i]].ToString();

                        if(sGetPrice == "")
                        {
                            tempLabel.Text = "Calculate";
                            tempLabel.BackColor = System.Drawing.Color.Red;
                            tempLabel.Size = new Size(75, 20);
                        }
                        else
                        {
                            float fParse = 0.0f;
                            float.TryParse(reader[g_strArrTableContents[i]].ToString(), out fParse);

                            tempLabel.Text = "$" + fParse.ToString("N2");

                            tempLabel.Size = new Size(150, 20);
                        }
                    }

                    // Sets up the label
                    tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                    tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);


                    // Adds the button to the controls
                    Controls.Add(tempLabel);
                }
                // Sets up the paid status
                else if (i == 7)
                {
                    string sPaidStatus = reader[g_strArrTableContents[i]].ToString();

                    if (sPaidStatus == "To Pay")
                    {
                        // Sets the button name to the same as the Invoice number
                        tempButton.Name = reader[g_strArrTableContents[4]].ToString();

                        // Sets the button name to the same as the Paid Status
                        tempButton.Text = sPaidStatus;

                        // Sets up where the button is located and size
                        tempButton.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                        tempButton.Size = new Size(100, 20);

                        // Sends the button to the front
                        tempButton.BringToFront();

                        tempButton.BackColor = System.Drawing.Color.Yellow;

                        // Adds the button to the controls
                        Controls.Add(tempButton);

                        // Adds the click event to the event handler
                        tempButton.Click += new EventHandler(PaidStatus_Click);
                    }
                    else if (sPaidStatus == "OnAcc")
                    {
                        tempLabel.BackColor = System.Drawing.Color.Pink;

                        // Gets the text for the label from the array
                        tempLabel.Text = reader[g_strArrTableContents[i]].ToString();

                        // Sets up the label
                        tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                        tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                        tempLabel.Size = new Size(60, 20);

                        // Adds the button to the controls
                        Controls.Add(tempLabel);
                    }
                    else if (sPaidStatus == "N/C")
                    {
                        tempLabel.BackColor = System.Drawing.Color.Pink;

                        // Gets the text for the label from the array
                        tempLabel.Text = reader[g_strArrTableContents[i]].ToString();

                        // Sets up the label
                        tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                        tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                        tempLabel.Size = new Size(45, 20);

                        // Adds the button to the controls
                        Controls.Add(tempLabel);
                    }
                    else
                    {
                        tempLabel.BackColor = System.Drawing.Color.LightBlue;

                        // Gets the text for the label from the array
                        tempLabel.Text = reader[g_strArrTableContents[i]].ToString();

                        // Sets up the label
                        tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                        tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                        tempLabel.Size = new Size(60, 20);

                        // Adds the button to the controls
                        Controls.Add(tempLabel);
                    }
                }
                // Sets up the button for Notes
                else if (i == 10)
                {
                    string tempString = reader[g_strArrTableContents[i]].ToString();
                    string tempAlert = reader["Alerts"].ToString();

                    if (tempString != "")
                    {
                        // Sets the button name to the same as the Invoice Number
                        tempButton.Name = reader[g_strArrTableContents[4]].ToString();

                        // Sets the button Name to *
                        tempButton.Text = "Note";
                        tempButton.ForeColor = Color.White;

                        // Sets up the button
                        tempButton.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                        tempButton.Size = new Size(50, 20);
                        tempButton.BackColor = System.Drawing.Color.MediumPurple;
                        tempButton.BringToFront();

                        // Adds the button to the controls
                        Controls.Add(tempButton);

                        // Sets up the button with the eventhandler
                        tempButton.Click += new EventHandler(NotesButton_Click);

                        g_intLabelLocationX += 50;
                    }

                    
                    if (tempAlert != "")
                    {
                        Button Alert = new Button();

                        // Sets the button name to the same as the Invoice Number
                        Alert.Name = reader[g_strArrTableContents[4]].ToString();

                        // Sets the button Name to *
                        Alert.Text = "Alert";
                        Alert.ForeColor = Color.White;

                        // Sets up the button
                        Alert.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                        Alert.Size = new Size(50, 20);
                        Alert.BackColor = System.Drawing.Color.Red;
                        Alert.BringToFront();

                        // Adds the button to the controls
                        Controls.Add(Alert);

                        // Sets up the button with the eventhandler
                        Alert.Click += new EventHandler(AlertsButton_Click);

                        //g_intLabelLocationX += 30;
                    }
                }
                // Sets up all the other labels
                else
                {
                    if (i == 9 && chk_datebroughtin.Checked == true)
                    {
                        tempLabel.Text = "-";
                        tempLabel.Text = reader[g_strArrTableContents[8]].ToString();
                    }
                    else if (i == 8 && chk_datebroughtin.Checked == true)
                    {
                        //g_strDatePicked = dateTimePicker1.Value.DayOfWeek.ToString() + ", " +
                        //dateTimePicker1.Value.Day.ToString() + " " +
                        //dateTimePicker1.Value.ToString("MMMM") + " " +
                        //dateTimePicker1.Value.Year.ToString();

                        string DayTime = dateTimePicker1.Value.ToString("ddd").ToUpper() + ", " +
                        dateTimePicker1.Value.Day.ToString() + "-" +
                        dateTimePicker1.Value.ToString("MM") + "-" +
                        dateTimePicker1.Value.ToString("yy");

                        tempLabel.Text = DayTime;
                    }
                    else if (i == 8 && chk_datepaid.Checked == true)
                    {
                        tempLabel.Text = reader["DatePaid"].ToString();
                    }
                    else
                    {
                        // Gets the text for the label from the array
                        tempLabel.Text = reader[g_strArrTableContents[i]].ToString();
                    }

                    // Sets up the label
                    tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                    tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                    tempLabel.Size = new Size(150, 20);

                    // Adds the button to the controls
                    Controls.Add(tempLabel);
                }

                // Sets the X location along for the next label/iteration
                g_intLabelLocationX += iMoveXPosition;
            }

            // Sets the X position back to start the first line
            g_intLabelLocationX = 5;

            // Puts the next data 20 down on the Y
            g_intLabelLocationY += 20;

            // Add a divider line
            CreateLineDivider();

            // Puts the next data 20 down on the Y
            g_intLabelLocationY += 20;
        }
        #endregion

        #region Buttons
        private void AlertsButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            string query = @"SELECT Alerts FROM Invoice
                             WHERE InvoiceNumber = " + x + "";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string tempStr = reader["Alerts"].ToString();
                MessageBox.Show(tempStr, "Alert");

                break;
            }

            connection.Close();
        }

        private void NotesButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            string query = @"SELECT Notes FROM Invoice
                             WHERE InvoiceNumber = " + x + "";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string tempStr = reader["Notes"].ToString();
                MessageBox.Show(tempStr, "Note");

                break;
            }

            connection.Close();
        }

        private void InvoiceButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            //Invoice inv = new Invoice();

            //inv.SetUpFromCarReturns(x, this);

            //inv.Show();

            //CarReturnsInvoice cri = new CarReturnsInvoice(this);

            //cri.SetUpFromCarReturns(x);

            //cri.Show();
        }

        private void PaidStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            //Invoice inv = new Invoice();

            //inv.SetUpFromCarReturns(x, this);

            //inv.Show();

            //Button btn = (Button)sender;

            //int x = 0;
            //Int32.TryParse(btn.Name, out x);

            //CarReturnsInvoice cri = new CarReturnsInvoice(this);

            //cri.SetUpFromCarReturns(x);

            //cri.Show();
        }

        // In event method.
        private void PickUpStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            if (btn.Text == "No")
            {
                string sTabsStillOpen = "Has the car being picked up, and do you wish to release the keybox number?";

                DialogResult dialogResult = MessageBox.Show(sTabsStillOpen, "Picking Up Car", MessageBoxButtons.YesNo);

                string KeyNumber = "";

                if (dialogResult == DialogResult.Yes)
                {
                    connection.Open();

                    command = new OleDbCommand();

                    command.Connection = connection;

                    command.CommandText = @"UPDATE Invoice
                                        SET [PickUp] = True
                                        WHERE [InvoiceNumber] = " + x + "";

                    command.ExecuteNonQuery();

                    connection.Close();




                    connection.Open();

                    command = new OleDbCommand();

                    command.Connection = connection;

                    string s = btn.Name;

                    string query = @"select KeyNumber from Invoice WHERE InvoiceNumber = " + x + "";

                    command.CommandText = query;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        KeyNumber = reader["KeyNumber"].ToString();

                        break;
                    }

                    connection.Close();





                    // Releases the Keybox Number in KeyBox
                    connection.Open();

                    OleDbCommand command2 = new OleDbCommand();

                    command2.Connection = connection;

                    string temp = "";

                    string cmd1 = @"UPDATE KeyBox
                                SET [Rego] = '" + temp + "' WHERE [KeyBoxNumber] = '" + KeyNumber + "'";

                    command2.CommandText = cmd1;

                    command2.ExecuteNonQuery();

                    connection.Close();


                    RefreshNewTable();
                }
            }
            else if (btn.Text == "Yes")
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                command.CommandText = @"UPDATE Invoice 
                                        SET [PickUp] = False
                                        WHERE [InvoiceNumber] = " + x + "";


                command.ExecuteNonQuery();

                connection.Close();

                RefreshNewTable();
            }
        }

        private void btn_alertsnotes_Click(object sender, EventArgs e)
        {
            AlertsAndNotes aan = new AlertsAndNotes(g_strDatePicked);
            aan.ShowDialog();
            //aan.TopMost = true;
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dateTimePicker1.Value;

            dtStore = dtStore.AddDays(-1);

            dateTimePicker1.Value = dtStore;

            g_strDatePicked = dtStore.DayOfWeek.ToString() + ", " +
            dtStore.Day.ToString() + " " +
            dtStore.ToString("MMMM") + " " +
            dtStore.Year.ToString();

            RefreshNewTable();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dateTimePicker1.Value;

            dtStore = dtStore.AddDays(1);

            dateTimePicker1.Value = dtStore;

            g_strDatePicked = dtStore.DayOfWeek.ToString() + ", " +
            dtStore.Day.ToString() + " " +
            dtStore.ToString("MMMM") + " " +
            dtStore.Year.ToString();

            RefreshNewTable();
        }

        #endregion

        #region NavigationButtons
        private void btn_mainmenu_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["MainMenu"];

            if (fm.WindowState == FormWindowState.Minimized)
            {
                fm.WindowState = FormWindowState.Normal;
            }

            fm.BringToFront();
        }

        private void btn_invoice_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["InvoiceParent"];

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
                InvoiceParent ip = new InvoiceParent();
                ip.Show();
            }
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
        #endregion

        #region CheckBoxes

        private void chk_returndate_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_returndate.Checked == true)
            {
                chk_datebroughtin.Checked = false;
                chk_datepaid.Checked = false;
            }
        }

        private void chk_datebroughtin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_datebroughtin.Checked == true)
            {
                chk_returndate.Checked = false;
                chk_datepaid.Checked = false;
            }
        }

        private void chk_datepaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_datepaid.Checked == true)
            {
                chk_returndate.Checked = false;
                chk_datebroughtin.Checked = false;
            }
        }

        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            g_strDatePicked = dateTimePicker1.Value.DayOfWeek.ToString() + ", " +
            dateTimePicker1.Value.Day.ToString() + " " +
            dateTimePicker1.Value.ToString("MMMM") + " " +
            dateTimePicker1.Value.Year.ToString();

            RefreshNewTable();
        }

        private void chk_filters_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_filters.Checked)
            {
                chkbox_cash.Visible = true;
                chkbox_eftpos.Visible = true;
                chkbox_internet.Visible = true;
                chkbox_cheque.Visible = true;
                chkbox_stilltopay.Visible = true;
                chkbox_onaccount.Visible = true;
                chkbox_internet.Visible = true;
                chkbox_nocharge.Visible = true;
                chkbox_creditcard.Visible = true;

                chkbox_cash.Checked = false;
                chkbox_eftpos.Checked = false;
                chkbox_internet.Checked = false;
                chkbox_cheque.Checked = false;
                chkbox_stilltopay.Checked = false;
                chkbox_onaccount.Checked = false;
                chkbox_internet.Checked = false;
                chkbox_nocharge.Checked = false;
                chkbox_creditcard.Checked = false;
            }
            else if(!chk_filters.Checked)
            {
                chkbox_cash.Visible = false;
                chkbox_eftpos.Visible = false;
                chkbox_internet.Visible = false;
                chkbox_cheque.Visible = false;
                chkbox_stilltopay.Visible = false;
                chkbox_onaccount.Visible = false;
                chkbox_internet.Visible = false;
                chkbox_nocharge.Visible = false;
                chkbox_creditcard.Visible = false;

                chkbox_cash.Checked = true;
                chkbox_eftpos.Checked = true;
                chkbox_internet.Checked = true;
                chkbox_cheque.Checked = true;
                chkbox_stilltopay.Checked = true;
                chkbox_onaccount.Checked = true;
                chkbox_internet.Checked = true;
                chkbox_nocharge.Checked = true;
                chkbox_creditcard.Checked = true;
            }
        }
    }
}