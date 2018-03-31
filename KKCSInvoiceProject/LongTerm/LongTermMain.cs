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

        Panel pnl;

        public LongTermMain()
        {
            InitializeComponent();

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

            OleDbDataReader reader = command.ExecuteReader();

            int iLocationY = 0;
            int iLocationX = pnl_template.Location.X;
            int iCount = 0;

            int iLongTermNumber = 0;

            while (reader.Read())
            {
                if (iCount == 10)
                {
                    iLocationY = 0;
                    iLocationX = pnl_template.Size.Width + 50;
                }

                pnl = new Panel();

                pnl.Size = pnl_template.Size;
                pnl.BackColor = pnl_template.BackColor;
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

        void ControlLabels(Control p)
        {
            Label lbl = new Label();
            lbl.Location = p.Location;
            lbl.Text = p.Text;
            lbl.Size = p.Size;
            lbl.Font = p.Font;
            pnl.Controls.Add(lbl);
        }
    }
}