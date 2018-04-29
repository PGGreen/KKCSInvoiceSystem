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
using System.Data.SqlClient;


namespace KKCSInvoiceProject
{
    public partial class DailyNotes : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        Color defaultBackColour;

        string g_sOriginalValue = "";

        string g_sID = "";

        bool g_bIsSaved = false;

        public DailyNotes()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            defaultBackColour = chk_hp.BackColor;

            cmb_worker.SelectedIndex = 0;
        }

        public void LoadFromEdit(string _sInvoice)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            int iInvoice = 0;
            int.TryParse(_sInvoice, out iInvoice);

            command.CommandText = "SELECT Notes,IsHighPriority FROM Notes WHERE ID = "+ iInvoice + "";

            OleDbDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                txt_notes.Text = reader["Notes"].ToString();
                
                if((bool)reader["IsHighPriority"])
                {
                    chk_hp.Checked = true;
                }
            }

            connection.Close();

            g_sOriginalValue = txt_notes.Text;

            btn_save.Enabled = false;
            btn_save.Text = "SAVED";
            btn_save.BackColor = Color.Green;
            BackColor = Color.LightGreen;

            g_bIsSaved = true;
        }

        private void txt_title_TextChanged(object sender, EventArgs e)
        {

        }

        private void DailyNotes_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //objNotesManager.RefreshNotes();
        }

        public void LoadFromNotesManager(int _ID)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //DateTime dt = new DateTime(dt_dateandtime.Value.Year, dt_dateandtime.Value.Month, dt_dateandtime.Value.Day, 12, 0, 0);

            //Insert the new Number Plate into the Database
            string cmd1 = @"SELECT * FROM Notes WHERE ID = " + _ID + "";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                //txt_title.Text = reader["Title"].ToString();
                txt_notes.Text = reader["NoteStore"].ToString();

                //dt_dateandtime.Value = (DateTime)reader["DateAndTime"];
            }

            connection.Close();

            this.BackColor = Color.LightGreen;

            btn_save.Text = "Saved";
            btn_save.BackColor = Color.Green;
        }

        void SaveDailyNoteToDatabase()
        {

            if(cmb_worker.Text == "Please Pick...")
            {
                WarningSystem ws = new WarningSystem("- Please enter a Staff Member.", false);
                ws.ShowDialog();

                return;
            }

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dt = DateTime.Now;

            bool bIsHighPriority = false;

            if(chk_hp.Checked)
            {
                bIsHighPriority = true;
            }

            //Insert the new Number Plate into the Database
            string cmd1 = @"INSERT INTO Notes (StaffMember,Notes,DateAndTime,IsHighPriority) values ('" + cmb_worker.Text + "','" + txt_notes.Text + "','"+ dt + "',"+ bIsHighPriority + ")";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            command.ExecuteNonQuery();

            // Get ID
            command = new OleDbCommand();

            command.Connection = connection;

            command.CommandText = "SELECT ID FROM Notes ORDER BY ID DESC";

            OleDbDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                g_sID = reader["ID"].ToString();

                break;
            }
            
            connection.Close();

            this.BackColor = Color.LightGreen;

            btn_save.Text = "Saved";
            btn_save.BackColor = Color.Green;

            g_sOriginalValue = txt_notes.Text;

            g_bIsSaved = true;

            btn_save.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveDailyNoteToDatabase();
        }

        

        private void chk_hp_CheckedChanged(object sender, EventArgs e)
        {
            chk_hp.BackColor = defaultBackColour;

            if (chk_hp.Checked)
            {
                chk_hp.BackColor = Color.Red;
            }
        }

        private void txt_notes_TextChanged(object sender, EventArgs e)
        {
            if (g_bIsSaved && txt_notes.Text != g_sOriginalValue)
            {
                btn_update.Visible = true;
                BackColor = Color.Yellow;
            }
            else if(g_bIsSaved)
            {
                btn_update.Visible = false;
                BackColor = Color.LightGreen;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            int iID = 0;
            int.TryParse(g_sID, out iID);

            command.CommandText = "UPDATE Notes SET IsHighPriority = True, Notes = '" + txt_notes.Text + "' WHERE ID = " + iID + "";

            command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            BackColor = Color.LightGreen;
            btn_update.Visible = false;
        }
    }
}