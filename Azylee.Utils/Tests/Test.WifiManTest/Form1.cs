using Azylee.Core.NetUtils.WifiManUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.WifiManTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WlanTool wlan = new WlanTool();
            var isconn = wlan.IsConnect("lala");
            var result = wlan.Connect("lala", "12345678a");
            //var result = wlan.Connect("pppppp", "123123123");
        }
    }
}
