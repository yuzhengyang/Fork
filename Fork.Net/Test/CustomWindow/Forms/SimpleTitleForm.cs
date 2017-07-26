using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomWindow.Forms
{
    public partial class SimpleTitleForm : Form
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
        #endregion

        public SimpleTitleForm()
        {
            InitializeComponent();
        }
        private void NoTitleForm_Load(object sender, EventArgs e)
        {
            SetTitle();
            SetBorder();
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
        /// 设置图标和标题
        /// </summary>
        protected void SetTitle()
        {
            label1.Text = Text;
        }
        #region API
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        #endregion

        private void BTClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x00A1, 2, 0);
            }
        }
    }
}
