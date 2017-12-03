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
    public partial class ManualTime : Form
    {
        bool g_bPickedManualTime = false;

        public ManualTime()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            g_bPickedManualTime = true;

            Close();
        }

        public string GetTime()
        {
            return (cmb_timeinhours.Text + cmb_timeinminutes.Text);
        }

        public bool GetPickedManual()
        {
            return (g_bPickedManualTime);
        }
    }
}
