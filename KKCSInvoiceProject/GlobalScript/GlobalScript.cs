using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KKCSInvoiceProject
{
    public class MyAppManager
    {
        private static readonly MainMenu _MainMenu = new MainMenu();

        public static MainMenu MainMenuInstance
        {
            get
            {
                return _MainMenu;
            }
        }
    }
}