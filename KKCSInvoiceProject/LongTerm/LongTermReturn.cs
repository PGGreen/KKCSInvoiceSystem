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
using System.Xml;

namespace KKCSInvoiceProject
{
    public partial class LongTermReturn : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        string m_sLongTermKey = "";
        string m_sFName = "";
        string m_sLName = "";
        string m_sRego = "";
        string m_sMake = "";
        string m_sPhone = "";

        public LongTermReturn(string _sRego)
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            m_sRego = _sRego;

            LoadLongTerm();

            FindFlightTimesXML();
        }

        void LoadLongTerm()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM LongTermAccounts WHERE Rego1 = '"+ m_sRego + "' OR Rego2 = '"+ m_sRego + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string sLongTerm = "";

                m_sMake = reader["MakeModel"].ToString();

                m_sLongTermKey = reader["LongTermKey"].ToString();
                m_sFName = reader["FName"].ToString();
                m_sLName = reader["LName"].ToString();
                m_sPhone = reader["Ph"].ToString();

                sLongTerm += "LT"+ m_sLongTermKey + ": " + m_sRego + "\r\n";
                sLongTerm += "Name: " + m_sFName + " " + m_sLName + "\r\n";
                sLongTerm += "Ph: " + m_sPhone;

                lbl_longterm.Text = sLongTerm;
            }

            connection.Close();
        }

        private void chk_enablereturn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_flighttime.Enabled = false;
            lbl_returndate.Enabled = false;
            lbl_return.Enabled = false;
            dt_dateleft.Enabled = false;
            dt_dateright.Enabled = false;
            dt_returndate.Enabled = false;
            txt_flighttimes.Enabled = false;
            btn_save.Visible = false;
            btn_save.Enabled = false;
            this.BackColor = Color.White;


            if (chk_enablereturn.Checked)
            {
                lbl_flighttime.Enabled = true;
                lbl_return.Enabled = true;
                lbl_returndate.Enabled = true;
                dt_dateleft.Enabled = true;
                dt_dateright.Enabled = true;
                dt_returndate.Enabled = true;
                txt_flighttimes.Enabled = true;
                btn_save.Visible = true;
                btn_save.Enabled = true;

                this.BackColor = Color.MistyRose;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            InsertIntoDatabaseLT();

            this.BackColor = Color.LightGreen;
            btn_save.Text = "Saved";
            btn_save.BackColor = Color.Green;
        }

        void InsertIntoDatabaseLT()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            int iInvoice = 0;
            DateTime dtIn = new DateTime();
            string sTimeIn = "0600";
            DateTime dtDatePaid = new DateTime();
            string sPaidStatus = "LT";
            DateTime dtReturnDate = new DateTime(dt_returndate.Value.Year, dt_returndate.Value.Month, dt_returndate.Value.Day, 12, 0, 0);
            string sReturnTime = txt_flighttimes.Text.Substring(0, 4);
            string sTotalPay = "0";
            string sCarLocation = "Front";
            string sStay = "1 Day";
            string sFlightStatus = "Standard - On Flight";
            bool bIsLongTerm = true;
            string sLongTerm = "LT" + m_sLongTermKey;

            // Insert the new Number Plate into the Database
            string cmd1 = @"INSERT into CustomerInvoices (InvoiceNumber,KeyNumber,Rego,FirstName,LastName,PhoneNumber,MakeModel,DTDateIn,TimeIn,
            DTDatePaid,PaidStatus,DTReturnDate,ReturnTime,TotalPay,CarLocation,Stay,FlightStatus,StaffMember,IsLongTerm) VALUES
                                                            ("+ iInvoice + ",'" +
                                                            sLongTerm + "','" +
                                                            m_sRego + "','" +
                                                            m_sFName + "','" +
                                                            m_sLName + "','" +
                                                            m_sPhone + "','" +
                                                            m_sMake + "','" +
                                                            dtIn + "','" +
                                                            sTimeIn + "','" +
                                                            dtDatePaid + "','" +
                                                            sPaidStatus + "','" +
                                                            dtReturnDate + "','" +
                                                            sReturnTime + "','" +
                                                            sTotalPay + "','" +
                                                            sCarLocation + "','" +
                                                            sStay + "','" +
                                                            sFlightStatus + "','" +
                                                            cmb_worker.Text + "'," +
                                                            bIsLongTerm +
                                                        ")";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
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

            txt_flighttimes.SelectedIndex = 0;
        }

        private void dt_returndate_ValueChanged(object sender, EventArgs e)
        {
            FindFlightTimesXML();
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