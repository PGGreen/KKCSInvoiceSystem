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
    public partial class AdminPricing : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        private OleDbConnection connection = new OleDbConnection();

        string sOrigPrice1 = "";
        string sOrigPrice27 = "";
        string sOrigPrice8 = "";
        string sOrigPriceMonth = "";
        string sOrigPriceCC = "";

        bool bIsFinishedLoading = false;

        Color cColorOriginal;

        public AdminPricing()
        {
            InitializeComponent();

            cColorOriginal = this.BackColor;

            connection.ConnectionString = m_strDataBaseFilePath;

            LoadPricing();
        }

        void StoreOriginalPrices()
        {
            sOrigPrice1 = txt_1.Text;
            sOrigPrice27 = txt_27.Text;
            sOrigPrice8 = txt_8.Text;
            sOrigPriceMonth = txt_month.Text;
            sOrigPriceCC = txt_creditcard.Text;
        }

        void LoadPricing()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from CarYardPricing";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                txt_1.Text = reader["One"].ToString();
                txt_27.Text = reader["TwoToSeven"].ToString();
                txt_8.Text = reader["EightPlus"].ToString();
                txt_month.Text = reader["MonthPlus"].ToString();
                txt_creditcard.Text = reader["CreditCardFee"].ToString();
            }

            StoreOriginalPrices();

            bIsFinishedLoading = true;

            connection.Close();
        }

        private void txt_1_TextChanged(object sender, EventArgs e)
        {
            CheckAgainstOrigValues();
        }

        private void txt_27_TextChanged(object sender, EventArgs e)
        {
            CheckAgainstOrigValues();
        }

        private void txt_8_TextChanged(object sender, EventArgs e)
        {
            CheckAgainstOrigValues();
        }

        private void txt_month_TextChanged(object sender, EventArgs e)
        {
            CheckAgainstOrigValues();
        }

        private void txt_creditcard_TextChanged(object sender, EventArgs e)
        {
            CheckAgainstOrigValues();
        }

        void CheckAgainstOrigValues()
        {
            this.BackColor = cColorOriginal;
            btn_update.Visible = false;
            lbl_changesmade.Visible = false;
            lbl_saved.Visible = true;

            if (bIsFinishedLoading)
            {
                if (!CheckIsNumber())
                {
                    return;
                }

                int iCount = 0;

                if (txt_1.Text != sOrigPrice1)
                {
                    iCount++;
                }
                if (txt_27.Text != sOrigPrice27)
                {
                    iCount++;
                }
                if (txt_8.Text != sOrigPrice8)
                {
                    iCount++;
                }
                if (txt_month.Text != sOrigPriceMonth)
                {
                    iCount++;
                }
                if (txt_creditcard.Text != sOrigPriceCC)
                {
                    iCount++;
                }

                if(iCount > 0)
                {
                    this.BackColor = Color.Yellow;
                    btn_update.Visible = true;
                    lbl_changesmade.Visible = true;

                    lbl_saved.Visible = false;
                }
            }
        }

        bool CheckIsNumber()
        {
            int iNumber = 0;
            float fNumber = 0.0f;

            bool b1IsNumber = int.TryParse(txt_1.Text, out iNumber);
            bool b27IsNumber = int.TryParse(txt_27.Text, out iNumber);
            bool b8IsNumber = int.TryParse(txt_8.Text, out iNumber);
            bool bMonthIsNumber = int.TryParse(txt_month.Text, out iNumber);
            bool bCCFIsNumber = float.TryParse(txt_creditcard.Text, out fNumber);

            if(!b1IsNumber || !b27IsNumber || !b8IsNumber || !bMonthIsNumber || !bCCFIsNumber)
            {
                WarningSystem ws = new WarningSystem("Please only use numbers", false);
                ws.ShowDialog();

                txt_1.Text = sOrigPrice1;
                txt_27.Text = sOrigPrice27;
                txt_8.Text = sOrigPrice8;
                txt_month.Text = sOrigPriceMonth;
                txt_creditcard.Text = sOrigPriceCC;

                return (false);
            }

            return (true);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string UpdateCommand = @"UPDATE CarYardPricing
                                    SET One = @one, TwoToSeven = @two, EightPlus = @eight,
                                        MonthPlus = @month, CreditCardFee = @ccf WHERE ID=1";

            command.Parameters.AddWithValue("@one", txt_1.Text);
            command.Parameters.AddWithValue("@two", txt_27.Text);
            command.Parameters.AddWithValue("@eight", txt_8.Text);
            command.Parameters.AddWithValue("@month", txt_month.Text);
            command.Parameters.AddWithValue("@ccf", txt_creditcard.Text);

            command.CommandText = UpdateCommand;

            command.ExecuteNonQuery();

            connection.Close();

            this.BackColor = cColorOriginal;
            btn_update.Visible = false;
            lbl_changesmade.Visible = false;

            lbl_saved.Visible = true;

            Form fmCustomerShow = Application.OpenForms["CustomerShow"];

            CustomerShow objCustomerShow = (CustomerShow)fmCustomerShow;
            objCustomerShow.UpdatePricing();

            StoreOriginalPrices();
        }
    }
}
