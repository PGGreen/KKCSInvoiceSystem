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
    public partial class KeyAllocation : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;
        private OleDbConnection connection = new OleDbConnection();
        OleDbCommand command;
        OleDbDataReader reader;

        Invoice invoice;

        public KeyAllocation(Invoice _invoice)
        {
            InitializeComponent();

            invoice = _invoice;

            connection.ConnectionString = m_strDataBaseFilePath;

            SetUpKeyNumbers();
        }

        private void PaidStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //invoice.SetKeyNumberTextBox(btn.Name);

            Close();
        }

        void SetUpKeyNumbers()
        {
            int iLocationX = 10;
            int iLocationY = 100;
            int iCount = 0;

            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Keybox ORDER BY ID ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string testNumber = reader["KeyBoxNumber"].ToString();
                string sRego = reader["Rego"].ToString();

                if(sRego == "")
                {
                    Button KeyNumberButton = new Button();

                    KeyNumberButton.Location = new Point(iLocationX, iLocationY);
                    KeyNumberButton.Size = new Size(80, 20);

                    KeyNumberButton.Text = testNumber + ". Open";
                    KeyNumberButton.Name = testNumber;

                    KeyNumberButton.Click += new EventHandler(PaidStatus_Click);

                    Controls.Add(KeyNumberButton);
                }
                else
                {
                    Label KeyNumberLabels = new Label();

                    KeyNumberLabels.Location = new Point(iLocationX, iLocationY);
                    KeyNumberLabels.Size = new Size(80, 20);

                    KeyNumberLabels.Text = testNumber + ". " + sRego;
                    Controls.Add(KeyNumberLabels);
                }

                iLocationX += 100;

                iCount++;

                if (iCount % 10 == 0 && iCount != 0)
                {
                    iLocationY += 40;
                    iLocationX = 10;
                }
            }

            connection.Close();
        }
    }
}