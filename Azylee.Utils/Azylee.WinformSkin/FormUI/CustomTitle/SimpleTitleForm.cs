using Azylee.WinformSkin.APIUtils;
using Azylee.WinformSkin.FormUI.NoTitle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azylee.WinformSkin.FormUI.CustomTitle
{
    public partial class SimpleTitleForm : NoTitleForm
    {
        private int HeadHeight = 52;
        public SimpleTitleForm()
        {
            InitializeComponent();
        }
        private void SimpleTitleForm_Load(object sender, EventArgs e)
        {
            HeadHeight = PNHead.Height;
            PBHeadIcon.Image = Icon.ToBitmap();
        }
        #region 窗口设置
        public void SetIcon()
        {
        }
        #endregion
        #region 窗口操作：拖动、边框、最小化、最大化、还原、双击标题栏最大化、拖动标题栏还原、关闭
        /// <summary>
        /// 拖动窗口移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBHeadTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormStyleAPI.ReleaseCapture();
                FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
            }
        }
        /// <summary>
        /// 大小改变，刷新边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DarkTitleForm_SizeChanged(object sender, EventArgs e)
        {
            SetBorder();
            PNHead.Height = HeadHeight;
        }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTFormMinBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 最大化及还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTFormMaxBox_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void LBHeadTitle_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTFormCloseBox_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
