using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace KKCSInvoiceProject
{
    public partial class NewFlightTimes : Form
    {
        public NewFlightTimes()
        {
            InitializeComponent();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\BOICarStorage\Desktop\KKCS Invoice\Invoice System\Data\Flight Times\FlightTimes.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            lbl_test.Text = "";

            for (int i = 1; i <= rowCount; i++)
            {
                lbl_test.Text += "\r\n";

                for (int j = 1; j <= colCount; j++)
                {

                    //new line
                    if (j == 1)
                        Console.Write("\r\n");
                    //string sTest = xlRange.Cells[i, j].ToString();
                    //string sTest2 = xlRange.Cells[i, j].Value2.ToString();
                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        lbl_test.Text += xlRange.Cells[i, j].Value2.ToString();
                    }

                    //add useful things here!
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}