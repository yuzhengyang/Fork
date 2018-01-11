using Azylee.WinformSkin.APIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azylee.WinformSkin.FormUI.SimpleShadow
{
    public partial class SimpleShadowForm : Form
    {
        #region 属性
        private Point _MouseLocation;
        internal Point MouseLocation { get { return _MouseLocation; } }
        internal int ShadowWidth = 15;
        private SimpleShadowBackForm Shadow;
        #endregion

        public SimpleShadowForm()
        {
            InitializeComponent();
            //SetStyles();//减少闪烁
            FormBorderStyle = FormBorderStyle.None;//设置无边框的窗口样式
            ShowInTaskbar = false;
        }
        private void SimpleShadowForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Shadow = new SimpleShadowBackForm(this);//创建皮肤层
                ShadowForm_LocationChanged(null, null);
                Shadow.BackColor = Color.Red;
              
                LocationChanged += new EventHandler(ShadowForm_LocationChanged);
            }
        }
        private void SimpleShadowForm_Shown(object sender, EventArgs e)
        {
            if (!DesignMode)
                Shadow.Show();//显示皮肤层
        }
        private void SimpleShadowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!DesignMode)
                Shadow.Hide();//关闭皮肤层
        }
        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;
        }
        #endregion
        /// <summary>
        /// 窗体显示状态
        /// </summary>
        /// <param name="value"></param>
        public void Visibility(bool value)
        {
            if (value)
            {
                Show();
                Shadow.Show();
            }
            else
            {
                Hide();
                Shadow.Hide();
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _MouseLocation = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                FormStyleAPI.ReleaseCapture();
                FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
            }
        }
        private void ShadowForm_LocationChanged(object sender, EventArgs e)
        {
            if (Shadow != null)
            {
                Shadow.Location = new Point(Left - ShadowWidth, Top - ShadowWidth);
                Shadow.DrawShadow();
            }
        }

        public void DrawShadow()
        {
            if (Shadow != null)
            {
                Invoke(new Action(() =>
                {
                    Shadow.DrawShadow();
                }));
            }
        }

        #region 界面UI及元素操作
        /// <summary>
        /// 控件可用
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="enable"></param>
        public void UIEnable(Control ctrl, bool enable = true)
        {
            Invoke(new Action(() =>
            {
                ctrl.Enabled = enable;
            }));
        }
        /// <summary>
        /// 控件显示
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="enable"></param>
        public void UIVisible(Control ctrl, bool enable = true)
        {
            Invoke(new Action(() =>
            {
                ctrl.Visible = enable;
            }));
        }
        /// <summary>
        /// UICLose
        /// </summary>
        public void UIClose()
        {
            Invoke(new Action(() =>
            {
                Close();
                Shadow.Close();
            }));
        }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UIMin()
        {
            Invoke(new Action(() =>
            {
                WindowState = FormWindowState.Minimized;
                Shadow.WindowState = FormWindowState.Minimized;
            }));
        }
        /// <summary>
        /// 最大化及还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UIMax()
        {
            Invoke(new Action(() =>
            {
                if (WindowState != FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Maximized;
                    Shadow.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    Shadow.WindowState = FormWindowState.Normal;
                }
            }));
        }
        public void UIShow()
        {
            Invoke(new Action(() =>
            {
                Show();
                Shadow.Show();
            }));
        }
        public void UIHide()
        {
            Invoke(new Action(() =>
            {
                Hide();
                Shadow.Hide();
            }));
        }

        #endregion 
    }
}
