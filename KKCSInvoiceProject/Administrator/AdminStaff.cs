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
    public partial class AdminStaff : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        bool bIsFinishedLoading = false;

        string sOriginalText = "";

        public AdminStaff()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            LoadStaff();

            sOriginalText = txt_staff.Text;

            bIsFinishedLoading = true;

            //SaveStaff();


            //Delete();
        }

        void LoadStaff()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from Staff";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                txt_staff.Text += reader["StaffMember"].ToString() + "\r\n";
            }

            connection.Close();
        }

        void SaveStaff()
        {
            int iLines = txt_staff.Lines.Length;

            connection.Open();

            for(int i = 0; i < iLines; i++)
            {
                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                string cmd1 = @"INSERT into Staff (StaffMember) values ('" + txt_staff.Lines[i] + "')";
                command.CommandText = cmd1;

                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        void Delete()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "DELETE FROM Staff";

            command.CommandText = query;

            command.ExecuteNonQuery();

            //StoreOriginalPrices();

            connection.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Delete();

            SaveStaff();

            sOriginalText = txt_staff.Text;

            lbl_saved.Visible = true;
            lbl_changesmade.Visible = false;
            btn_update.Visible = false;
        }

        private void txt_staff_TextChanged(object sender, EventArgs e)
        {
            lbl_saved.Visible = true;
            lbl_changesmade.Visible = false;
            btn_update.Visible = false;

            if (txt_staff.Text != sOriginalText && bIsFinishedLoading)
            {
                lbl_saved.Visible = false;
                lbl_changesmade.Visible = true;
                btn_update.Visible = true;
            }
        }
    }
}
