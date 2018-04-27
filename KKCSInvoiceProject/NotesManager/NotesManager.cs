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
    public partial class NotesManager : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        public NotesManager()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            LoadNotes();
        }

        public void RefreshNotes()
        {
            // Deletes all the buttons in the table apart from the Load button
            foreach (Button bt in this.Controls.OfType<Button>().ToArray())
            {
                if (bt.Name == "btn_dailynew" || bt.Name == "btn_left" || bt.Name == "btn_right" || bt.Name == "btn_dailynotesplaceholder"
                    || bt.Name == "btn_newbookings" || bt.Name == "btn_bookingsdelete" || bt.Name == "btn_bookingsplaceholder"
                    || bt.Name == "btn_constantnew" || bt.Name == "btn_constantdelete" || bt.Name == "btn_constantplaceholder"
                    || bt.Name == "btn_topline" || bt.Name == "btn_leftline" || bt.Name == "btn_rightline")
                {
                    // Do Nothing
                }
                else
                {
                    bt.Text = string.Empty;
                    Controls.Remove(bt);
                }
            }

            LoadNotes();
        }

        void LoadNotes()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dt = new DateTime(dt_dateandtime.Value.Year, dt_dateandtime.Value.Month, dt_dateandtime.Value.Day);

            string sDate = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();

            //Insert the new Number Plate into the Database
            string cmd1 = @"SELECT * FROM Notes WHERE DateAndTime = #" + sDate + "#";
            //string cmd1 = @"SELECT * FROM Notes WHERE DateAndTime = '" + dt + "'";
            //string cmd1 = @"SELECT * FROM Notes WHERE DateAndTime = #20/09/2016#";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            reader = command.ExecuteReader();

            int iLocationXDefault = 23;
            int iLocationYDefault = 96;

            while (reader.Read())
            {
                Button btn = new Button();

                btn.Size = btn_dailynotesplaceholder.Size;
                btn.Font = btn_dailynotesplaceholder.Font;
                btn.BackColor = btn_dailynotesplaceholder.BackColor;

                btn.Location = new Point(iLocationXDefault, iLocationYDefault);

                btn.Visible = true;
                btn.Enabled = true;
                btn.Name = reader["ID"].ToString();

                btn.Text = reader["Title"].ToString();

                Controls.Add(btn);

                btn.Click += new EventHandler(DailyNotes_Click);

                iLocationYDefault += 39;
            }

            connection.Close();
        }

        private void DailyNotes_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = 0;
            Int32.TryParse(btn.Name, out x);
        }

        private void btn_dailynew_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["DailyNotes"];

            if (fm != null)
            {
                fm.BringToFront();
            }
            else
            {


            }
        }

        private void dt_dateandtime_ValueChanged(object sender, EventArgs e)
        {
            RefreshNotes();
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dt_dateandtime.Value;

            dtStore = dtStore.AddDays(-1);

            dt_dateandtime.Value = dtStore;

            RefreshNotes();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            DateTime dtStore = dt_dateandtime.Value;

            dtStore = dtStore.AddDays(1);

            dt_dateandtime.Value = dtStore;

            RefreshNotes();
        }
    }
}
