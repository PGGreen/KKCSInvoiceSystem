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
    public partial class PettyCashReimburse : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        private OleDbDataReader reader;

        float fPettyRemaning = 0;

        public PettyCashReimburse()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
            
            GetCurrentPettyCash();

            FindStaffMembers();

            cmb_worker.SelectedIndex = 0;
        }

        void FindStaffMembers()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from Staff";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            cmb_worker.Items.Add("Please Pick...");

            while (reader.Read())
            {
                cmb_worker.Items.Add(reader["StaffMember"].ToString());
            }

            connection.Close();
        }

        void GetCurrentPettyCash()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NewPettyCash ORDER BY DatePetty DESC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                fPettyRemaning = 0;
                float.TryParse(reader["PettyRunningTotal"].ToString(), out fPettyRemaning);

                txt_pccurrent.Text = fPettyRemaning.ToString("0.00");

                break;
            }

            float fAmountTo = 200.0f - fPettyRemaning;

            txt_currentpetty.Text = fAmountTo.ToString("0.00");
            txt_totalnew.Text = (fAmountTo + fPettyRemaning).ToString("0.00");

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }

        #region Save

        void Save()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            bool bIsReimburse = true;

            string cmd1 = @"INSERT INTO NewPettyCash (DatePetty,Amount,PettyRunningTotal,Notes,IsReimburse) values
                                                    ('" + txt_returndate.Value + "','" +
                                                        txt_currentpetty.Text + "','" +
                                                        txt_totalnew.Text + "','" +
                                                        txt_notes.Text + "'," +
                                                        bIsReimburse +
                                                    ")";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #endregion Save

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            Save();

            btn_save.Text = "Saved";
            btn_save.BackColor = Color.Green;

            PettyCash.ActiveForm.BackColor = Color.LightGreen;
        }
    }
}
