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
        public WarningSystemEmail()
        {
            InitializeComponent();

            //System.Threading.Thread.Sleep(10000);

            //SendAccountEmail();
        }

        public void SendAccountEmail()
        {
            SmtpClient client = new SmtpClient("smtp.live.com");
            client.Port = 25;
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("pg8472@hotmail.com", "Voyger300");
            MailMessage msg = new MailMessage();
            //msg.To.Add("ar.boiairportcarstorage@outlook.com");
            msg.To.Add("peter.george.green@gmail.com");
            msg.From = new MailAddress("pg8472@hotmail.com");
            msg.Subject = "Test";
            msg.Body = "K";// AccountsTest();
            client.Send(msg);

            this.Close();
            
        }
    }
}
