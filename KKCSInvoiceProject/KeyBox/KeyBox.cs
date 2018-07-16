﻿using System;
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
using System.IO;

namespace KKCSInvoiceProject
{
    public partial class KeyBox : Form
    {
        #region GlobalVariables

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        List<TextBox> textBoxes = new List<TextBox>();

        List<string> lstStrRegos = new List<string>();

        List<Button> lstKeyBox = new List<Button>();

        int iLocationX = 0;
        int iLocationY = 0;

        int iCount = 0;

        #endregion GlobalVariables

        #region Load

        public KeyBox()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            PopulateKeyBoxButtons();

            //for (int i = 0; i < lstKeyBox.Count; i++)
            //{
            //    Button btn = new Button();
            //    btn.BackColor = lstKeyBox[i].BackColor;

            //    btnTempOriginalButtons.Add(btn);
            //}

            //GetXMLFiles("H:\\Music");
        }

        /*
        public static IEnumerable<string> GetXMLFiles(string directory)
        {
            List<string> files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(directory, "*", SearchOption.AllDirectories));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string s = Path.GetFileName(files[94]);

            return files;
        }
        */
        #endregion Load

        #region CreateRegoButtons

        void PopulateKeyBoxButtons()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from CustomerInvoices WHERE PickUp = False AND IsLongTerm = False ORDER BY KeyNumber";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            int iNumberOfCars = 0;
            //int iNumberOfNoKeys = 0;
            lbl_nokey.Visible = false;

            int iLocationNoKeyX = 0;

            for (int i = 0; i < 70; i++)
            {
                Button RegoButton = CreateRegoButtons();

                RegoButton.Text = (i + 1).ToString() + ". ";
                RegoButton.BackColor = Color.MistyRose;

                lstKeyBox.Add(RegoButton);
            }
            
            while (reader.Read())
            {
                string sKeyNumber = reader["KeyNumber"].ToString();

                if(sKeyNumber == "NK")
                {
                    lbl_nokey.Visible = true;

                    Button NoKeyRegoButton = new Button();

                    NoKeyRegoButton.Size = btn_nokeytemp.Size;
                    NoKeyRegoButton.Font = btn_nokeytemp.Font;
                    NoKeyRegoButton.Location = new Point(btn_nokeytemp.Location.X + iLocationNoKeyX, btn_nokeytemp.Location.Y);
                    NoKeyRegoButton.Text = reader["Rego"].ToString();
                    NoKeyRegoButton.BackColor = Color.LightGreen;
                    NoKeyRegoButton.Name = reader["Rego"].ToString();

                    string sInvoiceNumber = reader["InvoiceNumber"].ToString();
                    NoKeyRegoButton.Click += (sender, EventArgs) => { InvoiceButton_Click(sender, EventArgs, sInvoiceNumber); };

                    cmb_regos.Items.Add(reader["Rego"].ToString());
                    lstKeyBox.Add(NoKeyRegoButton);

                    iLocationNoKeyX += 130;

                    Controls.Add(NoKeyRegoButton);
                }

                int iTempKeyNumber = 0;
                bool bIsNumber = int.TryParse(sKeyNumber, out iTempKeyNumber);

                if(bIsNumber)
                {
                    string sRego = reader["Rego"].ToString();

                    lstKeyBox[iTempKeyNumber - 1].Text = iTempKeyNumber.ToString() + ". " + reader["Rego"].ToString();
                    lstKeyBox[iTempKeyNumber - 1].Name = sRego;
                    lstKeyBox[iTempKeyNumber - 1].BackColor = Color.LightGreen;

                    string sInvoiceNumber = reader["InvoiceNumber"].ToString();

                    if(sRego == "")
                    {
                        lstKeyBox[iTempKeyNumber - 1].BackColor = Color.LightBlue;
                        lstKeyBox[iTempKeyNumber - 1].Text = iTempKeyNumber.ToString() + ". " + "On Hold";

                        lstKeyBox[iTempKeyNumber - 1].Click += (sender, EventArgs) => { DeleteInvoice_Click(sender, EventArgs, sInvoiceNumber, iTempKeyNumber); };
                    }
                    else
                    {
                        lstKeyBox[iTempKeyNumber - 1].Click += (sender, EventArgs) => { InvoiceButton_Click(sender, EventArgs, sInvoiceNumber); };

                        cmb_regos.Items.Add(reader["Rego"].ToString());
                    }
                }

                iNumberOfCars++;
            }
            
            cmb_regos.Sorted = true;

            txt_nocars.Text = iNumberOfCars.ToString() + "/70 Cars";

