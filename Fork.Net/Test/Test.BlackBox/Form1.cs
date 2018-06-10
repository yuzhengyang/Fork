using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.LogUtils.StatusLogUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using Azylee.WinformSkin.FormUI.Toast;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.BlackBox
{
    public partial class Form1 : Form
    {
        Log Log = new Log(true);
        public Form1()
        {
            InitializeComponent();
            Log.SetCacheDays(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var ram = ComputerInfoTool.RAMModel();
        }
        private void BTStartBB_Click(object sender, EventArgs e)
        {
            StatusLog.Instance.SetCacheDays(0);
            bool flag = StatusLog.Instance.Start();
            textBox1.AppendText(Environment.NewLine + (flag ? "启动成功" : "启动失败"));
        }

        private void BTStopBB_Click(object sender, EventArgs e)
        {
            bool flag = StatusLog.Instance.Stop();
            textBox1.AppendText(Environment.NewLine + (flag ? "停止成功" : "停止失败"));
        }

        private void BTWriteLog_Click(object sender, EventArgs e)
        {
            Log.e("yoyoyoyoyo");
            Log.w("yoyoyoyoyo");
            Log.d("yoyoyoyoyo");
            Log.i("yoyoyoyoyo");
            Log.v("yoyoyoyoyo");
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    string ceshi = "cpu占用";
                    ceshi = ceshi + ceshi;
                    int count = ceshi.Length + ceshi.Length;
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToastForm.Display("标题", "内容", ToastForm.ToastType.error, new Action(() =>
            {
                new Form2().Show();
            }), 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToastForm.Display("标题222", "内容222", ToastForm.ToastType.error, null, 10);
        }
    }
}
