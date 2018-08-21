using Azylee.WinformSkin.FormUI.Toast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Azylee.WinformSkin.FormUI.Toast.ToastForm;

namespace Test.Toast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToastForm.Display("中车四方终端准入系统提示", "系统自动检测发现故障，由于准入系统认证组件工作异常，导致无法正常访问网络，需要进行尝试修复，请点击此提示系统自动修复，修复成功后请尝试登录。", ToastType.info, null, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToastForm.Display("中车四方终端准入系统提示", "一二三四五六七八九十一二三四五六七八", ToastType.info, null, 10);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToastForm.Display("中车四方终端准入系统提示", "一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五", ToastType.info, null, 10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToastForm.Display("中车四方终端准入系统提示", "一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六", ToastType.info, null, 10);
        }

        string str = "六";
        private void button5_Click(object sender, EventArgs e)
        {
            str = "一二三四五六七八九十";
            str = str + str + str + str + str + str + str + str + str + str + str
                 + str + str + str + str + str + str + str + str + str + str
                 + str + str + str + str + str + str + str + str + str + str;
            ToastForm.Display("中车四方终端准入系统提示", str, ToastType.info, null, 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ToolTipIcon icon = ToolTipIcon.Info;
            icon = ToolTipIcon.Error;
            notifyIcon1.ShowBalloonTip(5, "123wrefdasdfgf", str, icon);
        }
    }
}
