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

            txt_year.Focus();
        }

        void SetHeadings(DateTime _dt)
        {
            pnl = new Panel();
            pnl.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);
            pnl.Name = "F";
            pnl.Size = new Size(pnl_template.Size.Width - 1000, pnl_template.Height);
            pnl.BackColor = Color.LightBlue;
            pnl.BorderStyle = pnl_template.BorderStyle;

            Label lbl = new Label();
            //lbl.Name = _p.Name;
            lbl.Font = lbl_rego.Font;
            lbl.Size = new Size(lbl_rego.Size.Width + 100, lbl_rego.Height);
            lbl.Location = lbl_rego.Location;

            lbl.Text = _dt.ToString("MMMM").ToUpper() + " - " + txt_year.Text;

            pnl.Controls.Add(lbl);

            Controls.Add(pnl);
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

            string sStoreMonthFirst = "";
            string sStoreMonthSecond = "";
            bool bIgnoreFirstTime = true;

            while (reader.Read())
            {
                DateTime dtDate = (DateTime)reader["DateCustomerLeaving"];
                sStoreMonthFirst = dtDate.Month.ToString();

                if(bIgnoreFirstTime)
                {
                    SetHeadings(dtDate);

                    iInitialPanelLocationY += 60;
                }

                if(sStoreMonthFirst != sStoreMonthSecond && !bIgnoreFirstTime)
                {
                    sStoreMonthSecond = sStoreMonthFirst;

                    SetHeadings(dtDate);

                    iInitialPanelLocationY += 60;
                }

                m_bIsFinished = (bool)reader["BookingFinished"];

                pnl = new Panel();
                pnl.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);
                pnl.Name = "F";

                pnl.Size = pnl_template.Size;

                if (!m_bIsFinished)
                {
                    pnl.BackColor = Color.Yellow;
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
                        ControlButtons(p);
                    }
                    // Handles all the Label Controlls
                    if (p.GetType() == typeof(Label))
                    {
                        ControlLabels(p);
                    }
                }

                Controls.Add(pnl);

                iInitialPanelLocationY += 60;

                bIgnoreFirstTime = false;

                sStoreMonthSecond = sStoreMonthFirst;
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

                string sTimeLeave = reader["FlightTimeLeaving"].ToString().Substring(0, 4);

                if (sTimeLeave == "Time")
                {
                    sTimeLeave = "Unkn";
                }

                lbl.Text = dtDate.Day.ToString("00") + "/" + dtDate.Month.ToString("00") + "/" + dtDate.Year + " - " + sTimeLeave;
            }

            if (_p.Name == "lbl_datepickup")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                DateTime dtDate = (DateTime)reader["DateCustomerPickingUp"];

                string sTimePickUp = reader["FlightTimePickingUp"].ToString().Substring(0, 4);

                if(sTimePickUp == "Time")
                {
                    sTimePickUp = "Unkn";
                }

                lbl.Text = dtDate.Day.ToString("00") + "/" + dtDate.Month.ToString("00") + "/" + dtDate.Year + " - " + sTimePickUp;
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

        void ControlButtons(Control _p)
        {
            // Creates a new button
            Button btn = new Button();

            // Is it the Picked Up Button
            if (_p.Name == "btn_edit")
            {
                btn.Text = "Edit";
                btn.BackColor = _p.BackColor;

                btn.Name = reader["ID"].ToString();

                btn.Click += new EventHandler(EditButton_Click);
            }

            if (_p.Name == "btn_delete")
            {
                btn.Text = "Delete";
                btn.BackColor = _p.BackColor;

                btn.Name = reader["ID"].ToString();

                btn.Click += new EventHandler(DeleteBooking_Click);
            }

            btn.Location = _p.Location;
                btn.Size = _p.Size;
                pnl.Controls.Add(btn);
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            Bookings book = new Bookings();

            book.SetUpFromBookingsManager(x);
            book.FormClosing += BookingsClosing;
            book.ShowDialog();

        }
        private void DeleteBooking_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = 0;
            Int32.TryParse(btn.Name, out x);

            string sWarningMessage = "Are you sure you want to delete this booking?";

            WarningSystem ws = new WarningSystem(sWarningMessage, true);
            ws.ShowDialog();

            if (ws.DialogResult == DialogResult.OK)
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                string query = "DELETE FROM Bookings WHERE ID = " + x + "";

                command.CommandText = query;

                command.ExecuteNonQuery();

                connection.Close();

                ChangeBookingDate();
            }
            else
            {
                ws.Close();
            }
        }

        void ChangeBookingDate()
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
                if (pnl.Name == "pnl_template" || pnl.Name == "pnl_green" || pnl.Name == "pnl_yellow")
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

        private void txt_year_TextChanged(object sender, EventArgs e)
        {
            int iNumber = 0;
            bool bIsNumber = int.TryParse(txt_year.Text, out iNumber);

            if(bIsNumber && txt_year.TextLength == 4)
            {
                ChangeBookingDate();
            }
        }

        private void btn_yearleft_Click(object sender, EventArgs e)
        {
            int iNumber = 0;
            int.TryParse(txt_year.Text, out iNumber);
            iNumber -= 1;

            txt_year.Text = iNumber.ToString();
        }

        private void btn_yearright_Click(object sender, EventArgs e)
        {
            int iNumber = 0;
            int.TryParse(txt_year.Text, out iNumber);
            iNumber += 1;

            txt_year.Text = iNumber.ToString();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Bookings"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                Bookings st = new Bookings();
                st.FormClosing += BookingsClosing;
                st.ShowDialog();
                
            }
        }

        private void BookingsClosing(object sender, CancelEventArgs e)
        {
            ChangeBookingDate();
        }
    }
}