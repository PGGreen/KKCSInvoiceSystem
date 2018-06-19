using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Xml;

namespace KKCSInvoiceProject
{
    public partial class Bookings : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        bool bIsAlreadySaved = false;

        int m_iID = 0;

        bool bIsSetUpFromEdit = false;

        public Bookings()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            cmb_flightleaving.SelectedIndex = 0;
            txt_flighttimes.SelectedIndex = 0;

            PopulateRegoBox();
            FindFlightTimesXML();
            FindFlightTimesOutFlightXML();
            PopulateAccountBox();
            PopulateMakeModel();

            cmb_rego.Select();
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

            cmd_accountlist.Items.Add("");

            while (reader.Read())
            {
                sFirstName = reader["Account"].ToString();

                if (sFirstName != sSecondName)
                {
                    sSecondName = sFirstName;

                    cmd_accountlist.Items.Add(sFirstName);
                }
            }

            cmd_accountlist.SelectedIndex = 0;

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void cmb_rego_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;

            if (!bIsSetUpFromEdit)
            {
                // Opens the connection to the database
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Checks to see if the NumberPlate already exists
                string cmdStr = @"SELECT COUNT(*) FROM Bookings
                        WHERE Rego = '" + cmb_rego.Text + "' AND BookingFinished = FALSE";

                // Runs the command from above to search the database
                OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

                count = (int)cmd.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            if (count == 0)
            {
                CheckDatabase();
            }
            else if(count > 0)
            {
                string sWarning = "This Rego (" + cmb_rego.Text + ") already\r\nhas an active booking.";

                WarningSystem ws = new WarningSystem(sWarning, false);
                ws.ShowDialog();

                cmb_rego.Text = "";
            }
        }

        public void SetUpFromBookingsManager(int _id)
        {
            bIsSetUpFromEdit = true;

            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from Bookings WHERE ID="+ _id + "";

            command.CommandText = query;

            reader = command.ExecuteReader();

            string sRego = "";

            while(reader.Read())
            {
                sRego = reader["Rego"].ToString();
                dt_customerleaving.Value = (DateTime)reader["DateCustomerLeaving"];
                cmb_flightleaving.Text = reader["FlightTimeLeaving"].ToString();
                txt_notes.Text = reader["Notes"].ToString();
                dt_returndate.Value = (DateTime)reader["DateCustomerPickingUp"];
                txt_flighttimes.Text = reader["FlightTimePickingUp"].ToString();

                int.TryParse(reader["ID"].ToString(), out m_iID);
            }

            connection.Close();

            cmb_rego.Text = sRego;

            this.BackColor = Color.LightGreen;
            btn_save.BackColor = Color.Green;
            btn_save.Text = "Saved";

            WarningsStoreOriginalValues();

            bIsAlreadySaved = true;
        }

        void UpdateDatabase()
        {
            // Closes the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            // Make the command equal the physical location of the database (connection)
            command.Connection = connection;

            string cmd1 = @"UPDATE Bookings SET
                                    Rego = '" + cmb_rego.Text +
                                "', DateCustomerLeaving = '" + dt_returndate.Value +
                                "', FlightTimeLeaving = '" + cmb_flightleaving.Text +
                                "', FName = '" + txt_firstname.Text +
                                "', LName = '" + txt_lastname.Text +
                                "', Ph = '" + txt_ph.Text +
                                "', Make = '" + cmb_makemodel.Text +
                                "', Account = '" + cmd_accountlist.Text +
                                "', AccountPart = '" + txt_particulars.Text +
                                "', DateCustomerPickingUp = '" + dt_returndate.Value +
                                "', FlightTimePickingUp = '" + txt_flighttimes.Text +
                                "', Notes = '" + txt_notes.Text +
                                "' WHERE ID = " + m_iID + "";

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

        void CheckDatabase()
        {
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
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            CheckIfAccount();
        }

        private void CheckIfAccount()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"select * from Accounts where Rego = '" + cmb_rego.Text + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                cmd_accountlist.Text = reader["Account"].ToString();
                txt_particulars.Text = reader["AccountParticulars"].ToString();
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void PopulateRegoBox()
        {
            object[] a = new object[MyAppManager.MainMenuInstance.GetCmbRegoComboBox().Items.Count];
            MyAppManager.MainMenuInstance.GetCmbRegoComboBox().Items.CopyTo(a, 0);
            cmb_rego.Items.AddRange(a);
        }

        void SaveData()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtCustomerLeaving = new DateTime(dt_customerleaving.Value.Year, dt_customerleaving.Value.Month, dt_customerleaving.Value.Day, 12, 0, 0);
            DateTime dtCustomerReturn = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, 12, 0, 0);

