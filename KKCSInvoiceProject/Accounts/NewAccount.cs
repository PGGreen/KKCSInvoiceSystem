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
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class NewAccount : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;
        private OleDbConnection connection = new OleDbConnection();

        private OleDbCommand command = new OleDbCommand();

        public NewAccount()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        void SaveToDatabase()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"INSERT INTO AccountsMain (Account,FName,LName,Email,Ph) 
                    values ('" + txt_accountname.Text +
                    "','" + txt_fname.Text +
                    "','" + txt_lname.Text +
                    "','" + txt_email.Text +
                    "','" + txt_ph.Text +
                    "')";

            command.CommandText = query;

            command.ExecuteNonQuery();

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveToDatabase();

            btn_save.BackColor = Color.Green;
            btn_save.Text = "Saved";
            this.BackColor = Color.LightGreen;
        }
    }
}