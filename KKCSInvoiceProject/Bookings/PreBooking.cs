using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace KKCSInvoiceProject
{
    public partial class PreBooking : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        //OleDbDataReader reader;

        private OleDbConnection connection = new OleDbConnection();

        OleDbCommand command;

        public PreBooking(string _sPreBookings)
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            lbl_prebooking.Text = _sPreBookings;

            //LoadBookingsInfo();
        }

        void LoadBookingsInfo()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "SELECT * FROM Bookings";

            command.CommandText = query;

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
