using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Test.RaiseOtherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("AccessSecurity");
            if (ListTool.HasElements(p))
            {
                ApplicationAPI.Raise(p[0], true);
            }
        }
    }
}