            string query = @"INSERT INTO Bookings (DateCustomerLeaving,Rego,FlightTimeLeaving,FName,LName,Ph,Make,Account,AccountPart,DateCustomerPickingUp,FlightTimePickingUp,Notes)
                    values ('" + dtCustomerLeaving +
                    "','" + cmb_rego.Text +
                    "','" + cmb_flightleaving.Text +
                    "','" + txt_firstname.Text +
                    "','" + txt_lastname.Text +
                    "','" + txt_ph.Text +
                    "','" + cmb_makemodel.Text +
                    "','" + cmd_accountlist.Text +
                    "','" + txt_particulars.Text +
                    "','" + dtCustomerReturn +
                    "','" + txt_flighttimes.Text +
                    "','" + txt_notes.Text +
                    "')";

            command.CommandText = query;

            command.ExecuteNonQuery();

            connection.Close();
        }

        void FindFlightTimesXML()
        {
            XmlReader xmlReader = XmlReader.Create("Data/XML/FlightTimes.xml");

            string sDatePicked = dt_returndate.Value.Year + "-" + dt_returndate.Value.Month + "-" + dt_returndate.Value.Day;

            txt_flighttimes.Items.Clear();

            txt_flighttimes.Items.Add("Time Not Known");

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
                            txt_flighttimes.Items.Add("1215 - NZ8274");
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
                            txt_flighttimes.Items.Add("1215 - NZ8274");
                            txt_flighttimes.Items.Add("1440 - NZ8268");
                            txt_flighttimes.Items.Add("1720 - NZ8270");
                            txt_flighttimes.Items.Add("2025 - NZ8272");

                            break;
                        }
                }
            }

            txt_flighttimes.SelectedIndex = 0;
        }

        void FindFlightTimesOutFlightXML()
        {
            string sDatePicked = dt_customerleaving.Value.Year + "-" + dt_customerleaving.Value.Month + "-" + dt_customerleaving.Value.Day;

            cmb_flightleaving.Items.Clear();

            cmb_flightleaving.Items.Add("Time Not Known");

            if (cmb_flightleaving.Items.Count <= 2)
            {
                string sDay = dt_customerleaving.Value.ToString("dddd");
                switch (sDay)
                {
                    case "Saturday":
                        {
                            cmb_flightleaving.Items.Add("0640 - NZ8275");
                            cmb_flightleaving.Items.Add("0945 - NZ8267");
                            cmb_flightleaving.Items.Add("1240 - NZ8273");
                            cmb_flightleaving.Items.Add("1745 - NZ8271");

                            break;
                        }
                    case "Sunday":
                        {
                            cmb_flightleaving.Items.Add("0945 - NZ8267");
                            cmb_flightleaving.Items.Add("1505 - NZ8269");
                            cmb_flightleaving.Items.Add("1745 - NZ8271");

                            break;
                        }
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        {
                            cmb_flightleaving.Items.Add("0600 - NZ8275");
                            cmb_flightleaving.Items.Add("0945 - NZ8267");
                            cmb_flightleaving.Items.Add("1505 - NZ8269");
                            cmb_flightleaving.Items.Add("1745 - NZ8271");

                            break;
                        }
                }
            }

            cmb_flightleaving.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dt_returndate_ValueChanged(object sender, EventArgs e)
        {
            FindFlightTimesXML();
        }

        private void PopulateMakeModel()
        {
            object[] a = new object[MyAppManager.MainMenuInstance.GetCmbMakeModelComboBox().Items.Count];
            MyAppManager.MainMenuInstance.GetCmbMakeModelComboBox().Items.CopyTo(a, 0);
            cmb_makemodel.Items.AddRange(a);
        }

        private void btn_dlleft_Click(object sender, EventArgs e)
        {
            dt_customerleaving.Value = dt_customerleaving.Value.AddDays(-1);
        }

        private void btn_dlright_Click(object sender, EventArgs e)
        {
            dt_customerleaving.Value = dt_customerleaving.Value.AddDays(1);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(btn_save.Text != "Saved")
            {
                if(cmb_rego.Text == "")
                {
                    WarningSystem ws = new WarningSystem("Missing Rego", false);
                    ws.ShowDialog();

                    return;
                }

                SaveData();

                m_iID = GetId();

                InsertIntoNumberPlates();
                InsertIntoAccounts();

                this.BackColor = Color.LightGreen;
                btn_save.BackColor = Color.Green;
                btn_save.Text = "Saved";

                WarningsStoreOriginalValues();

                bIsAlreadySaved = true;
            }
        }

        private void dt_dateleft_Click(object sender, EventArgs e)
        {
            dt_returndate.Value = dt_returndate.Value.AddDays(-1);
        }

        private void dt_dateright_Click(object sender, EventArgs e)
        {
            dt_returndate.Value = dt_returndate.Value.AddDays(1);
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
                        WHERE NumberPlates = '" + cmb_rego.Text + "'";

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
                string cmd1 = @"INSERT into NumberPlates (NumberPlates,ClientName,LastName,MakeModel,Ph
                                                            ) values
                                                            ('" + cmb_rego.Text + "','" +
                                                                txt_firstname.Text + "','" +
                                                                txt_lastname.Text + "','" +
                                                                cmb_makemodel.Text + "','" +
                                                                txt_ph.Text +
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

                //string sRemaining = "";

                string cmd1 = @"UPDATE NumberPlates SET
                                    NumberPlates = '" + cmb_rego.Text +
                                    "', ClientName = '" + txt_firstname.Text +
                                    "', LastName = '" + txt_lastname.Text +
                                    "', MakeModel = '" + cmb_makemodel.Text +
                                    "', Ph = '" + txt_ph.Text +
                                    "' WHERE NumberPlates = '" + cmb_rego.Text + "'";

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
                                                                cmd_accountlist.Text + "','" +
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
                                    "', Account = '" + cmd_accountlist.Text +
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

        int GetId()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Bookings ORDER BY ID DESC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            int iID = 0;

            while (reader.Read())
            {
                int.TryParse(reader["ID"].ToString(), out iID);

                break;
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return (iID);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            UpdateDatabase();
            InsertIntoNumberPlates();
            InsertIntoAccounts();

            WarningsStoreOriginalValues();

            this.BackColor = Color.LightGreen;
            btn_update.Visible = false;
        }

        #region ValuesChanges

        private void cmb_makemodel_TextChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void cmb_text_TextChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void dt_customerleaving_ValueChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void txt_flighttimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void cmb_flightleaving_SelectedIndexChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void txt_firstname_TextChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void txt_lastname_TextChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void txt_ph_TextChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void cmb_makemodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void cmd_accountlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void txt_particulars_TextChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        private void txt_notes_TextChanged(object sender, EventArgs e)
        {
            WarningsChangesMade();
        }

        DateTime dtOriginalLeave;
        DateTime dtOriginalReturn;

        private void chk_unkleave_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_unkleave.Checked)
            {
                dtOriginalLeave = dt_customerleaving.Value;

                DateTime dtUnkLeave = new DateTime(2001, 1, 1, 12, 0, 0);
                dt_customerleaving.Value = dtUnkLeave;
                dt_customerleaving.Visible = false;
            }
            else
            {
                dt_customerleaving.Value = dtOriginalLeave;
                dt_customerleaving.Visible = true;
            }

            WarningsChangesMade();

        }

        private void chk_unkreturn_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_unkreturn.Checked)
            {
                dtOriginalReturn = dt_returndate.Value;

                DateTime dtUnkReturn = new DateTime(2001, 1, 1, 12, 0, 0);
                dt_returndate.Value = dtUnkReturn;
                dt_returndate.Visible = false;
            }
            else
            {
                dt_returndate.Value = dtOriginalReturn;
                dt_returndate.Visible = true;
            }

            WarningsChangesMade();

        }

        #endregion ValueChanges

        #region Changes

        List<string> lstOriginalValues = new List<string>();
        List<string> lstCheckValues = new List<string>();

        void WarningsStoreOriginalValues()
        {
            lstOriginalValues = new List<string>();

            lstOriginalValues.Add(cmb_rego.Text);
            lstOriginalValues.Add(dt_customerleaving.Value.ToString());
            lstOriginalValues.Add(cmb_flightleaving.Text);
            lstOriginalValues.Add(txt_firstname.Text);
            lstOriginalValues.Add(txt_lastname.Text);
            lstOriginalValues.Add(txt_ph.Text);
            lstOriginalValues.Add(cmb_makemodel.Text);
            lstOriginalValues.Add(cmd_accountlist.Text);
            lstOriginalValues.Add(txt_particulars.Text);
            lstOriginalValues.Add(dt_returndate.Value.ToString());
            lstOriginalValues.Add(txt_flighttimes.Text);
            lstOriginalValues.Add(txt_notes.Text);
        }

        void WarningsChangesMade()
        {
            if (bIsAlreadySaved)
            {
                lstCheckValues = new List<string>();

                lstCheckValues.Add(cmb_rego.Text);
                lstCheckValues.Add(dt_customerleaving.Value.ToString());
                lstCheckValues.Add(cmb_flightleaving.Text);
                lstCheckValues.Add(txt_firstname.Text);
                lstCheckValues.Add(txt_lastname.Text);
                lstCheckValues.Add(txt_ph.Text);
                lstCheckValues.Add(cmb_makemodel.Text);
                lstCheckValues.Add(cmd_accountlist.Text);
                lstCheckValues.Add(txt_particulars.Text);
                lstCheckValues.Add(dt_returndate.Value.ToString());
                lstCheckValues.Add(txt_flighttimes.Text);
                lstCheckValues.Add(txt_notes.Text);

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
                    btn_update.Visible = true;
                }
                else
                {
                    this.BackColor = Color.LightGreen;
                    btn_update.Visible = false;
                }
            }
        }

        #endregion Changes
    }
}