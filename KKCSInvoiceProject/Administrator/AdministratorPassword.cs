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
    public partial class AdministratorPassword : Form
    {
        public AdministratorPassword()
        {
            InitializeComponent();

            label1.Enabled = false;
            txt_password.Enabled = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_password.Text == "4026")
            {
                Administrator adp = new Administrator();
                adp.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Password Incorrect");

                txt_password.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = false;
            txt_password.Enabled = false;
            button1.Enabled = false;

            if (checkBox1.Checked)
            {
                label1.Enabled = true;
                txt_password.Enabled = true;
                button1.Enabled = true;
            }
        }
    }
}
