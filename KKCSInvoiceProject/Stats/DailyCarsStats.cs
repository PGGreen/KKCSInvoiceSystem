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

namespace KKCSInvoiceProject
{
    public partial class DailyCarsStats : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        OleDbDataReader reader;

        private OleDbConnection connection = new OleDbConnection();

        public DailyCarsStats()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            Test();
        }

        void Test()
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart1.ChartAreas[0].AxisY.Title = "Money ($)";

            chart1.Series.Add(sSeries("Daily Cars", Color.Red));
            //chart1.Series.Add(sSeries("Cash23", Color.Black));

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            DateTime dtDate = DateTime.Today;
            
            dtDate = new DateTime(2017, 2, dtDate.Day, 12, 0, 0);

            string query = @"select * from CustomerInvoices WHERE year(DTDateIn) = year(@dtDate)
                            AND month(DTDateIn) = month(@dtDate) 
                            ORDER BY DTDateIn ASC";

            command.Parameters.AddWithValue("@dtDate", dtDate);
            command.CommandText = query;

            reader = command.ExecuteReader();

            int iCount = 0;

            // Skips the very first check as there is no time to compare on the first
            bool bSkipFirstCheck = true;

            // Stores the time from the table
            double StoreTime = 0.0f;

            DateTime dt;
            string sDay;

            // Stores time at end to compare and see if a new time has shown
            double StoreTimeSecond = 0.0f;

            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            while (reader.Read())
            {
                // Gets the current time of the record
                //StoreTime = ((DateTime)reader["DTDateIn"]).Day;

                //string sDay = StoreTime.ToString() + ((DateTime)reader["DTDateIn"]).ToString("ddd");

                // Gets the current time of the record
                StoreTime = ((DateTime)reader["DTDateIn"]).Day;

                // Compares the 2 times together to see if they are different or not
                // Skips the first check
                if (StoreTime != StoreTimeSecond && !bSkipFirstCheck)
                {
                    dt = (DateTime)reader["DTDateIn"];
                    dt = dt.AddDays(-1);
                    sDay = (StoreTime - 1.0f).ToString() + " " + dt.ToString("ddd");

                    chart1.Series["Daily Cars"].Points.AddXY(sDay, iCount);

                    iCount = 0;
                }

                // Makes the Second time = the first time for comparision purposes
                StoreTimeSecond = StoreTime;

                //if(!bSkipFirstCheck)
                //{
                    iCount++;
                //}
                
                bSkipFirstCheck = false;

                // Makes the first check to false for using
                //bSkipFirstCheck = false;
                //string Invoice = reader["InvoiceNumber"].ToString();

                //DateTime DTReturn = (DateTime)reader["DTReturnDate"];
                //DateTime DTDateIn = (DateTime)reader["DTDateIn"];

                //int iDate = (((DateTime)reader["DTReturnDate"]) - ((DateTime)reader["DTDateIn"])).Days;

                //chart1.Series["Cash"].Points.AddXY(iTest, iDate);
                //chart1.Series["Cash23"].Points.AddXY(iTest, iDate - 4);
            }

            //dt = (DateTime)reader["DTDateIn"];
            //dt = dt.AddDays(-1);
            //sDay = (StoreTime - 1.0f).ToString() + " " + dt.ToString("ddd");

            //chart1.Series["Daily Cars"].Points.AddXY(sDay, iCount);

            connection.Close();

            //chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            //while (reader.Read())
            //{
            //    SetUpCollumns();

            //    iCount++;
            //}

            //AddingToChart(0);

            //lbl_cash.Text += " $" + iCashTotal;
            //lbl_eftpos.Text += " $" + iEftposTotal;
            //lbl_total.Text += " $" + iTotal;

            //connection.Close();
        }

        /*
        void Test()
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart1.ChartAreas[0].AxisY.Title = "Money ($)";

            chart1.Series.Add(sSeries("Cash", Color.Red));
            chart1.Series.Add(sSeries("Cash23", Color.Black));

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            //command.CommandText = "SELECT * FROM CustomerInvoices ORDER BY ID";

            DateTime dtDate = DateTime.Today;
            ////string query = @"SELECT * FROM Invoice WHERE ReturnMonth = '" + 02 + "' AND ReturnYear = '" + 2017 + "' AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DateInInvisible DESC";
            dtDate = new DateTime(2017, 1, dtDate.Day, 12, 0, 0);

            //string query = "select * from CustomerInvoices WHERE year(DTReturnDate) = year(@dtDate) AND month(DTDatePaid) = month(@dtDate) AND PaidStatus = 'OnAcc' ORDER BY AccountHolder,DTDateIn ASC";
            string query = @"select * from CustomerInvoices WHERE year(DTReturnDate) = year(@dtDate) 
                            AND month(DTDatePaid) = month(@dtDate) 
                            ORDER BY DTDateIn ASC";

            command.Parameters.AddWithValue("@dtDate", dtDate);
            command.CommandText = query;

            reader = command.ExecuteReader();

            int iTest = 0;

            while (reader.Read())
            {
                string Invoice = reader["InvoiceNumber"].ToString();

                DateTime DTReturn = (DateTime)reader["DTReturnDate"];
                DateTime DTDateIn = (DateTime)reader["DTDateIn"];

                int iDate = (((DateTime)reader["DTReturnDate"]) - ((DateTime)reader["DTDateIn"])).Days;

                chart1.Series["Cash"].Points.AddXY(iTest, iDate);
                chart1.Series["Cash23"].Points.AddXY(iTest, iDate - 4);

                iTest++;

                if (iTest > 30)
                {
                    break;
                }
            }

            connection.Close();

            //chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            //while (reader.Read())
            //{
            //    SetUpCollumns();

            //    iCount++;
            //}

            //AddingToChart(0);

            //lbl_cash.Text += " $" + iCashTotal;
            //lbl_eftpos.Text += " $" + iEftposTotal;
            //lbl_total.Text += " $" + iTotal;

            //connection.Close();
        }
        */

        Series sSeries(string _sName, Color cColour)
        {
            Series Series = new Series
            {
                Name = _sName,
                Color = cColour,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            return (Series);
        }
    }
}