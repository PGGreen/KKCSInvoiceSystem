using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace KKCSInvoiceProject
{
    public partial class DrivingBack : Form
    {
        string g_sPrint = "";
        public DrivingBack()
        {
            InitializeComponent();
        }

        public void SetText(string _sPicked)
        {
            switch(_sPicked)
            {
                case "Driving Back":
                    {
                        lbl_drivingback.Text = DrivingBackText();
                        g_sPrint = DrivingBackText();
                        break;
                    }
                case "Unknown":
                    {
                        lbl_drivingback.Text = Unknown();
                        g_sPrint = Unknown();
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

        string DrivingBackText()
        {
            string sDrivingBack = @"Kerikeri Airport Car Storage Driving Back or Bus.

If you are driving back or are on a bus instead of coming on the plane, 
please note our opening times below:

-Mon - Fri-           -Sat-                    -Sun-
0500 - 0600         0545 - 0645         0830 - 1000
0830 - 1000         0830 - 1000         1230 - 1400
1230 - 1400         1230 - 1400         1600 - 1800              
1600 - 1800         1600 - 1800                    
2025 (See Below)    (NO 2025 on Sat)    2025 (See Below)

2025 - For the 2025 flight we are open 5 minutes before the plane
       only IF we have customers coming in, otherwise we will be closed.

*Please note all these times are subject to change in the event such as plane timetable changes
 or cancellations and any other unforeseen circumstances outside our control. 

If you are going to be outside these hours, please let us know, and we can arrange 
something with you.
(It is important you call us, or otherwise you might not be able to get your car out.)

*Please note:
-The Airport gates are locked at night after the final plane. We DO NOT have any control over this.
-Please DO NOT ask us to leave your car outside the Airport car gates, this is company policy 
 and we will not do this under any circumstances.

Phone: 09-401-6351";

            return (sDrivingBack);
        }

        string Unknown()
        {
            string sDrivingBack = @"Kerikeri Airport Car Storage Unknown Return.

If you do not know your return time, please take note of the following information.

Phone: 09-401-6351";

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
            printDocument.PrinterSettings.PrinterName = "Adobe PDF";
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
            int offset = 30;

            graphic.DrawString(g_sPrint, new Font("Times New Roman", 10), new SolidBrush(Color.Black), startX, startY);
            
        }

        private void btn_printdrivingback_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}
