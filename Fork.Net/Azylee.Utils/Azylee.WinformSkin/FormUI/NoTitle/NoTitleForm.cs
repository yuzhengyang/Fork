using Azylee.WinformSkin.APIUtils;
using Azylee.WinformSkin.StyleUtils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Azylee.WinformSkin.FormUI.NoTitle
{
    public partial class NoTitleForm : Form
    {
        Label BorderTop = new Label();
        Label BorderBottom = new Label();
        Label BorderLeft = new Label();
        Label BorderRight = new Label();
        #region 属性
        //窗体边框粗细
        private int _Border = 1;
        [Category("Style")]
        [Description("窗体边框粗细")]
        [DefaultValue(typeof(int), "1")]
        public int Border
        {
            get { return _Border; }
            set
            {
                if (_Border != value)
                {
                    _Border = value;
                    SetBorder();
                }
            }
        }
        //窗体边框颜色
        private Color _BorderColor = Color.Black;
        [Category("Style")]
        [Description("窗体边框颜色")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                if (_BorderColor != value)
                {
                    _BorderColor = value;
                    SetBorder();
                }
            }
        }
        //设置炫彩模式
        private bool _Colorful = false;
        [Category("Style")]
        [Description("炫彩模式")]
        [DefaultValue(typeof(bool), "false")]
        public bool Colorful
        {
            get { return _Colorful; }
            set
            {
                if (_Colorful != value)
                {
                    _Colorful = value;
                    if (value) SetColorful();
                }
            }
        }
        #endregion

        public NoTitleForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
        }
        private void NoTitleForm_Load(object sender, EventArgs e)
        {
            SetBorder();
            if (_Colorful) SetColorful();
        }


        /// <summary>
        /// 设置无标题窗口可拖动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                FormStyleAPI.ReleaseCapture();
                FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
            }
        }
        /// <summary>
        /// 设置窗口边框
        /// </summary>
        protected void SetBorder()
        {
            if (_Border > 0)
            {
                BorderTop.BackColor = _BorderColor;
                BorderTop.Width = Width;
                BorderTop.Height = _Border;
                Controls.Add(BorderTop);
                BorderTop.BringToFront();
                BorderTop.Top = 0;
                BorderTop.Left = 0;

                BorderBottom.BackColor = _BorderColor;
                BorderBottom.Width = Width;
                BorderBottom.Height = _Border;
                Controls.Add(BorderBottom);
                BorderBottom.BringToFront();
                BorderBottom.Top = Height - _Border;
                BorderBottom.Left = 0;

                BorderLeft.BackColor = _BorderColor;
                BorderLeft.Width = _Border;
                BorderLeft.Height = Height;
                Controls.Add(BorderLeft);
                BorderLeft.BringToFront();
                BorderLeft.Top = 0;
                BorderLeft.Left = 0;

                BorderRight.BackColor = _BorderColor;
                BorderRight.Width = _Border;
                BorderRight.Height = Height;
                Controls.Add(BorderRight);
                BorderRight.BringToFront();
                BorderRight.Top = 0;
                BorderRight.Left = Width - _Border;
            }
        }
        /// <summary>
        /// 设置炫彩模式
        /// </summary>
        protected void SetColorful()
        {
            string[] colors = ColorStyle.Warm.Concat(ColorStyle.Silence).ToArray();
            int index = new Random().Next(colors.Length);
            BackColor = ColorTranslator.FromHtml(colors[index]);
        }
        #region 界面优化
        /// <summary>
        /// 避免拖动窗口闪烁，使用会导致Windows自带动画失效
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED  
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Graphics g = CreateGraphics();
            //g.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(0, 0, Width, Height));
        }
        #endregion
        #region Invoke UI操作
        /// <summary>
        /// 设置控件是否可用
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="enable"></param>
        public void UIEnable(Control ctrl, bool enable = true)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    ctrl.Enabled = enable;
                }));
            }
            catch (Exception e) { }
        }
        public void UIVisible(Control ctrl, bool enable = true)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    ctrl.Visible = enable;
                }));
            }
            catch (Exception e) { }
        }
        public void UIClose()
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    Close();
                }));
            }
            catch (Exception e) { }
        }
        #endregion
    }
}
