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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void btn_alerts_Click(object sender, EventArgs e)
        {
            AdminAlerts aa = new AdminAlerts();
            aa.Show();
        }

        private void btn_flighttimes_Click(object sender, EventArgs e)
        {
            AdminFlightTimes aft = new AdminFlightTimes();
            aft.Show();
        }

        private void btn_pricing_Click(object sender, EventArgs e)
        {
            AdminPricing ap = new AdminPricing();
            ap.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminStaff staff = new AdminStaff();
            staff.ShowDialog();
        }

        private void btn_baddebot_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NewCarReturns"];

            if (fm != null)
            {
                fm.Close();

                NewCarReturns ncr = new NewCarReturns();
                ncr.Show();
                ncr.LoadBadDebots();
            }
            else
            {
                NewCarReturns ncr = new NewCarReturns();
                ncr.Show();
                ncr.LoadBadDebots();
            }
        }
    }
}
