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
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Drawing.Printing;
using System.Xml;

namespace KKCSInvoiceProject
{
    public partial class Testing : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        OleDbCommand command;

        private OleDbConnection connection = new OleDbConnection();

        public Testing()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            lbl_testing.Text = "";

            //Test();

            //XMLTest();

            GetRegoFromInvoice();
        }

        void Test()
        {
            connection.Open();

            DateTime dtTodaysDate = new DateTime(2017, 10, 7, 12, 0, 0);

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "SELECT * FROM CustomerInvoices WHERE year(DTDatePaid) = year(@dtTodaysDate) AND month(DTDatePaid) >= month(@dtTodaysDate) AND PaidStatus = 'Cash' ORDER BY DTDatePaid";
            command.Parameters.AddWithValue("@dtTodaysDate", dtTodaysDate);

            command.CommandText = query;

            reader = command.ExecuteReader();

            int iTotalPrice = 0;

            while (reader.Read())
            {
                DateTime dtDate = (DateTime)reader["DTDatePaid"];

                if (dtDate.Month == 11 && dtDate.Day > 17)
                {
                    break;
                }

                if (dtDate.Month == 10 && dtDate.Day >= 6)
                {
                    int iPrice = 0;
                    int.TryParse(reader["TotalPay"].ToString(), out iPrice);

                    iTotalPrice += iPrice;
                }


            }

            lbl_testing.Text = iTotalPrice.ToString();
        }

        void XMLTest()
        {
            XmlReader xmlReader = XmlReader.Create("Data/XML/Test.xml");

            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) )//&& (xmlReader.Name == "Cube"))
                {
                    if (xmlReader.HasAttributes)
                        //Console.WriteLine(xmlReader.GetAttribute("currency") + ": " + xmlReader.GetAttribute("rate"));
                    lbl_testing.Text += xmlReader.Name + " " + xmlReader.GetAttribute("currency") + ": " + xmlReader.GetAttribute("rate") + "\r\n";
                }
            }
            //Console.ReadKey();
        }

        void GetRegoFromInvoice()
        {
            int[] Yes = {
4289,
5875,
5976,
6018,
6034,
6050,
6076,
6089,
6111,
6117,
6129,
6173,
6181,
6188,
6200,
6206,
6218,
6220,
6238,
6262,
6273,
6273,
6293,
6317,
6326,
6360,
6386,
6425,
6452,
6501,
6504,
6505,
6513,
6519,
6528,
6530,
6530,
6541,
6546,
6568,
6573,
6574,
6575,
6593,
6605,
6607,
6611,
6620,
6639,
6690,
6701,
6705,
6709,
6712,
6712,
6720,
6721,
6733,
6736,
6740,
6759,
6766,
6768,
6773,
6773,
6777,
6793,
6809,
6815,
6824,
6827,
6835,
6866,
6874,
6894,
6905,
6916,
6924,
6925,
6930,
6931,
6937,
6969,
6970,
6970,
6972,
6980,
6981,
6993,
6994,
7024,
7042,
7051,
7058,
7077,
7098,
7107,
7115,
7129,
7130,
7134,
7137,
7153,
7161,
7179,
7196,
7204,
7229,
7233,
7246,
7253,
7254,
7283,
7314,
7315,
7319,
7353,
7364,
7388,
7396,
7398,
7415,
7428,
7443,
7452,
7455,
7466,
7483,
7528,
7620,
7637,
7649,
7659,
7678,
7688,
7690,
7695,
7698,
7699,
7777,
7779,
7795,
7801,
7803,
7810,
7826,
7829,
7830,
7832,
7839,
7848,
7870,
7871,
7940,
7952,
7953,
7956,
7957,
7972,
7985,
7991,
8003,
8004,
8033,
8033,
8036,
8075,
8077,
8078,
8079,
8097,
8102

                 };

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string sString = "";
            int iCount = 0;

            for (int i = 0; i < Yes.Length; i++)
            {
                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                string query = "select Rego from CustomerInvoices WHERE InvoiceNumber = "+ Yes[i] + "";

                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();

                //iCount = 0;

                while (reader.Read())
                {
                    iCount++;

                    sString += reader["Rego"].ToString() + "\r\n";
                }

            }

            txt_test.Text = sString;

          

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #region Accounts

        int iLocationY = 0;
        int iItemsPerPage = 0;
        
        int iListCount = 0;
         
        int iPageNumber = 1;

        Brush blackBrush = new SolidBrush(Color.Black);
        //PointF pf = new PointF(_Label.Bounds.Location.X, _pReturns.Bounds.Location.Y + iLocationY);
        PointF pf = new PointF(0, 0);

        List<string> lstAccounts = new List<string>();

        public void PrintReturns()
        {
            iItemsPerPage = 0;

            iListCount = 0;

            iPageNumber = 1;

            GetAccountInfo();

            PrintDocument PrintDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            PrintDocument.DefaultPageSettings.PaperSize = ps;

            PrintDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            //PrintDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            PrintDocument.OriginAtMargins = false;
            PrintDocument.DefaultPageSettings.Landscape = false;
            PrintDocument.PrintPage += new PrintPageEventHandler(doc_PrintReturnsPage);

            PrintDocument.Print();

            //pnl_printtitles.Visible = false;
        }

        private void doc_PrintReturnsPage(object sender, PrintPageEventArgs e)
        {
            Font f = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            while (iListCount < lstAccounts.Count)
            {
                pf = new PointF(0, 0 + iLocationY);
                e.Graphics.DrawString((iListCount+1).ToString() + ". " + lstAccounts[iListCount], f, blackBrush, pf);
                
                iLocationY += 20;

                iListCount++;

                if (iItemsPerPage < 56)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    iItemsPerPage = 0;
                    e.HasMorePages = true;

                    iLocationY = 0;

                    return;
                }
            }

            int i = 0;
        }

        void GetAccountInfo()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            string query = "SELECT * FROM Accounts ORDER BY Account";


            command.CommandText = query;

            reader = command.ExecuteReader();

            while(reader.Read())
            {
                string sTemp = reader["Account"].ToString() + "       "+ reader["Rego"] + "       " + reader["ClientName"].ToString();

                lstAccounts.Add(sTemp);
            }

            connection.Close();
        }

        #endregion Accounts

        #region Cash

        List<string> lstCash = new List<string>();

        public void PrintCash()
        {
            iItemsPerPage = 0;

            iListCount = 0;

            iPageNumber = 1;

            GetCashInfo();

            PrintDocument PrintDocument = new PrintDocument();

            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;

            PrintDocument.DefaultPageSettings.PaperSize = ps;

            PrintDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            //PrintDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //PrintDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            PrintDocument.OriginAtMargins = false;
            PrintDocument.DefaultPageSettings.Landscape = false;
            PrintDocument.PrintPage += new PrintPageEventHandler(doc_PrintCashPages);

            PrintDocument.Print();

            //pnl_printtitles.Visible = false;
        }

        private void doc_PrintCashPages(object sender, PrintPageEventArgs e)
        {
            Font f = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            while (iListCount < lstCash.Count)
            {
                pf = new PointF(0, 0 + iLocationY);
                e.Graphics.DrawString((iListCount + 1).ToString() + ". " + lstCash[iListCount], f, blackBrush, pf);

                iLocationY += 20;

                iListCount++;

                if (iItemsPerPage < 56)
                {
                    iItemsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    iItemsPerPage = 0;
                    e.HasMorePages = true;

                    iLocationY = 0;

                    return;
                }
            }

            int i = 0;
        }

        void GetCashInfo()
        {
            connection.Open();

            command = new OleDbCommand();

            command.Connection = connection;

            DateTime dt2018 = new DateTime(2018, 01, 01, 12, 0, 0);

            string query = "SELECT * FROM CustomerInvoices WHERE PaidStatus = 'Cash' AND year(DTDatePaid) = year(dt2018) ORDER BY DTDatePaid";
            command.Parameters.AddWithValue("@dt2018", dt2018);

            command.CommandText = query;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                float fPrice = 0.0f;
                float.TryParse(reader["TotalPay"].ToString(), out fPrice);

                string sTemp = reader["DTDatePaid"].ToString() + " - $" + fPrice.ToString("0.00");

                lstCash.Add(sTemp);
            }

            connection.Close();
        }

        #endregion Cash

        private void button1_Click(object sender, EventArgs e)
        {
            PrintReturns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintCash();
        }
    }
}
