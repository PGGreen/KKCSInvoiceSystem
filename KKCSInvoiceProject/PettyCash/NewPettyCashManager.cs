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
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        int iInitialPanelLocationY = 200;

        Panel pnl;

        OleDbDataReader reader;

        bool m_bIsReimburse = false;

        public NewPettyCashManager()
        {
            connection.ConnectionString = m_strDataBaseFilePath;

            InitializeComponent();

            SetUpInitialMonthAndYear();
        }

        void SetUpInitialMonthAndYear()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NewPettyCash ORDER BY DatePetty ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            iInitialPanelLocationY = pnl_template.Location.Y;

            while (reader.Read())
            {
                m_bIsReimburse = (bool)reader["IsReimburse"];

                pnl = new Panel();
                pnl.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);

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
                pc.Show();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            PettyCash pc = new PettyCash();
            pc.Show();
        }

        #endregion Buttons
    }
}
