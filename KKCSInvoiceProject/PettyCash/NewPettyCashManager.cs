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
    public partial class NewPettyCashManager : Form
    {
        #region Globals

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        int iInitialPanelLocationY = 200;

        Panel pnl;

        OleDbDataReader reader;

        bool bFinalOnlyOnce = false;
        bool bUpdateOnce = false;

        bool m_bIsReimburse = false;

        bool m_bIsInitial = true;

        #endregion Globals

        public NewPettyCashManager()
        {
            connection.ConnectionString = m_strDataBaseFilePath;

            InitializeComponent();

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            txt_year.Text = dt.ToString("yyyy");
            cmb_month.SelectedIndex = dt.Month - 1;

            //SetUpMonthAndYear(dt);

            txt_year.Focus();

            m_bIsInitial = false;
        }

        void SetUpMonthAndYear(DateTime _dt)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NewPettyCash WHERE year(DatePetty) = year(@_dt) AND month(DatePetty) = month(@_dt) ORDER BY DatePetty DESC";
            command.Parameters.AddWithValue("@_dt", _dt);

            command.CommandText = query;

            reader = command.ExecuteReader();

            lbl_latest.Visible = false;
            DateTime dtTodayCompare = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            DateTime dtPickedCompare = new DateTime(_dt.Year, _dt.Month, _dt.Day, 12, 0, 0);

            if(dtTodayCompare.Year == dtPickedCompare.Year && dtTodayCompare.Month == dtPickedCompare.Month)
            {
                lbl_latest.Visible = true;
            }

            iInitialPanelLocationY = pnl_template.Location.Y;

            string sFinalAmount = "";

            bool bPettyCashThisMonth = false;

            while (reader.Read())
            {
                m_bIsReimburse = (bool)reader["IsReimburse"];

                pnl = new Panel();
                pnl.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);
                pnl.Name = "F";

                pnl.Size = pnl_template.Size;

                if(!m_bIsReimburse)
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

                if(!bFinalOnlyOnce)
                {
                    sFinalAmount = reader["PettyRunningTotal"].ToString();

                    bFinalOnlyOnce = true;
                }

                bPettyCashThisMonth = true;
            }

            if(!bPettyCashThisMonth)
            {
                lbl_latest.Visible = false;
            }

            connection.Close();

            if (!bUpdateOnce)
            {
                float fFinalAmount = 0.0f;
                float.TryParse(sFinalAmount, out fFinalAmount);

                if(fFinalAmount == 0.0f)
                {
                    connection.Open();

                    OleDbCommand commands = new OleDbCommand();

                    commands.Connection = connection;

                    string q = @"SELECT * FROM NewPettyCash ORDER BY DatePetty DESC";

                    commands.CommandText = q;

                    reader = commands.ExecuteReader();

                    while(reader.Read())
                    {
                        float.TryParse(reader["PettyRunningTotal"].ToString(), out fFinalAmount);

                        break;
                    }

                    connection.Close();
                }

                lbl_remain.Text = "$" + fFinalAmount.ToString("0.00");

                bUpdateOnce = true;
            }
        }

        void ControlLabels(Control _p)
        {
            Label lbl = new Label();
            lbl.Name = _p.Name;

            if (_p.Name == "lbl_item")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                if(!m_bIsReimburse)
                {
                    lbl.Text = reader["Item"].ToString();
                }
                else
                {
                    lbl.Text = "Reimburse";
                }
            }

            if (_p.Name == "lbl_date")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["DatePetty"].ToString();
            }

            if (_p.Name == "lbl_amount")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                float iAmount = 0.0f;
                float.TryParse(reader["Amount"].ToString(), out iAmount);
                
                if(!m_bIsReimburse)
                {
                    lbl.Text = "-$" + iAmount.ToString("0.00");
                    lbl.BackColor = _p.BackColor;
                }
                else
                {
                    lbl.Text = "+$" + iAmount.ToString("0.00");
                }
            }

            if (_p.Name == "lbl_runningamount")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                float iAmount = 0.0f;
                float.TryParse(reader["PettyRunningTotal"].ToString(), out iAmount);

                if (!m_bIsReimburse)
                {
                    lbl.Text = "$" + iAmount.ToString("0.00");
                    lbl.BackColor = _p.BackColor;
                }
                else
                {
                    lbl.Text = "$" + iAmount.ToString("0.00");
                }
            }

            lbl.Location = _p.Location;

            pnl.Controls.Add(lbl);
        }

        #region Buttons

        private void button1_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["PettyCashReimburse"];

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
                PettyCashReimburse pc = new PettyCashReimburse();
                pc.FormClosing += CloseReimburse;
                pc.ShowDialog();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            PettyCash pc = new PettyCash();
            pc.FormClosing += CloseNewPettyCashItem;
            pc.ShowDialog();
        }

        void CloseNewPettyCashItem(object sender, EventArgs e)
        {
            bUpdateOnce = false;
            bFinalOnlyOnce = false;

            ChangePettyCashDate();
        }

        void CloseReimburse(object sender, EventArgs e)
        {
            bUpdateOnce = false;
            bFinalOnlyOnce = false;

            ChangePettyCashDate();
        }

        #endregion Buttons

        private void cmb_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePettyCashDate();
        }

        void ChangePettyCashDate()
        {
            DeleteControls();

            DateTime dt = new DateTime();

            //if (cmb_month.SelectedIndex != 0)
            //{
                int iYear = 0;
                int.TryParse(txt_year.Text, out iYear);

                dt = new DateTime(iYear, cmb_month.SelectedIndex + 1, DateTime.Now.Day, 12, 0, 0);

                SetUpMonthAndYear(dt);
            //}
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

        

        #region ButtonsLeftRight

        private void bnt_monthright_Click(object sender, EventArgs e)
        {
            if (cmb_month.SelectedIndex >= 11)
            {
                cmb_month.SelectedIndex = 11;
            }
            else
            {
                cmb_month.SelectedIndex += 1;
            }
        }

        private void btn_monthleft_Click(object sender, EventArgs e)
        {
            if (cmb_month.SelectedIndex <= 0)
            {
                cmb_month.SelectedIndex = 0;
            }
            else
            {
                cmb_month.SelectedIndex -= 1;
            }
        }

        private void btn_yearleft_Click(object sender, EventArgs e)
        {
            int iYear = 0;
            bool bIsInt = int.TryParse(txt_year.Text, out iYear);

            if (!bIsInt)
            {
                WarningSystem ws = new WarningSystem("Initial Date is not in format YYYY \r\n e.g. 2017", false);
                ws.ShowDialog();
            }
            else
            {
                iYear -= 1;

                txt_year.Text = iYear.ToString();
            }
        }

        private void btn_yearright_Click(object sender, EventArgs e)
        {
            int iYear = 0;
            bool bIsInt = int.TryParse(txt_year.Text, out iYear);

            if (!bIsInt)
            {
                WarningSystem ws = new WarningSystem("Initial Date is not in format YYYY \r\n e.g. 2017", false);
                ws.ShowDialog();
            }
            else
            {
                iYear += 1;

                txt_year.Text = iYear.ToString();
            }
        }

        #endregion ButtonsLeftRight

        private void txt_year_TextChanged(object sender, EventArgs e)
        {
            if(txt_year.TextLength == 4 && !m_bIsInitial)
            {
                int iTestForIntYear = 0;
                bool bIsInt = int.TryParse(txt_year.Text, out iTestForIntYear);

                if(!bIsInt)
                {
                    WarningSystem ws = new WarningSystem("Please enter year in format YYYY only \r\n e.g. 2017", false);
                    ws.ShowDialog();
                }
                else
                {
                    ChangePettyCashDate();
                }
            }
        }
    }
}