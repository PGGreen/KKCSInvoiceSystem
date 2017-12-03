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
    public partial class ReminderAddToReturns : Form
    {
        public ReminderAddToReturns()
        {
            InitializeComponent();

            cmb_printerpicked.SelectedIndex = 0;

            // Out of Colour Ink (Uncomment Next Line)
            //cmb_printerpicked.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NewCarReturns"];

            if (fm != null)
            {
                fm.Close();
            }

            NewCarReturns ncr = new NewCarReturns();
            ncr.Show();

            // Out of Colour Ink (Uncomment Next Line)
            //cmb_printerpicked.SelectedIndex = 1;

            // B&W Printer Down
            cmb_printerpicked.SelectedIndex = 0;

            ncr.PrintReturns(cmb_printerpicked.SelectedIndex);

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
