using System;
using System.Windows.Forms;

namespace Y.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //flexiblePanel1.InitMouseAndContolStyle();
            //embedPanel1.Start(@"D:\Soft\DisplayX.1034260498.exe");
            embedPanel1.Start(@"D:\CoCo\GitHub\Temp\ClipboardMonitor\ClipboardMonitor\ClipboardMonitor\bin\Debug\ClipboardMonitor.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1 焦点问题，焦点导致内外两个窗口标题栏颜色不一致；
            //2 有些应用嵌入不了，会直接被单独打开；
            //3 有些应用嵌入不正常，位置与预计的不同；
            //4 有些应用嵌入关闭时会在后台继续运行；
            //5 调试期间 vs 不能强行退出 否则嵌入的程序不会退出；

            //embedPanel1.ReEmbed();
            //embedPanel1.Start(@"D:\CoCo\GitHub\Temp\ClipboardMonitor\ClipboardMonitor\ClipboardMonitor\bin\Debug\ClipboardMonitor.exe");
            embedPanel1.Start(@"D:\Soft\DisplayX.1034260498.exe");
        }
    }
}
