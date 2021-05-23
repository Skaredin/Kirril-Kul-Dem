using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eyyafyadlayokyudl.Forms
{
    public partial class MenuFrm : TempFrm
    {
        public MenuFrm()
        {
            InitializeComponent();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Frm = new CustFrm();
            Frm.Show();
          
        }

        private void MenuFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }       
    }
}
