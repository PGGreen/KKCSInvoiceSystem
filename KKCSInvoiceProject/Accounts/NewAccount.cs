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
    public partial class NewAccount : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;
        private OleDbConnection connection = new OleDbConnection();

        private OleDbCommand command;

        public NewAccount()
        {
            InitializeComponent();
        }

        string AccountsTest()
        {
            string sCombinedNewAccount = "";
            /*
            command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtDate = DateTime.Today;
            //string query = @"SELECT * FROM Invoice WHERE ReturnMonth = '" + 02 + "' AND ReturnYear = '" + 2017 + "' AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DateInInvisible DESC";
            dtDate = new DateTime(2017, 1, dtDate.Day, 12, 0, 0);

            string query = "select * from CustomerInvoices WHERE year(DTReturnDate) = year(@dtDate) AND month(DTDatePaid) = month(@dtDate) AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DTDateIn ASC";
            command.Parameters.AddWithValue("@dtDate", dtDate);

            command.CommandText = query;

            reader = command.ExecuteReader();
            */

            //string StoreAccountName1 = "";
            //string StoreAccountName2 = "";
            

            string sLineBreak = "-------------------------------------------------------------------------------------------------------------------------";
            string sNextLine = "\r\n";

            bool bFirstTimeOnly = false;

            //sCombinedAccount += "Date In" + Padding.Left(5);

            //sTitle = "BOI Car Storage Yard - " + sMonthDisplay + " " + sYear + " Accounts";
            //sTitle = "BOI Car Storage Yard - January 2017 Accounts";
            DateTime dtToday = dt_accountsetup.Value;

            sCombinedNewAccount += "Date: " + dtToday + sNextLine;
            sCombinedNewAccount += "Account Name: " + txt_accountname.Text + sNextLine;
            sCombinedNewAccount += "Customer Name: " + txt_firstname.Text + " " + txt_lastname.Text + sNextLine;
            sCombinedNewAccount += "Phone: " + txt_ph + sNextLine;
            sCombinedNewAccount += "Email: " + txt_email.Text + sNextLine;
            sCombinedNewAccount += "Car Rego: " + txt_rego1.Text + sNextLine;
            sCombinedNewAccount += "Make/Model: " + txt_make1.Text + sNextLine + sNextLine;
            sCombinedNewAccount += "Notes: " + dtToday + sNextLine;

            int iPadLength = 25;

            //sCombinedNewAccount = "Date In".PadRight(15) + "Date Out".PadRight(15) + "Name".PadRight(35)
            //                    + "Rego".PadRight(25) + "Total" + sNextLine + sLineBreak + sNextLine + sNextLine;

            return (sCombinedNewAccount);

        }

        void SendAccountEmail()
        {
            lbl_sendingemail.Visible = true;

            SmtpClient client = new SmtpClient("smtp.live.com");
            client.Port = 25;
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(
                "pg8472@hotmail.com", "Voyger300");
            MailMessage msg = new MailMessage();
            //msg.To.Add("ar.boiairportcarstorage@outlook.com");
            msg.To.Add("peter.george.green@gmail.com");
            msg.From = new MailAddress("pg8472@hotmail.com");
            msg.Subject = "Test";
            msg.Body = AccountsTest();
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            client.SendAsync(msg, msg);
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // prompt user with "send cancelled" message 
            }
            if (e.Error != null)
            {
                // prompt user with error message 
            }
            else
            {
                lbl_sendingemail.Visible = false;
                MessageBox.Show("Accounts Email Sent Successfully", "Account Email");
                // prompt user with message sent!
                // as we have the message object we can also display who the message
                // was sent to etc ssss
            }

            // finally dispose of the message
            //if (msg != null)
            //    msg.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AccountsTest();
            SendAccountEmail();
        }

        private void btn_adddrivers_Click(object sender, EventArgs e)
        {
            btn_adddrivers.Location = new Point(btn_adddrivers.Location.X, btn_adddrivers.Location.Y + 50);

            //TextBox txt = new TextBox();
            //txt.Size = txt_firstname.Size;
            //txt.Location = new Point(txt_firstname.Location.X, txt_firstname.Location.Y + 50);
            //txt.Font = txt_firstname.Font;
            //panel1.Controls.Add(txt);
        }
    }
}