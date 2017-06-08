using System;
using System.IO;
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
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class WarningNewAccount : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        private OleDbCommand command;

        string g_sAccount = "";
        bool g_bIsExistingAccount = false;
        bool g_bIsNewAccount = false;

        public WarningNewAccount()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            PopulateAccountBox();
        }

        public string sGetAccount()
        {
            return (g_sAccount);
        }

        public bool sGetIsExistingAccount()
        {
            return (g_bIsExistingAccount);
        }

        public bool sGetIsNewAccount()
        {
            return (g_bIsExistingAccount);
        }

        void PopulateAccountBox()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Accounts ORDER BY Account ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            string sFirstName = "";
            string sSecondName = "";

            while (reader.Read())
            {
                sFirstName = reader["Account"].ToString();

                if (sFirstName != sSecondName)
                {
                    sSecondName = sFirstName;

                    cmd_accountlist.Items.Add(sFirstName);
                }
            }

            cmd_accountlist.SelectedIndex = 0;

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void cmd_accountlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_sAccount = cmd_accountlist.Text;
        }

        private void btn_addtoaccount_Click(object sender, EventArgs e)
        {
            g_bIsExistingAccount = true;

            this.Close();
        }

        private void btn_createnewaccount_Click(object sender, EventArgs e)
        {
            NewAccount na = new NewAccount();
            na.ShowDialog();
        }
    }
}