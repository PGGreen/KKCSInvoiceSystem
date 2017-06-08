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
    public partial class LongTermSort : Form
    {
        #region GlobalVariables

        OleDbCommand command;
        OleDbConnection connection = new OleDbConnection();
        OleDbDataReader reader;

        int g_iLocation = 0;

        string sPageNumber = "";

        List<Panel> lstPanels;

        int iPanelLocationY = 0;

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        #endregion GlobalVariables

        public LongTermSort()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            GetPageNumbers();

            //DateIn();
        }

        void GetPageNumbers()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "";

            query = @"SELECT * FROM LongTermSort ORDER BY KeyNumber,DTDateIn";
            command.CommandText = query;
            reader = command.ExecuteReader();

            // Stores the time from the table
            int StoreFirstRecord = 0;

            // Stores time at end to compare and see if a new time has shown
            int StoreSecondRecord = 0;

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            iPanelLocationY = pnl_template.Location.Y;

            while (reader.Read())
            {
                StoreFirstRecord = (int)reader["KeyNumber"];

                // Compares the 2 times together to see if they are different or not
                // Skips the first check
                if (StoreFirstRecord != StoreSecondRecord && !bSkipFirstCheck)
                {
                    iPanelLocationY += 50;
                }

                // Makes the Second time = the first time for comparision purposes
                StoreSecondRecord = StoreFirstRecord;

                // Makes the first check to false for using
                bSkipFirstCheck = false;

                Things();
            }

            connection.Close();
        }

        void Things()
        {
            iPanelLocationY += 50;

            Panel pnl = new Panel();

            pnl.Size = pnl_template.Size;
            pnl.Location = new Point(pnl_template.Location.X, iPanelLocationY);
            pnl.BackColor = pnl_template.BackColor;

            int iCount = 0;

            // Handles the controls within the panel
            foreach (Control p in pnl_template.Controls)
            {
                Label lbl = new Label();
                lbl.Font = p.Font;
                lbl.Size = p.Size;
                lbl.Location = p.Location;

                if (p.Name == "lbl_keynumber")
                {
                    lbl.Text = reader["KeyNumber"].ToString();
                }
                else if (p.Name == "lbl_numberplate")
                {
                    lbl.Text = reader["NumberPlate"].ToString();
                }
                else if (p.Name == "lbl_datein")
                {
                    lbl.Text = reader["DateIn"].ToString();

                    if(lbl.Text != "")
                    {
                        iCount++;
                    }
                }
                else if (p.Name == "lbl_dateout")
                {
                    lbl.Text = reader["DateOut"].ToString();

                    if (lbl.Text != "")
                    {
                        iCount++;
                    }
                }

                pnl.Controls.Add(lbl);
            }

            if(iCount >= 2)
            {
                pnl.BackColor = Color.LightGreen;
            }

            Controls.Add(pnl);
        }

        void DateIn()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "";

            query = @"SELECT * FROM LongTermSort";
            command.CommandText = query;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string sDate = reader["DateOut"].ToString();

                if (sDate != "")
                {
                    int iYear = 0;
                    int iMonth = 0;
                    int iDay = 0;

                    int.TryParse("20" + sDate.Substring(6, 2), out iYear);
                    int.TryParse(sDate.Substring(3, 2), out iMonth);
                    int.TryParse(sDate.Substring(0, 2), out iDay);

                    DateTime dt = new DateTime(iYear, iMonth, iDay, 12, 0, 0);
                    txt_DateIn.Text += dt.ToString() + "\r\n";
                }
                else
                {
                    txt_DateIn.Text += "\r\n";
                }
            }

            connection.Close();
        }
    }
}