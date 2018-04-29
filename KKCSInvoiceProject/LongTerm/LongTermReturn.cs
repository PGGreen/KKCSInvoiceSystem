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
    public partial class LongTermReturn : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        string m_sRego = "";

        public LongTermReturn(string _sRego)
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            m_sRego = _sRego;

            LoadLongTerm();
        }

        void LoadLongTerm()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM LongTermAccounts WHERE Rego1 = '"+ m_sRego + "' OR Rego2 = '"+ m_sRego + "'";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string sLongTerm = "";

                string sLTNumber = reader["LongTermKey"].ToString();
                string sName = reader["ClientName"].ToString();
                string sPh = reader["Ph"].ToString();

                sLongTerm += "LT"+ sLTNumber + ": " + m_sRego + "\r\n";
                sLongTerm += "Name: " + sName + "\r\n";
                sLongTerm += "Ph: " + sPh;

                lbl_longterm.Text = sLongTerm;
            }

            connection.Close();
        }

        private void chk_enablereturn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_flighttime.Enabled = false;
            lbl_returndate.Enabled = false;
            lbl_return.Enabled = false;
            dt_dateleft.Enabled = false;
            dt_dateright.Enabled = false;
            dt_returndate.Enabled = false;
            txt_flighttimes.Enabled = false;
            btn_save.Visible = false;
            btn_save.Enabled = false;
            this.BackColor = Color.White;


            if (chk_enablereturn.Checked)
            {
                lbl_flighttime.Enabled = true;
                lbl_return.Enabled = true;
                lbl_returndate.Enabled = true;
                dt_dateleft.Enabled = true;
                dt_dateright.Enabled = true;
                dt_returndate.Enabled = true;
                txt_flighttimes.Enabled = true;
                btn_save.Visible = true;
                btn_save.Enabled = true;

                this.BackColor = Color.MistyRose;
            }
        }
    }
}
