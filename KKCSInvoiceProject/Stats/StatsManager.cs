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
    public partial class StatsManager : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        private OleDbConnection connection = new OleDbConnection();

        OleDbDataReader reader;

        int iSeriesCount = 0;

        int iCount = 0;

        int iCashDaily = 0;
        int iEftposDaily = 0;
        float fCreditEftposDaily = 0.0f;

        int iCashTotal = 0;
        int iEftposTotal = 0;
        float fCreditEftposTotal = 0.0f;
        int iTotal = 0;

        int iDayOld = 0;

        public enum eMonth
        {
            NULL = -1,

            JANUARY = 1,
            FEBRUARY = 2,
            MARCH = 3,
            APRIL = 4,
            MAY = 5,
            JUNE = 6,
            JULY = 7,
            AUGUST = 8,
            SEPTEMBER = 9,
            OCTOBER = 10,
            NOVEMBER = 11,
            DECEMBER = 12,

            MAX_MONTH
        };

        public StatsManager()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;

            cmb_month.SelectedIndex = 7;
        }

        void ResetTable()
        {
            bool bDelete = false;

            while (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
                bDelete = true;
            }

            if (bDelete)
            {
                chart1.Series.Dispose();

                iDayOld = 0;
                iDay = 0;

                bFirstTime = false;

                bDelete = false;
            }

            iCashTotal = 0;
            iEftposTotal = 0;
            fCreditEftposTotal = 0.0f;
            iTotal = 0;

            lbl_cash.Text = "Cash Total:";
            lbl_eftpos.Text = "Eftpos Total:";
            lbl_total.Text = "Total:";
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            ResetTable();

            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            command.CommandText = sQuery();

            reader = command.ExecuteReader();

            chart1.ChartAreas[0].AxisX.Title = cmb_month.Text;
            chart1.ChartAreas[0].AxisY.Title = "Money ($)";

            CreateGraphSeries();

            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            while (reader.Read())
            {
                SetUpCollumns();

                iCount++;
            }

            AddingToChart(0);

            lbl_cash.Text += " $" + iCashTotal;
            lbl_eftpos.Text += " $" + iEftposTotal;
            lbl_total.Text += " $" + iTotal;

            connection.Close();
        }

        private void btn_savechart_Click(object sender, EventArgs e)
        {
            Form frm = Form.ActiveForm;
            Bitmap bmp = new Bitmap(frm.Width, frm.Height);
            frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
            }
        }

        List<int> list = new List<int>();

        int iDay = 0;

        bool bFirstTime = false;

        void SetUpCollumns()
        {
            iDay = int.Parse(reader["DPReturnDay"].ToString());

            if(!bFirstTime)
            {
                iDayOld = iDay;

                bFirstTime = true;
            }

            if (iDayOld != iDay && iCount > 0)
            {
                AddingToChart(1);

                iDayOld = iDay;
            }

            if (filter_cash.Checked)
            {
                if (reader["PaidStatus"].ToString() == "Cash")
                {
                    int o = 0;
                    Int32.TryParse(reader["TotalPay"].ToString(), out o);

                    iCashDaily += o;

                    iCashTotal += o;
                    iTotal += o;
                }
            }

            if (filter_eftpos.Checked)
            {
                if (reader["PaidStatus"].ToString() == "Eftpos")
                {
                    int o = 0;
                    Int32.TryParse(reader["TotalPay"].ToString(), out o);

                    iEftposDaily += o;

                    iEftposTotal += o;
                    iTotal += o;
                }
            }

            if (filter_crediteftpos.Checked)
            {
                if (reader["PaidStatus"].ToString() == "Eftpos" || reader["PaidStatus"].ToString() == "Credit Card")
                {
                    float o = 0.0f;
                    float.TryParse(reader["TotalPay"].ToString(), out o);
                    //Math.Round(o,2);

                    fCreditEftposDaily += o;

                    fCreditEftposTotal += o;

                    //iTotal += o;
                }
            }
        }

        void AddingToChart(int _iNumber)
        {
            if (filter_cash.Checked)
            {
                list.Add(iCashDaily);
                chart1.Series["Cash"].Points.AddXY(sDayOfWeek(iDay - _iNumber), iCashDaily);

                iCashDaily = 0;
            }

            if (filter_eftpos.Checked)
            {
                list.Add(iEftposDaily);
                chart1.Series["Eftpos"].Points.AddXY(sDayOfWeek(iDay - _iNumber), iEftposDaily);

                iEftposDaily = 0;
            }

            if (filter_crediteftpos.Checked)
            {
                Math.Round(fCreditEftposDaily, 2);
                list.Add(iEftposDaily);
                chart1.Series["Credit + Eftpos"].Points.AddXY(sDayOfWeek(iDay - _iNumber), fCreditEftposDaily);

                fCreditEftposDaily = 0.0f;
            }
        }

        string sDayOfWeek(int _iDay)
        {
            int iYear = 0;
            Int32.TryParse(lbl_year.Text, out iYear);

            int iMonth = (int)Enum.Parse(typeof(eMonth), cmb_month.Text.ToString());

            DateTime dt = new DateTime(iYear, iMonth, _iDay);
            string sDayOfWeek = _iDay.ToString() + "(" + dt.ToString("ddd") + ")";

            return (sDayOfWeek);
        }

        void CreateGraphSeries()
        {
            if(filter_cash.Checked)
            {
                chart1.Series.Add(sSeries("Cash", Color.Red));

                iSeriesCount++;
            }

            if(filter_eftpos.Checked)
            {
                chart1.Series.Add(sSeries("Eftpos", Color.Green));

                iSeriesCount++;
            }

            if (filter_crediteftpos.Checked)
            {
                chart1.Series.Add(sSeries("Credit + Eftpos", Color.Purple));

                iSeriesCount++;
            }

            if (filter_total.Checked)
            {
                chart1.Series.Add(sSeries("Total", Color.Blue));

                iSeriesCount++;
            }
        }

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

        string sQuery()
        {
            string query = "";

            if (chk_monthly.Checked)
            {
                int iMonth = (int)Enum.Parse(typeof(eMonth), cmb_month.Text.ToString());

                query = "select * from Invoice WHERE DPReturnMonth = '" + iMonth + "' ORDER BY DPInvisible ASC";
            }

            return (query);
        }
    }
}