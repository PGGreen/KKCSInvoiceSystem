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
    public partial class PettyCashManager : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        bool bFirstTimeSkip = true;

        int iInitialLocationX = 17;
        int iInitialLocationY = 90;

        public PettyCashManager()
        {
            connection.ConnectionString = m_strDataBaseFilePath;

            InitializeComponent();

            SetUpInitialMonthAndYear();
        }

        void SetUpInitialMonthAndYear()
        {
            DateTime dt = DateTime.Today;

            cmb_month.Text = dt.ToString("MMMM");
            txt_year.Text = dt.Year.ToString();

            SetUpPettyCashMonth();
        }

        void SetUpPettyCashMonth()
        {
            SetUpTopRow();

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            string query = @"SELECT * FROM PettyCash WHERE DateMonth = '" + cmb_month.Text + 
            "' AND DateYear = '" + txt_year.Text + "' ORDER BY DateDay ASC";

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                SetUpPettyCashRows();
            }

            connection.Close();
        }

        void SetUpTopRow()
        {
            string[] sarrItems = { "Item", "Date", "Amount", "Till", "Plastic Box", "Reciept", "Notes" };

            for (int i = 0; i < 7; i++)
            {
                Label lb = new Label();

                lb.Location = new Point(iInitialLocationX, iInitialLocationY);
                lb.Text = sarrItems[i];//reader[sItems[i]].ToString();
                lb.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold | FontStyle.Underline);
                lb.Size = new Size(120, 30);

                Controls.Add(lb);

                iInitialLocationX += 160;
            }

            iInitialLocationY += 40;
            iInitialLocationX = 17;
        }

        void SetUpPettyCashRows()
        {
            string[] sarrDatabase = { "Item", "DatePetty", "Amount1", "Amount1Location", "Amount2Location", "Reciept", "Notes" };

            iInitialLocationX = 17;

            for (int i = 0; i < 7; i++)
            {
                Label lb = new Label();

                lb.Location = new Point(iInitialLocationX, iInitialLocationY);
                
                lb.Font = new Font("Microsoft Sans Serif", 12);
                lb.Size = new Size(110, 30);

                if (i == 1)
                {
                    string concantanateDate = reader["DateDay"].ToString() + "/" +
                                              SetUpMonthAsNumber() + "/" +
                                              reader["DateYear"].ToString().Substring(2, 2);

                    lb.Text = concantanateDate;
                }
                else if(i == 2)
                {
                    float fAmount = 0.0f;
                    float.TryParse(reader[sarrDatabase[i]].ToString(), out fAmount);

                    lb.Text = "-$" + fAmount.ToString("0.00");
                }
                else if(i == 3)
                {
                    if(reader["Amount1Location"].ToString() == "Till")
                    {
                        float fAmount = 0.0f;
                        float.TryParse(reader["Amount1"].ToString(), out fAmount);

                        lb.Text = "-$" + fAmount.ToString("0.00");
                    }
                }
                else if(i == 4)
                {
                    if (reader["Amount1Location"].ToString() == "Plastic Box")
                    {
                        float fAmount = 0.0f;
                        float.TryParse(reader["Amount1"].ToString(), out fAmount);

                        lb.Text = "-$" + fAmount.ToString("0.00");
                    }
                }
                else
                {
                    lb.Text = reader[sarrDatabase[i]].ToString();
                }
                
                Controls.Add(lb);

                iInitialLocationX += 160;
            }

            iInitialLocationY += 40;
        }

        private void PettyCashManager_Load(object sender, EventArgs e)
        {

        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            DeleteLabels();
            SetUpPettyCashMonth();
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            if(cmb_month.SelectedIndex > 0)
            {
                cmb_month.SelectedIndex -= 1;
            }
        }

        private void bnt_right_Click(object sender, EventArgs e)
        {
            if (cmb_month.SelectedIndex < 11)
            {
                cmb_month.SelectedIndex += 1;
            }
        }

        private void cmb_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!bFirstTimeSkip)
            {
                DeleteLabels();

                SetUpPettyCashMonth();
            }

            bFirstTimeSkip = false;
        }

        string SetUpMonthAsNumber()
        {
            switch (reader["DateMonth"].ToString())
            {
                case "January":
                    return ("1");

                case "February":
                    return ("2");

                case "March":
                    return ("3");

                case "April":
                    return ("4");

                case "May":
                    return ("5");

                case "June":
                    return ("6");

                case "July":
                    return ("7");

                case "August":
                    return ("8");

                case "September":
                    return ("9");

                case "October":
                    return ("10");

                case "November":
                    return ("11");

                case "December":
                    return ("12");

                default:
                    return ("NULL");
            }

            //if(reader["DateMonth"].ToString() == "January")
            //{
            //    return ("0");
            //}
            //else if()
        }

        void DeleteLabels()
        {
            iInitialLocationY = 90;
            iInitialLocationX = 17;

            // Wipes all the labels for refrehsing or setting up new table
            foreach (Label lb in this.Controls.OfType<Label>().ToArray())
            {
                if (lb.Name == "lbl_month" || lb.Name == "label1")
                {
                    // Do Nothing
                }
                else
                {
                    lb.Text = string.Empty;
                    Controls.Remove(lb);
                }
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Form fm = Application.OpenForms["PettyCash"];

            if (fm != null)
            {
                if (fm.WindowState == FormWindowState.Minimized)
                {
                    fm.WindowState = FormWindowState.Normal;
                }

                fm.BringToFront();
            }
            else
            {
                PettyCash pc = new PettyCash();
                pc.Show();
            }
        }
    }
}