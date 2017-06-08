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
    public partial class Refunds : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        CarReturnsInvoice carReturnsInvoice;

        string sInvoiceNumber = "";
        string sCarRego = "";

        public Refunds(CarReturnsInvoice _carReturnsInvoice)
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            carReturnsInvoice = _carReturnsInvoice;

            this.FormClosing += Refunds_FormClosing;

            cmb_refund1.SelectedIndex = 0;
            cmb_refund2.SelectedIndex = 1;
        }

        void Save()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string sReturnDate = "";

            sReturnDate = dt_todaysdate.Value.DayOfWeek.ToString() + ", " +
            dt_todaysdate.Value.Day.ToString() + " " +
            dt_todaysdate.Value.ToString("MMMM") + " " +
            dt_todaysdate.Value.Year.ToString();

            string cmd1 = @"INSERT into Refunds (DateRefund,Refund1,Refund2,Refund1Location,Refund2Location,Notes,InvoiceNumber,Rego) values
                                                        ('" + sReturnDate + "','" +
                                                            txt_refund1.Text + "','" +
                                                            txt_refund2.Text + "','" +
                                                            cmb_refund1.Text + "','" +
                                                            cmb_refund2.Text + "','" +
                                                            txt_notes.Text + "','" +
                                                            sInvoiceNumber + "','" +
                                                            sCarRego +
                                                        "')";
            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void SetDataToRefunds(DateTime _DateIn, DateTime _DateReturn, string _TotalPrice, string _TimeIn, string _ReturnTime, string _iInvoiceNo, string _sCarRego)
        {
            dt_cardroppedoff.Value = _DateIn;
            dt_originaldue.Value = _DateReturn;
            txt_originaltotal.Text = _TotalPrice;

            sInvoiceNumber = _iInvoiceNo;
            sCarRego = _sCarRego;

            int iTimeIn = 0;
            int iReturnTime = 0;
            int iTotalPrice = 0;

            Int32.TryParse(_TimeIn, out iTimeIn);
            Int32.TryParse(_ReturnTime, out iReturnTime);
            Int32.TryParse(_TotalPrice, out iTotalPrice);

            DateTime dtTimeReturn = new DateTime(_DateReturn.Year, _DateReturn.Month, _DateReturn.Day, 12, 0, 0);
            DateTime stTodaysDate = new DateTime(dt_todaysdate.Value.Year, dt_todaysdate.Value.Month, dt_todaysdate.Value.Day, 12, 0, 0);

            int iDayDifference = (int)(dtTimeReturn - stTodaysDate).TotalDays;

            if (iReturnTime - iTimeIn > 4)
            {
                iDayDifference += 1;
            }

            iTotalPrice = iDayDifference * 10;

            txt_refundowned.Text = iTotalPrice.ToString();

            txt_refund1.Text = txt_refundowned.Text;
        }

        private void chkbox_nocharge_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_nocharge.Checked == true)
            {
                cmb_refund2.Visible = true;
                txt_refund2.Visible = true;
                txt_dollar2.Visible = true;

                cmb_refund2.Enabled = true;
                txt_refund2.Enabled = true;
                txt_dollar2.Enabled = true;
            }
            else
            {
                cmb_refund2.Visible = false;
                txt_refund2.Visible = false;
                txt_dollar2.Visible = false;

                cmb_refund2.Enabled = false;
                txt_refund2.Enabled = false;
                txt_dollar2.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();

            labl_savedstatus.Text = "Saved";
            labl_savedstatus.ForeColor = Color.Green;
        }

        private void Refunds_FormClosing(object sender, FormClosingEventArgs e)
        {
            //instanceForm1.fillComboBox();//Step 5 we call the method to execute the task updating the form1
            carReturnsInvoice.GetRefundGiven().Visible = true;
        }

        private void txt_refund2_TextChanged(object sender, EventArgs e)
        {
            int iRefundOwed = 0;
            int iRefund2 = 0;

            Int32.TryParse(txt_refundowned.Text, out iRefundOwed);
            Int32.TryParse(txt_refund2.Text, out iRefund2);

            txt_refund1.Text = (iRefundOwed - iRefund2).ToString();
        }

        private void txt_refund1_TextChanged(object sender, EventArgs e)
        {
            int iRefundOwed = 0;
            int iRefund1 = 0;

            Int32.TryParse(txt_refundowned.Text, out iRefundOwed);
            Int32.TryParse(txt_refund1.Text, out iRefund1);

            txt_refund2.Text = (iRefundOwed - iRefund1).ToString();
        }
    }
}