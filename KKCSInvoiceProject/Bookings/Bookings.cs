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
        OleDbCommand command;
        OleDbDataReader reader;

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
            CheckDatabase();
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

            OleDbDataReader reader = command.ExecuteReader();

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

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"INSERT INTO Bookings (DateCustomerLeaving,FlightTimeLeaving,FName,LName,Ph,Make,Account,AccountPart,DateCustomerPickingUp,FlightTimePickingUp,Stay,Price,Notes) 
                    values ('" + dt_customerleaving.Value + 
                    "','" + cmb_flightleaving.Text +
                    "','" + txt_firstname.Text +
                    "','" + txt_lastname.Text +
                    "','" + txt_ph.Text +
                    "','" + cmb_makemodel.Text +
                    "','" + cmd_accountlist.Text +
                    "','" + txt_particulars.Text +
                    "','" + dt_returndate.Value +
                    "','" + txt_flighttimes.Text +
                    "','" + lbl_staytext.Text +
                    "','" + txt_total.Text +
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

            txt_flighttimes.Items.Add("Not Known");

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

            cmb_flightleaving.Items.Add("Not Known");

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
                    case "Monday":
                        {
                            cmb_flightleaving.Items.Add("0920 - NZ8266");
                            cmb_flightleaving.Items.Add("1215 - NZ8274");
                            cmb_flightleaving.Items.Add("1440 - NZ8268");
                            cmb_flightleaving.Items.Add("1720 - NZ8270");
                            cmb_flightleaving.Items.Add("2025 - NZ8272");

                            break;
                        }
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                        {
                            cmb_flightleaving.Items.Add("0920 - NZ8266");
                            cmb_flightleaving.Items.Add("1440 - NZ8268");
                            cmb_flightleaving.Items.Add("1720 - NZ8270");
                            cmb_flightleaving.Items.Add("2025 - NZ8272");

                            break;
                        }
                    case "Friday":
                        {
                            cmb_flightleaving.Items.Add("0920 - NZ8266");
                            cmb_flightleaving.Items.Add("1215 - NZ8274");
                            cmb_flightleaving.Items.Add("1440 - NZ8268");
                            cmb_flightleaving.Items.Add("1720 - NZ8270");
                            cmb_flightleaving.Items.Add("2025 - NZ8272");

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
            SaveData();

            this.BackColor = Color.LightGreen;
            btn_save.BackColor = Color.Green;
            btn_save.Text = "Saved";
        }

        private void dt_dateleft_Click(object sender, EventArgs e)
        {
            dt_returndate.Value = dt_returndate.Value.AddDays(-1);
        }

        private void dt_dateright_Click(object sender, EventArgs e)
        {
            dt_returndate.Value = dt_returndate.Value.AddDays(1);
        }
    }
}