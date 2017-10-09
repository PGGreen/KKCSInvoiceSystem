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
    public partial class CashChangeCalc : Form
    {
        public CashChangeCalc()
        {
            InitializeComponent();

            text_change.Text = "0";
        }

        protected override void OnShown(EventArgs e)
        {
            txtbox_entercash.Focus();
            base.OnShown(e);
        }

        public void CashChangeCalculation(int _iCashChange)
        {
            txt_total.Text = _iCashChange.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void text_change_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_entercash_TextChanged(object sender, EventArgs e)
        {
            int iCashGiven = 0;

            try
            {
                iCashGiven = int.Parse(txtbox_entercash.Text);

                int iTotal = int.Parse(txt_total.Text);

                int iChangeToGive = iCashGiven - iTotal;

                text_change.Text = iChangeToGive.ToString();
            }
            catch
            {
                text_change.Text = "ERROR";
            }
        }
    }
}
