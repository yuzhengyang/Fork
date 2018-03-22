using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.SystemSleep
{
    public partial class Form1 : Form
    {
        int SleepTime = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemSleepAPI.PreventSleep(true);
            label2.Text = "已阻止";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SystemSleepAPI.ResotreSleep();
            label2.Text = "已恢复";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var fmt = DateTimeTool.ToHMS(SleepTime++ * 1000);
            label3.Text = $"计时：{fmt.Item1}:{fmt.Item2}:{fmt.Item3}";
        }
    }
}
