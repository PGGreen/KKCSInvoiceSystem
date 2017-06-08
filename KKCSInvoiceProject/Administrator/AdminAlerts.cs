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
    public partial class AdminAlerts : Form
    {
        string sTxtFileLocation = "";
        string sTxtFileBody = "";
        string sTitleForPreview = "";

        public AdminAlerts()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;

            LoadTextFile("No Key Policy");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTextFile(comboBox1.Text);

            lbl_savestatus.Text = "Unsaved";
            lbl_savestatus.ForeColor = Color.Red;
        }

        void LoadTextFile(string _sLoadTextFile)
        {
            if (_sLoadTextFile == "No Key Policy")
            {
                sTitleForPreview = "No Key Policy";
                NoKeyPolicy();
            }
        }

        void NoKeyPolicy()
        {
            sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Alerts\\No Key Policy.txt";

            using (StreamReader sr = new StreamReader(sTxtFileLocation))
            {
                sTxtFileBody = sr.ReadToEnd();
            }

            txt_text.Text = sTxtFileBody;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string[] sTextToSave = { txt_text.Text };

            File.WriteAllLines(sTxtFileLocation, sTextToSave);

            lbl_savestatus.Text = "Saved";
            lbl_savestatus.ForeColor = Color.Green;
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            AlertGeneric ag = new AlertGeneric("");
            ag.Preview(txt_text.Text, sTitleForPreview);
            ag.Show();
        }

        private void txt_text_TextChanged(object sender, EventArgs e)
        {
            lbl_savestatus.Text = "Unsaved";
            lbl_savestatus.ForeColor = Color.Red;
        }
    }
}