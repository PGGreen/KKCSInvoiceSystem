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

            int LocationY = 0;

            int iLongTermNumber = 0;

            while (reader.Read())
            {
                iLongTermNumber++;

                Label lbl = new Label();

                lbl.Location = new Point(lbl_template.Location.X, lbl_template.Location.Y + LocationY);

                lbl.Text = "LT" + reader["LongTermKey"].ToString().ToString() + ". "+ reader["ClientName"].ToString();

                lbl.Font = lbl_template.Font;

                lbl.Size = new Size(1000, lbl.Size.Height + 10);

                lbl.BackColor = Color.LightBlue;

                Controls.Add(lbl);

                LocationY += 40;

            }

            connection.Close();
        }
    }
}