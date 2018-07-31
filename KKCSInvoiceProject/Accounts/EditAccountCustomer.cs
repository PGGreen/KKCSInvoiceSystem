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
    public partial class EditAccountCustomer : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        // Creates the OleDbConnection
        private OleDbConnection connection = new OleDbConnection();

        // Creates the OleDb Items
        OleDbDataReader reader;

        // Sets up the main OleDb Command
        OleDbCommand command;

        bool g_bIsFinishedLoading = false;

        bool g_bIsNewCustomer = false;

        string sOrigRego = "";
        string sOrigMake = "";
        string sOrigFirst = "";
        string sOrigLast = "";
        string sOrigPh = "";
        string sOrigAccPart = "";

        string sAccount = "";

        public EditAccountCustomer()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        public void LoadFromEditAccount(string _sRego, string _sAccount)
        {
            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NumberPlates WHERE NumberPlates = @Account";

            command.Parameters.AddWithValue("@Rego", _sRego);

            command.CommandText = query;

            reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                txt_rego.Text = reader["NumberPlates"].ToString();
                txt_make.Text = reader["MakeModel"].ToString();
                txt_firstname.Text = reader["ClientName"].ToString();
                txt_lastname.Text = reader["LastName"].ToString();
                txt_ph.Text = reader["Ph"].ToString();
                txt_accpart.Text = reader["AccountParticulars"].ToString();

                sOrigRego = txt_rego.Text;
                sOrigMake = txt_make.Text;
                sOrigFirst = txt_firstname.Text;
                sOrigLast = txt_lastname.Text;
                sOrigPh = txt_ph.Text;
                sOrigAccPart = txt_accpart.Text;
            }

            lbl_title.Text = txt_firstname.Text + " " + txt_lastname.Text + " under\r\n";
            lbl_title.Text += _sAccount + " account";

            g_bIsFinishedLoading = true;

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void LoadFromNewCustomer(string _sAccount)
        {
            sAccount = _sAccount;

            lbl_title.Text = "'New User under'\r\n" + _sAccount + " account";

            g_bIsNewCustomer = true;
            this.BackColor = Color.White;

            g_bIsFinishedLoading = true;

            btn_update.BackColor = Color.Red;
            btn_update.Text = "UNSAVED";
            btn_update.Visible = true;
        }

        void CheckChanges()
        {
            int iChanges = 0;

            if (txt_rego.Text != sOrigRego)
            {
                iChanges++;
            }

            if (txt_make.Text != sOrigMake)
            {
                iChanges++;
            }

            if (txt_firstname.Text != sOrigFirst)
            {
                iChanges++;
            }

            if (txt_lastname.Text != sOrigLast)
            {
                iChanges++;
            }

            if (txt_ph.Text != sOrigPh)
            {
                iChanges++;
            }

            if(txt_accpart.Text != sOrigAccPart)
            {
                iChanges++;
            }

            if (iChanges > 0)
            {
                this.BackColor = Color.Yellow;
                btn_update.Visible = true;
            }
            else
            {
                this.BackColor = Color.LightGreen;
                btn_update.Visible = false;
            }
        }

        private void txt_rego_TextChanged(object sender, EventArgs e)
        {
            if (g_bIsFinishedLoading && !g_bIsNewCustomer)
            {
                CheckChanges();
            }
        }

        private void txt_make_TextChanged(object sender, EventArgs e)
        {
            if (g_bIsFinishedLoading && !g_bIsNewCustomer)
            {
                CheckChanges();
            }
        }

        private void txt_firstname_TextChanged(object sender, EventArgs e)
        {
            if (g_bIsFinishedLoading && !g_bIsNewCustomer)
            {
                CheckChanges();
            }
        }

        private void txt_lastname_TextChanged(object sender, EventArgs e)
        {
            if (g_bIsFinishedLoading && !g_bIsNewCustomer)
            {
                CheckChanges();
            }
        }

        private void txt_ph_TextChanged(object sender, EventArgs e)
        {
            if (g_bIsFinishedLoading && !g_bIsNewCustomer)
            {
                CheckChanges();
            }
        }

        private void txt_accpart_TextChanged(object sender, EventArgs e)
        {
            if (g_bIsFinishedLoading && !g_bIsNewCustomer)
            {
                CheckChanges();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (g_bIsNewCustomer)
            {
                if(txt_rego.Text == "")
                {
                    WarningSystem ws = new WarningSystem("-Please at least enter a Car Rego", false);
                    ws.ShowDialog();

                    return;
                }
                
                connection.Open();

                command = new OleDbCommand();

                command.Connection = connection;

                string query = @"INSERT INTO NumberPlates (NumberPlates,ClientName,LastName,MakeModel,Ph,Account,AccountParticulars) 
                        values ('" + txt_rego.Text +
                        "','" + txt_firstname.Text +
                        "','" + txt_lastname.Text +
                        "','" + txt_make.Text +
                        "','" + txt_ph.Text +
                        "','" + sAccount +
                        "','" + txt_accpart.Text +
                        "')";

                command.CommandText = query;

                sOrigRego = txt_rego.Text;
                sOrigMake = txt_make.Text;
                sOrigFirst = txt_firstname.Text;
                sOrigLast = txt_lastname.Text;
                sOrigPh = txt_ph.Text;
                sOrigAccPart = txt_accpart.Text;

                g_bIsNewCustomer = false;

                command.ExecuteNonQuery();

                connection.Close();

                this.BackColor = Color.LightGreen;
                btn_update.Text = "UPDATE Changes";
                btn_update.BackColor = Color.Fuchsia;
                btn_update.Visible = false;
            }
            else
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command = new OleDbCommand();

                command.Connection = connection;

                string cmd1 = @"UPDATE NumberPlates SET NumberPlates = '" + txt_rego.Text +
                    "', MakeModel = '" + txt_make.Text +
                    "', ClientName = '" + txt_firstname.Text +
                    "', LastName = '" + txt_lastname.Text +
                    "', Ph = '" + txt_ph.Text +
                    "', AccountParticulars = '" + txt_accpart.Text +
                    "' WHERE NumberPlates = '" + sOrigRego + "'";

                command.CommandText = cmd1;

                command.ExecuteNonQuery();

                sOrigRego = txt_rego.Text;
                sOrigMake = txt_make.Text;
                sOrigFirst = txt_firstname.Text;
                sOrigLast = txt_lastname.Text;
                sOrigPh = txt_ph.Text;
                sOrigAccPart = txt_accpart.Text;

                this.BackColor = Color.LightGreen;
                btn_update.Visible = false;

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
