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

        public LongTermMain()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            Public();
        }

        void Public()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM LongTermAccounts ORDER BY LongTermKey ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            int LocationX = 17;
            int LocationY = 52;

            int iCount = 0;

            while (reader.Read())
            {
                Button butLongTerm = new Button();

                butLongTerm.Location = new Point(LocationX, LocationY);
                butLongTerm.Size = new Size(189, 87);
                butLongTerm.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                butLongTerm.Text = "#LT" + reader["LongTermKey"].ToString() + " - " + reader["ClientName"].ToString();
                butLongTerm.Name = reader["LongTermKey"].ToString();

                bool bIsCarInYard = (bool)reader["IsCarInYard"];

                if(bIsCarInYard)
                {
                    butLongTerm.BackColor = Color.LightGreen;
                }
                else
                {
                    butLongTerm.BackColor = Color.PaleVioletRed;
                }
                
                //butLongTerm.Click += new EventHandler(LongTermKey_Click);

                LocationX += 222;

                iCount++;

                if (iCount % 5 == 0)
                {
                    LocationY += 119;
                    LocationX = 17;
                }

                Controls.Add(butLongTerm);
            }

            connection.Close();
        }
    }
}