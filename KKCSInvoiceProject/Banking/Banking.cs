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
    public partial class Banking : Form
    {
        string date;

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        public Banking()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            New();

            FindStaffMembers();
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

        void New()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            date = txt_returndate.Value.Day.ToString() + "/" + txt_returndate.Value.Month.ToString("00") + "/" + txt_returndate.Value.ToString("yy");

            command.Connection = connection;

            string query = "select * from MoneyInYard WHERE DateYard = '"+ date + "'";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                lbl_inplasticbox.Text += " $" + reader["TinSOD"].ToString();
                txt_amount.Text = reader["TinSOD"].ToString();
            }

            connection.Close();
        }

        void Save()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string cmd1 = @"INSERT into Banking (DateBanking,Amount) values ('" + date + "','" + txt_amount.Text + "')";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            command.ExecuteNonQuery();

            connection.Close();




            connection.Open();

            OleDbCommand command2 = new OleDbCommand();

            command2.Connection = connection;

            string cmd12 = @"UPDATE MoneyInYard SET Banking = '" + txt_amount.Text + "' WHERE DateYard = '" + date + "'";

            // Makes the command text equal the string
            command2.CommandText = cmd12;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            command2.ExecuteNonQuery();

            connection.Close();

        }

        private void chkbox_splitpay_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (chkbox_splitpay.Checked == true)
            {
                txt_dollar2.Visible = true;
                txt_amount2.Visible = true;
                cmb_amount2.Visible = true;

                txt_dollar2.Enabled = true;
                txt_amount2.Enabled = true;
                cmb_amount2.Enabled = true;

                cmb_amount2.SelectedIndex = 1;
            }
            else
            {
                txt_dollar2.Visible = false;
                txt_amount2.Visible = false;
                cmb_amount2.Visible = false;

                txt_dollar2.Enabled = false;
                txt_amount2.Enabled = false;
                cmb_amount2.Enabled = false;

                cmb_amount2.SelectedIndex = -1;
            }
            */
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();

            btn_save.BackColor = Color.Green;

            this.BackColor = Color.LightGreen;

            btn_save.Text = "SAVED";

            btn_save.Enabled = false;
            /*
            // Checks to see if anything is left blank
            if (txt_item.Text == "" || txt_amount1.Text == "" || cmb_reciept.Text == "")
            {
                if (txt_item.Text == "")
                {
                    sWarning += "\n" + "-Item";
                }

                if (cmb_reciept.Text == "")
                {
                    sWarning += "\n" + "-Reciept";
                }

                if (txt_amount1.Text == "")
                {
                    sWarning += "\n" + "-Amount";
                }
            }
            else
            {
                bCheck1 = true;
            }

            if (chkbox_splitpay.Checked == true && txt_amount2.Text == "")
            {
                sWarning += "\n" + "-Second Amount";
            }
            else
            {
                bCheck2 = true;
            }

            if (bCheck1 && bCheck2)
            {
                Save();

                labl_savedstatus.Text = "Saved";
                labl_savedstatus.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show(sWarning, "ERROR");

                bCheck1 = false;
                bCheck2 = false;
            }
            */
        }

        private void chk_no_CheckedChanged(object sender, EventArgs e)
        {
            lbl_pleaseentercustom.Enabled = false;
            lbl_amountbacking.Enabled = false;
            txt_amount.Enabled = false;

            if (chk_no.Checked)
            {
                lbl_pleaseentercustom.Enabled = true;
                lbl_amountbacking.Enabled = true;
                txt_amount.Enabled = true;

                chk_yes.Checked = false;
            }
        }

        private void chk_yes_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_yes.Checked)
            {
                chk_no.Checked = false;
            }
        }
    }
}