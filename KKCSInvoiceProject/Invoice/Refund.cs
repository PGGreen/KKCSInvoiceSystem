using System;
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
    public partial class Refund : Form
    {
        DateTime m_dtIn;
        DateTime m_dtOut;
        string m_sPrice;
        string m_sInvoice;
        string m_sTimeIn;
        string m_sTimeOut;

        public Refund()
        {
            InitializeComponent();

            LoadCredit();
        }

        private void LoadCredit()
        {

        }
        
        public void SetUpRefund()
        {
            // Sets up the global days and times
            int iDays = 0;
            int iTimeInHours = 0;
            int iReturnTimeHours = 0;

            int iTotalMoney = 0;

            //int iFirstDay = 15;
            int iDaysAfter = 12;
            int iDays7Plus = 10;
            int iMonth = 55;

            DateTime dtToday = DateTime.Now;

            // Works out how many days there are between the date the car was
            // brought in, and when they are returning
            TimeSpan TimeDifference = m_dtOut - dtToday;

            // Put the difference of days into the variable
            iDays = TimeDifference.Days;

            // Works out if the hours are above 20. If they are, add 1 day to the price
            if (TimeDifference.Hours > 20)
            {
                iDays++;
            }

            //m_sTimeIn
            //m_sTimeOut

            // Gets the time the customer brought the car in
            iTimeInHours = int.Parse(m_sTimeIn.Substring(0, 2));

            iReturnTimeHours = int.Parse(m_sTimeOut.Substring(0, 2));

            // If there is a gap of more than 4 hours between dropping off and picking up, add another days pay
            if (iReturnTimeHours - iTimeInHours > 4 && iDays != 0)
            {
                iDays++;
            }

            // Checks to see if the pricing is within a month, or over

            // This means they are staying less than a month
            if (iDays < 28)
            {
                // If the days are less than 0, this is impossible so give an error
                if (iDays < 0)
                {
                    
                }

                // If they are only staying for 1 day
                else if (iDays == 0 || iDays == 1)
                {
                    iTotalMoney = 15;
                }

                // If they are staying between 2 to 7 days
                else if (iDays >= 2 && iDays <= 7)
                {
                    // Multiplies the price by the number of days
                    //int iCalculateTotal = (15 + (iDaysAfter * (iDays - 1)));
                    int iCalculateTotal = ((iDaysAfter * iDays) + 3);

                    // Puts in the price in to the box
                    iTotalMoney = iCalculateTotal;
                }

                else
                {
                    int iCalculateTotal = (87 + (iDays7Plus * (iDays - 7)));

                    iTotalMoney = iCalculateTotal;
                }
            }
            // This calculates prices if the customer are staying over 1 month or more
            else if (iDays >= 28)
            {
                float fWorkOutWeeks = (float)iDays / 7;

                int iWorkOutWeeks = (int)decimal.Round((decimal)fWorkOutWeeks, 0, MidpointRounding.AwayFromZero);

                iTotalMoney = iMonth * iWorkOutWeeks;
            }

            // Adds the credit card fee if applicable
            //if (g_sPaidStatus == "Credit Card")
            //{
            //    float fTempCreditCardCharge = (float)iTotalMoney * 0.02f;

            //    float fTempTotalPrice = (float)iTotalMoney + fTempCreditCardCharge;
            //    txt_total.Text = fTempTotalPrice.ToString("N2");

            //    lbl_cccharges.Visible = true;
            //}
            //else
            //{
            //    txt_total.Text = iTotalMoney.ToString();

            //    lbl_cccharges.Visible = false;

            //    txt_total.Text = iTotalMoney.ToString();
            //}

            //if (iDays > 1)
            //{
            //    lbl_stay.Text = iDays.ToString("0") + " Days";
            //}
            //else
            //{
            //    lbl_stay.Text = iDays.ToString("0") + " Day";
            //}
        }
        
        private void chk_addascredit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void LoadInfoFromInvoice(DateTime _dtIn, DateTime _dtOut, string _sTimeIn, string _sTimeOut,
                                        string _sPrice, string _sInvoice, string _sDays, string _sFName,
                                         string _sLName, string _sRego, string _sPaidStatus)
        {
            m_dtIn = _dtIn;
            m_dtOut = _dtOut;
            m_sPrice = _sPrice;
            m_sInvoice = _sInvoice;
            m_sTimeIn = _sTimeIn;
            m_sTimeOut = _sTimeOut;

            DateTime dtToday = DateTime.Now;

            TimeSpan TimeDifference = m_dtOut - dtToday;
            int iDays = TimeDifference.Days;

            SetUpRefund();

            //lbl_daysearl.Text += " " + _sDays;

            //TimeSpan TimeDifference = m_dtOut - dtToday;
            //int iDays = TimeDifference.Days;

            //lbl_daysearly.Text += " " + iDays.ToString();
        }

        private void btn_eftpos_Click(object sender, EventArgs e)
        {
            pnl_credit.Visible = false;
            pnl_refund.Visible = false;
            cmb_location.Visible = false;
            lbl_from.Visible = false;

            pnl_refund.Visible = true;
            cmb_location.Visible = false;
            lbl_from.Visible = false;

            lbl_typeofrefund.Text = "Eftpos Refund";

            btn_confirm.Visible = true;
            btn_instructions.Visible = true;
        }

        private void btn_cash_Click(object sender, EventArgs e)
        {
            pnl_credit.Visible = false;
            pnl_refund.Visible = false;

            cmb_location.Visible = true;
            lbl_from.Visible = true;
            pnl_refund.Visible = true;

            lbl_typeofrefund.Text = "Cash Refund";

            btn_confirm.Visible = true;
            btn_instructions.Visible = false;
        }

        private void btn_credit_Click(object sender, EventArgs e)
        {
            pnl_credit.Visible = false;
            pnl_refund.Visible = false;

            pnl_credit.Visible = true;

            btn_confirm.Visible = true;
        }
    }
}