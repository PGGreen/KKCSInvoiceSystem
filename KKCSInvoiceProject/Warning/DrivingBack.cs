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
        public DrivingBack()
        {
            InitializeComponent();

            lbl_drivingback.Text = DrivingBackText();
        }

        string DrivingBackText()
        {
            string sDrivingBack = @"Kerikeri Airport Car Storage Driving Back/Bus/Non-Flight Procedure

If you are driving back instead of coming on the plane, please note our opening times below.

-Mon - Fri-           -Sat-                    -Sun-
0500 - 0600         0545 - 0645        1230 - 1400
0830 - 1000         0830 - 1000        1600 - 1800
1230 - 1400         1230 - 1400                                 
1600 - 1800         1600 - 1800                                 

2025 (all days except Saturday) - For all of these last flights we are open 5 minutes before 
                                    the plane arrives, only IF we have customers coming in,
                                    otherwise we will be closed.

*Please note these times are subject to change in the event such as plane timetable changes
 or cancellations and any other unforeseen circumstances. 
 If you are not sure please give us a call.

If you are going to be outside these hours, there are a couple of options:

-Pick up your car at a later date (charges may apply for extra days)

-With your permission we can leave your car out in the public car park or Hertz rank
 (or wherever we can find room), and put your keys into our outside safe.
-------------------------------------------------------------------------------------
  a. If you choose this option, the safe is up the ramp by the toilets next to the airport.
  b. To open the safe you press “Start – XXXX – Start” then twist open.
  c. The XXXX is a 4-Digit Code we will provide for you on the day you come back.
  d. You need to call us for the safe code and with your approximate return time 
     on the day as well.
  e. Please lock the safe using the same sequence as in step b, as there may be other 
     keys in with yours as well.
-------------------------------------------------------------------------------------

*Please note:
-The Airport gates are locked at night after the final plane. We DO NOT have any 
 control over this.
-Please DO NOT ask us to leave your car outside the Airport car gates, this is company policy 
 and we will not do this under any circumstances.
-If you do not get hold of us, we can not leave your car out for you.

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

            graphic.DrawString(DrivingBackText(), new Font("Times New Roman", 10), new SolidBrush(Color.Black), startX, startY);
            
        }

        private void btn_printdrivingback_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}
