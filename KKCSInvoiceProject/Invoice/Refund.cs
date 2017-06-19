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
        public Refund()
        {
            InitializeComponent();
        }

        private void chk_addascredit_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_addascredit.Checked)
            {
                pnl_credit.Visible = true;
                pnl_refund.Visible = false;

                pnl_credit.Enabled = true;
                pnl_refund.Enabled = false;
            }
            else
            {
                pnl_credit.Visible = false;
                pnl_refund.Visible = true;

                pnl_credit.Enabled = false;
                pnl_refund.Enabled = true;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}