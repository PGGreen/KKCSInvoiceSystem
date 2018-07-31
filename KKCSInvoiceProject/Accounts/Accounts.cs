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

            //PopulateAccountBox();

            LoadAccountsMain();

            //Test2();
        }

        void Test2()
        {
            dataGridView1.Columns.Add("col1", "Name");
            dataGridView1.Columns.Add("col2", "Age");

            //adding two button columns:
            DataGridViewButtonColumn btnColumn1 = new DataGridViewButtonColumn();
            btnColumn1.Name = "col3";
            btnColumn1.HeaderText = "Edit";
            btnColumn1.Text = "editing";
            btnColumn1.UseColumnTextForButtonValue = true;
            btnColumn1.CellTemplate.Style.BackColor = Color.GreenYellow;

            dataGridView1.Columns.Add(btnColumn1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //add some rows as example:
            dataGridView1.Rows.Add("Name 1", "23");
            dataGridView1.Rows.Add("Name 2", "35");

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        void ClosingFromDeleteAccount(object sender, FormClosingEventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            LoadFromDeleteAccount();
        }

        void LoadFromDeleteAccount()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM AccountsMain ORDER BY Account ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();
          
            int iCountFields = 1;

            while (reader.Read())
            {
                string sAccount = reader["Account"].ToString();
                string sPh = reader["Ph"].ToString();
                string sEmail = reader["Email"].ToString();
                string sFName = reader["FName"].ToString();
                string sLName = reader["LName"].ToString();

                dataGridView1.Rows.Insert(0, iCountFields.ToString(), sAccount, sPh, sEmail, sFName, sLName);

                iCountFields++;
            }

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            //dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadAccountsMain()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM AccountsMain ORDER BY Account ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();
            DataTable schema = reader.GetSchemaTable();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dataGridView1.ColumnCount = reader.FieldCount;

            int iInt = 0;

            foreach (DataRow rdrColumn in schema.Rows)
            {
                string columnName = rdrColumn[schema.Columns["ColumnName"]].ToString();

                if(columnName == "ID")
                {
                    columnName = "#";
                }

                dataGridView1.Columns[iInt].Name = columnName;
                dataGridView1.Columns[iInt].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                iInt++;
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Edit";
            btn.Name = "Edit";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

            int iFieldCount = reader.FieldCount;
            int iCountFields = 1;

            while (reader.Read())
            {
                string sAccount = reader["Account"].ToString();
                string sPh = reader["Ph"].ToString();
                string sEmail = reader["Email"].ToString();
                string sFName = reader["FName"].ToString();
                string sLName = reader["LName"].ToString();

                dataGridView1.Rows.Insert(0, iCountFields.ToString(), sAccount, sPh, sEmail, sFName, sLName);

                iCountFields++;
            }

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();

            //MessageBox.Show("Clicked " + value);

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                EditAccount ea = new EditAccount();
                ea.LoadFromManager(value);
                ea.FormClosing += ClosingFromDeleteAccount;
                ea.ShowDialog();
            }
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

            //cmd_accountlist.Items.Add("");

            while (reader.Read())
            {
                sFirstName = reader["Account"].ToString();

                if (sFirstName != sSecondName)
                {
                    sSecondName = sFirstName;

                    //cmd_accountlist.Items.Add(sFirstName);
                }
            }

            //cmd_accountlist.SelectedIndex = 0;

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}