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
    public partial class MoneyInYard : Form
    {
        #region GlobalVariables
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        // Creates the OleDbConnection
        private OleDbConnection connection = new OleDbConnection();

        // Sets up the main OleDb Command
        OleDbCommand command;

        OleDbDataReader reader;
        #endregion

        public MoneyInYard()
        {
            InitializeComponent();

            // Initialises the connection to the file path
            connection.ConnectionString = m_strDataBaseFilePath;
        }
    }
}