            connection.Close();
        }

        Button CreateRegoButtons()
        {
            Font fFont = new Font(btn_one.Font.FontFamily, 14.0f , FontStyle.Bold);

            Button btn = new Button();

            btn.Font = fFont;//btn_one.Font;
            //btn.Font.Size = btn_one.Font.Size;

            btn.Location = new Point(btn_one.Location.X + iLocationX, btn_one.Location.Y + iLocationY);
            btn.Size = btn_one.Size;

            Controls.Add(btn);

            iLocationX += 157;

            iCount++;

            if (iCount % 10 == 0)
            {
                iLocationX = 0;
                iLocationY += 95;
            }

            return (btn);
        }

        #endregion CreateRegoButtons

        #region SelectRego

        List<Button> btnTempOriginalButtons = new List<Button>();

        private void cmb_regos_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lstKeyBox.Count; i++)
            {
                Button btn = new Button();
                btn.BackColor = lstKeyBox[i].BackColor;

                btnTempOriginalButtons.Add(btn);
            }

            foreach (Button btn in lstKeyBox)
            {
                if (btn.Name == cmb_regos.Text)
                {
                    btn.BackColor = Color.Red;
                }
                else
                {
                    btn.BackColor = Color.White;
                }
            }
        }

        #endregion SelectRego

        #region Buttons

        private void InvoiceButton_Click(object sender, EventArgs e, string _sInvoiceNumber)
        {
            int x = 0;
            Int32.TryParse(_sInvoiceNumber, out x);

            Invoice inv = new Invoice(true);

            inv.SetUpFromCarReturns(x, null);

            inv.Show();
        }

        private void DeleteInvoice_Click(object sender, EventArgs e, string _sInvoiceNumber, int _iKeyNumber)
        {
            Form fm = Application.OpenForms["InvoiceManager"];
            InvoiceManager im = (InvoiceManager)fm;

            int iCountError = 0;

            if (im != null)
            {
                for (int i = 0; i < im.GetInvoiceFormList().Count; i++)
                {
                    Invoice invoice = (Invoice)im.GetInvoiceFormList()[i];
                    string sKeyNumber = invoice.GetKeyNumber();

                    if(_iKeyNumber.ToString("00") == sKeyNumber)
                    {
                        iCountError++;
                    }
                }
            }

            if(iCountError > 0)
            {
                string sWarning = "This Invoice is still active/open.";

                WarningSystem ws = new WarningSystem(sWarning, false);
                ws.ShowDialog();
            }
            else
            {

                string sWarning = "Do you wish to release this key?";

                WarningSystem ws = new WarningSystem(sWarning, true);
                ws.ShowDialog();

                if (ws.DialogResult == DialogResult.OK)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();

                    command.Connection = connection;

                    string query = "DELETE FROM CustomerInvoices WHERE InvoiceNumber = @invoceNumber";

                    command.Parameters.AddWithValue("@invoceNumber", _sInvoiceNumber);

                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();

                    connection.Close();

                    lstKeyBox[_iKeyNumber - 1].Text = _iKeyNumber.ToString() + ". ";
                    lstKeyBox[_iKeyNumber - 1].BackColor = Color.MistyRose;
                }
                else
                {
                    ws.Close();
                }
            }


        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstKeyBox.Count; i++)
            {
                lstKeyBox[i].BackColor = btnTempOriginalButtons[i].BackColor;
            }
        }

        #endregion Buttons

        #region ShortCutButtons

        private void btn_mainmenu_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["MainMenu"];

            if (fm != null)
            {
                if (fm.WindowState == FormWindowState.Minimized)
                {
                    fm.WindowState = FormWindowState.Normal;
                }

                fm.BringToFront();
            }
            else
            {
                MainMenu mm = new MainMenu();
                mm.Show();
            }
        }

        private void btn_invoice_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["InvoiceManager"];

            if (fm != null)
            {
                if (fm.WindowState == FormWindowState.Minimized)
                {
                    fm.WindowState = FormWindowState.Maximized;
                }

                fm.BringToFront();
            }
            else
            {
                InvoiceManager ip = new InvoiceManager();
                ip.Show();
            }
        }

        private void btn_returns_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NewCarReturns"];

            if (fm != null)
            {
                if (fm.WindowState == FormWindowState.Minimized)
                {
                    fm.WindowState = FormWindowState.Maximized;
                }

                fm.BringToFront();
            }
            else
            {
                NewCarReturns cr = new NewCarReturns();
                cr.Show();
            }
        }

        #endregion ShortCutButtons
    }
}