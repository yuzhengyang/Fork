using Azylee.Core.NetUtils;
using Azylee.Core.WindowsUtils.AdminUtils;
using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.WinformSkin.FormUI.Toast;
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
            var result = PingTool.Internet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = CMDServiceTool.Install(
                 "AccessSecurity.Service",
                 @"F:\AccessSecurity.Service\AccessSecurity.Service.exe",
                 new WindowsAccountModel("", "administrator", "yzy"));

            if (result) ToastForm.Display("安装服务", "成功");
            else ToastForm.Display("安装服务", "失败", ToastForm.ToastType.error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = CMDServiceTool.Uninstall("AccessSecurity.Service",
                new WindowsAccountModel("", "administrator", "yzy"));

            if (result) ToastForm.Display("卸载服务", "成功");
            else ToastForm.Display("卸载服务", "失败", ToastForm.ToastType.error);
        }
    }
}
