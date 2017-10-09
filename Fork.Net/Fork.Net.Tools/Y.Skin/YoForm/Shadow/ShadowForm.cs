//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.4.27 - 2017.8.25
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.WindowsUtils.APIUtils;

namespace Y.Skin.YoForm.Shadow
{
    public partial class ShadowForm : Form
    {
        private Point _MouseLocation;
        internal Point MouseLocation { get { return _MouseLocation; } }
        internal int ShadowWidth = 15;
        private ShadowFormSkin Skin;
        public ShadowForm()
        {
            InitializeComponent();
            //SetStyles();//减少闪烁
            FormBorderStyle = FormBorderStyle.None;//设置无边框的窗口样式
            ShowInTaskbar = false;
        }
        private void IrregularForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Skin = new ShadowFormSkin(this);//创建皮肤层
                ShadowForm_LocationChanged(null, null);
                Skin.BackColor = Color.Red;
                Skin.Show();//显示皮肤层
            }
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
                Skin.Show();
            }
            else
            {
                Hide();
                Skin.Hide();
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
            if (Skin != null)
            {
                Skin.Location = new Point(Left - ShadowWidth, Top - ShadowWidth);
                Skin.DrawShadow();
            }
        }
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
                Skin.Close();
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
                Skin.WindowState = FormWindowState.Minimized;
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
                    Skin.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    Skin.WindowState = FormWindowState.Normal;
                }
            }));
        }
        public void UIShow()
        {
            Invoke(new Action(() =>
            {
                Show();
                Skin.Show();
            }));
        }
        public void UIHide()
        {
            Invoke(new Action(() =>
            {
                Hide();
                Skin.Hide();
            }));
        }
        public void DrawShadow()
        {
            if (Skin != null)
            {
                Invoke(new Action(() =>
                {
                    Skin.DrawShadow();
                }));
            }
        }
    }
}
