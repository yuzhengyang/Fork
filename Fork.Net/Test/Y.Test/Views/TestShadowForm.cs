using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Y.Utils.WindowsUtils.APIUtils;

namespace Y.Test.Views
{
    public partial class TestShadowForm : Form
    {
        private Point _MouseLocation;
        internal Point MouseLocation { get { return _MouseLocation; } }
        int ShadowWidth = 0;
        private Form Shadow;
        public TestShadowForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;//设置无边框的窗口样式
            //Opacity = 0.5;
        }
        private void TestShadowForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Shadow = new Form();//创建皮肤层
                Owner = Shadow;//设置控件层的拥有皮肤层
                Shadow.ShowInTaskbar = false;//禁止阴影显示到任务栏
                Shadow.Size = Size;//统一大小
                ShadowWidth = (Shadow.Width - 2 - Shadow.ClientRectangle.Width) / 2;
                Shadow.Width += ShadowWidth * 2;
                Shadow.Height += ShadowWidth;
                TestShadowForm_LocationChanged(this, null);
                Shadow.Show();//显示皮肤层
            }
        }

        #region 属性
        private bool _Moveable = true;
        [Category("Skin")]
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool Movable
        {
            get { return _Moveable; }
            set
            {
                if (_Moveable != value)
                {
                    _Moveable = value;
                }
            }
        }
        private bool _InTaskbar = true;
        [Category("Skin")]
        [Description("窗体是否显示到任务栏")]
        [DefaultValue(typeof(bool), "true")]
        public bool InTaskbar
        {
            get { return _InTaskbar; }
            set
            {
                if (_InTaskbar != value)
                {
                    _InTaskbar = value;
                }
            }
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

        private void TestShadowForm_LocationChanged(object sender, EventArgs e)
        {
            if (Shadow != null)
            {
                Shadow.Location = new Point(Left - ShadowWidth, Top);
            }
        }
    }
}
