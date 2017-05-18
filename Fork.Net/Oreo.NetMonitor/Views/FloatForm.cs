using Oreo.NetMonitor.Commons;
using Oreo.NetMonitor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.UnitConvertUtils;

namespace Oreo.NetMonitor.Views
{
    public partial class FloatForm : Form
    {
        NetDetailForm monitor;
        NetReportForm report;
        public FloatForm()
        {
            InitializeComponent();
        }

        private void FloatForm_Load(object sender, EventArgs e)
        {
            #region 窗口设置
            this.ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            BackgroundImageLayout = ImageLayout.None;
            Color c = Color.Green;
            TransparencyKey = c;
            Width = 140;
            Height = 60;

            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Left = iActulaWidth - this.Width - 50;
            this.Top = iActulaHeight - this.Height - 100;
            #endregion
            try
            {
                CpuLoad();
                NetFlow();
                ProConn();
                UI();
            }
            catch { }
        }
        #region 菜单功能
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("技术支持：诺亚信息", "帮助");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (monitor == null || monitor.IsDisposed)
            {
                monitor = new NetDetailForm();
                monitor.Show();
            }
        }
        #endregion
        #region 开启检测
        private void CpuLoad()
        {
            R.Log.v("CpuLoad 1");
            if (NetWorkService.CpuLoadLoop)
            {
                R.Log.v("CpuLoad 2");
                NetWorkService.CpuLoadLoop = false;

            }
            else
            {
                R.Log.v("CpuLoad 3");
                NetWorkService.CpuLoadLoop = true;
                NetWorkService.StartCpuLoad();
            }
        }
        private void NetFlow()
        {
            if (NetWorkService.NetFlowLoop)
            {
                NetWorkService.NetFlowLoop = false;
            }
            else
            {
                NetWorkService.NetFlowLoop = true;
                NetWorkService.StartNetFlow();
            }
        }
        private void ProConn()
        {
            if (NetWorkService.ProConnLoop)
            {
                NetWorkService.ProConnLoop = false;
            }
            else
            {
                NetWorkService.ProConnLoop = true;
                NetWorkService.StartConnectCheck();
            }
        }
        #endregion
        #region 刷新界面
        private void UI()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (!this.IsDisposed)
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (!this.IsDisposed)
                            {
                                label1.Text = ByteConvertTool.Fmt(NetWorkService.NowSent) + "/s";
                                label2.Text = ByteConvertTool.Fmt(NetWorkService.NowReceived) + "/s";
                                label6.Text = Math.Floor(NetWorkService.CpuLoad) + "%";
                                //流量超出报警
                                if ((NetWorkService.UnitSent + NetWorkService.UnitReceived) > NetWorkService.FlowThreshold)
                                {
                                    if (report == null || report.IsDisposed)
                                    {
                                        report = new NetReportForm();
                                        report.Show();
                                    }
                                }
                            }
                        }));
                        Thread.Sleep(1000);
                    }
                }
                catch
                { }
            });
        }
        #endregion
        #region 窗体拖动及右键菜单
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        private void FloatForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FloatForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void FloatForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, e.Location);
            }
        }
        #endregion

        private void label5_Click(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(() =>
            //{
            //    bool send_res = Tools.SendServerMsg("37", "37");
            //});
        }

    }
}
