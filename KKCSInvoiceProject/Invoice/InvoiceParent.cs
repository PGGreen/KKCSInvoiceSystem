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
    public partial class InvoiceParent : Form
    {
        //private TabControl tabControl1;

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        const int LEADING_SPACE = 12;
        const int CLOSE_SPACE = 15;
        const int CLOSE_AREA = 15;

        public InvoiceParent()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            this.FormClosing += ParentForm_Closing;
        }

        TabPage tp = new TabPage();

        private void ParentForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command2 = new OleDbCommand();

            command2.Connection = connection;

            string temp = "";
            string temp2 = "-";

            string cmd1 = @"UPDATE KeyBox
                                SET [Rego] = '" + temp + "' WHERE [Rego] = '" + temp2 + "'";

            command2.CommandText = cmd1;

            command2.ExecuteNonQuery();

            connection.Close();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
