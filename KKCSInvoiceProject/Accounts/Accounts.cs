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
    public partial class Accounts : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        // Creates the OleDbConnection
        private OleDbConnection connection = new OleDbConnection();

        // Creates the OleDb Items
        OleDbDataReader reader;

        // Sets up the main OleDb Command
        OleDbCommand command;

        public Accounts()
        {
            // Initialises the main Windows Form Component
            InitializeComponent();

            // Initialises the connection to the file path
            connection.ConnectionString = m_strDataBaseFilePath;

            PopulateAccountBox();
        }

        void PopulateAccountBox()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Accounts ORDER BY Account ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            string sFirstName = "";
            string sSecondName = "";

            cmd_accountlist.Items.Add("");

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
    }
}