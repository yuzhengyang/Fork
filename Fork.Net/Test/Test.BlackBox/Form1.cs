using Azylee.BlackBox.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.BlackBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTStartBB_Click(object sender, EventArgs e)
        {
            bool flag = BlackBoxTool.Instance.Start();
            textBox1.AppendText(Environment.NewLine + (flag ? "启动成功" : "启动失败"));
        }

        private void BTStopBB_Click(object sender, EventArgs e)
        {
            bool flag = BlackBoxTool.Instance.Stop();
            textBox1.AppendText(Environment.NewLine + (flag ? "停止成功" : "停止失败"));
        }
    }
}
