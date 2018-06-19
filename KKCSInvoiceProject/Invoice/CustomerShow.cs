﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KKCSInvoiceProject
{
    public partial class CustomerShow : Form
    {
        //int eError = 2147483647;

        public CustomerShow()
        {
            InitializeComponent();

            tim_currentime.Tick += timer1_Tick;

            tim_currentime.Enabled = true;
            tim_currentime.Interval = 1000;
        }

        public void WipeInformation()
        {
            lbl_stay.Text = "";
            txt_name.Text = "";
            txt_carrego.Text = "";
            txt_carmake.Text = "";
            dt_datein.Text = "";
            dt_returndate.Text = "";
            lbl_price.Text = "";
            lbl_ccfee.Visible = false;
            lbl_paidby.Text = "Paid By:";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("dd-MMM-yyyy\r\n  hh:mmtt");
        }

        public void UpdateInfo(string _sName, string _sRego, string _sCarMake, string _sAccount)
        {
            txt_name.Text = _sName;
            txt_carrego.Text = _sRego;
            txt_carmake.Text = _sCarMake;

            pnl_acc.Visible = false;

            if (_sAccount != "")
            {
                pnl_acc.Visible = true;
                lbl_acc.Text = _sAccount;
            }
        }

        public void UpdateDateAndTime(string _sTimeIn, string _sFlightOut, string _sDays)
        {
            dt_datein.Text = _sTimeIn;
            dt_returndate.Text = _sFlightOut;
            lbl_stay.Text = _sDays;
        }

        public void UpdatePaidStatus(string _sPaidStatus)
        {
            int i = 0;
        }

        public void UpdatePrice(string _sPrice, string _sPaidStatus)
        {
            //switch(_sPaidStatus)
            //{
            //    case "Eftpos":
            //    case "Credit Card":
            //        {
            //            lbl_paidby.BackColor = Color.Lime;
            //            break;
            //        }
            //}

            lbl_paidby.Text = "Paid By: " + _sPaidStatus;

            if(_sPrice == "UNKNOWN")
            {
                lbl_price.Text = "UNKNOWN";

                return;
            }

            lbl_ccfee.Visible = false;

            if (_sPaidStatus == "Credit Card")
            {
                lbl_ccfee.Visible = true;
            }

            if (_sPrice != "")
            {
                float fPrice = 0.0f;
                float.TryParse(_sPrice, out fPrice);

                lbl_price.Visible = true;
                lbl_price.Text = "$" + fPrice.ToString("0.00");
            }
            else
            {
                lbl_price.Visible = false;
                lbl_price.Text = "";
            }
        }

        #region TextChanged

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            if(txt_name.Text != "")
            {
                txt_name.BackColor = Color.LightGreen;
            }
            else
            {
                txt_name.BackColor = Color.White;
            }
        }

        private void txt_carrego_TextChanged(object sender, EventArgs e)
        {
            if (txt_carrego.Text != "")
            {
                txt_carrego.BackColor = Color.LightGreen;
            }
            else
            {
                txt_carrego.BackColor = Color.White;
            }
        }

        private void txt_carmake_TextChanged(object sender, EventArgs e)
        {
            if (txt_carmake.Text != "")
            {
                txt_carmake.BackColor = Color.LightGreen;
            }
            else
            {
                txt_carmake.BackColor = Color.White;
            }
        }

        private void dt_datein_TextChanged(object sender, EventArgs e)
        {
            if (dt_datein.Text != "")
            {
                dt_datein.BackColor = Color.LightGreen;
            }
            else
            {
                dt_datein.BackColor = Color.White;
            }
        }

        private void dt_returndate_TextChanged(object sender, EventArgs e)
        {
            if (dt_returndate.Text != "")
            {
                dt_returndate.BackColor = Color.LightGreen;
            }
            else
            {
                dt_returndate.BackColor = Color.White;
            }
        }

        #endregion TextChanged
    }
}