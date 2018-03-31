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
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class WarningSystemEmail : Form
    {
        public WarningSystemEmail(string _sWarning)
        {
            InitializeComponent();

            System.Media.SystemSounds.Asterisk.Play();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(600, 300);

            lbl_warning.Text = _sWarning;
        }
    }
}
