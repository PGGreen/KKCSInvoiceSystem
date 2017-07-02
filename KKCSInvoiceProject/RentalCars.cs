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
    public partial class RentalCars : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        public RentalCars()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            Insert();
        }

        void Insert()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string sMileage = txt_mileage.Text;
            string sACheck = txt_acheck.Text;
            string sDifference = txt_difference.Text;

            DateTime dtReg = dt_reg.Value;
            DateTime dtCOF = dt_cof.Value;

            if (!chk_service.Checked)
            {
                sMileage = "";
                sACheck = "";
                sDifference = "";
            }

            if(!chk_reg.Checked)
            {
                dtReg = new DateTime(2001, 1, 1, 12, 0, 0);
            }

            if(!reg_cof.Checked)
            {
                dtCOF = new DateTime(2001, 1, 1, 12, 0, 0);
            }

            string cmd1 = @"INSERT into RentalCars (Rego,ServiceMileage,ServiceACheck,ServiceDifference,RegDue,COFDue)
                                                                             values ('" + txt_rego.Text +
                                                                                     "','" + sMileage +
                                                                                     "','" + sACheck +
                                                                                     "','" + sDifference +
                                                                                     "','" + dtReg +
                                                                                     "','" + dtCOF + "')";

            command.CommandText = cmd1;

            command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void chk_service_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_service.Checked)
            {
                lbl_mil.Visible = true;
                lbl_acheck.Visible = true;
                lbl_dif.Visible = true;

                txt_mileage.Visible = true;
                txt_acheck.Visible = true;
                txt_difference.Visible = true;
            }
            else
            {
                lbl_mil.Visible = false;
                lbl_acheck.Visible = false;
                lbl_dif.Visible = false;

                txt_mileage.Visible = false;
                txt_acheck.Visible = false;
                txt_difference.Visible = false;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void chk_reg_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_reg.Checked)
            {
                dt_reg.Visible = true;
            }
            else
            {
                dt_reg.Visible = false;
            }
        }

        private void reg_cof_CheckedChanged(object sender, EventArgs e)
        {
            if (reg_cof.Checked)
            {
                dt_cof.Visible = true;
            }
            else
            {
                dt_cof.Visible = false;
            }
        }
    }
}
