using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KKCSInvoiceProject
{
    public partial class WarningSystem : Form
    {
        bool m_bIsYesNo = false;

        public WarningSystem(string _sWarning, bool _bIsYesNo)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(600, 300);

            m_bIsYesNo = _bIsYesNo;

            lbl_warning.Text = _sWarning;

            if(m_bIsYesNo)
            {
                btn_one.Text = "YES";
                btn_one.BackColor = Color.LightGreen;
                btn_one.Visible = true;
                btn_one.DialogResult = DialogResult.OK;

                btn_two.Text = "NO";
                btn_two.BackColor = Color.Red;
                btn_two.ForeColor = Color.White;
                btn_two.Visible = true;
                btn_two.DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_two_Click(object sender, EventArgs e)
        {
            if (!m_bIsYesNo)
            {
                Close();
            }
        }
    }
}