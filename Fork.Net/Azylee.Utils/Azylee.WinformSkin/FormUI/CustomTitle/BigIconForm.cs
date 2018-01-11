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
    public partial class BigIconForm : NoTitleForm
    {
        public BigIconForm()
        {
            InitializeComponent();
        }

        private void BigIconForm_Load(object sender, EventArgs e)
        {
        }

        #region 属性
        private int _BigIconFormHeadHeight = 68;
        [Category("Style")]
        [Description("标题栏高度")]
        [DefaultValue(typeof(int), "68")]
        public int BigIconFormHeadHeight
        {
            get { return _BigIconFormHeadHeight; }
            set
            {
                if (_BigIconFormHeadHeight != value)
                {
                    _BigIconFormHeadHeight = value;
                    BigIconFormPNHead.Height = value;
                }
            }
        }
        #endregion
        #region 窗口操作：拖动、边框、最小化、最大化、还原、双击标题栏最大化、拖动标题栏还原、关闭
        /// <summary>
        /// 拖动窗口移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BigIconFormLBHeadTitle_MouseMove(object sender, MouseEventArgs e)
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
        private void BigIconFormBigIconForm_SizeChanged(object sender, EventArgs e)
        {
            SetBorder();
            BigIconFormPNHead.Height = BigIconFormHeadHeight;
        }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BigIconFormBTFormMinBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 最大化及还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BigIconFormBTFormMaxBox_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }
        private void BigIconFormLBHeadTitle_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BigIconFormBTFormCloseBox_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


    }
}
