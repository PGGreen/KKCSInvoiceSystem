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
    public partial class PettyCash : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        private OleDbDataReader reader;

        float fPettyRemaning = 0;
        float fTotalRemaning = 0;

        public PettyCash()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            GetCurrentPettyCash();
        }

        void GetCurrentPettyCash()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NewPettyCash ORDER BY ID DESC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while(reader.Read())
            {
                fPettyRemaning = 0;
                float.TryParse(reader["PettyRunningTotal"].ToString(), out fPettyRemaning);

                txt_currentpetty.Text = fPettyRemaning.ToString("0.00");
                txt_pettycashremaning.Text = fPettyRemaning.ToString("0.00");

                break;
            }

            connection.Close();
        }

        #region Saved

        void Save()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            bool bIsReceipt = false;

            if(cmb_reciept.Text == "Yes")
            {
                bIsReceipt = true;
            }

            string cmd1 = @"INSERT INTO NewPettyCash (DatePetty,Item,Amount,PettyRunningTotal,Notes,Receipt) values
                                                    ('" + txt_returndate.Value + "','" +
                                                        txt_item.Text + "','" +
                                                        txt_itemamount.Text + "','" +
                                                        txt_pettycashremaning.Text + "','" +
                                                        txt_notes.Text + "'," +
                                                        bIsReceipt +
                                                    ")";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            connection.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (fTotalRemaning < 0.0f)
            {
                string sWarning = "You do not have enough Petty Cash\r\n";
                sWarning += "left to complete this transaction.\r\n\r\n";
                sWarning += "Please Reimburse Petty Cash first.";
                WarningSystem ws = new WarningSystem(sWarning, false);

                ws.ShowDialog();
            }
            else
            {
                Save();

                btn_save.Text = "Saved";
                btn_save.BackColor = Color.Green;

                PettyCash.ActiveForm.BackColor = Color.LightGreen;
            }
        }

        #endregion Saved

        #region TextChanged

        private void txt_itemamount_TextChanged_1(object sender, EventArgs e)
        {
            fTotalRemaning = 0;

            float fCurrentItemPrice = 0;
            float.TryParse(txt_itemamount.Text, out fCurrentItemPrice);

            txt_minusamount.Text = txt_itemamount.Text;

            fTotalRemaning = fPettyRemaning - fCurrentItemPrice;

            if(fTotalRemaning < 0.0f)
            {
                string sWarning = "You do not have enough Petty Cash\r\n";
                    sWarning += "left to complete this transaction.\r\n\r\n";
                    sWarning += "Please Reimburse Petty Cash first.";

                WarningSystem ws = new WarningSystem(sWarning, false);

                ws.ShowDialog();
            }

            txt_pettycashremaning.Text = fTotalRemaning.ToString("0.00");
        }

        #endregion TextChanged
    }
}