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
    public partial class InvoiceManager : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool GetForegroundWindow();

        Label g_lblTabLabel;

        int iFormNumberCount = 0;

        int g_iInitialLocationX = 107;
        int g_iInitialLocationY = 12;

        List<Form> g_listInvoiceFormList;
        List<Label> g_listTabLabelList;

        public InvoiceManager()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            this.FormClosing += InvoiceManager_Closing;

            this.WindowState = FormWindowState.Maximized;

            g_listInvoiceFormList = new List<Form>();
            g_listTabLabelList = new List<Label>();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.White;
                }
            }

            InvoiceChildForms();
        }

        private void InvoiceManager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //string sTabsStillOpen = "Are you sure you want to\r\nclose all Invoices?";

            //WarningSystem ws = new WarningSystem(sTabsStillOpen, true);
            //ws.ShowDialog();

            //if (ws.DialogResult == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        void InvoiceChildForms()
        {
            ///////////////////////////////////////////////////
            // Set up the new Invoice form
            // Instantiate new Invoice
            Invoice objInvoice = new Invoice(false);

            // Set this manager as the parent
            //objInvoice.TopLevel = false;
            objInvoice.MdiParent = this;

            // Set the Invoice name as the counter
            objInvoice.Name = iFormNumberCount.ToString();

            // Show the invoice and bring it to the front
            objInvoice.Show();

            // Send this form to the Invoice Manager
            objInvoice.GetInvoiceManager(this);
            objInvoice.SetTabNumberFromManager(iFormNumberCount);

            // Add the Invoice form to the list
            g_listInvoiceFormList.Add(objInvoice);

            // Put the forms in the same location each time
            objInvoice.StartPosition = FormStartPosition.Manual;
            objInvoice.Location = new Point(4, 58);
            ///////////////////////////////////////////////////

            // Setsa all the tabs to off to begin with
            if (g_listTabLabelList.Count > 0)
            {
                TabLabelsToUnselected();
            }

            ///////////////////////////////////////////////////
            // Set up a new tab label
            g_lblTabLabel = new Label();
            g_lblTabLabel.Location = new Point(g_iInitialLocationX, g_iInitialLocationY);

            g_lblTabLabel.BorderStyle = BorderStyle.Fixed3D;
            g_lblTabLabel.BackColor = lbl_template.BackColor;
            g_lblTabLabel.Font = new Font(lbl_template.Font.FontFamily, 12, FontStyle.Bold);
            g_lblTabLabel.ForeColor = Color.Blue;
            g_lblTabLabel.AutoSize = false;
            g_lblTabLabel.Text = "UNUSED";
            g_lblTabLabel.Name = iFormNumberCount.ToString();

            g_listTabLabelList.Add(g_lblTabLabel);

            Controls.Add(g_lblTabLabel);

            g_lblTabLabel.Click += new System.EventHandler(TabLabel_Click);
            g_lblTabLabel.Show();

            g_iInitialLocationX += g_lblTabLabel.Size.Width + 10;

            iFormNumberCount++;
            ///////////////////////////////////////////////////
        }

        void TabLabelsToUnselected()
        {
            for (int i = 0; i < g_listTabLabelList.Count; i++)
            {
                g_listTabLabelList[i].BorderStyle = BorderStyle.FixedSingle;
                g_listTabLabelList[i].Font = new Font(lbl_template.Font.FontFamily, 12, FontStyle.Regular);
                g_listTabLabelList[i].ForeColor = Color.Black;
            }
        }

        public void ChangeColour(int _iTabNumber)
        {
            for (int i = 0; i < g_listTabLabelList.Count; i++)
            {
                if (i == _iTabNumber)
                {
                    g_listTabLabelList[i].BackColor = Color.LightGreen;
                }
            }
        }

        public void ChangeTabText(int _iTabNumber, string _sCarRego)
        {
            for (int i = 0; i < g_listTabLabelList.Count; i++)
            {
                if (i == _iTabNumber)
                {
                    g_listTabLabelList[i].Text = _sCarRego;
                }
            }
        }

        private void TabLabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            for(int i = 0; i < g_listTabLabelList.Count; i++)
            {
                if(g_listInvoiceFormList[i].Name == lbl.Name)
                {
                    g_listInvoiceFormList[i].BringToFront();
                    g_listInvoiceFormList[i].Show();

                    g_listTabLabelList[i].BorderStyle = BorderStyle.Fixed3D;
                    g_listTabLabelList[i].Font = new Font(lbl_template.Font.FontFamily, 12, FontStyle.Bold);
                    g_listTabLabelList[i].ForeColor = Color.Blue;
                }
                else
                {
                    //g_listTabLabelList[i].SendToBack();

                    g_listTabLabelList[i].BorderStyle = BorderStyle.FixedSingle;
                    g_listTabLabelList[i].Font = new Font(lbl_template.Font.FontFamily, 12, FontStyle.Regular);
                    g_listTabLabelList[i].ForeColor = Color.Black;
                }
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            //System.Media.SystemSounds.Exclamation.Play();

            InvoiceChildForms();

            //g_listInvoiceFormList[0].BringToFront();
        }

        public void DeleteTab(int _TabNumber)
        {
            g_iInitialLocationX -= g_lblTabLabel.Size.Width + 10;

            Controls.Remove(g_listTabLabelList[_TabNumber]);
            g_listTabLabelList[_TabNumber].Dispose();

            for (int i = 0; i < g_listTabLabelList.Count; i++)
            {
                if(i > _TabNumber && g_listTabLabelList[i] != null)
                {
                    int iNewXLocation = g_listTabLabelList[i].Location.X - g_lblTabLabel.Size.Width - 10;
                    g_listTabLabelList[i].Location = new Point(iNewXLocation, g_listTabLabelList[i].Location.Y);
                }
            }

            //Form f = GetForegroundWindow();

            //if (GetForegroundWindow() == Process.GetCurrentProcess().MainWindowHandle)
            //{
            //    //do stuff
            //}
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}