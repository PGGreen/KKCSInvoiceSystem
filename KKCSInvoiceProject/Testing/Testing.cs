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

            XMLTest();
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
