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

namespace KKCSInvoiceProject
{
    public partial class BookingsManager : Form
    {

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        Panel pnl;

        bool m_bIsFinished = false;

        private OleDbConnection connection = new OleDbConnection();

        int iInitialPanelLocationY = 0;

        public BookingsManager()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            txt_year.Text = dt.ToString("yyyy");

            ChangePettyCashDate();

            txt_year.Focus();
        }

        void SetUpMonthAndYear(DateTime _dt)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Bookings WHERE year(DateCustomerLeaving) = year(@_dt) ORDER BY DateCustomerLeaving DESC";
            command.Parameters.AddWithValue("@_dt", _dt);

            command.CommandText = query;

            reader = command.ExecuteReader();

            iInitialPanelLocationY = pnl_template.Location.Y;

            string sFinalAmount = "";

            bool bPettyCashThisMonth = false;

            while (reader.Read())
            {
                m_bIsFinished = (bool)reader["BookingFinished"];

                pnl = new Panel();
                pnl.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);
                pnl.Name = "F";

                pnl.Size = pnl_template.Size;

                if (!m_bIsFinished)
                {
                    pnl.BackColor = pnl_template.BackColor;
                }
                else
                {
                    pnl.BackColor = Color.LightGreen;
                }

                pnl.BorderStyle = pnl_template.BorderStyle;

                foreach (Control p in pnl_template.Controls)
                {
                    // Handles all the button controls
                    if (p.GetType() == typeof(Button))
                    {
                        //ControlButtons(p);
                    }
                    // Handles all the Label Controlls
                    if (p.GetType() == typeof(Label))
                    {
                        ControlLabels(p);
                    }
                }

                Controls.Add(pnl);

                iInitialPanelLocationY += 60;
            }

            connection.Close();
        }

        void ControlLabels(Control _p)
        {
            Label lbl = new Label();
            lbl.Name = _p.Name;

            if (_p.Name == "lbl_rego")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["Rego"].ToString();
            }

            if (_p.Name == "lbl_name")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["FName"].ToString() + " " + reader["LName"].ToString();
            }

            if (_p.Name == "lbl_dateleave")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                DateTime dtDate = (DateTime)reader["DateCustomerLeaving"];



                lbl.Text = dtDate.Year + "/" + dtDate.Month + "/" + dtDate.Day + " - " + reader["FlightTimeLeaving"].ToString().Substring(0,4);
            }

            if (_p.Name == "lbl_datepickup")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                DateTime dtDate = (DateTime)reader["DateCustomerPickingUp"];

                lbl.Text = dtDate.Year + "/" + dtDate.Month + "/" + dtDate.Day + " - " + reader["FlightTimePickingUp"].ToString().Substring(0, 4);
            }

            if (_p.Name == "lbl_ph")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["Ph"].ToString();
            }

            if (_p.Name == "lbl_account")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["Account"].ToString();
            }

            lbl.Location = _p.Location;

            pnl.Controls.Add(lbl);
        }

        void ChangePettyCashDate()
        {
            DeleteControls();

            DateTime dt = new DateTime();

            int iYear = 0;
            int.TryParse(txt_year.Text, out iYear);

            dt = new DateTime(iYear, 1, 1, 12, 0, 0);

            SetUpMonthAndYear(dt);
        }

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
    }
}

        