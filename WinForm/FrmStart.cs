using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmStart : Form
    {
        private bool formOpened = false;
        public FrmStart()
        {
            InitializeComponent();
            tmrTime.Interval = 5000; 
            tmrTime.Start();

        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {

            if (!formOpened)
            {
                FrmListLog listLog = new FrmListLog();
                listLog.Show();
                this.Hide();
                formOpened = true;
            }
        }
    }
}
