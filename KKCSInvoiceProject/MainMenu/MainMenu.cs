using System;
using System.IO;
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
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class MainMenu : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private ComboBox cmb_storeRegoItems;
        private ComboBox cmb_storeAccountItems;
        private ComboBox cmb_storeMakeModel;

        private bool m_bUserExit = false;

        string sVersionNumber = "3.00";

        int iTemplateX = 0;
        int iTemplateY = 0;
        int iCount = 1;

        private OleDbConnection connection = new OleDbConnection();
        OleDbCommand command;

        OleDbDataReader reader;

        public MainMenu()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            testToolStripMenuItem.Visible = false;

            Form fm = Application.OpenForms["CustomerShow"];

            if (fm == null)
            {
                CustomerShow cs = new CustomerShow();
                cs.Show();
            }

            versionToolStripMenuItem.Text = "v" + sVersionNumber;

            this.FormClosing += MainMenu_Closing;

            cmb_printerpicked.SelectedIndex = 0;

            // Out of Colour Ink (Uncomment Next Line)
            //cmb_printerpicked.SelectedIndex = 1;

#if DEBUG
            Debug();
#endif

            SetUpRegoComboBox();

            SetUpMakeModelComboBox();

            SetUpAccountComboBox();

            SetUpAccountComboBox();

            UpdateAmountOfCars();

            LoadAllNotes();
        }

        void LoadAllNotes()
        {
            LoadGeneralNotes();

            FindInvoiceNumbersNotesAlerts();

            LoadInvoiceNotes();

            LoadInvoiceAlerts();
        }

        #region Debug

        void Debug()
        {
            versionToolStripMenuItem.BackColor = Color.Black;
            versionToolStripMenuItem.ForeColor = Color.White;
            versionToolStripMenuItem.Text = "dv" + sVersionNumber;

            lbl_debug.Visible = true;
            //lbl_debug.Location = new Point(70, 100);
            lbl_debug.Text += "\r\n" + m_strDataBaseFilePath.Substring(90, 26);

            testToolStripMenuItem.Visible = true;
        }

        #endregion Debug

        public void UpdateAmountOfCars()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from CustomerInvoices WHERE PickUp = False ORDER BY KeyNumber";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            int iNumberOfCars = 0;

            while (reader.Read())
            {
                iNumberOfCars++;
            }

            txt_noofcars.Text = iNumberOfCars.ToString() + "/70 Cars";

            connection.Close();
        }

        #region GetFunctions

        public MainMenu GetMainMenu()
        {
            return (this);
        }

        public ComboBox GetCmbAccountsComboBox()
        {
            return (cmb_storeAccountItems);
        }

        public ComboBox GetCmbRegoComboBox()
        {
            return (cmb_storeRegoItems);
        }

        public ComboBox GetCmbMakeModelComboBox()
        {
            return (cmb_storeMakeModel);
        }

        #endregion GetFunctions

        #region SetFunctions

        public void SetUpRegoComboBox()
        {
            cmb_storeRegoItems = new ComboBox();

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from NumberPlates ORDER BY NumberPlates ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            int iCountNumberPlates = 0;

            while (reader.Read())
            {
                cmb_storeRegoItems.Items.Add(reader["NumberPlates"].ToString());

                iCountNumberPlates++;
            }

            //lbl_carsindatabase.Text += " " + iCountNumberPlates.ToString();

            connection.Close();
        }

        public void SetUpMakeModelComboBox()
        {
            cmb_storeMakeModel = new ComboBox();

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from NumberPlates ORDER BY MakeModel ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            string sStoreFirstMM = "";
            string sStoreSecondMM = "";
            bool bSkipFirstCheck = false;

            while (reader.Read())
            {
                //cmb_storeMakeModel
                sStoreFirstMM = reader["MakeModel"].ToString();

                if (sStoreFirstMM != sStoreSecondMM)
                {
                    if (sStoreFirstMM != "")
                    {
                        cmb_storeMakeModel.Items.Add(sStoreFirstMM);
                    }
                }

                sStoreSecondMM = sStoreFirstMM;
            }

            connection.Close();
        }

        public void SetUpAccountComboBox()
        {
            cmb_storeAccountItems = new ComboBox();

            // Opens the connection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Accounts ORDER BY Account ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            string sFirstName = "";
            string sSecondName = "";

            while (reader.Read())
            {
                sFirstName = reader["Account"].ToString();

                if (sFirstName != sSecondName)
                {
                    sSecondName = sFirstName;

                    cmb_storeAccountItems.Items.Add(reader["Account"].ToString());
                }
            }

            // Closes the connection to the database
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #endregion SetFunctions

        #region Buttons

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

        private void btn_keybox_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["KeyBox"];

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
                KeyBox kb = new KeyBox();
                kb.Show();
            }
        }

        private void btn_printcarreturns_Click(object sender, EventArgs e)
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
            //cmb_printerpicked.SelectedIndex = 0;

            ncr.PrintReturns(cmb_printerpicked.SelectedIndex);

            //cmb_printerpicked.SelectedIndex = 0;

            // Out of Colour Ink (Uncomment Next Line)
            //cmb_printerpicked.SelectedIndex = 1;

            //PrintTest();

            //PrintLongTerm();
        }

        private void btn_eod_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["EndOfDay"];

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
                EndOfDay eod;

                if (ModifierKeys.HasFlag(Keys.Shift))
                {
                    eod = new EndOfDay();
                }
                else
                {
                    eod = new EndOfDay();
                }

                eod.Show();
            }
        }

        #endregion Buttons

        #region Notes

        bool bShowClosedNotes = false;

        void LoadGeneralNotes()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "";

            if (bShowClosedNotes)
            {
                query = "select * from Notes ORDER BY IsHighPriority,DateAndTime";
            }
            else
            {
                query = "select * from Notes WHERE IsClosed = False ORDER BY IsHighPriority,DateAndTime";
            }

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            iTemplateX = txt_template.Location.X;
            iTemplateY = txt_template.Location.Y;

            int iButtonMarkX = btn_mark.Location.X;
            int iButtonMarkY = btn_mark.Location.Y;

            int iButtonEditX = btn_edit.Location.X;
            int iButtonEditY = btn_edit.Location.Y;

            iCount = 1;

            while (reader.Read())
            {
                TextBox txtBox = new TextBox();
                txtBox.Location = new Point(iTemplateX, iTemplateY);
                txtBox.Multiline = true;
                txtBox.ScrollBars = ScrollBars.Vertical;
                txtBox.Font = txt_template.Font;
                txtBox.ReadOnly = true;
                txtBox.Size = txt_template.Size;

                Button btn = new Button();
                btn.Location = new Point(iButtonMarkX, iButtonMarkY);
                btn.Font = btn_mark.Font;
                btn.Size = btn_mark.Size;
                btn.Text = btn_mark.Text;
                btn.BackColor = btn_mark.BackColor;
                btn.Click += btn_mark_Click;
                btn.Name = reader["ID"].ToString();

                pnl_notes.Controls.Add(btn);

                btn = new Button();
                btn.Location = new Point(iButtonEditX, iButtonEditY);
                btn.Font = btn_edit.Font;
                btn.Size = btn_edit.Size;
                btn.Text = btn_edit.Text;
                btn.BackColor = btn_edit.BackColor;
                btn.Click += btn_edit_Click;
                btn.Name = reader["ID"].ToString();

                pnl_notes.Controls.Add(btn);

                if ((bool)reader["IsHighPriority"])
                {
                    txtBox.BackColor = Color.Red;
                    txtBox.ForeColor = Color.White;
                }
                else
                {
                    txtBox.BackColor = txt_template.BackColor;
                }

                DateTime dtNoteTime = (DateTime)reader["DateAndTime"];
                string sDate = dtNoteTime.Day.ToString() + "/" + dtNoteTime.Month + "/" + dtNoteTime.ToString("yy") + " - " + dtNoteTime.ToString("h:mm tt");

                txtBox.Text = reader["Notes"].ToString() + "\r\n\r\n" + reader["StaffMember"].ToString() + " (" + sDate + ")"; ;

                iTemplateX += txt_template.Size.Width + 50;

                iButtonMarkX += btn_mark.Size.Width + 235;

                iButtonEditX += btn_edit.Size.Width + 265;

                if (iCount % 4 == 0)
                {
                    iTemplateY += txt_template.Size.Height + 50;
                    iTemplateX = txt_template.Location.X;

                    iButtonMarkY += btn_mark.Size.Height + 180;
                    iButtonMarkX = btn_mark.Location.X;

                    iButtonEditY += btn_edit.Size.Height + 180;
                    iButtonEditX = btn_edit.Location.X;
                }

                iCount++;

                pnl_notes.Controls.Add(txtBox);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        List<string> lstInvoice;
        List<string> lstRego;

        void FindInvoiceNumbersNotesAlerts()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            lstInvoice = new List<string>();
            lstRego = new List<string>();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            string query = @"select * from CustomerInvoices WHERE DTReturnDate = @dt AND (IsNotes = True OR IsAlerts = True)";
            query += " OR (DTReturnDate < @dt AND PickUp = False) AND (IsNotes = True OR IsAlerts = True)";

            command.Parameters.AddWithValue("@dt", dt);
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lstInvoice.Add(reader["InvoiceNumber"].ToString());
                lstRego.Add(reader["Rego"].ToString());
            }

            int iStop = 0;

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadInvoiceNotes()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            //int iNumber = 0;
            //int.TryParse(lstInvoice[0], out iNumber);

            string sInvoiceNumber = "";

            for(int i = 0; i < lstInvoice.Count; i++)
            {
                sInvoiceNumber += lstInvoice[i] + ",";
            }

            string query = "select * from InvoiceNotes WHERE InvoiceNumber IN ("+ sInvoiceNumber + ") ORDER BY DateAndTime DESC";

            //string query = "select * from InvoiceNotes WHERE InvoiceNumber IN (7196, 6937, 6916)";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TextBox txtBox = new TextBox();
                txtBox.Location = new Point(iTemplateX, iTemplateY);
                txtBox.Multiline = true;
                txtBox.ScrollBars = ScrollBars.Vertical;
                txtBox.Font = txt_template.Font;
                txtBox.ReadOnly = true;
                txtBox.Size = txt_template.Size;
                txtBox.BackColor = Color.LightBlue;

                txtBox.Text = reader["Rego"].ToString() + " (" + reader["InvoiceNumber"].ToString() + "): \r\n";
                txtBox.Text += "-------------------------------------\r\n";
                txtBox.Text += reader["Notes"].ToString();

                iTemplateX += txt_template.Size.Width + 50;

                if (iCount % 4 == 0)
                {
                    iTemplateY += txt_template.Size.Height + 50;
                    iTemplateX = txt_template.Location.X;
                }

                iCount++;

                pnl_notes.Controls.Add(txtBox);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoadInvoiceAlerts()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            //int iNumber = 0;
            //int.TryParse(lstInvoice[0], out iNumber);

            string sRego = "";

            for (int i = 0; i < lstRego.Count; i++)
            {
                sRego += "'" + lstRego[i] + "',";
            }

            string query = "select * from Alerts WHERE Rego IN (" + sRego + ")";

            //string query = "select * from InvoiceNotes WHERE InvoiceNumber IN (7196, 6937, 6916)";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TextBox txtBox = new TextBox();
                txtBox.Location = new Point(iTemplateX, iTemplateY);
                txtBox.Multiline = true;
                txtBox.ScrollBars = ScrollBars.Vertical;
                txtBox.Font = txt_template.Font;
                txtBox.ReadOnly = true;
                txtBox.Size = txt_template.Size;
                txtBox.BackColor = Color.LightBlue;

                txtBox.Text = reader["Alert"].ToString();

                iTemplateX += txt_template.Size.Width + 50;

                if (iCount % 4 == 0)
                {
                    iTemplateY += txt_template.Size.Height + 50;
                    iTemplateX = txt_template.Location.X;
                }

                iCount++;

                pnl_notes.Controls.Add(txtBox);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void btn_mark_Click(object sender, EventArgs e)
        {
            string sWarning = "Do you wish to close this note?";
            WarningSystem ws = new WarningSystem(sWarning, true);
            ws.ShowDialog();

            if (ws.DialogResult == DialogResult.OK)
            {
                Button btn = (Button)sender;

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                int iInovice = 0;
                int.TryParse(btn.Name, out iInovice);

                command.CommandText = "UPDATE Notes SET IsClosed = True WHERE ID = " + iInovice + "";

                command.ExecuteNonQuery();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                DeleteAndRefreshNotes();
            }
            else
            {
                ws.Close();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            DailyNotes DailyNotes = new DailyNotes();
            DailyNotes.LoadFromEdit(btn.Name);
            DailyNotes.ShowDialog();

            DeleteAndRefreshNotes();
        }

        void DeleteAndRefreshNotes()
        {
            foreach (TextBox txt in pnl_notes.Controls.OfType<TextBox>().ToArray())
            {
                pnl_notes.Controls.Remove(txt);
            }

            foreach (Button btn in pnl_notes.Controls.OfType<Button>().ToArray())
            {
                if(btn.Name != "btn_addnewnote")
                {
                    pnl_notes.Controls.Remove(btn);
                }
            }

            LoadAllNotes();
        }

        private void btn_addnewnote_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["DailyNotes"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                DailyNotes cu = new DailyNotes();
                cu.FormClosing += CloseNewNote;
                cu.ShowDialog();
            }
        }

        void CloseNewNote(object sender, FormClosingEventArgs e)
        {
            DeleteAndRefreshNotes();
        }

        private void chk_showclosed_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_showclosed.Checked)
            {
                bShowClosedNotes = true;
            }
            else
            {
                bShowClosedNotes = false;
            }

            DeleteAndRefreshNotes();
        }

        #endregion Notes






        private void MainMenu_Closing(object sender, FormClosingEventArgs e)
        {
            if(!m_bUserExit)
            {
                e.Cancel = true;

                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            string sTabsStillOpen = "If you close the Main Menu, all other forms will also close, Any unsaved data WILL be lost. Is this ok?";

            DialogResult dialogResult = MessageBox.Show(sTabsStillOpen, "WARNING", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //Close();

                m_bUserExit = true;

                Close();
            }
        }

        

        private void financesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Finances"];

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
                Finances cr = new Finances();
                cr.Show();
            }
        }

        

        

        private void btn_moneyinyard_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["MoneyInYard"];

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
                MoneyInYard miy = new MoneyInYard();
                miy.Show();
            }
        }

        private void btn_pettycash_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NewPettyCashManager"];

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
                NewPettyCashManager pc = new NewPettyCashManager();
                pc.Show();
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFlightTimes nft = new NewFlightTimes();
            nft.Show();
            //Form fm = Application.OpenForms["YardStats"];

            //if (fm != null)
            //{
            //    if (fm.WindowState == FormWindowState.Minimized)
            //    {
            //        fm.WindowState = FormWindowState.Normal;
            //    }

            //    fm.BringToFront();
            //}
            //else
            //{
            //    YardStats pc = new YardStats();
            //    pc.Show();
            //}
        }

        // Banking
        private void button1_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Banking"];

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
                Banking bank = new Banking();
                bank.Show();
            }
        }

        private void btn_accounts_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Accounts"];

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
                Accounts ac = new Accounts();

                if (ModifierKeys.HasFlag(Keys.Shift) && ModifierKeys.HasFlag(Keys.Control))
                {
                    //ac.SetAdminMode();
                }
                
                ac.Show();
            }
        }

        
        
        private void btn_build_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift) && ModifierKeys.HasFlag(Keys.Control) && ModifierKeys.HasFlag(Keys.Alt))
            {
                AdministratorPassword adp = new AdministratorPassword();
                adp.Show();
            }
            else
            {
                Form fm = Application.OpenForms["Changelog"];

                if (fm != null)
                {
                    fm.BringToFront();
                }
                else
                {
                    Changelog cl = new Changelog();
                    cl.Show();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Customers"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                btn_firstnameseach cu = new btn_firstnameseach();
                cu.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["LongTermMain"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                LongTermMain ltm = new LongTermMain(false, "");
                ltm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["YardStats"];
            //Form fm = Application.OpenForms["StatsManager"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                YardStats st = new YardStats();
                st.Show();
            }
        }

        private void btn_notesbookings_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NotesManager"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                NotesManager nm = new NotesManager();
                nm.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshInformation();
        }

        void RefreshInformation()
        {

        }

        private void btn_refresh_Click_1(object sender, EventArgs e)
        {

        }

        

        public void MinimiseForm()
        {
            this.WindowState = FormWindowState.Minimized;
        }
       
        #region Printing

        private void PrintLongTerm()
        {
            PrintDocument printDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            printDocument.DefaultPageSettings.PaperSize = ps;

            //printDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //printDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            printDocument.OriginAtMargins = false;
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += new PrintPageEventHandler(PrintLongTerm);

            printDocument.Print();

            printDocument.Dispose();
        }

        public void PrintLongTerm(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtNow = DateTime.Now;
            DateTime dtDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);

            string sTodaysQuerys = "select * from LongTermAccounts ORDER BY LongTermKey ASC";

            command.CommandText = sTodaysQuerys;

            Graphics graphic = e.Graphics;

            Font font = new Font("Times New Roman", 10); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            OleDbDataReader reader = command.ExecuteReader();

            int startX = 10;
            int startY = 10;
            int offset = 30;

            string sLine = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

            DateTime dt = DateTime.Now;

            graphic.DrawString("Long Term Check Sheet " + dt, new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            offset = offset + (int)fontHeight * 2;

            string sHeaders = "LT Key No                 Rego                              Name                                                                                   Is Key Here?                    Is Car Here?";
            graphic.DrawString(sHeaders, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            graphic.DrawString(sLine, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;

            while (reader.Read())
            {
                int iLT = 0;
                int.TryParse(reader["LongTermKey"].ToString(), out iLT);

                string sRego1 = reader["Rego1"].ToString();
                string sRego2 = reader["Rego2"].ToString();
                string sCombined = "";

                if (sRego2 != "")
                {
                    sCombined = sRego1 + "/" + sRego2;
                }
                else
                {
                    sCombined = sRego1;
                }

                string sLongTerm = "LT-" + iLT.ToString("00") + "                 " + sCombined + "                           " + reader["ClientName"].ToString();
                graphic.DrawString(sLongTerm, font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight;

                graphic.DrawString(sLine, font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight;
            }

            graphic.DrawString("Thank You for Parking with Us!", font, new SolidBrush(Color.Black), startX, startY + offset);
        }

        private void PrintReturns()
        {
            PrintDocument printDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            printDocument.DefaultPageSettings.PaperSize = ps;

            //printDocument.PrinterSettings.PrinterName = "Adobe PDF";
            printDocument.OriginAtMargins = false;
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += new PrintPageEventHandler(PrintReturns);

            printDocument.Print();

            printDocument.Dispose();
        }

        public void PrintReturns(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtNow = DateTime.Now;
            DateTime dtDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);

            string sTodaysQuerys = "select * from CustomerInvoices WHERE DTReturnDate = @dtDate ORDER BY ReturnTime,KeyNumber ASC";

            command.CommandText = sTodaysQuerys;
            command.Parameters.AddWithValue("@dtDate", dtDate);

            Graphics graphic = e.Graphics;

            Font font = new Font("Times New Roman", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 30;

            OleDbDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string sString = reader["Rego"].ToString();

                SizeF stringSize = new SizeF();
                stringSize = e.Graphics.MeasureString(sString, font);

                graphic.DrawString(reader["Rego"].ToString(), font, new SolidBrush(Color.Black), startX, startY + offset);

                Brush brush = new SolidBrush(Color.FromArgb(30, 0, 0, 255));
                e.Graphics.FillRectangle(brush, startX, startY + offset, stringSize.Width, stringSize.Height);

                offset = offset + (int)fontHeight;

                break;
            }

            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }



            //string s = "Ph: 09-401-6351";

            //SizeF size = graphic.MeasureString(s, font);

            //graphic.DrawString("BOI Airport Car Storage Receipt", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            //offset = offset + (int)fontHeight; //make the spacing consistent

            //Brush brush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
            //e.Graphics.FillRectangle(brush, startX, startY + 7, size.Width, size.Height);

            //graphic.DrawString("Ph: 09-401-6351", font, new SolidBrush(Color.Black), startX, startY + 25);

            //Brush brush = new SolidBrush(Color.FromArgb(40, 0, 0, 255));
            //e.Graphics.FillRectangle(brush, startX, startY + 25, size.Width, size.Height);

            //graphic.DrawString("---------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight; //make the spacing consistent

            //Font fontStencil = new Font("Stencil", 20);
            //graphic.DrawString("Paid By: " + g_sPaidStatus, fontStencil, new SolidBrush(Color.Black), startX, startY + offset);
        }

        private void btn_rentalcars_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["RentalCars"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                RentalCars nm = new RentalCars();
                nm.Show();
            }
        }

        #endregion
        
#region Printing Test



        // Print Button
        int totalnumber = 0;//this is for total number of items of the list or array
        int itemperpage = 0;//this is for no of item per page

        int startX = 10;
        int startY = 10;

        string g_strDatePicked = "";

        // Stores the time from the table
        string StoreTime = "";

        // Stores time at end to compare and see if a new time has shown
        string StoreTimeSecond = "";

        int move = 115;

        // Skips the very first check as there is no time to compare on the first
        bool bSkipFirstCheck = true;

        bool bReferenceDatabaseOnce = true;
        bool bReferenceUnknownOnce = true;

        string sPrinterName = "Lexmark MX510 Series XL";
        //string sPrinterName = "Adobe PDF";
        //string sPrinterName = "CutePDF Writer";

        DateTime dt = DateTime.Today;

        string sLine = "----------------------------------------------------------------------------------------------------------------------------------\r\n";

        //private void button3_Click(object sender, EventArgs e)
        void PrintTest()
        {
            bReferenceDatabaseOnce = true;
            bReferenceUnknownOnce = true;

            startX = 10;
            startY = 10;

            // Prints Todays Car Returns
            // ----------------------------------------------------------------------------
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateTodaysReturns); //add an event handler that will do the printing

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            printDocument.DefaultPageSettings.PaperSize = ps;
            printDocument.DefaultPageSettings.Landscape = true;

            printDocument.PrinterSettings.PrinterName = sPrinterName;

            printDocument.Print();
            // ----------------------------------------------------------------------------

            // Prints Unknown Car Returns
            // ----------------------------------------------------------------------------
            PrintDialog printDialog2 = new PrintDialog();

            PrintDocument printDocument2 = new PrintDocument();

            printDialog2.Document = printDocument2; //add the document to the dialog box...        

            //printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateTodaysUnknowns); //add an event handler that will do the printing

            ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            printDocument2.DefaultPageSettings.PaperSize = ps;
            printDocument2.DefaultPageSettings.Landscape = true;

            printDocument2.PrinterSettings.PrinterName = sPrinterName;

            if (CheckForPrintUnknowns())
            {
                //printDocument2.Print();
            }
            // ----------------------------------------------------------------------------
        }

        void SetUpTopRow(System.Drawing.Printing.PrintPageEventArgs _e)
        {
            _e.Graphics.DrawString("Customer", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("Rego", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("Vechicle", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("InvNo", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("KeyNo", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("Amount", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("PaidStatus", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("DateIn", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("ReturnDate", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("ReturnTime", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);
        }

        public void CreateTodaysReturns(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (bReferenceDatabaseOnce)
            {
                // Create todays date
                dt = DateTime.Today;

                // Makes a customised string for pulling data out of the database
                g_strDatePicked = dt.DayOfWeek.ToString() + ", " +
                dt.Day.ToString() + " " +
                dt.ToString("MMMM") + " " +
                dt.Year.ToString();

                string PickedReturnValue = "ReturnDate";

                // Opens commection to the database
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command = new OleDbCommand();

                command.Connection = connection;

                string query = @"SELECT * FROM Invoice WHERE " + PickedReturnValue + " = '" + g_strDatePicked + "' ORDER BY DisplayedReturnDate,ReturnTime";

                command.CommandText = query;

                reader = command.ExecuteReader();

                //connection.Close();

                itemperpage = 0;
                totalnumber = 0;

                bReferenceDatabaseOnce = false;
            }

            //dt = dt.AddDays(1);

            string sDateToday = dt.DayOfWeek.ToString() + ", " +
            dt.Day.ToString() + " " +
            dt.ToString("MMMM") + " " +
            dt.Year.ToString();

            e.Graphics.FillRectangle(Brushes.LightBlue, startX + 700, startY, 400, 30);
            e.Graphics.DrawString(sDateToday, new Font("Courier New", 20), new SolidBrush(Color.Black), startX + 700, startY);

            startY += 50;

            SetUpTopRow(e);

            startY += 17;
            startX = 10;

            e.Graphics.DrawString(sLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startY += 20;

            while (reader.Read())
            {
                PrintReturns(e);

                if (itemperpage < 16)
                {
                    itemperpage++;
                    e.HasMorePages = false;
                }
                else
                {
                    itemperpage = 0;
                    e.HasMorePages = true;

                    startX = 10;
                    startY = 10;

                    return;
                }
            }

            startX = 10;
            startY = 10;

            connection.Close();
        }

        public void CreateTodaysUnknowns(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (bReferenceUnknownOnce)
            {
                // Create todays date
                dt = DateTime.Today;

                //graphic = e.Graphics;

                // Makes a customised string for pulling data out of the database
                g_strDatePicked = dt.DayOfWeek.ToString() + ", " +
                dt.Day.ToString() + " " +
                dt.ToString("MMMM") + " " +
                dt.Year.ToString();

                string PickedReturnValue = "ReturnDate";

                // Opens commection to the database
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command = new OleDbCommand();

                command.Connection = connection;

                string query = @"SELECT * FROM Invoice WHERE " + PickedReturnValue + " <> '" + g_strDatePicked + "' AND PickUp = False ORDER BY DisplayedReturnDate,ReturnTime";

                command.CommandText = query;

                reader = command.ExecuteReader();

                //connection.Close();

                itemperpage = 0;
                totalnumber = 0;

                bReferenceUnknownOnce = false;
            }

            string sDateToday = dt.DayOfWeek.ToString() + ", " +
            dt.Day.ToString() + " " +
            dt.ToString("MMMM") + " " +
            dt.Year.ToString();

            e.Graphics.FillRectangle(Brushes.Orange, startX + 800, startY, 270, 30);
            e.Graphics.DrawString("Unknown/Overdue", new Font("Courier New", 20), new SolidBrush(Color.Black), startX + 800, startY);

            startY += 50;

            SetUpTopRow(e);

            startY += 17;
            startX = 10;

            e.Graphics.DrawString(sLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startY += 20;

            while (reader.Read())
            {
                DateTime d1 = new DateTime(dt.Year, dt.Month, dt.Day);

                int ReturnYear = 0;
                Int32.TryParse(reader["ReturnYear"].ToString(), out ReturnYear);

                int ReturnMonth = 0;
                Int32.TryParse(reader["ReturnMonth"].ToString(), out ReturnMonth);

                int ReturnDay = 0;
                Int32.TryParse(reader["ReturnDay"].ToString(), out ReturnDay);

                DateTime d2 = new DateTime(ReturnYear, ReturnMonth, ReturnDay);

                int result = DateTime.Compare(d2, d1);

                if (result < 0 || reader["ReturnDate"].ToString() == "Unknown")
                {
                    PrintReturns(e);

                    if (itemperpage < 16)
                    {
                        itemperpage++;
                        e.HasMorePages = false;
                    }
                    else
                    {
                        itemperpage = 0;
                        e.HasMorePages = true;

                        startX = 10;
                        startY = 10;

                        return;
                    }
                }
            }

            connection.Close();
        }

        void PrintReturns(System.Drawing.Printing.PrintPageEventArgs _e)
        {
            // Gets the current time of the record
            StoreTime = reader["ReturnTime"].ToString();

            // Compares the 2 times together to see if they are different or not
            // Skips the first check
            if (StoreTime != StoreTimeSecond && !bSkipFirstCheck)
            {
                startY += 20;

                _e.Graphics.DrawString(sLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

                startY += 20;

                itemperpage++;
            }

            string Customer = reader["ClientName"].ToString();
            string Rego = reader["Rego"].ToString();
            string Vechicle = reader["MakeModel"].ToString();
            string InvNo = reader["InvoiceNumber"].ToString();
            string KeyNo = reader["KeyNumber"].ToString();
            string Amount = reader["TotalPay"].ToString();
            string PaidStatus = reader["PaidStatus"].ToString();

            DateTime dDateIn = (DateTime)reader["DateInInvisible"];
            DateTime dDateReturn = (DateTime)reader["ReturnDateInvisible"];

            string DateIn = dDateIn.Day.ToString("00") + "/" + dDateIn.Month.ToString("00") + "/" + dDateIn.ToString("yy");

            string ReturnDate = "";

            if (reader["ReturnDate"].ToString() == "Unknown")
            {
                ReturnDate = "Unknown";
            }
            else
            {
                ReturnDate = dDateReturn.Day.ToString("00") + "/" + dDateReturn.Month.ToString("00") + "/" + dDateReturn.ToString("yy");
            }

            string ReturnTime = reader["ReturnTime"].ToString();

            if (Vechicle.Length > 10)
            {
                Vechicle = Vechicle.Substring(0, 10);
            }

            if (Customer.Length > 10)
            {
                Customer = Customer.Substring(0, 10);
            }

            _e.Graphics.DrawString(Customer, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(Rego, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(Vechicle, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(InvNo, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.FillRectangle(Brushes.Yellow, startX, startY, 22, 17);
            _e.Graphics.DrawString(KeyNo, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            float fPrice = 0.0f;
            float.TryParse(Amount, out fPrice);

            string AmountTotal = "$" + fPrice.ToString("0.00");

            if (PaidStatus == "To Pay" && fPrice == 0.0f)
            {
                _e.Graphics.FillRectangle(Brushes.Red, startX, startY, 180, 17);
                _e.Graphics.DrawString("Calculate", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);
            }
            else if (PaidStatus == "To Pay")
            {
                _e.Graphics.FillRectangle(Brushes.Yellow, startX, startY, 180, 17);
                _e.Graphics.DrawString(AmountTotal, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);
            }
            else
            {
                _e.Graphics.DrawString(AmountTotal, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);
            }

            startX += move;

            if (PaidStatus == "OnAcc" || PaidStatus == "N/C")
            {
                _e.Graphics.FillRectangle(Brushes.Pink, startX, startY, 60, 17);
            }
            else if (PaidStatus != "To Pay")
            {
                _e.Graphics.FillRectangle(Brushes.LightBlue, startX, startY, 60, 17);
            }
            _e.Graphics.DrawString(PaidStatus, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(DateIn, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(ReturnDate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(ReturnTime, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startY += 20;
            startX = 10;

            _e.Graphics.DrawString(sLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            startY += 20;

            //sTodaysReturns += Customer.PadRight(20) + Rego.PadRight(10) + Vechicle.PadRight(15) + InvNo.PadRight(10) + KeyNo.PadRight(10) + AmountTotal.PadRight(10) +
            //                    PaidStatus.PadRight(15) + DateIn.PadRight(15) + ReturnDate.PadRight(13) + ReturnTime + "\r\n";

            //sTodaysReturns += sLine;

            //graphic.DrawString(sTodaysReturns, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            // Makes the Second time = the first time for comparision purposes
            StoreTimeSecond = StoreTime;

            // Makes the first check to false for using
            bSkipFirstCheck = false;
        }

        public bool CheckForPrintUnknowns()
        {
            // Create todays date
            dt = DateTime.Today;

            //graphic = e.Graphics;

            // Makes a customised string for pulling data out of the database
            g_strDatePicked = dt.DayOfWeek.ToString() + ", " +
            dt.Day.ToString() + " " +
            dt.ToString("MMMM") + " " +
            dt.Year.ToString();

            string PickedReturnValue = "ReturnDate";

            // Opens commection to the database
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM Invoice WHERE " + PickedReturnValue + " <> '" + g_strDatePicked + "' AND PickUp = False ORDER BY DisplayedReturnDate,ReturnTime";

            command.CommandText = query;

            reader = command.ExecuteReader();

            itemperpage = 0;
            totalnumber = 0;

            string sDateToday = dt.DayOfWeek.ToString() + ", " +
            dt.Day.ToString() + " " +
            dt.ToString("MMMM") + " " +
            dt.Year.ToString();

            while (reader.Read())
            {
                DateTime d1 = new DateTime(dt.Year, dt.Month, dt.Day);

                int ReturnYear = 0;
                Int32.TryParse(reader["ReturnYear"].ToString(), out ReturnYear);

                int ReturnMonth = 0;
                Int32.TryParse(reader["ReturnMonth"].ToString(), out ReturnMonth);

                int ReturnDay = 0;
                Int32.TryParse(reader["ReturnDay"].ToString(), out ReturnDay);

                DateTime d2 = new DateTime(ReturnYear, ReturnMonth, ReturnDay);

                int result = DateTime.Compare(d2, d1);

                if (result < 0 || reader["ReturnDate"].ToString() == "Unknown")
                {
                    if (itemperpage < 16)
                    {
                        itemperpage++;
                    }
                    else
                    {
                        itemperpage = 0;

                        startX = 10;
                        startY = 10;
                    }
                }
            }

            connection.Close();

            if (itemperpage <= 0)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        void SetUpFlightTimes()
        {
            //string sTodaysDay = dt_returndate.Value.DayOfWeek.ToString();

            //txt_flighttimes.Items.Clear();
            
            string sTxtFileLocation = "";

            //if (sTodaysDay == "Saturday")
            {
                sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sat.txt";
            }
            //else if (sTodaysDay == "Sunday")
            {
                sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sun.txt";
            }
            //else
            {
                sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Mon To Fri.txt";
            }

            using (StreamReader sr = new StreamReader(sTxtFileLocation))
            {
                //txt_flighttimes.Items.AddRange(System.IO.File.ReadAllLines(sTxtFileLocation));
            }
        }

        private void pettyCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NewPettyCashManager"];

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
                NewPettyCashManager pc = new NewPettyCashManager();
                pc.Show();
            }
        }


        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift) && ModifierKeys.HasFlag(Keys.Control))
            {
                AdministratorPassword adp = new AdministratorPassword();
                adp.Show();
            }
            else
            {
                Form fm = Application.OpenForms["Changelog"];

                if (fm != null)
                {
                    fm.BringToFront();
                }
                else
                {
                    Changelog cl = new Changelog();
                    cl.Show();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sTabsStillOpen = "If you close the Main Menu, all other forms will also close, Any unsaved data WILL be lost. Is this ok?";

            DialogResult dialogResult = MessageBox.Show(sTabsStillOpen, "WARNING", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //Close();

                m_bUserExit = true;

                Close();
            }
        }

        private void tEstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Testing"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {
                Testing test = new Testing();
                test.Show();
            }
        }

        private void longTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["LongTermMain"];

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
                LongTermMain ltm = new LongTermMain(false, "");
                ltm.Show();
            }
        }

        private void bookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["BookingsManager"];

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
                BookingsManager book = new BookingsManager();
                book.ShowDialog();
            }
        }

        private void bankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Banking"];

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
                Banking bank = new Banking();
                bank.Show();
            }
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["NewAccount"];

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
                NewAccount bank = new NewAccount();
                bank.ShowDialog();
            }
        }

        private void accountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["Accounts"];

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
                Accounts bank = new Accounts();
                bank.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["LongTermMain"];

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
                LongTermMain bank = new LongTermMain(false, "");
                bank.ShowDialog();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        #endregion


        // This Function handles the printing of the Daily Car Returns print out
        // TODO: -Clean up in general
        //       -Look at adding long term returns
        //       -Add Picked Up Status

        /*
#region Printing

        // Print Button
        int totalnumber = 0;//this is for total number of items of the list or array
        int itemperpage = 0;//this is for no of item per page

        int startxfull = 370;

        int startX = 370;
        int startY = 10;

        string g_strDatePicked = "";

        // Stores the time from the table
        string StoreTime = "";

        // Stores time at end to compare and see if a new time has shown
        string StoreTimeSecond = "";

        int move = 115;

        // Skips the very first check as there is no time to compare on the first
        bool bSkipFirstCheck = true;

        bool bReferenceDatabaseOnce = true;
        bool bReferenceUnknownOnce = true;

        string sPrinterName = "Lexmark MX510 Series XL";
        //string sPrinterName = "Adobe PDF";
        //string sPrinterName = "CutePDF Writer";

        DateTime dt = DateTime.Today;

        string sLine = "----------------------------------------------------------------------------------------------------------------------------------\r\n";

        private void button3_Click(object sender, EventArgs e)
        {
            bReferenceDatabaseOnce = true;
            bReferenceUnknownOnce = true;

            startX = startxfull;
            startY = 10;

            // Prints Todays Car Returns
            // ----------------------------------------------------------------------------
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateTodaysReturns); //add an event handler that will do the printing

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            printDocument.DefaultPageSettings.PaperSize = ps;
            printDocument.DefaultPageSettings.Landscape = true;

            printDocument.PrinterSettings.PrinterName = sPrinterName;

            DialogResult result = printDialog.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }

            // ----------------------------------------------------------------------------
        }

        void SetUpTopRow(System.Drawing.Printing.PrintPageEventArgs _e)
        {
            _e.Graphics.DrawString("Rego", new Font("Courier New", 8, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("InvNo", new Font("Courier New", 8, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("Amount", new Font("Courier New", 8, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("PaidStatus", new Font("Courier New", 8, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("DateIn", new Font("Courier New", 8, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("ReturnDate", new Font("Courier New", 8, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString("DatePaid", new Font("Courier New", 8, FontStyle.Bold | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY);
        }

        public void CreateTodaysReturns(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Opens commection to the database
            //if (connection.State == ConnectionState.Closed)
            //{
            //    connection.Open();
            //}

            if (bReferenceDatabaseOnce)
            {
                // Create todays date
                dt = DateTime.Today;

                // Opens commection to the database
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command = new OleDbCommand();

                command.Connection = connection;

                string PickedReturnValue = "PaidStatus";
                string g_strDatePicked = "Credit Card";

                //string query = @"SELECT * FROM Invoice WHERE PaidStatus = Eftpos ORDER BY InvoiceNumber";
                string query = @"SELECT * FROM Invoice WHERE " + PickedReturnValue + " = '" + g_strDatePicked + "' ORDER BY InvoiceNumber";

                command.CommandText = query;

                reader = command.ExecuteReader();

                //connection.Close();

                itemperpage = 0;
                totalnumber = 0;

                bReferenceDatabaseOnce = false;
            }

            SetUpTopRow(e);

            startY += 17;
            startX = startxfull;

            //e.Graphics.DrawString(sLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);

            //startY += 20;

            while (reader.Read())
            {
                PrintReturns(e);

                if (itemperpage < 37)
                {
                    itemperpage++;
                    e.HasMorePages = false;
                }
                else
                {
                    itemperpage = 0;
                    e.HasMorePages = true;

                    startX = startxfull;
                    startY = 10;

                    return;

                    //break;
                }

                //break;
            }

            startX = startxfull;
            startY = 10;

            connection.Close();
        }

        void PrintReturns(System.Drawing.Printing.PrintPageEventArgs _e)
        {
            string Rego = reader["Rego"].ToString();
            string InvNo = reader["InvoiceNumber"].ToString();
            string Amount = reader["TotalPay"].ToString();
            string PaidStatus = reader["PaidStatus"].ToString();

            DateTime dDateIn = (DateTime)reader["DateInInvisible"];
            DateTime dDateReturn = (DateTime)reader["ReturnDateInvisible"];
            DateTime dDatePaid = (DateTime)reader["DPInvisible"];

            string DateIn = dDateIn.Day.ToString("00") + "/" + dDateIn.Month.ToString("00") + "/" + dDateIn.ToString("yy");

            string DatePaid = dDatePaid.Day.ToString("00") + "/" + dDatePaid.Month.ToString("00") + "/" + dDatePaid.ToString("yy");

            string ReturnDate = "";

            if (reader["ReturnDate"].ToString() == "Unknown")
            {
                ReturnDate = "Unknown";
            }
            else
            {
                ReturnDate = dDateReturn.Day.ToString("00") + "/" + dDateReturn.Month.ToString("00") + "/" + dDateReturn.ToString("yy");
            }

            string ReturnTime = reader["ReturnTime"].ToString();

            _e.Graphics.DrawString(Rego, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(InvNo, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            float fPrice = 0.0f;
            float.TryParse(Amount, out fPrice);

            string AmountTotal = "$" + fPrice.ToString("0.00");

            if (PaidStatus == "To Pay" && fPrice == 0.0f)
            {
                _e.Graphics.FillRectangle(Brushes.Red, startX, startY, 180, 17);
                _e.Graphics.DrawString("Calculate", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);
            }
            else if (PaidStatus == "To Pay")
            {
                _e.Graphics.FillRectangle(Brushes.Yellow, startX, startY, 180, 17);
                _e.Graphics.DrawString(AmountTotal, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);
            }
            else
            {
                _e.Graphics.DrawString(AmountTotal, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY);
            }

            startX += move;

            _e.Graphics.DrawString(PaidStatus, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(DateIn, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(ReturnDate, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY);

            startX += move;

            _e.Graphics.DrawString(DatePaid, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY);

            startY += 20;
            startX = startxfull;

            // Makes the Second time = the first time for comparision purposes
            StoreTimeSecond = StoreTime;

            // Makes the first check to false for using
            bSkipFirstCheck = false;
        }
#endregion
        */
    }
}