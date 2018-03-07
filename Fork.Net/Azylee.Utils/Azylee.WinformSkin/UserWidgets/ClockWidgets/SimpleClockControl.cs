using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Azylee.WinformSkin.Properties;

namespace Azylee.WinformSkin.UserWidgets.ClockWidgets
{
    public partial class SimpleClockControl : UserControl
    {
        #region 属性
        private Image _SecondHandImage = null;
        [Category("时钟样式")]
        [Description("秒针")]
        public Image SecondHandImage
        {
            get { return _SecondHandImage; }
            set { _SecondHandImage = value; }
        }

        private Image _MinuteHandImage = null;
        [Category("时钟样式")]
        [Description("分针")]
        public Image MinuteHandImage
        {
            get { return _MinuteHandImage; }
            set { _MinuteHandImage = value; }
        }

        private Image _HourHandImage = null;
        [Category("时钟样式")]
        [Description("时针")]
        public Image HourHandImage
        {
            get { return _HourHandImage; }
            set { _HourHandImage = value; }
        }
        #endregion
        Graphics Graph = null;
        Bitmap Bmp = null;
        Graphics BmpGraph = null;
        DateTime Time = DateTime.Now;
        public SimpleClockControl()
        {
            InitializeComponent();
            //采用双缓冲技术的控件必需的设置
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        private void SimpleClockControl_Load(object sender, EventArgs e)
        {
        }
        public void Start()
        {
            Graph = CreateGraphics();
            Graph.SmoothingMode = SmoothingMode.AntiAlias;
            Bmp = new Bitmap(Width, Height);
            BmpGraph = Graphics.FromImage(Bmp);
            BmpGraph.SmoothingMode = SmoothingMode.AntiAlias;
            TMPainter.Interval = 1 * 1000;

            if (SecondHandImage == null)
            {
                TMPainter.Interval = 60 * 1000;
                //SecondHandImage = Resources.simpleclock_simple_second_hand_1;
            }
            if (MinuteHandImage == null)
            {
                TMPainter.Interval = 60 * 60 * 1000;
                MinuteHandImage = Resources.simpleclock_simple_minute_hand_1;
            }
            if (HourHandImage == null)
            {
                HourHandImage = Resources.simpleclock_simple_hour_hand_1;
            }

            Draw();//第一次绘制
            TMPainter.Enabled = true;
        }
        public void ReDraw()
        {
            Draw();
        }
        private void TMPainter_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            try
            {
                if (Graph != null && Bmp != null && BmpGraph != null)
                {
                    Refresh();//强制重绘控件
                    Time = DateTime.Now;
                    BmpGraph.ResetTransform();//恢复默认状态
                    BmpGraph.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
                    if (BackgroundImage != null) BmpGraph.DrawImage(BackgroundImage, 0, 0, Width, Height);

                    //绘制时针
                    if (HourHandImage != null)
                    {
                        BmpGraph.ResetTransform();//恢复默认状态
                        BmpGraph.TranslateTransform(Width / 2, Height / 2);//设置原点
                        BmpGraph.RotateTransform(Time.Hour * 30 + Time.Minute * 1 / 2);
                        BmpGraph.DrawImage(HourHandImage, -(Width / 2), -(Height / 2), Width, Height);
                    }
                    //绘制分针
                    if (MinuteHandImage != null)
                    {
                        BmpGraph.ResetTransform();//恢复默认状态
                        BmpGraph.TranslateTransform(Width / 2, Height / 2);//设置原点
                        BmpGraph.RotateTransform(Time.Minute * 6);
                        BmpGraph.DrawImage(MinuteHandImage, -(Width / 2), -(Height / 2), Width, Height);
                    }
                    //绘制秒针
                    if (SecondHandImage != null)
                    {
                        BmpGraph.ResetTransform();//恢复默认状态
                        BmpGraph.TranslateTransform(Width / 2, Height / 2);//设置原点
                        BmpGraph.RotateTransform(Time.Second * 6);//以水平线为x轴，从垂直上方开始旋转，每次旋转6度。
                        BmpGraph.DrawImage(SecondHandImage, -(Width / 2), -(Height / 2), Width, Height);
                    }
                    OnPaint(new PaintEventArgs(Graph, new Rectangle(0, 0, Width, Height)));
                }
            }
            catch { }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!DesignMode && e != null && e.Graphics != null && Bmp != null)
            {
                Graphics g = e.Graphics;
                g.DrawImage(Bmp, 0, 0, Width, Height);
            }
        }
        ~SimpleClockControl()
        {
            Graph.Dispose();
            Bmp.Dispose();
            BmpGraph.Dispose();
        }
    }
}
