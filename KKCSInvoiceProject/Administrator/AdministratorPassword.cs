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
    }
}
