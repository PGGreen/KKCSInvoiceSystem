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

            //WorkOutTotalPettyCash();
        }

        void GetCurrentPettyCash()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NewPettyCash ORDER BY ID DESC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                fPettyRemaning = 0;
                float.TryParse(reader["PettyRunningTotal"].ToString(), out fPettyRemaning);

                txt_currentpetty.Text = fPettyRemaning.ToString("0.00");

                break;
            }

            connection.Close();

            RestCalculation();
        }

        void RestCalculation()
        {
            float fReimburseAmount = 0.0f;
            fReimburseAmount = 200.0f - fPettyRemaning;

            txt_pettyadding.Text = fReimburseAmount.ToString("0.00");

            float New = fReimburseAmount + fPettyRemaning;
            txt_newpettycash.Text = New.ToString("0.00");
        }

        #region Save

        void Save()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            bool bIsReimburse = true;

            string cmd1 = @"INSERT INTO NewPettyCash (DatePetty,Amount,PettyRunningTotal,Notes,IsReimburse) values
                                                    ('" + txt_returndate.Value + "','" +
                                                        txt_pettyadding.Text + "','" +
                                                        txt_newpettycash.Text + "','" +
                                                        txt_notes.Text + "'," +
                                                        bIsReimburse +
                                                    ")";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            connection.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

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
