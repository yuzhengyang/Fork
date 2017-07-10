using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Y.Utils.DrawUtils.ColorUtils;
using Y.Utils.WindowsUtils.APIUtils;

namespace Y.Skin.YoForm.NoTitle
{
    public partial class NoTitleForm : Form
    {
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
            FormStyleAPI.ReleaseCapture();
            FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
        }
        /// <summary>
        /// 设置窗口边框
        /// </summary>
        protected void SetBorder()
        {
            if (_Border > 0)
            {
                Label BorderTop = new Label();
                BorderTop.BackColor = _BorderColor;
                BorderTop.Width = Width;
                BorderTop.Height = _Border;
                Controls.Add(BorderTop);
                BorderTop.BringToFront();
                BorderTop.Top = 0;
                BorderTop.Left = 0;

                Label BorderBottom = new Label();
                BorderBottom.BackColor = _BorderColor;
                BorderBottom.Width = Width;
                BorderBottom.Height = _Border;
                Controls.Add(BorderBottom);
                BorderBottom.BringToFront();
                BorderBottom.Top = Height - _Border;
                BorderBottom.Left = 0;

                Label BorderLeft = new Label();
                BorderLeft.BackColor = _BorderColor;
                BorderLeft.Width = _Border;
                BorderLeft.Height = Height;
                Controls.Add(BorderLeft);
                BorderLeft.BringToFront();
                BorderLeft.Top = 0;
                BorderLeft.Left = 0;

                Label BorderRight = new Label();
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Graphics g = CreateGraphics();
            //g.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(0, 0, Width, Height));
        }

    }
}
