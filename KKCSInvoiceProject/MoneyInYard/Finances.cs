using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace KKCSInvoiceProject
{
    public partial class Finances : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        int iTotalCashTill = 0;
        int iTotalRefundsTill = 0;
        int iSODTill = 0;
        int iEODTill = 0;

        private OleDbConnection connection = new OleDbConnection();

        public Finances()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            LoadFinances();
        }

        private void LoadFinances()
        {
            int iDayModifier = 1;

            DateTime dt = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day- iDayModifier);

            string sQuery = "";

            connection.Open();

            #region TillLoad

            sQuery = "SELECT * FROM Till WHERE DateTill = @dt";
            DatabaseConnection(sQuery, dt);
            TillReader();

            dt = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day - iDayModifier, 12,0,0);
            sQuery = "SELECT * FROM CustomerInvoices WHERE DTDatePaid = @dt AND PaidStatus = 'Cash'";
            DatabaseConnection(sQuery, dt);
            TillCashTaken();

            dt = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day - iDayModifier);
            sQuery = "SELECT * FROM Refunds WHERE DateRefund = @dt AND RefundLoc = 'Till'";
            DatabaseConnection(sQuery, dt);
            TillRefunds();

            TillCurrent();

            #endregion TillLoad

            #region PlasticBoxLoad

            sQuery = "SELECT * FROM Till WHERE DateTill = @dt";
            DatabaseConnection(sQuery, dt);
            TillReader();

            dt = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day - iDayModifier, 12, 0, 0);
            sQuery = "SELECT * FROM CustomerInvoices WHERE DTDatePaid = @dt AND PaidStatus = 'Cash'";
            DatabaseConnection(sQuery, dt);
            TillCashTaken();

            dt = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day - iDayModifier);
            sQuery = "SELECT * FROM Refunds WHERE DateRefund = @dt AND RefundLoc = 'Till'";
            DatabaseConnection(sQuery, dt);
            TillRefunds();

            TillCurrent();
            #endregion PlasticBoxLoad

            connection.Close();
        }

        void DatabaseConnection(string _query, DateTime _dt)
        {
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;
            command.Parameters.AddWithValue("@_dt", _dt);

            command.CommandText = _query;

            reader = command.ExecuteReader();
        }

        #region Till

        void TillReader()
        {
            iSODTill = 0;
            iEODTill = 0;

            while (reader.Read())
            {
                int.TryParse(reader["SOD"].ToString(), out iSODTill);
                int.TryParse(reader["EOD"].ToString(), out iEODTill);

                lbl_sodtill.Text += reader["SOD"].ToString();

                if(reader["EOD"].ToString() == "")
                {
                    lbl_eodtill.Text += "Day Not Yet Ended";
                }
                else
                {
                    lbl_sodtill.Text += reader["EOD"].ToString();
                }
            }
        }

        void TillCashTaken()
        {
            iTotalCashTill = 0;

            while (reader.Read())
            {
                int iCashParse = 0;
                int.TryParse(reader["TotalPay"].ToString(), out iCashParse);

                iTotalCashTill += iCashParse;
            }

            lbl_cashtaken.Text += iTotalCashTill;
        }

        void TillCurrent()
        {
            lbl_currenttill.Text += (iSODTill + iTotalCashTill - iTotalRefundsTill).ToString();
        }

        void TillRefunds()
        {
            iTotalRefundsTill = 0;

            while (reader.Read())
            {
                int iRefundsParse = 0;
                int.TryParse(reader["AmountRefunded"].ToString(), out iRefundsParse);

                iTotalRefundsTill += iRefundsParse;
            }

            lbl_refundstill.Text += iTotalRefundsTill;
        }

        #endregion Till

        #region PlasticBox

        #endregion PlasticBox
    }
}