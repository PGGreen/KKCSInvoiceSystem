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
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
//using System.Data.OleDb;
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class PettyCash : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        private OleDbDataReader reader;

        float fPettyRemaning = 0;
        float fTotalRemaning = 0;

        float fPettyCashRemaning = 0.0f;
        float fPettyCashStart = 0.0f;

        bool bIsReceipt;

        public PettyCash()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            GetCurrentPettyCash();

            cmb_worker.SelectedIndex = 0;

            txt_itemamount.Focus();
        }

        void GetCurrentPettyCash()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM NewPettyCash ORDER BY DatePetty DESC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while(reader.Read())
            {
                fPettyRemaning = 0;
                float.TryParse(reader["PettyRunningTotal"].ToString(), out fPettyRemaning);

                txt_currentpetty.Text = fPettyRemaning.ToString("0.00");
                txt_pettycashremaning.Text = fPettyRemaning.ToString("0.00");

                break;
            }

            connection.Close();
        }

        #region Saved

        void Save()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            bIsReceipt = false;

            if(cmb_reciept.Text == "Yes")
            {
                bIsReceipt = true;
            }

            string cmd1 = @"INSERT INTO NewPettyCash (DatePetty,Item,Amount,PettyRunningTotal,Notes,Staff,Receipt) values
                                                    ('" + txt_returndate.Value + "','" +
                                                        txt_item.Text + "','" +
                                                        txt_itemamount.Text + "','" +
                                                        txt_pettycashremaning.Text + "','" +
                                                        txt_notes.Text + "','" +
                                                        cmb_worker.Text + "'," +
                                                        bIsReceipt +
                                                    ")";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            connection.Close();

            SendingEmails();
        }

        void SendingEmails()
        {
            fPettyCashRemaning = 0.0f;
            float.TryParse(txt_pettycashremaning.Text, out fPettyCashRemaning);

            string sTitleItem = "CAR STORAGE - PETTY CASH SPEND";

            string sBodyItem = "Petty Cash Item\r\n";
            sBodyItem += "------------------\r\n";

            sBodyItem += "Staff Member: " + cmb_worker.Text + "\r\n";
            sBodyItem += "Date: " + txt_returndate.Value.ToString() + "\r\n";
            sBodyItem += "Item(s): " + txt_item.Text + "\r\n";

            float fItemAmount = 0.0f;
            float.TryParse(txt_itemamount.Text, out fItemAmount);

            sBodyItem += "Amount: $" + fItemAmount.ToString("0.00") + "\r\n";
            
            fPettyCashStart = 0.0f;
            float.TryParse(txt_currentpetty.Text, out fPettyCashStart);

            string sIsReceipt = "";

            if(bIsReceipt)
            {
                sIsReceipt = "Yes";
            }
            else
            {
                sIsReceipt = "No";
            }
            sBodyItem += "Receipt Y/N: " + sIsReceipt + "\r\n";

            if (txt_notes.Text != "")
            {
                sBodyItem += "Note(s): " + txt_notes.Text + "\r\n";
            }

            sBodyItem += "------------------\r\n\r\n";
            sBodyItem += "Petty Cash Running Amount Start: $" + fPettyCashStart.ToString("0.00") + "\r\n";
            sBodyItem += "Minus cost of Item: -$" + fItemAmount.ToString("0.00") + "\r\n";
            sBodyItem += "Current Petty Cash Remaining: $" + fPettyCashRemaning.ToString("0.00");

            SendEmailTest(sTitleItem, sBodyItem, true);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int iWarnings = 0;

            if (fTotalRemaning < 0.0f)
            {
                string sWarning = "You do not have enough Petty Cash\r\n";
                sWarning += "left to complete this transaction.\r\n\r\n";
                sWarning += "Please Reimburse Petty Cash first.";
                WarningSystem ws = new WarningSystem(sWarning, false);

                ws.ShowDialog();

                iWarnings++;
            }
            else
            {
                float fPriceOfItem = 0.0f;
                bool bIsCurrency = float.TryParse(txt_itemamount.Text, out fPriceOfItem);

                string sWarning = "";

                if (!bIsCurrency && txt_itemamount.Text != "")
                {
                    sWarning = "-Please enter only numbers/currency\r\n";
                    sWarning += " e.g 10.50\r\n\r\n";

                    iWarnings++;
                }

                if(txt_itemamount.Text == "")
                {
                    sWarning = "-Please enter Cost of Item\r\n";
                    sWarning += " e.g 10.50\r\n\r\n";

                    iWarnings++;
                }

                if (txt_item.Text == "")
                {
                    sWarning = "-Please Enter an Item Name\r\n";

                    iWarnings++;
                }

                if(cmb_reciept.Text == "")
                {
                    sWarning = "-Please select if there is a Receipt or Not\r\n";

                    iWarnings++;
                }

                if(cmb_worker.Text == "Please Pick...")
                {
                    sWarning = "-Please select Staff Member\r\n";

                    iWarnings++;
                }

                if(iWarnings > 0)
                {
                    WarningSystem ws = new WarningSystem(sWarning, false);

                    ws.ShowDialog();
                }
            }

            if (iWarnings == 0)
            {
                Save();

                btn_save.Text = "Saved";
                btn_save.BackColor = Color.Green;

                PettyCash.ActiveForm.BackColor = Color.LightGreen;
            }
        }

        #endregion Saved

        #region TextChanged

        private void txt_itemamount_TextChanged_1(object sender, EventArgs e)
        {
            fTotalRemaning = 0;

            float fCurrentItemPrice = 0;
            float.TryParse(txt_itemamount.Text, out fCurrentItemPrice);

            txt_minusamount.Text = txt_itemamount.Text;

            fTotalRemaning = fPettyRemaning - fCurrentItemPrice;

            if(fTotalRemaning < 0.0f)
            {
                string sWarning = "You do not have enough Petty Cash\r\n";
                    sWarning += "left to complete this transaction.\r\n\r\n";
                    sWarning += "Please Reimburse Petty Cash first.";

                WarningSystem ws = new WarningSystem(sWarning, false);

                ws.ShowDialog();
            }

            txt_pettycashremaning.Text = fTotalRemaning.ToString("0.00");
        }

        #endregion TextChanged

        void SendEmailTest(string _sSubject, string _sBody, bool _bSendLow)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.live.com");
                client.Port = 25;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("pg8472@hotmail.com", "Voyger600!");
                MailMessage msg = new MailMessage();
                //msg.To.Add("peter.george.green@gmail.com");
                msg.To.Add("deborah.green@hertz.com");
                //msg.CC.Add("peter.george.green@gmail.com");
                msg.From = new MailAddress("pg8472@hotmail.com");
                msg.Subject = _sSubject;
                msg.Body = _sBody;
                Object state = msg;
                client.SendAsync(msg, state);

                if(_bSendLow)
                {
                    client.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (fPettyCashRemaning <= 50.0f)
            {
                string sTitle = "CAR STORAGE - PETTY CASH 'LOW WARNING'";

                string sBody = "Warning, the Petty Cash is getting low.\r\n\r\n";
                sBody += "Current Petty Cash is: $" + fPettyCashRemaning.ToString("0.00");
                SendEmailTest(sTitle, sBody, false);
            }
        }
    }
}