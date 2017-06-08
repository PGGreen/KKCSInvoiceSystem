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
    public partial class MoneyInYard : Form
    {
        #region GlobalVariables
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        // Creates the OleDbConnection
        private OleDbConnection connection = new OleDbConnection();

        // Sets up the main OleDb Command
        OleDbCommand command;

        OleDbDataReader reader;

        int g_intLabelName = 0;

        // Initial location of labels
        int g_intLabelLocationX = 60;
        int g_intLabelLocationY = 60;

        string EODDate = "";

        DateTime EODDateTime;

        int iMoveXPosition = 130;

        string[] g_strArrTableHeaders;
        string[] g_strArrTableContents;

        float fTempStoreMoney = 0.0f;
        float fStartOfDay = 0.0f;
        float fStartOfDayTin = 0.0f;

        string g_strDatePicked = "";
        #endregion

        public MoneyInYard()
        {
            InitializeComponent();

            // Initialises the connection to the file path
            connection.ConnectionString = m_strDataBaseFilePath;

            EODDateTime = DateTime.Today;

            //EODDate = EODDateTime.Day.ToString() + "/" + EODDateTime.Month.ToString("00") + "/" + EODDateTime.ToString("yy");

            g_strDatePicked = dateTimePicker1.Value.DayOfWeek.ToString() + ", " +
            dateTimePicker1.Value.Day.ToString() + " " +
            dateTimePicker1.Value.ToString("MMMM") + " " +
            dateTimePicker1.Value.Year.ToString();

            EODDate = dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Month.ToString("00") + "/" + dateTimePicker1.Value.ToString("yy");

            DateTime dt = dateTimePicker1.Value;

            string datesd = dt.AddDays(1).ToString();
            //g_strDatePicked = "Sunday, 8 May 2016";

            // Creates the Array for Text
            CreateQueryArray();

            RefreshNewTable();
        }

        void CreateQueryArray()
        {
            // Sets the names for the Table Headers
            g_strArrTableHeaders = new string[] { "Rego/Item", "Inv No.", "Amount", "", "Total Cash", "Running Total", "", "Item", "Amount", "Running Total"};

            // Sets up the array for pulling information out of the database
            g_strArrTableContents = new string[] { "Rego", "InvoiceNumber", "TotalPay"};
        }

        void RefreshNewTable()
        {
            // Resets the Label Location
            g_intLabelLocationY = 60;

            CreateHeaders();

            StartOfDayDatabase();

            StartOfDayTill();

            StartOfDayTin();

            // Creates the Table
            CreateCashTable();

            g_intLabelLocationY += 25;

            CreateRefundsTable();

            g_intLabelLocationY += 25;

            CreatePettyCashTable();

            g_intLabelLocationY += 25;

            CreateBankingTable();

            CreateEndOfDayTable();
        }

        #region StartOfDay
        void StartOfDayDatabase()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM MoneyInYard WHERE DateYard = '" + EODDate + "'";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                fStartOfDay = float.Parse(reader["SOD"].ToString());
                fStartOfDayTin = float.Parse(reader["TinSOD"].ToString());
            }

            connection.Close();
        }

        // Gets the start of the day till
        void StartOfDayTill()
        {
            // Creates a new label for use for each part of the table
            Label tempLabel = new Label();

            g_intLabelLocationX = 710;

            // Sets up the label
            tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
            tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
            tempLabel.Size = new Size(150, 20);
            tempLabel.BackColor = Color.LightGreen;

            tempLabel.Text = "SOD: " + fStartOfDay.ToString("0.00");

            // Adds the label to the controls
            Controls.Add(tempLabel);

            // Moves the label location down ready for Time Header
            //g_intLabelLocationY += 30;
        }

        void StartOfDayTin()
        {
            // Creates a new label for use for each part of the table
            Label tempLabel = new Label();

            g_intLabelLocationX = 1230;

            // Sets up the label
            tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
            tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
            tempLabel.Size = new Size(150, 20);
            tempLabel.BackColor = Color.LightGreen;

            tempLabel.Text = "SOD: " + fStartOfDayTin.ToString("0.00");

            // Adds the label to the controls
            Controls.Add(tempLabel);

            // Moves the label location down ready for Time Header
            g_intLabelLocationY += 30;
        }
        #endregion

        // Creates the title headers
        void CreateHeaders()
        {
            // Resets location and counter back to the start
            g_intLabelName = 0;
            g_intLabelLocationX = 60;

            for (int i = 0; i < g_strArrTableHeaders.Length; i++)
            {
                // Sets up new label for the header
                Label tempLabel = new Label();
                tempLabel.Text = g_strArrTableHeaders[i];
                tempLabel.Font = new Font("Arial", 12, FontStyle.Regular | FontStyle.Underline);
                tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                tempLabel.Size = new Size(100, 20);
                tempLabel.Name = "Header" + g_intLabelName.ToString();

                // Moves the next header along by 150 pixels
                g_intLabelLocationX += iMoveXPosition;

                // Adds the label to the controls
                Controls.Add(tempLabel);

                // Increments the label name
                g_intLabelName += 1;
            }

            // Moves the label location down ready for Time Header
            g_intLabelLocationY += 25;
        }

        #region CashLabels
        // Creates the table for the days cash invoices
        void CreateCashTable()
        {
            // Opens and creates the connection for the database
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select ID,ClientName,Rego,MakeModel,InvoiceNumber,KeyNumber,
                            TotalPay,PaidStatus,AccountHolder,PickUp,DisplayedReturnDate,ReturnTime,Notes
                            from Invoice WHERE DatePaid = '" + g_strDatePicked + "' AND PaidStatus = 'Cash'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Creates the labels for that record
                CreateCashLabels();
            }

            // Closes the connection
            connection.Close();
        }

        void CreateCashLabels()
        {
            //   0           1             2            3
            //"Rego", "InvoiceNumber", "TotalPay", "PaidStatus" };

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Iterates through each label
            for (int i = 0; i < g_strArrTableHeaders.Length; i++)
            {
                // Creates a new label for use for each part of the table
                Label tempLabel = new Label();

                // Sets up the label
                tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                tempLabel.Size = new Size(100, 20);

                if (i < 2)
                {
                    // Gets the text for the label from the array
                    tempLabel.Text = reader[g_strArrTableContents[i]].ToString();
                }
                else if(i == 2)
                {
                    float x = 0.0f;
                    float.TryParse(reader[g_strArrTableContents[i]].ToString(), out x);

                    tempLabel.Text = "$" + x.ToString(".00");
                }
                else if (i == 4)
                {
                    float x = 0.0f;
                    float.TryParse(reader[g_strArrTableContents[2]].ToString(), out x);

                    fTempStoreMoney += x;

                    tempLabel.Text = "$" + fTempStoreMoney.ToString(".00");
                }
                else if(i == 5)
                {
                    float x = 0.0f;
                    float.TryParse(reader[g_strArrTableContents[2]].ToString(), out x);

                    fStartOfDay += x;

                    tempLabel.Text = "$" + fStartOfDay.ToString(".00");
                }

                // Adds the button to the controls
                Controls.Add(tempLabel);

                // Sets the X location along for the next label/iteration
                g_intLabelLocationX += iMoveXPosition;
            }

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Puts the next data 20 down on the Y
            g_intLabelLocationY += 30;
        }
        #endregion

        #region PettyCashLabels
        // Creates the tables for the days petty cash
        void CreatePettyCashTable()
        {
            // Opens and creates the connection for the database
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT Item,Amount1,DatePetty,Amount1Location from PettyCash WHERE DatePetty = '" + g_strDatePicked + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Creates the labels for that record
                CreatePettyCashLabels();
            }

            // Closes the connection
            connection.Close();
        }

        void CreatePettyCashLabels()
        {
            //   0           1             2            3
            //"Rego", "InvoiceNumber", "TotalPay", "PaidStatus" };

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            if (reader["Amount1Location"].ToString() == "Till")
            {
                // Iterates through each label
                for (int i = 0; i < g_strArrTableHeaders.Length; i++)
                {
                    // Creates a new label for use for each part of the table
                    Label tempLabel = new Label();

                    // Sets up the label
                    tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                    tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                    tempLabel.Size = new Size(100, 20);

                    if (i == 0)
                    {
                        tempLabel.Text = reader["Item"].ToString();
                    }
                    if (i == 1)
                    {
                        tempLabel.Text = "Petty Cash";
                    }
                    else if (i == 2)
                    {
                        float x = 0.0f;
                        float.TryParse(reader["Amount1"].ToString(), out x);

                        //fTempStoreMoney += x;

                        tempLabel.Text = "-$" + x.ToString("0.00");
                    }
                    else if (i == 4)
                    {
                        float x = 0.0f;
                        float.TryParse(reader["Amount1"].ToString(), out x);

                        fTempStoreMoney -= x;

                        tempLabel.Text = "$" + fTempStoreMoney.ToString("0.00");
                    }
                    else if (i == 5)
                    {
                        float x = 0.0f;
                        float.TryParse(reader["Amount1"].ToString(), out x);

                        fStartOfDay -= x;

                        tempLabel.Text = "$" + fStartOfDay.ToString("0.00");
                    }

                    // Adds the button to the controls
                    Controls.Add(tempLabel);

                    // Sets the X location along for the next label/iteration
                    g_intLabelLocationX += iMoveXPosition;
                }
            }
            else if(reader["Amount1Location"].ToString() == "Tin")
            {
                // Iterates through each label
                for (int i = 0; i < g_strArrTableHeaders.Length; i++)
                {
                    // Creates a new label for use for each part of the table
                    Label tempLabel = new Label();

                    // Sets up the label
                    tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                    tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                    tempLabel.Size = new Size(100, 20);

                    if (i == 7)
                    {
                        tempLabel.Text = reader["Item"].ToString() + "/Petty Cash";
                    }
                    if (i == 8)
                    {
                        float x = 0.0f;
                        float.TryParse(reader["Amount1"].ToString(), out x);

                        //fTempStoreMoney += x;

                        tempLabel.Text = "-$" + x.ToString("0.00");
                    }
                    else if (i == 9)
                    {
                        float x = 0.0f;
                        float.TryParse(reader["Amount1"].ToString(), out x);

                        fStartOfDayTin -= x;

                        tempLabel.Text = "$" + fStartOfDayTin.ToString("0.00");
                    }

                    // Adds the button to the controls
                    Controls.Add(tempLabel);

                    // Sets the X location along for the next label/iteration
                    g_intLabelLocationX += iMoveXPosition;
                }
            }

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Puts the next data 20 down on the Y
            g_intLabelLocationY += 30;
        }
        #endregion

        #region BankingTable
        void CreateBankingTable()
        {
            // Opens and creates the connection for the database
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Banking WHERE DateBanking = '" + EODDate + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Creates the labels for that record
                CreateBankingLabels();
            }

            // Closes the connection
            connection.Close();
        }

        void CreateBankingLabels()
        {
            // Iterates through each label
            for (int i = 0; i < g_strArrTableHeaders.Length; i++)
            {
                // Creates a new label for use for each part of the table
                Label tempLabel = new Label();

                // Sets up the label
                tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                tempLabel.Size = new Size(100, 20);

                if (i == 7)
                {
                    tempLabel.Text = "Banking";
                }
                if (i == 8)
                {
                    float x = 0.0f;
                    float.TryParse(reader["Amount"].ToString(), out x);

                    tempLabel.Text = "-$" + x.ToString("0.00");

                    fStartOfDayTin -= x;
                }       
                else if (i == 9)
                {
                    //float x = 0.0f;
                    //float.TryParse(reader["Amount1"].ToString(), out x);

                    //fStartOfDayTin -= x;

                    tempLabel.Text = "$" + fStartOfDayTin.ToString("0.00");
                }

                // Adds the button to the controls
                Controls.Add(tempLabel);

                // Sets the X location along for the next label/iteration
                g_intLabelLocationX += iMoveXPosition;


            }

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Puts the next data 20 down on the Y
            g_intLabelLocationY += 30;

        }
        #endregion

        #region RefundsLabels
        // Creates the tables for the days refunds
        void CreateRefundsTable()
        {
            // Opens and creates the connection for the database
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Refunds WHERE DateRefund = '" + g_strDatePicked + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Creates the labels for that record
                CreateRefundsLabels();
            }

            // Closes the connection
            connection.Close();
        }

        void CreateRefundsLabels()
        {
            //   0           1             2            3
            //"Rego", "InvoiceNumber", "TotalPay", "PaidStatus" };

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Iterates through each label
            for (int i = 0; i < g_strArrTableHeaders.Length; i++)
            {
                // Creates a new label for use for each part of the table
                Label tempLabel = new Label();

                // Sets up the label
                tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                tempLabel.Size = new Size(100, 20);

                if (i == 0)
                {
                    tempLabel.Text = reader["Rego"].ToString();
                }
                if (i == 1)
                {
                    tempLabel.Text = reader["InvoiceNumber"].ToString() + " (Refund)";
                    //tempLabel.BackColor = Color.Yellow;
                }
                else if (i == 2)
                {
                    float x = 0.0f;
                    float.TryParse(reader["Refund1"].ToString(), out x);

                    //fTempStoreMoney += x;

                    tempLabel.Text = "-$" + x.ToString(".00");
                }
                else if (i == 4)
                {
                    float x = 0.0f;
                    float.TryParse(reader["Refund1"].ToString(), out x);

                    fTempStoreMoney -= x;

                    tempLabel.Text = "$" + fTempStoreMoney.ToString(".00");
                }
                else if (i == 5)
                {
                    float x = 0.0f;
                    float.TryParse(reader["Refund1"].ToString(), out x);

                    fStartOfDay -= x;

                    tempLabel.Text = "$" + fStartOfDay.ToString(".00");
                }

                // Adds the button to the controls
                Controls.Add(tempLabel);

                // Sets the X location along for the next label/iteration
                g_intLabelLocationX += iMoveXPosition;
            }

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Puts the next data 20 down on the Y
            g_intLabelLocationY += 30;
        }
        #endregion

        #region EndOfDays
        void CreateEndOfDayTable()
        {
            // Opens and creates the connection for the database
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string g_sDateYard =
            dateTimePicker1.Value.Day.ToString() + "/" +
            dateTimePicker1.Value.ToString("MM") + "/" +
            dateTimePicker1.Value.ToString("yy");

            string query = @"SELECT * FROM MoneyInYard WHERE DateYard = '" + g_sDateYard + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader["DayEnded"].ToString() == "True")
                {
                    // Creates the labels for that record
                    CreateEndOfDayLabels();
                }
            }

            // Closes the connection
            connection.Close();
        }

        // Creates the end of day
        void CreateEndOfDayLabels()
        {
            //   0           1             2            3
            //"Rego", "InvoiceNumber", "TotalPay", "PaidStatus" };

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Iterates through each label
            for (int i = 0; i < g_strArrTableHeaders.Length; i++)
            {
                // Creates a new label for use for each part of the table
                Label tempLabel = new Label();

                // Sets up the label
                tempLabel.Font = new Font("Arial", 12, FontStyle.Regular);
                tempLabel.Location = new Point(g_intLabelLocationX, g_intLabelLocationY);
                
                
                if (i == 4)
                {
                    tempLabel.Size = new Size(150, 20);

                    tempLabel.BackColor = Color.Yellow;

                    tempLabel.Text = "EOD: $" + fTempStoreMoney.ToString(".00");
                }
                else if (i == 5)
                {
                    //tempLabel.Size = new Size(70, 20);

                    //tempLabel.BackColor = Color.Yellow;

                    //tempLabel.Text = "$" + fStartOfDay.ToString(".00");
                }
                else if (i == 6)
                {

                    if (fTempStoreMoney >= 0.0f)
                    {
                        tempLabel.BackColor = Color.LightBlue;
                        tempLabel.Text = "----->";
                        tempLabel.Size = new Size(50, 20);
                    }

                }
                else if(i == 7)
                {
                    tempLabel.Size = new Size(110, 20);

                    if (fTempStoreMoney >= 0.0f)
                    {
                        tempLabel.Text = "EOD Transfer";
                        tempLabel.BackColor = Color.Yellow;
                    }      
                }
                else if(i == 8)
                {
                    if (fTempStoreMoney >= 0.0f)
                    {
                        tempLabel.Size = new Size(110, 20);

                        tempLabel.BackColor = Color.Yellow;

                        tempLabel.Text = "$" + fTempStoreMoney.ToString(".00");
                    }
                }
                else if(i == 9)
                {
                    tempLabel.Size = new Size(140, 20);

                    tempLabel.BackColor = Color.Yellow;

                    if (fTempStoreMoney >= 0.0f)
                    {
                        float TinEOD = fTempStoreMoney + fStartOfDayTin;
                        tempLabel.Text = "EOD: $" + TinEOD.ToString(".00");
                    }
                    else
                    {
                        tempLabel.Text = "EOD: $" + fStartOfDayTin;
                    }
                }

                // Adds the button to the controls
                Controls.Add(tempLabel);

                // Sets the X location along for the next label/iteration
                g_intLabelLocationX += iMoveXPosition;
            }

            // Sets the X position back to start the first line
            g_intLabelLocationX = 60;

            // Puts the next data 20 down on the Y
            g_intLabelLocationY += 30;
        }
        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadNewPage();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LoadNewPage();
        }

        void LoadNewPage()
        {
            fTempStoreMoney = 0.0f;
            fStartOfDay = 0.0f;
            fStartOfDayTin = 0.0f;

            g_strDatePicked = dateTimePicker1.Value.DayOfWeek.ToString() + ", " +
            dateTimePicker1.Value.Day.ToString() + " " +
            dateTimePicker1.Value.ToString("MMMM") + " " +
            dateTimePicker1.Value.Year.ToString();

            EODDate = dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Month.ToString("00") + "/" + dateTimePicker1.Value.ToString("yy");

            // Wipes all the labels for refrehsing or setting up new table
            foreach (Label lb in this.Controls.OfType<Label>().ToArray())
            {
                if (lb.Name == "txt_tillheader" || lb.Name == "txt_headertin")
                {
                    // Do Nothing
                }
                else
                {
                    lb.Text = string.Empty;
                    Controls.Remove(lb);
                }
            }

            RefreshNewTable();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
        }
    }
}