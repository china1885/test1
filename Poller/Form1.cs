using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZtpBoss.BLL;

namespace Poller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timerAccessToken_Tick(object sender, EventArgs e)
        {
            ZtpBoss.BLL.AccessToken.UpdateAccessToken();
        }
    }
}
