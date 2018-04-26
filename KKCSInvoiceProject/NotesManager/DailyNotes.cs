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
    public partial class DailyNotes : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        NotesManager objNotesManager = new NotesManager();

        public DailyNotes(NotesManager _objNotesManager)
        {
            InitializeComponent();

            objNotesManager = _objNotesManager;

            connection.ConnectionString = m_strDataBaseFilePath;

            //txt_title.MaxLength = 35;
        }

        private void txt_title_TextChanged(object sender, EventArgs e)
        {
            //int iTextLength = txt_title.Text.Length;

            //lbl_maxchar.Text = iTextLength.ToString() + "/35";
        }

        private void DailyNotes_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            objNotesManager.RefreshNotes();
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
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string sTypeOfNote = "Daily Note";

            //DateTime dt = new DateTime(dt_dateandtime.Value.Year, dt_dateandtime.Value.Month, dt_dateandtime.Value.Day);

            //Insert the new Number Plate into the Database
            string cmd1 = @"INSERT into Notes (TypeOfNote,DateAndTime,Title,NoteStore) values
                                                            ('" + sTypeOfNote + "','" +
                                                            //dt + "','" +
                                                            //txt_title.Text + "','" +
                                                            txt_notes.Text +
                                                        "')";

            // Makes the command text equal the string
            command.CommandText = cmd1;

            // Run a NonQuery (Saves into Database instead of pulling data out)
            command.ExecuteNonQuery();

            connection.Close();

            this.BackColor = Color.LightGreen;

            btn_save.Text = "Saved";
            btn_save.BackColor = Color.Green;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveDailyNoteToDatabase();
        }
    }
}