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

namespace KKCSInvoiceProject
{
    public partial class LongTermForm : Form
    {
        #region GlobalVariables

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        int YDown = 280;
        int iAmountOfStays = 0;

        OleDbDataReader reader;

        int iMakePanelGreen = 0;
        int Y = 0;

        int g_iLongTermKey = 0;
        bool g_bCarInYard = false;
        string g_sClientName = "";
        string g_sRego1 = "";
        string g_sRego2 = "";
        string g_sMakeModel = "";
        string g_sPhone = "";
        string g_sAlerts = "";

        string g_sLTInvoice = "";

        int g_iCheckForMoreThanOneStay = 0;
        
        #endregion GlobalVariables

        #region Load

        public LongTermForm()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        public void LongTermPick(int _iLongTermKey)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM LongTermAccounts WHERE LongTermKey = " + _iLongTermKey + "";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                g_iLongTermKey = (int)reader["LongTermKey"];
                g_bCarInYard = (bool)reader["IsCarInYard"];
                g_sClientName = reader["ClientName"].ToString();
                g_sRego1 = reader["Rego1"].ToString();
                g_sRego2 = reader["Rego2"].ToString();
                g_sMakeModel = reader["MakeModel"].ToString();
                g_sPhone = reader["Ph"].ToString();
                g_sAlerts = reader["Alerts"].ToString();
            }

            lbl_customername.Text = "LT-" + g_iLongTermKey.ToString() + ": " + g_sClientName;

            connection.Close();

