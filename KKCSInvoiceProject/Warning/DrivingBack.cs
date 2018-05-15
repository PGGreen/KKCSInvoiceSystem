﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Configuration;

namespace KKCSInvoiceProject
{
    public partial class DrivingBack : Form
    {
        string m_strDataBaseFilePath = ConfigurationManager.ConnectionStrings["DatabaseFilePath"].ConnectionString;

        //OleDbDataReader reader;

        //OleDbCommand command;

        private OleDbConnection connection = new OleDbConnection();

        string g_sPrint = "";

        //bool g_bProcedure = false;
        //bool g_bStaffMember = false;

        bool g_bClosedWithSaved = false;

        int g_iInvoiceNumber = 0;

        public DrivingBack()
        {
            InitializeComponent();

            connection.ConnectionString = m_strDataBaseFilePath;
        }

        public void SetText(string _sPicked, int _iInvoiceNumber)
        {
            g_iInvoiceNumber = _iInvoiceNumber;

            switch (_sPicked)
            {
                case "Unknown":
                    {
                        lbl_drivingback.Text = UnknownDateTime();
                        g_sPrint = UnknownDateTime();
                        break;
                    }
                case "Driving Back":
                    {
                        lbl_drivingback.Text = DrivingBackOrBus();
                        g_sPrint = DrivingBackOrBus();
                        break;
                    }
                case "Last Flight":
                    {
                        lbl_drivingback.Text = LastFlight();
                        g_sPrint = LastFlight();
                        break;
                    }
                default:
                    {
                        lbl_drivingback.Text = "Error";
                        g_sPrint = "Error";
                        break;
                    }
            }
        }

        string UnknownDateTime()
        {
            
            string sDrivingBack = @"Kerikeri Airport Car Storage - Unknown Date & Time of Return.

If you do not know your return time, please take note of the following information.

We are open one hour before each incoming flight, and we close after the flight has 
left Kerikeri. You will need to pick up your car within our opening hours.

Please make sure to check all incoming flight times prior to arriving as sometimes
there are delays.

If you are going to be outside these hours, you will need to either pick up the car on
the next flight or on the next day.

For the final plane (normally 2025) we are open 5 minutes before the plane arrives and
only IF we have customers coming in, otherwise we will be closed.

If you have any queries or contact us, please give us a call on:
Phone: 09-401-6351

Thank You,
Kerikeri Airport Car Storage Staff";

            return (sDrivingBack);
        }

        string DrivingBackOrBus()
        {
            string sDrivingBack = @"Kerikeri Airport Car Storage - Driving Back or Bus.

If you are driving up by road (NOT on the plane), or you are coming up on a bus that HAS NOT been 
arranged through Air NZ because of a cancelled flight, please take note of the following information.

We are open one hour before each incoming flight, and we close after the flight has left Kerikeri. 
You will need to pick up your car within our opening ours.

Please make sure to check all incoming flight times prior to arriving as sometimes there are delays.

If you are going to be outside these hours, you will need to either pick up the car on the next flight
or on the next day.

For the final plane (normally 2025) we are open 5 minutes before the plane arrives and
only IF we have customers coming in, otherwise we will be closed.

If you have any queries, please give us a call on:
Phone: 09-401-6351

Thank You,
Kerikeri Airport Car Storage Staff";

            return (sDrivingBack);
        }

        string LastFlight()
        {
            string sDrivingBack = @"Kerikeri Airport Car Storage Last Flight.

If you are on the last flight for the day, please take note of the following information.

Phone: 09-401-6351";

            return (sDrivingBack);
        }

        void Print()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            PaperSize oPS = new PaperSize();
            oPS.RawKind = (int)PaperKind.A5;

            PaperSource oPSource = new PaperSource();
            oPSource.RawKind = (int)PaperSourceKind.Lower;

            printDocument.PrinterSettings = new PrinterSettings();
            printDocument.PrinterSettings.PrinterName = "Lexmark MX510 Series XL";
            //printDocument.PrinterSettings.PrinterName = "Adobe PDF";
            //printDocument.PrinterSettings.PrinterName = "CutePDF Writer";
            printDocument.DefaultPageSettings.PaperSize = oPS;
            printDocument.DefaultPageSettings.PaperSource = oPSource;

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

            printDocument.Print();

            printDocument.Dispose();
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            //int offset = 30;

            graphic.DrawString(g_sPrint, new Font("Times New Roman", 10), new SolidBrush(Color.Black), startX, startY);
            
        }

        private void btn_printdrivingback_Click(object sender, EventArgs e)
        {
            Print();
        }

        public bool GetClosedWithSaved()
        {
            return (g_bClosedWithSaved);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}