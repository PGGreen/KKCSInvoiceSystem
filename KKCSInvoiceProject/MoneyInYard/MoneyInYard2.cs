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
    public partial class MoneyInYard2 : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        string[] g_strArrTableHeaders;
        string[] g_strArrTableContents;

        public MoneyInYard2()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        void CreateQueryArray()
        {
            // Sets the names for the Table Headers
            g_strArrTableHeaders = new string[] { "Rego/Item", "Inv No.", "Amount", "", "Total Cash", "Running Total", "", "Item", "Amount", "Running Total" };

            // Sets up the array for pulling information out of the database
            g_strArrTableContents = new string[] { "Rego", "InvoiceNumber", "TotalPay" };
        }


    }
}
