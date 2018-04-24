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
    public partial class LongTermMain : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        Panel pnl;

        bool m_bHighlight = false;
        string m_sRegoToHighlight = "";

        public LongTermMain(bool _bHighlight, string _sRego)
        {
            InitializeComponent();

            m_bHighlight = _bHighlight;
            m_sRegoToHighlight = _sRego;

            connection.ConnectionString = m_strDataBaseFilePath;

            Public();

            //PublicPeople();
        }

        void Public()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM LongTermAccounts ORDER BY LongTermKey ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            int iLocationY = 0;
            int iLocationX = pnl_template.Location.X;
            int iCount = 0;

            int iLongTermNumber = 0;

            while (reader.Read())
            {
                if (iCount == 15)
                {
                    iLocationY = 0;
                    iLocationX = pnl_template.Size.Width + 50;
                }

                pnl = new Panel();

                pnl.Size = pnl_template.Size;

                if(m_bHighlight)
                {
                    pnl.BackColor = Color.White;
                }
                else
                {
                    pnl.BackColor = pnl_template.BackColor;
                }
                
                pnl.Location = new Point(iLocationX, pnl_template.Location.Y + iLocationY);
                pnl.Visible = true;

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

                this.Controls.Add(pnl);

                iCount++;

                /*
                iLongTermNumber++;

                Label lbl = new Label();

                lbl.Location = new Point(lbl_template.Location.X, lbl_template.Location.Y + LocationY);

                lbl.Text = "LT" + reader["LongTermKey"].ToString().ToString() + ". "+ reader["ClientName"].ToString();

                lbl.Font = lbl_template.Font;

                lbl.Size = new Size(1000, lbl.Size.Height + 10);

                lbl.BackColor = Color.LightBlue;
                */

                //Controls.Add(lbl);

                iLocationY += 50;

            }



            connection.Close();
        }

        void ControlLabels(Control _p)
        {
            Label lbl = new Label();
            lbl.Font = _p.Font;
            lbl.Text = _p.Text;
            lbl.Location = _p.Location;
            lbl.Size = _p.Size;

            if (_p.Name == "lbl_ltnumber")
            {
                lbl.Text = "LT" + reader["LongTermKey"].ToString();
            }

            if (_p.Name == "lbl_name")
            {
                string sName = reader["ClientName"].ToString();

                if(sName.Length > 15)
                {
                    lbl.Font = new Font(_p.Font.FontFamily, 8);
                    //sName = sName.Substring(0, 15);
                }
                lbl.Text = sName;
            }
            if(_p.Name == "lbl_rego")
            {
                string sRego1 = reader["Rego1"].ToString();

                if (m_bHighlight && sRego1 == m_sRegoToHighlight)
                {
                    pnl.BackColor = Color.LightGreen;
                }

                lbl.Text = sRego1;
            }
            if (_p.Name == "lbl_rego2")
            {
                string sRego2 = reader["Rego2"].ToString();

                if (m_bHighlight && sRego2 == m_sRegoToHighlight)
                {
                    pnl.BackColor = Color.LightGreen;
                }

                lbl.Text = sRego2;
            }
            if(_p.Name == "lbl_ph")
            {
                lbl.Text = reader["Ph"].ToString();
            }

            pnl.Controls.Add(lbl);
        }
    }
}