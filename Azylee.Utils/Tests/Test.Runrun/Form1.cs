using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.ProcessUtils;
using Azylee.Core.WindowsUtils.AdminUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Runrun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTRun_Click(object sender, EventArgs e)
        {
            List<string> pwdlist = new List<string>();
            pwdlist.Add("123456");
            pwdlist.Add("yuzhengyang");

            MessageBox.Show($"确认管理员密码为：{ AdminTool.CheckPasswords(pwdlist)}");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
