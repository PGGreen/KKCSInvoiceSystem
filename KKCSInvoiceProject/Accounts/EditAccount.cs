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
    public partial class EditAccount : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        // Creates the OleDbConnection
        private OleDbConnection connection = new OleDbConnection();

        // Creates the OleDb Items
        OleDbDataReader reader;

        // Sets up the main OleDb Command
        OleDbCommand command;

        bool g_bLoadingComplete = false;

        string g_sAccount = "";

        string g_sOrigAccountName = "";
        string g_sOrigFirstName = "";
        string g_sOrigLastName = "";
        string g_sOrigEmail = "";
        string g_sOrigPh = "";

        public EditAccount()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        private void btn_delaccount_Click(object sender, EventArgs e)
        {
            string sWarning = "WARNING! WARNING! WARNING!\r\n\r\n";
            sWarning += "Deleting this account will remove all the customers associated with it.\r\n";
            sWarning += "(This will NOT affect their names and regos coming up as a regular customer however.)\r\n\r\n";
            sWarning += "Are you sure you want to delete this account?\r\n\r\n";

            WarningSystem ws = new WarningSystem(sWarning, true);
            ws.ShowDialog();

            if(ws.DialogResult == DialogResult.OK)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command = new OleDbCommand();

                command.Connection = connection;

                string cmd1 = @"DELETE FROM AccountsMain WHERE Account = '" + g_sAccount + "'";

                command.CommandText = cmd1;

                command.ExecuteNonQuery();
                //

                //
                command = new OleDbCommand();

                command.Connection = connection;

                cmd1 = @"UPDATE NumberPlates SET Account = '', AccountParticulars = '' WHERE Account = '" + g_sAccount + "'";

                command.CommandText = cmd1;

                command.ExecuteNonQuery();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                this.Close();
            }
        }

        public void LoadFromManager(string _sAccount)
        {
            lbl_title.Text = _sAccount + " Account";

            g_sAccount = _sAccount;

            LoadAccountsMain(_sAccount);

            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NumberPlates WHERE Account = @Account ORDER BY ClientName ASC";

            command.Parameters.AddWithValue("@Account", _sAccount);

            command.CommandText = query;

            reader = command.ExecuteReader();
            DataTable schema = reader.GetSchemaTable();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dataGridView1.ColumnCount = 7;

            int iInt = 0;

            dataGridView1.Columns[0].Name = "#";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[2].Name = "Last Name";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[3].Name = "Rego";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[4].Name = "Ph";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[5].Name = "Account Particular";
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Edit";
            btn.Name = "Edit";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(6, btn);

            btn = new DataGridViewButtonColumn();
            btn.Text = "Delete";
            btn.Name = "Delete";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(7, btn);

            int iFieldCount = reader.FieldCount;
            int iCountFields = 1;

            while (reader.Read())
            {
                string sFName = reader["ClientName"].ToString();
                string SLName = reader["LastName"].ToString();
                string sRego = reader["NumberPlates"].ToString();
                string sPh = reader["Ph"].ToString();
                string sAccountPart = reader["AccountParticulars"].ToString();

                dataGridView1.Rows.Insert(0, iCountFields.ToString("00"), sFName, SLName, sRego, sPh, sAccountPart);

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
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                DeleteIndividual(e);
            }
            else if(e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                EditIndividual(e);
            }
        }

        void DeleteIndividual(DataGridViewCellEventArgs _e)
        {
            string sWarning = "WARNING!\r\n\r\n";
            sWarning += "Are you sure you want to delete this customer?\r\n";

            WarningSystem ws = new WarningSystem(sWarning, true);
            ws.ShowDialog();

            if (ws.DialogResult == DialogResult.OK)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command = new OleDbCommand();

                command.Connection = connection;

                string sRego = dataGridView1.Rows[_e.RowIndex].Cells[3].FormattedValue.ToString();

                string cmd1 = @"UPDATE NumberPlates SET Account = '', AccountParticulars = '' WHERE NumberPlates = '" + sRego + "'";

                command.CommandText = cmd1;

                command.ExecuteNonQuery();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                ReloadDataView();
            }
        }

        void EditIndividual(DataGridViewCellEventArgs _e)
        {
            string value = dataGridView1.Rows[_e.RowIndex].Cells[3].FormattedValue.ToString();

            EditAccountCustomer eac = new EditAccountCustomer();
            eac.LoadFromEditAccount(value, g_sAccount);
            eac.ShowDialog();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            ReloadDataView();
        }

        void ReloadDataView()
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NumberPlates WHERE Account = @Account ORDER BY ClientName ASC";

            command.Parameters.AddWithValue("@Account", g_sAccount);

            command.CommandText = query;

            reader = command.ExecuteReader();
            DataTable schema = reader.GetSchemaTable();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            int iCountFields = 1;

            while (reader.Read())
            {
                string sFName = reader["ClientName"].ToString();
                string SLName = reader["LastName"].ToString();
                string sRego = reader["NumberPlates"].ToString();
                string sPh = reader["Ph"].ToString();
                string sAccountPart = reader["AccountParticulars"].ToString();

                dataGridView1.Rows.Insert(0, iCountFields.ToString("00"), sFName, SLName, sRego, sPh, sAccountPart);

                iCountFields++;
            }

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadAccountsMain(string _sAccount)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM AccountsMain WHERE Account = @Account";

            command.Parameters.AddWithValue("@Account", _sAccount);

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string sAccount = reader["Account"].ToString();
                string sFName = reader["FName"].ToString();
                string sLName = reader["LName"].ToString();
                string sEmail = reader["Email"].ToString();
                string sPh = reader["Ph"].ToString();

                g_sOrigAccountName = sAccount;
                g_sOrigFirstName = sFName;
                g_sOrigLastName = sLName;
                g_sOrigEmail = sEmail;
                g_sOrigPh = sPh;

                txt_accountname.Text = sAccount;
                txt_fname.Text = sFName;
                txt_lname.Text = sLName;
                txt_email.Text = sEmail;
                txt_ph.Text = sPh;
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            g_bLoadingComplete = true;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string cmd1 = @"UPDATE AccountsMain SET Account = '" + txt_accountname.Text +
                "', FName = '" + txt_fname.Text +
                "', LName = '" + txt_lname.Text +
                "', Email = '" + txt_email.Text +
                "', Ph = '" + txt_ph.Text +
                "' WHERE Account = '" + g_sAccount + "'";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            g_sOrigAccountName = txt_accountname.Text;
            g_sOrigFirstName = txt_fname.Text;
            g_sOrigLastName = txt_lname.Text;
            g_sOrigEmail = txt_email.Text;
            g_sOrigPh = txt_ph.Text;

            panel1.BackColor = Color.LightGreen;
            btn_update.Visible = false;
            //

            //
            command = new OleDbCommand();

            command.Connection = connection;

            cmd1 = @"UPDATE NumberPlates SET Account = '"+ txt_accountname.Text + "' WHERE Account = '" + g_sAccount + "'";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            g_sAccount = txt_accountname.Text;

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void txt_accountname_TextChanged(object sender, EventArgs e)
        {
            if(g_bLoadingComplete)
            {
                CheckChanges();
            }
        }

        private void txt_fname_TextChanged(object sender, EventArgs e)
        {
            if (g_bLoadingComplete)
            {
                CheckChanges();
            }
        }

        private void txt_lname_TextChanged(object sender, EventArgs e)
        {
            if (g_bLoadingComplete)
            {
                CheckChanges();
            }
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            if (g_bLoadingComplete)
            {
                CheckChanges();
            }
        }

        private void txt_ph_TextChanged(object sender, EventArgs e)
        {
            if (g_bLoadingComplete)
            {
                CheckChanges();
            }
        }

        void CheckChanges()
        {
            int iChanges = 0;

            if(txt_accountname.Text != g_sOrigAccountName)
            {
                iChanges++;
            }

            if (txt_fname.Text != g_sOrigFirstName)
            {
                iChanges++;
            }

            if (txt_lname.Text != g_sOrigLastName)
            {
                iChanges++;
            }

            if (txt_email.Text != g_sOrigEmail)
            {
                iChanges++;
            }

            if (txt_ph.Text != g_sOrigPh)
            {
                iChanges++;
            }

            if(iChanges > 0)
            {
                panel1.BackColor = Color.Yellow;
                btn_update.Visible = true;
            }
            else
            {
                panel1.BackColor = Color.LightGreen;
                btn_update.Visible = false;
            }

            //txt_accountname.Text = sAccount;
            //txt_fname.Text = sFName;
            //txt_lname.Text = sLName;
            //txt_email.Text = sEmail;
            //txt_ph.Text = sPh;

            //string g_sOrigAccountName = sAccount;
            //string g_sOrigFirstName = sFName;
            //string g_sOrigLastName = sLName;
            //string g_sOrigEmail = sEmail;
            //string g_sOrigPh = sPh;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditAccountCustomer eac = new EditAccountCustomer();
            eac.LoadFromNewCustomer(g_sAccount);
            eac.ShowDialog();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            ReloadDataView();
        }
    }
}
