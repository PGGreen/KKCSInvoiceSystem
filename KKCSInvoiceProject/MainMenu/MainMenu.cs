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
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class MainMenu : Form
    {

        bool isDebugMode = false;
        //#if DEBUG
        //isDebugMode = true;
        //#endif

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private ComboBox cmb_storeRegoItems;
        private ComboBox cmb_storeAccountItems;
        private ComboBox cmb_storeMakeModel;

        private bool m_bUserExit = false;

        string sVersionNumber = "2.00";

        private OleDbConnection connection = new OleDbConnection();
        OleDbCommand command;

        OleDbDataReader reader;

        public MainMenu()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            this.FormClosing += MainMenu_Closing;

            btn_build.Text = "v" + sVersionNumber;

            #if DEBUG
            Debug();
            #endif

            SetUpRegoComboBox();

            SetUpMakeModelComboBox();

            SetUpAccountComboBox();
        }

        void Debug()
        {
            btn_build.BackColor = Color.Black;
            btn_build.ForeColor = Color.White;
            btn_build.Text = "d" + sVersionNumber;

            Label lblDebug = new Label();

            lblDebug.Location = new Point(400, 400);
            lblDebug.Text = "WARNING: TEST MODE";
            lblDebug.Font = new Font("Microsoft San Serif", 24, FontStyle.Bold);
            lblDebug.Size = new Size(400, 37);
            lblDebug.BackColor = Color.Black;
            lblDebug.ForeColor = Color.White;

            Controls.Add(lblDebug);
        }

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

            lbl_carsindatabase.Text += " " + iCountNumberPlates.ToString();

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
                    if(sStoreFirstMM != "")
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
            //cmb_storeAccountItems = new ComboBox();

            //connection.Open();

            //OleDbCommand command = new OleDbCommand();

            //command.Connection = connection;

            //string blank = "";

            //string query = "select * from NumberPlates WHERE Account <> '" + blank + "'  ORDER BY Account ASC";

            //command.CommandText = query;

            //OleDbDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    cmb_storeAccountItems.Items.Add(reader["Account"].ToString());
            //}

            //connection.Close();
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
                    ac.SetAdminMode();
                }
                
                ac.Show();
            }
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
                EndOfDay eod = new EndOfDay();
                eod.Show();
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
                LongTermMain ltm = new LongTermMain();
                ltm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["YardStats"];

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

        private void button3_Click(object sender, EventArgs e)
        {
            //PrintTest();

            PrintLongTerm();
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