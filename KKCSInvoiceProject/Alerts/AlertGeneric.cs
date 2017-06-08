using System;
using System.IO;
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
    public partial class AlertGeneric : Form
    {
        public AlertGeneric(string _AlertPicked)
        {
            InitializeComponent();

            if(_AlertPicked == "No Key Policy")
            {
                NoKeyPolicy();
            }
        }

        public void Preview(string _sPreview, string _sTitle)
        {
            lbl_title.Text = _sTitle;
            lbl_body.Text = _sPreview;
        }

        void NoKeyPolicy()
        {
            string sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Alerts\\No Key Policy.txt";
            string sTxtFileBody = "";

            using (StreamReader sr = new StreamReader(sTxtFileLocation))
            {
                sTxtFileBody = sr.ReadToEnd();
            }

            lbl_title.Text = "No Key Policy";
            lbl_body.Text = sTxtFileBody;
        }
    }
}