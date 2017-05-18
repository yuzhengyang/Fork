using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.WindowsUtils.APIUtils;

namespace Y.Skin.YoForm.Irregular
{
    partial class IrregularFormSkin : Form
    {
        private IrregularForm Main;
        public IrregularFormSkin(IrregularForm main)
        {
            InitializeComponent();
            SetStyles();//减少闪烁
            Main = main;//获取控件层对象
            Text = main.Text;//设置标题栏文本
            Icon = main.Icon;//设置图标
            TopMost = main.TopMost;
            FormBorderStyle = FormBorderStyle.None;//设置无边框的窗口样式
            ShowInTaskbar = true;//使控件层显示到任务栏
            BackgroundImage = Main.BackgroundImage;//将控件层背景图应用到皮肤层
            BackgroundImageLayout = ImageLayout.Stretch;//自动拉伸背景图以适应窗口
            Size = Main.Size;//统一大小
            Main.Owner = this;//设置控件层的拥有皮肤层
            FormMovableEvent();//激活皮肤层窗体移动
            SetBits();//绘制半透明不规则皮肤
            Location = new Point(Main.Location.X, Main.Location.Y);//统一控件层和皮肤层的位置
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
        #region 不规则无毛边方法
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }
        public void SetBits()
        {
            if (BackgroundImage != null)
            {
                //绘制绘图层背景
                Bitmap bitmap = new Bitmap(BackgroundImage, base.Width, base.Height);
                if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                    throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
                IntPtr oldBits = IntPtr.Zero;
                IntPtr screenDC = FormStyleAPI.GetDC(IntPtr.Zero);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr memDc = FormStyleAPI.CreateCompatibleDC(screenDC);

                try
                {
                    FormStyleAPI.Point topLoc = new FormStyleAPI.Point(Left, Top);
                    FormStyleAPI.Size bitMapSize = new FormStyleAPI.Size(Width, Height);
                    FormStyleAPI.BLENDFUNCTION blendFunc = new FormStyleAPI.BLENDFUNCTION();
                    FormStyleAPI.Point srcLoc = new FormStyleAPI.Point(0, 0);

                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                    oldBits = FormStyleAPI.SelectObject(memDc, hBitmap);

                    blendFunc.BlendOp = FormStyleAPI.AC_SRC_OVER;
                    blendFunc.SourceConstantAlpha = Byte.Parse(((int)(Main.Opacity * 255)).ToString());
                    blendFunc.AlphaFormat = FormStyleAPI.AC_SRC_ALPHA;
                    blendFunc.BlendFlags = 0;

                    FormStyleAPI.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, FormStyleAPI.ULW_ALPHA);
                }
                finally
                {
                    if (hBitmap != IntPtr.Zero)
                    {
                        FormStyleAPI.SelectObject(memDc, oldBits);
                        FormStyleAPI.DeleteObject(hBitmap);
                    }
                    FormStyleAPI.ReleaseDC(IntPtr.Zero, screenDC);
                    FormStyleAPI.DeleteDC(memDc);
                    bitmap.Dispose();
                }
            }
        }
        #endregion
        #region 无标题栏的窗口移动
        private Point mouseOffset; //记录鼠标指针的坐标
        private bool isMouseDown = false; //记录鼠标按键是否按下

        /// <summary>
        /// 窗体移动监听绑定
        /// </summary>
        private void FormMovableEvent()
        {
            //绘制层窗体移动
            this.MouseDown += new MouseEventHandler(Frm_MouseDown);
            this.MouseMove += new MouseEventHandler(Frm_MouseMove);
            this.MouseUp += new MouseEventHandler(Frm_MouseUp);
            this.LocationChanged += new EventHandler(Frm_LocationChanged);
            //控制层层窗体移动
            Main.MouseDown += new MouseEventHandler(Frm_MouseDown);
            Main.MouseMove += new MouseEventHandler(Frm_MouseMove);
            Main.MouseUp += new MouseEventHandler(Frm_MouseUp);
            Main.LocationChanged += new EventHandler(Frm_LocationChanged);
        }

        /// <summary>
        /// 窗体按下时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (Main.SkinMovable)
            {
                int xOffset;
                int yOffset;
                //点击窗体时，记录鼠标位置，启动移动
                if (e.Button == MouseButtons.Left)
                {
                    xOffset = -e.X;
                    yOffset = -e.Y;
                    mouseOffset = new Point(xOffset, yOffset);
                    isMouseDown = true;
                }
            }
        }

        /// <summary>
        /// 窗体移动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (Main.SkinMovable)
            {
                //将调用此事件的窗口保存下
                Form frm = (Form)sender;
                //确定开启了移动模式后
                if (isMouseDown)
                {
                    //移动的位置计算
                    Point mousePos = Control.MousePosition;
                    mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                    //判断是绘图层还是控件层调用了移动事件,并作出相应回馈
                    if (frm == this)
                    {
                        Location = mousePos;
                    }
                    else
                    {
                        Main.Location = mousePos;
                    }
                }
            }
        }

        /// <summary>
        /// 窗体按下并释放按钮时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (Main.SkinMovable)
            {
                // 修改鼠标状态isMouseDown的值
                // 确保只有鼠标左键按下并移动时，才移动窗体
                if (e.Button == MouseButtons.Left)
                {
                    //松开鼠标时，停止移动
                    isMouseDown = false;
                    //Top高度小于0的时候，等于0
                    if (this.Top < 0)
                    {
                        this.Top = 0;
                        Main.Top = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 窗口移动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Frm_LocationChanged(object sender, EventArgs e)
        {
            //将调用此事件的窗口保存下
            Form frm = (Form)sender;
            if (frm == this)
            {
                Main.Location = new Point(this.Left, this.Top);
            }
            else
            {
                Location = new Point(Main.Left, Main.Top);
            }
        }
        #endregion
    }
}
