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
    public partial class Changelog : Form
    {
        public Changelog()
        {
            InitializeComponent();

            lbl_changelog.Text = btn_build_Click();
        }

        private string btn_build_Click()
        {
            string sChangeLog = @"

v3.02 (05/09/2017)
- 

v3.00 (18/08/2017)
- Added 'Number of Days Stay'
- Added staff names to 'Alerts' and 'Invoice'
- Rearranged look of 'Main Menu'

v2.50 (19/06/2017)
- Added 'Search By Name' system
- Lots of small changes and fixes

v2.00 (16/12/2016)
- Main Menu Now has more info about the days car returns
- Main Menu Colour change to more yellow background
- Main Menu Button locations changed
- Added new Price Change Calculator

v1.57 (16/10/2016)
- Added the new flight times to the returns

v1.56 (13/10/16)
- Fixed 'Long Term' bug where it wasn't saving the date in or out correctly

v1.55 (30/09/16)
- Hopefully have the fixed the 'unupdatable bug'

v1.54 (28/09/16)
- Attempting to fix problems causing unclosed connections

v1.53 (27/09/16)
- Changing 'Stats' to track money more easily

v1.52 (26/09/16)
- Fixing some bugs that was causing the 'date paid' to not display correctly

v1.51 (21/09/2016)
- Fixed a bug causing 'Update' to add multiple/duplicate invoices

v1.50 (19/09/2016)
- Added a lot more filters to 'Statistics'
- Added the new Notes/Bookings page
- Fixed bug with returns where credit card was adding an extra '.00' to the end of the price
- The invoice in the 'Car Returns' is now the same as the main invoice
- Added a new 'Update' button to the invoice after it is saved

v1.44 (09/09/16)
- Added 'Credit Card' to the 'Filters' in 'Car Returns'
- Credit Cards is now selectable under the 'Paid Status'
- The 'Credit Card' button adds a 2% surcharge

v1.43 (31/08/16)
- Added an enabled button to 'Filters'

v1.42 (30/08/16)
- Added new filters to the 'Car Returns'
- Changed the save button in Banking to only work once at a time

v1.41 (28/08/16)
- A few bug fixes for 'Long Term Section'

v1.40 (25/08/16)
- Added the new 'Long Term Section'
- Added a new 'Statistics' button

v1.35 (12/08/16)
- Changed the colour in the invoice to show between saved and unsaved

v1.34 (22/07/16)
- Fixed the printing bug, so it can be printed at the start of each day

v1.33 (13/07/16)
- Accounts should now be working correctly on an invoice
- Fixed bug where the cash was displaying datein insead of datepaid

v1.32 (06/07/16)
- The 'Flight Times' now change based upon what day of the week is selected
- New warning screen will pop up when 'No Key' is selected

v1.31 (01/07/16)
- Created the new 'Customers' Section

v1.30 (27/06/16)
- In 'Car Returns' the 'Key Number' will change to 'P/UP' when the car is picked up
- Added new 'Key Box' buttons to the 'Invoice' and 'Car Returns'
- The 'Invoice Number' will now pick the next next free number in line
- The 'Key Number' now has more error checks in it to make sure no numbers are duplicated
- Have added a new 'Key Number' select if the key slot is already occupied
- If a customer is down under 'Unknown Date/Time' it will now populate the return date automatically
- If you don't pick a 'Return Date' or 'Return Time' in the 'Invoice' a warning will now come up

v1.28 (21/06/16)
- If an Invoice is 'Unknown' it will now automatically put the return date and time in

v1.27 (19/06/16)
- Buttons for navigating around the program now are working correctly

v1.26 (18/06/16)
- Fixed minor bug with 'Banking' which was causing it not to save
- Changed $0.00 'To Pay' invoices to say 'Calculate'

v1.25 (17/06/16)
- Added new 'Date Paid' label
- The 'Money In Yard' will now track the date the customer paid
- Added arrows in 'Money In Yard' for easier navigation

v1.22 (16/06/16)
- Printing out the car returns now has multiple pages and colour

v1.21 (14/06/16)
- Changed the receipt printing 'Total Paid' to just 'Paid'
- You can no longer print a receipt without first entering a car rego, price and paid status

v1.20 (13/06/16)
- You can now switch between 'Paid Status' easily within the 'Car Returns' invoice
- Changed the program so only one instance can be open at one time
- Time now updates to current time when entering a rego into the combo box
- Created a new Changelog page

v1.17 (09/06/16)
- Fixed critical error with 'Money In Yard' showing cash from return date 
  instead of the correct date in
- Fixed the same critical error in the 'End Of Day' section
- Added button to print out the current days car returns
- There is no longer a comfirmation window for printing
- Changed the 'No' button colour to a bit less jarring
- Cleaned up the 'Car Returns' printing

v1.16 (06/06/16)
- The 'Unknown - Time'  check box no longer shows both return times when 
  unticking it
- Update is now working correctly
- You can no longer close the program with the 'X' button in the 'Main Menu'
- New 'Exit' button added in 'Main Menu'
- Updating will now update the car rego as well
- When you close an invoice within 'CarReturns' page will now auto-refresh
- Print Function now include in the invoice within 'CarReturns'

v1.15 (28/05/16)
- You can now switch between 'Paid Status' easily
- The 'Clear All' button no longer brings both return times back
- Lots of minor bug fixes

v1.10 (20/05/16)
- Major Update
- The 'Refund' Section has been moved from 'Main Menu' to individual receipts
- The release button in 'Key Box' is now working
- Cleaned up the 'Money In Yard' Section
- Return Time now shows flight times in 'Invoice'
- Split Payment now working correctly
- Added new print feature for receipts
- New warnings within 'Invoice' when certain conditions happen
- Added 'Return Date' and 'Date Car Brought In' option to 'Car Returns'
- The 'Inv No' and 'To Pay' buttons are now functional within 'Car Returns'
- End of Day section is now fully functioning

v1.08 (12/05/16)
- The 'End of Day' section has now been implimented
- Added 'Date In' option to the Car Returns section

v1.07 (09/05/16)
- The 'Refund' and 'Petty Cash' sections now working correctly
- The 'Money In Yard' section now displays refunds and petty cash uses 

v1.06 (08/05/16)
- Changed 'Price' button to 'Calculate Price'
- You can no long calculate a price if 'Unknown Date' or 'Unknown Time' is picked

v1.05 (07/05/16)
- Fixed bug where car return times were displaying in random order 
  (instead of by return time)

v1.04 (03/05/16)
- Fixed critical bug that was causing new customers to not be saved into the database

v1.03 (29/04/16)
- Added the 'Petty Cash' and 'Refund Section'
- General bug fixes

v1.02 (26/04/16)
- Added a split pay system
- Moved and changed some controls around for better clarity
- Added new buttons into forms for easier navigation
- Added 'No Key' and 'No Charge' buttons

v1.01 (23/04/16)
- Changed labels to a lighter pink colour
- Made 'Return Date' and 'Return Time' bigger
- Updated the 'Main Menu' with new sections and colour

v1.00 (17/04/16)
- Initial release version of the invoice system";

            return (sChangeLog);
        }
    }
}