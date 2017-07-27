using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Skin.YoForm.NoTitle;
using Y.Utils.WindowsUtils.APIUtils;

namespace Y.Skin.YoForm.CustomTitle
{
    public partial class DarkTitleForm : NoTitleForm
    {
        public DarkTitleForm()
        {
            InitializeComponent();
        }
        private void DarkTitleForm_Load(object sender, EventArgs e)
        {
            PBHeadIcon.Image = Icon.ToBitmap();
        }
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
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTFormCloseBox_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
