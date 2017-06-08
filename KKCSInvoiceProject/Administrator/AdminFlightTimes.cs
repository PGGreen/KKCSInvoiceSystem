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
    public partial class AdminFlightTimes : Form
    {
        string sTxtFileLocation = "";
        string sTxtFileBody = "";

        public AdminFlightTimes()
        {
            InitializeComponent();

            cmb_pickday.SelectedIndex = 0;

            LoadDataFromTxtFile();
        }

        void LoadDataFromTxtFile()
        {
            if (cmb_pickday.Text == "Mon - Fri")
            {
                sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Mon To Fri.txt";
            }
            else if (cmb_pickday.Text == "Sat")
            {
                sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sat.txt";
            }
            else if(cmb_pickday.Text == "Sun")
            {
                sTxtFileLocation = Directory.GetCurrentDirectory() + "\\Data\\Flight Times\\Sun.txt";
            }

            using (StreamReader sr = new StreamReader(sTxtFileLocation))
            {
                sTxtFileBody = sr.ReadToEnd();
            }

            txt_text.Text = sTxtFileBody;

            txt_text.Text = txt_text.Text.TrimEnd();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string[] sTextToSave = { txt_text.Text.TrimEnd() };

            File.WriteAllLines(sTxtFileLocation, sTextToSave);

            lbl_savestatus.Text = "Saved";
            lbl_savestatus.ForeColor = Color.Green;
        }

        private void txt_text_TextChanged(object sender, EventArgs e)
        {
            lbl_savestatus.Text = "Unsaved";
            lbl_savestatus.ForeColor = Color.Red;
        }

        private void cmb_pickday_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataFromTxtFile();
        }
    }
}