            SetUpStays();
        }

        #endregion Load

        #region SetUpStays

        void SetUpStays()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM LongTermData WHERE LongTermKey = " + g_iLongTermKey + " ORDER BY LTInvoice DESC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            Y =  pnl_staytemplate.Location.Y + 320;

            while (reader.Read())
            {
                g_sLTInvoice = reader["LTInvoice"].ToString();

                CreatePanels();
            }

            connection.Close();
        }

        void CreatePanels()
        {
            Panel pnl = new Panel();

            pnl.Name = g_sLTInvoice;

            pnl.Size = pnl_staytemplate.Size;
            pnl.BackColor = pnl_staytemplate.BackColor;
            pnl.BorderStyle = pnl_staytemplate.BorderStyle;

            pnl.Location = new Point(pnl_staytemplate.Location.X, Y);

            foreach (Control p in pnl_staytemplate.Controls)
            {
                if (p.GetType() == typeof(TextBox))
                {
                    ControlTextBox(p, pnl);
                }

                if (p.GetType() == typeof(Label))
                {
                    ControlLabel(p, pnl);
                }

                if (p.GetType() == typeof(ComboBox))
                {
                    ControlComboBox(p, pnl);
                }

                if (p.GetType() == typeof(Button))
                {
                    ControlButton(p, pnl);
                }
            }

            Y += YDown;

            Controls.Add(pnl);
        }

        void ControlTextBox(Control _p, Panel _pPanel)
        {
            TextBox textBox = new TextBox();

            textBox.Location = _p.Location;
            textBox.Size = _p.Size;
            textBox.Name = _p.Name;
            textBox.Font = _p.Font;
            textBox.Text = "DD/MM/YY";

            if (_p.Name == "txtBox_carin")
            {
                if (reader["DateIn"].ToString() != "")
                {
                    textBox.BackColor = Color.LightGreen;
                    textBox.Text = reader["DateIn"].ToString();

                    textBox.TextChanged += new EventHandler(txtBox_carin_TextChanged);

                    iMakePanelGreen++;
                }
                else
                {
                    textBox.BackColor = _p.BackColor;
                }
            }

            if(_p.Name == "txtBox_carout")
            {
                if (reader["DateOut"].ToString() != "")
                {
                    textBox.BackColor = Color.LightGreen;
                    textBox.Text = reader["DateOut"].ToString();

                    textBox.TextChanged += new EventHandler(txtBox_carout_TextChanged);

                    iMakePanelGreen++;
                }
                else
                {
                    textBox.BackColor = _p.BackColor;
                }
            }

            if(iMakePanelGreen >= 2)
            {
                _pPanel.BackColor = Color.LightGreen;

                iMakePanelGreen = 0;
            }

            textBox.Enter += new EventHandler(textBox_Enter);
            textBox.Leave += new EventHandler(textBox_Leave);
            

            _pPanel.Controls.Add(textBox);
        }

        void ControlLabel(Control _p, Panel _pPanel)
        {
            Label lblLabel = new Label();

            lblLabel.Location = _p.Location;
            lblLabel.Size = _p.Size;
            lblLabel.Font = _p.Font;
            lblLabel.Text = _p.Text;
            lblLabel.Name = _p.Name;
            lblLabel.ForeColor = _p.ForeColor;

            if (_p.Name == "lbl_ltinvoice")
            {
                lblLabel.Text = "Invoice:\r\n" + reader["LTInvoice"].ToString();
            }

            if (reader["DateIn"].ToString() != "" && reader["DateOut"].ToString() != "")
            {
                lblLabel.BackColor = Color.LightGreen;
            }
            else
            {
                lblLabel.BackColor = Color.MistyRose;
            }
            
            _pPanel.Controls.Add(lblLabel);
        }

        void ControlComboBox(Control _p, Panel _pPanel)
        {
            ComboBox cmbComboBox = new ComboBox();

            cmbComboBox.Location = _p.Location;
            cmbComboBox.Size = _p.Size;
            cmbComboBox.Font = _p.Font;
            cmbComboBox.Name = _p.Name;
            cmbComboBox.Text = _p.Text;

            cmbComboBox.BackColor = _p.BackColor;

            _pPanel.Controls.Add(cmbComboBox);
        }

        void ControlButton(Control _p, Panel _pPanel)
        {
            Button btnButton = new Button();

            btnButton.Location = _p.Location;
            btnButton.Size = _p.Size;
            btnButton.Font = _p.Font;
            btnButton.Name = _p.Name;
            btnButton.Text = _p.Text;
            btnButton.BackColor = _p.BackColor;

            if (_p.Name == "btn_note")
            {
                if(reader["Notes"].ToString() != "")
                {
                    btnButton.Text = "Show/Edit Note";
                    btnButton.BackColor = Color.Green;
                }
            }

            if(_p.Name == "btn_ltreturn")
            {
                //btnButton.Text = "Show/Edit Return Date";
                //btnButton.BackColor = Color.Green;
            }

            if(_p.Name == "btn_savestay")
            {
                btnButton.Click += (sender, EventArgs) =>
                {
                    btn_savestay_Click(sender, EventArgs, g_sLTInvoice, g_sLTInvoice);
                };
            }

            _pPanel.Controls.Add(btnButton);
        }

        #endregion SetUpStays

        #region SaveAndUpdate

        void Save()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //string bCurrent = "true";

            //Insert the new Number Plate into the Database
            //string cmd1 = @"INSERT INTO LongTermData (ClientName,Rego,IsCurrent,LongTermKey,DateIn,DateOut) values
            //                                            ('" + ClientName + "','" +
            //                                            Rego1 + "','" +
            //                                            bCurrent + "'," +
            //                                            LongTermKey + ",'" +
            //                                            //txt_datein.Text + "','" +
            //                                            //txt_dateout.Text +
            //                                            "')";

            //command.CommandText = cmd1;

            command.ExecuteNonQuery();

            connection.Close();
        }
        /*
        void Update()
        {
            connection.Open();

            // record already exists
            // Make new command structure for database querys
            OleDbCommand command = new OleDbCommand();

            // Make the command equal the physical location of the database (connection)
            command.Connection = connection;

            //string sFalse = "false";

            string cmd1 = "";
            //@"UPDATE LongTermData SET 
            //                        DateOut = '" + txt_dateout.Text +
            //                    "', IsCurrent = '" + sFalse +
            //                    "' WHERE LongTermKey = " + LongTermKey + " AND IsCurrent = 'true'";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            command.ExecuteNonQuery();

            connection.Close();

            //txt_dateout.BackColor = Color.LightGreen;
        }
        */
        #endregion SaveAndUpdate

        #region TextBoxEnterLeave

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;

            if(txtBox.Text == "DD/MM/YY")
            {
                txtBox.Text = "";
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;

            if(txtBox.Text == "")
            {
                txtBox.Text = "DD/MM/YY";
            }
            
        }

        #endregion TextBoxEnterLeave

        #region Buttons

        private void btn_addstay_Click(object sender, EventArgs e)
        {
            pnl_staytemplate.Visible = true;

            string sStays = "";

            foreach (Control p in pnl_staytemplate.Controls)
            {
                if (p.GetType() == typeof(Label))
                {
                    if (p.Name == "lbl_ltinvoice")
                    {
                        int iStays = (iAmountOfStays + 1);

                        p.Text = "Stay:\r\n" + "LT" + g_iLongTermKey.ToString() + "-" + iStays.ToString("00");
                        sStays = "LT" + g_iLongTermKey.ToString() + "-" + iStays.ToString("00");
                    }
                }
            }

            InsertStay(sStays);

        }

        void InsertStay(string _sStays)
        {
            g_iCheckForMoreThanOneStay++;

            if(g_iCheckForMoreThanOneStay > 1)
            {
                Label tempTitle = lbl_customername;
                Button tempCustomerFile = btn_editcustomerfile;
                //Button tempAddNewStay = btn_addstay;
                //Button tempButtonReturn = btn_ltreturn;
                Panel tempStatTemplate = pnl_staytemplate;
                //Panel tempCarInYar = pnl_carinyard;
                
                this.Controls.Clear();

                Controls.Add(tempTitle);
                Controls.Add(tempCustomerFile);
                //Controls.Add(tempAddNewStay);
                Controls.Add(tempStatTemplate);
                //Controls.Add(tempCarInYar);
                //Controls.Add(tempButtonReturn);
                tempStatTemplate.Visible = true;

                YDown = 150;
                iAmountOfStays = 0;
                iMakePanelGreen = 0;
                Y = 0;

                SetUpStays();
            }


            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //Insert the new Number Plate into the Database
            string cmd1 = @"INSERT INTO LongTermData (LTInvoice,ClientName,Rego,LongTermKey) values ('" + _sStays + "','" +
                                                                                g_sClientName + "','" +
                                                                                g_sRego1 + "'," +
                                                                                g_iLongTermKey +
                                                                                ")";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion Buttons

        private void btn_saveinyard_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"UPDATE LongTermAccounts SET [IsCarInYard] = " + g_bCarInYard + " WHERE [LongTermKey] = " + g_iLongTermKey + "";

            command.CommandText = query;

            command.ExecuteNonQuery();

            connection.Close();
        }

        private void btn_savestay_Click(object sender, EventArgs e, string _sLTInvoiceNumber, string _sPnlName)
        {
            string sDI = "";
            string sDO = "";
            string sRego = "";
            string sNotes = "";

            Panel tempPanel = (Panel)Controls.Find(_sPnlName, false).FirstOrDefault();

            foreach (Control p in tempPanel.Controls)
            {
                if(p.Name != "")
                {
                    //int i = 0;
                }
                if(p.Name == "txtBox_carin")
                {
                    sDI = p.Text;
                }
                if (p.Name == "txtBox_carout")
                {
                    sDO = p.Text;
                }
                if (p.Name == "cmb_rego")
                {
                    sRego = p.Text;
                }
                if (p.Name == "txtBox_notes")
                {
                    sNotes = p.Text;
                }
            }

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string UpdateCommand = @"UPDATE LongTermData SET
                                                        DateIn = '" + sDI +
                                                    "', DateOut = '" + sDO +
                                                    "', Rego = '" + sRego +
                                                    "', Notes = '" + sNotes +
                                                    "' WHERE LTInvoice = '" + _sLTInvoiceNumber + "'";

            command.CommandText = UpdateCommand;

            command.ExecuteNonQuery();

            connection.Close();
        }

        private void txtBox_carin_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;

            if(txtBox.Text != "DD/MM/YY" || txtBox.Text != "")
            {
                txtBox.BackColor = Color.White;
            }
            else
            {
                txtBox.BackColor = Color.Red;
            }
        }

        private void txtBox_carout_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;

            if (txtBox.Text != "DD/MM/YY")
            {
                txtBox.BackColor = Color.White;
            }
            else
            {
                txtBox.BackColor = Color.Red;
            }
        }
    }
}