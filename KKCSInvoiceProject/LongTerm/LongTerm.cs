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
    public partial class LongTerm : Form
    {
        #region GlobalVariables

        OleDbCommand command;
        OleDbConnection connection = new OleDbConnection();
        OleDbDataReader reader;

        int g_iLocation = 0;

        string sPageNumber = "";

        List<Panel> lstPanels;

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        #endregion GlobalVariables

        public LongTerm()
        {
            InitializeComponent();

            lstPanels = new List<Panel>();

            connection.ConnectionString = m_strDataBaseFilePath;

            GetPageNumbers();

            cmb_pagenumber.Text = "LT001";

            sPageNumber = cmb_pagenumber.Text;

            for (int i = 0; i < 15; i++)
            {
                CreateLongTermPanels();
            }

            PopulateLongTermPanels();
        }

        void GetPageNumbers()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "";

            query = @"SELECT * FROM LongTerm";
            command.CommandText = query;
            reader = command.ExecuteReader();

            // Stores the time from the table
            string StoreFirstRecord = "";

            // Stores time at end to compare and see if a new time has shown
            string StoreSecondRecord = "";

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            while (reader.Read())
            {
                StoreFirstRecord = reader["PageNumber"].ToString();

                // Compares the 2 times together to see if they are different or not
                // Skips the first check
                if (StoreFirstRecord != StoreSecondRecord && !bSkipFirstCheck)
                {
                    cmb_pagenumber.Items.Add(StoreFirstRecord);
                }

                // Makes the Second time = the first time for comparision purposes
                StoreSecondRecord = StoreFirstRecord;

                // Makes the first check to false for using
                bSkipFirstCheck = false;
            }
        }

        void CreateLongTermPanels()
        {
            Panel pnl = new Panel();

            pnl.Size = pnl_longtermtemplate.Size;
            pnl.Location = new Point(pnl_longtermtemplate.Location.X, pnl_longtermtemplate.Location.Y + g_iLocation);

            foreach (Control ctr in pnl_longtermtemplate.Controls)
            {
                // Handles all the Label Controlls
                if (ctr.GetType() == typeof(CheckBox))
                {
                    CheckBox chkBox = new CheckBox();

                    chkBox.Size = ctr.Size;
                    chkBox.Location = ctr.Location;
                    chkBox.Font = ctr.Font;
                    chkBox.BackColor = ctr.BackColor;
                    chkBox.Name = ctr.Name;
                    chkBox.Text = ctr.Text;
                    chkBox.Checked = false;

                    pnl.Controls.Add(chkBox);
                }
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = new TextBox();

                    txtBox.Size = ctr.Size;
                    txtBox.Location = ctr.Location;
                    txtBox.Font = ctr.Font;
                    txtBox.BackColor = ctr.BackColor;
                    txtBox.Name = ctr.Name;

                    if (ctr.Name == "txt_hiddenpagenumber")
                    {
                        txtBox.Text = sPageNumber;
                    }

                    pnl.Controls.Add(txtBox);
                }
            }

            this.Controls.Add(pnl);
            lstPanels.Add(pnl);

            g_iLocation += 45;

            connection.Close();
        }

        void PopulateLongTermPanels()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "SELECT * From LongTerm WHERE PageNumber = '" + sPageNumber + "' ORDER BY ID";

            command.CommandText = query;

            reader = command.ExecuteReader();

            int ilstPanelCount = 0;

            while (reader.Read())
            {
                Panel pnl = lstPanels[ilstPanelCount];

                ilstPanelCount++;

                pnl.Size = pnl_longtermtemplate.Size;

                foreach (Control ctr in pnl.Controls)
                {
                    // Handles all the Label Controlls
                    if(ctr.GetType() == typeof(CheckBox))
                    {
                        if(ctr.Name == "chk_isalreadysaved")
                        {
                            CheckBox chkBox = (CheckBox)ctr;

                            chkBox.Checked = (bool)reader["IsAlreadySaved"];
                        }
                    }

                    if (ctr.GetType() == typeof(TextBox))
                    {
                        TextBox txtBox = (TextBox)ctr;

                        switch(ctr.Name)
                        {
                            case "txt_keyno":
                                {
                                    txtBox.Text = reader["KeyNumber"].ToString();
                                    break;
                                }
                            case "txt_rego":
                                {
                                    txtBox.Text = reader["Rego"].ToString();
                                    break;
                                }
                            case "txt_carin":
                                {
                                    txtBox.Text = reader["DateIn"].ToString();
                                    break;
                                }
                            case "txt_carout":
                                {
                                    txtBox.Text = reader["DateOut"].ToString();
                                    break;
                                }
                            case "txt_hiddenid":
                                {
                                    txtBox.Text = reader["ID"].ToString();
                                    break;
                                }
                            case "txt_hiddenpagenumber":
                                {
                                    txtBox.Text = reader["PageNumber"].ToString();
                                    break;
                                }
                        }
                    }
                }
            }

            connection.Close();
        }

        void InsertIntoDatabase()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            for (int i = 0; i < lstPanels.Count; i++)
            {
                string sKeyNumber = "";
                string sRego = "";
                string sDateIn = "";
                string sDateOut = "";
                bool bIsAlreadySaved = false;
                int iHiddenID = 0;

                foreach (Control ctl in lstPanels[i].Controls)
                {
                    if (ctl.GetType() == typeof(CheckBox))
                    {
                        if(ctl.Name == "chk_isalreadysaved")
                        {
                            CheckBox cb = (CheckBox)ctl;
                            bIsAlreadySaved = cb.Checked;
                        }
                    }
                    if(ctl.GetType() == typeof(TextBox))
                    {
                        if (ctl.Name == "txt_keyno")
                        {
                            sKeyNumber = ctl.Text;
                        }
                        if (ctl.Name == "txt_carin")
                        {
                            sDateIn = ctl.Text;
                        }
                        if (ctl.Name == "txt_carout")
                        {
                            sDateOut = ctl.Text;
                        }
                        if (ctl.Name == "txt_rego")
                        {
                            sRego = ctl.Text;
                        }
                        if(ctl.Name == "txt_hiddenid")
                        {
                            int.TryParse(ctl.Text, out iHiddenID);
                        }

                    }
                }

                string query = "";

                query = @"UPDATE LongTerm
                            SET 
                            DateIn = '" + sDateIn + 
                            "', DateOut = '" + sDateOut +
                            "', Rego = '" + sRego +
                            "', KeyNumber = '" + sKeyNumber +
                            "' WHERE ID = " + iHiddenID + "";
                
                command.CommandText = query;

                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        //btn.Click += new EventHandler(InvoiceButton_Click);

        private void btn_addnew_Click(object sender, EventArgs e)
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "";

            query = @"SELECT * FROM LongTerm";
            command.CommandText = query;
            reader = command.ExecuteReader();

            string sPageName = ""; 

            while(reader.Read())
            {
                sPageName = reader["PageNumber"].ToString();
            }

            string sPageNumberOut = sPageName.Substring(2);

            int iPageNumber = 0;
            int.TryParse(sPageNumberOut, out iPageNumber);

            sPageNumber = "LT" + (iPageNumber + 1).ToString("000");

            command = new OleDbCommand();

            command.Connection = connection;

            for (int i = 0; i < 15; i++)
            {
                query = @"INSERT INTO LongTerm (PageNumber) values ('"+ sPageNumber + "')";
                
                command.CommandText = query;

                command.ExecuteNonQuery();
            }

            cmb_pagenumber.Items.Add(sPageNumber);
            cmb_pagenumber.Text = sPageNumber;

            connection.Close();

            DeleteControls();

            g_iLocation = 0;

            for (int i = 0; i < 15; i++)
            {
                CreateLongTermPanels();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            InsertIntoDatabase();

            btn_save.BackColor = Color.Green;
            btn_save.Text = "Saved";
            this.BackColor = Color.LightGreen;
        }

        private void txt_keyno_TextChanged(object sender, EventArgs e)
        {

        }

        void DeleteControls()
        {
            // Deletes all the buttons in the table apart from the Load button
            foreach (Panel pnl in this.Controls.OfType<Panel>().ToArray())
            {
                if (pnl.Name == "pnl_template")
                {
                    // Do Nothing
                }
                else
                {
                    Controls.Remove(pnl);
                }
            }

            // Deletes all the buttons in the table apart from the Load button
            foreach (Label lbl in this.Controls.OfType<Label>().ToArray())
            {
                if (lbl.Text == "Unknown/Overdue" || lbl.Name == "lbl_blank" || lbl.Name == "lbl_returndate"
                    || lbl.Name == "lbl_unknown" || lbl.Name == "lbl_title")
                {
                    Controls.Remove(lbl);
                }
            }

            lstPanels = new List<Panel>();
        }

        private void LongTerm_Load(object sender, EventArgs e)
        {

        }

        bool bFirstTimeSkip = false;

        private void cmb_pagenumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirstTimeSkip)
            {
                sPageNumber = cmb_pagenumber.Text;
                DeleteControls();

                g_iLocation = 0;

                for (int i = 0; i < 15; i++)
                {
                    CreateLongTermPanels();
                }

                PopulateLongTermPanels();
            }

            bFirstTimeSkip = true;
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            InsertIntoDatabase();

            if (cmb_pagenumber.SelectedIndex > 0)
            {
                cmb_pagenumber.SelectedIndex = (cmb_pagenumber.SelectedIndex - 1);
            }
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            InsertIntoDatabase();

            if (cmb_pagenumber.SelectedIndex < (cmb_pagenumber.Items.Count - 1))
            {
                cmb_pagenumber.SelectedIndex = (cmb_pagenumber.SelectedIndex + 1);
            }
        }        
    }
}