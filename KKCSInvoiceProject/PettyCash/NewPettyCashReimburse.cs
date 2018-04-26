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

            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            

            RestCalculation();
        }

        void RestCalculation()
        {
            float fReimburseAmount = 0.0f;
            fReimburseAmount = 200.0f - fPettyRemaning;

            //txt_pettyadding.Text = fReimburseAmount.ToString("0.00");

            float New = fReimburseAmount + fPettyRemaning;
            //txt_newpettycash.Text = New.ToString("0.00");
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
                                                        //txt_pettyadding.Text + "','" +
                                                        //txt_newpettycash.Text + "','" +
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

        private void chk_to200_CheckedChanged(object sender, EventArgs e)
        {
            lbl_custom.Enabled = true;
            txt_custom.Enabled = true;

            if (chk_to200.Checked)
            {
                lbl_custom.Enabled = false;
                txt_custom.Enabled = false;
                txt_custom.Text = "";

                float fCurrent = 0.0f;
                float.TryParse(txt_pccurrent.Text, out fCurrent);

                float fTotal = 200.0f - fCurrent;

                txt_currentpetty.Text = "+" + fTotal.ToString("0.00");

                textBox3.Text = "200.00";
            }
            else
            {
                txt_currentpetty.Text = "";
                textBox3.Text = "";

                txt_currentpetty.BackColor = Color.White;
                textBox3.BackColor = Color.White;
            }
        }

        private void txt_currentpetty_TextChanged(object sender, EventArgs e)
        {
            txt_currentpetty.BackColor = Color.White;

            if (txt_currentpetty.Text != "")
            {
                txt_currentpetty.BackColor = Color.Yellow;
                textBox3.BackColor = Color.LightGreen;
            }
        }

        private void txt_custom_TextChanged(object sender, EventArgs e)
        {
            lbl_amounttoadd.Visible = true;
            txt_currentpetty.Visible = true;

            if (txt_custom.Text == "")
            {
                txt_currentpetty.Text = "";
                textBox3.Text = "";

                txt_currentpetty.BackColor = Color.White;
                textBox3.BackColor = Color.White;
            }
            else
            {
                textBox3.BackColor = Color.LightGreen;

                lbl_amounttoadd.Visible = false;
                txt_currentpetty.Visible = false;

                float fCurrent = 0.0f;
                float.TryParse(txt_pccurrent.Text, out fCurrent);

                float fCustom = 0.0f;
                float.TryParse(txt_custom.Text, out fCustom);

                float fTotal = fCustom + fCurrent;

                textBox3.Text = fTotal.ToString("0.00");
            }
        }
    }
}
