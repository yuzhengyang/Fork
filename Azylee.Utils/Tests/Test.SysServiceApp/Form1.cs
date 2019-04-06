using Azylee.Core.WindowsUtils.AdminUtils;
using Azylee.Core.WindowsUtils.CMDUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.SysServiceApp
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
            var result = CMDServiceTool.Install(
                 "AccessSecurityService",
                 @"F:\InstallServer\AccessSecurity.Service.exe",
                 new WindowsAccountModel("", "administrator", "yzy123"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = CMDServiceTool.Uninstall("AccessSecurityService",
                new WindowsAccountModel("", "administrator", "yzy123"));
        }
    }
}
