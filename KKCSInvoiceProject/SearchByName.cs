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
    public partial class SearchByName : Form
    {
        #region GlobalVariables

        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        private OleDbConnection connection = new OleDbConnection();

        int iInitialPanelLocationY = 0;

        string g_sCustomerID = "";

        Panel pnl;

        #endregion

        #region Load

        public SearchByName()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            SetUpComboBoxes();
        }

        #endregion Load

        #region SetUpComboBoxes

        void SetUpComboBoxes()
        {
            SetUpFirstNameComboBox();

            SetUpLastNameComboBox();
        }

        public void SetUpFirstNameComboBox()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from NumberPlates ORDER BY ClientName ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            string sFirstName = "";

            string sFirstNameSecond = "";

            while (reader.Read())
            {
                sFirstName = reader["ClientName"].ToString();

                if (sFirstName != sFirstNameSecond)
                {
                    cmb_firstname.Items.Add(reader["ClientName"].ToString());
                }

                sFirstNameSecond = sFirstName;
            }

            connection.Close();
        }

        public void SetUpLastNameComboBox()
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = "select * from NumberPlates ORDER BY LastName ASC";

            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            string sLastName = "";

            string sLastNameSecond = "";

            while (reader.Read())
            {
                sLastName = reader["LastName"].ToString();

                if (sLastName != sLastNameSecond)
                {
                    cmb_lastname.Items.Add(reader["LastName"].ToString());
                }

                sLastNameSecond = sLastName;
            }

            connection.Close();
        }

        #endregion

        #region CreatePanels

        void RefreshFirstNameSearch()
        {
            // Set the initial location for the title
            iInitialPanelLocationY = pnl_template.Location.Y;

            // Creates the Title Header
            TitleHeaders(0);

            // Creates a query for todays returns
            string sQuery = "select * from NumberPlates WHERE ClientName = '" + cmb_firstname.Text + "' ORDER BY NumberPlates ASC";
            CreateQuery(sQuery);

            iInitialPanelLocationY += 10;

            Label lblBlank = new Label();
            lblBlank.Name = "lbl_blank";
            lblBlank.Location = new Point(0, iInitialPanelLocationY);
            Controls.Add(lblBlank);
        }

        void RefreshLastNameSearch()
        {
            // Set the initial location for the title
            iInitialPanelLocationY = pnl_template.Location.Y;

            // Creates the Title Header
            TitleHeaders(1);

            // Creates a query for todays returns
            string sQuery = "select * from NumberPlates WHERE LastName = '" + cmb_lastname.Text + "' ORDER BY NumberPlates ASC";
            CreateQuery(sQuery);

            iInitialPanelLocationY += 10;

            Label lblBlank = new Label();
            lblBlank.Name = "lbl_blank";
            lblBlank.Location = new Point(0, iInitialPanelLocationY);
            Controls.Add(lblBlank);
        }

        void TitleHeaders(int _iPickTitle)
        {
            Label lblTitle = new Label();
            lblTitle.Name = "lbl_title";
            lblTitle.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);

            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.Size = new Size(1400, 40);
            lblTitle.BringToFront();

            if (_iPickTitle == 0)
            {
                lblTitle.BackColor = System.Drawing.Color.LightBlue;
                lblTitle.ForeColor = System.Drawing.Color.Black;

                lblTitle.Text = "Searching First Name: " + cmb_firstname.Text;
            }
            else if (_iPickTitle == 1)
            {
                lblTitle.BackColor = System.Drawing.Color.LightBlue;
                lblTitle.ForeColor = System.Drawing.Color.Black;

                lblTitle.Text = "Searching Last Name: " + cmb_lastname.Text;
            }
            else if (_iPickTitle == 2)
            {
                lblTitle.BackColor = System.Drawing.Color.LightBlue;
                lblTitle.ForeColor = System.Drawing.Color.Black;

                //lblTitle.Text = "Searching Rego: " + cmb_rego.Text;
            }

            Controls.Add(lblTitle);
        }

        void CreateQuery(string _sQuery)
        {
            // Opens and creates the connection for the database
            connection.Open();

            // Make new OleDbCommand object
            command = new OleDbCommand();

            // Create the connection
            command.Connection = connection;

            command.CommandText = _sQuery;

            reader = command.ExecuteReader();

            // Moves the location down for the first panel
            iInitialPanelLocationY += 50;

            while (reader.Read())
            {
                // Creates the labels for that record
                CreateIndividualPanel();
            }

            connection.Close();
        }

        void CreateIndividualPanel()
        {
            pnl = new Panel();
            
            pnl.Location = new Point(pnl_template.Location.X, iInitialPanelLocationY);
            iInitialPanelLocationY += 50;

            pnl.Size = pnl_template.Size;
            pnl.BackColor = pnl_template.BackColor;
            pnl.BorderStyle = pnl_template.BorderStyle;

            // Handles the controls within the panel
            foreach (Control p in pnl_template.Controls)
            {
                // Handles all the button controls
                if (p.GetType() == typeof(Button))
                {
                    ControlButtons(p);
                }
                // Handles all the Label Controlls
                if (p.GetType() == typeof(Label))
                {
                    ControlLabels(p);
                }
            }

            Controls.Add(pnl);
        }

        void ControlButtons(Control _p)
        {
            // Creates a new button
            Button btn = new Button();
            btn.Visible = false;

            // Is it the Invoice No Button
            if (_p.Name == "btn_insert")
            {
                btn.Text = _p.Text;
                btn.Name = reader["ID"].ToString();
                btn.BackColor = _p.BackColor;

                btn.Visible = true;

                btn.Click += new EventHandler(Insert_Click);
            }

            btn.Location = _p.Location;
            btn.Size = _p.Size;
            pnl.Controls.Add(btn);

        }

        void ControlLabels(Control _p)
        {
            Label lbl = new Label();

            // Handles the customer name
            if (_p.Name == "lbl_customername")
            {
                string sNameLength = reader["ClientName"].ToString() + " " + reader["LastName"].ToString();
                string sStoreName = "";

                if (sNameLength.Length > 21)
                {
                    lbl.Font = new Font(_p.Font.FontFamily, 8);
                    lbl.Size = new Size(_p.Size.Width, _p.Size.Height + 10);
                    sStoreName = reader["ClientName"].ToString() + "\r\n" + reader["LastName"].ToString();

                    lbl.Text = sStoreName;
                }
                else
                {
                    lbl.Font = _p.Font;
                    lbl.Size = _p.Size;

                    lbl.Text = sNameLength;
                }
            }

            if (_p.Name == "lbl_ph")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["Ph"].ToString();
            }

            if (_p.Name == "lbl_rego")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["NumberPlates"].ToString();
            }

            if (_p.Name == "lbl_make")
            {
                lbl.Font = _p.Font;
                lbl.Size = _p.Size;

                lbl.Text = reader["MakeModel"].ToString();
            }

            //if (_p.Name == "lbl_account")
            //{
            //    lbl.Font = _p.Font;
            //    lbl.Size = _p.Size;

            //    lbl.Text = reader["Account"].ToString();
            //}

            lbl.Location = _p.Location;

            pnl.Controls.Add(lbl);
        }

        #endregion

        private void Insert_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            g_sCustomerID = btn.Name;

            Close();
        }

        public string GetCustomerID()
        {
            return (g_sCustomerID);
        }


        #region TextChanged

        private void cmb_firstname_TextChanged(object sender, EventArgs e)
        {
            DeleteControls();

            RefreshFirstNameSearch();
        }

        private void cmb_lastname_TextChanged(object sender, EventArgs e)
        {
            DeleteControls();

            RefreshLastNameSearch();
        }

        #endregion TextChanged

        #region Delete

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
                if (lbl.Name == "lbl_blank" || lbl.Name == "lbl_title")
                {
                    Controls.Remove(lbl);
                }
            }
        }

        #endregion
    }
}
