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
using System.Drawing.Imaging;

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

        private Image _ClockBackImage = null;
        [Category("时钟样式")]
        [Description("表盘")]
        public Image ClockBackImage
        {
            get { return _ClockBackImage; }
            set
            {
                _ClockBackImage = value;
                BackgroundImage = _ClockBackImage;
            }
        }
        #endregion
        Bitmap Bmp = null;
        Graphics Graph = null;
        DateTime Time = DateTime.Now;
        double TimeShift = 0;
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

        #region 对外提供方法
        /// <summary>
        /// 启动时钟刷新
        /// </summary>
        /// <param name="secondInterval">刷新间隔时间（）</param>
        /// <param name="timeShift">时间偏移（小时）</param>
        public void Start(int secondInterval = 1, double timeShift = 0)
        {
            Init(timeShift);//初始化数据
            Draw();//第一次绘制
            TMPainter.Interval = (secondInterval >= 1 ? secondInterval : 1) * 1000;//设置刷新间隔
            TMPainter.Enabled = true;//启动计时器任务
        }
        /// <summary>
        /// 强制重绘控件
        /// </summary>
        public void ReDraw()
        {
            Draw();
        }
        #endregion

        private void TMPainter_Tick(object sender, EventArgs e)
        {
            Draw();
        }
        private void Init(double timeShift)
        {
            try
            {
                Bmp = new Bitmap(Width, Height);
                Graph = Graphics.FromImage(Bmp);
                Graph.SmoothingMode = SmoothingMode.AntiAlias;
                TimeShift = timeShift;

                if (SecondHandImage == null)
                {
                    //TMPainter.Interval = 60 * 1000;
                    //SecondHandImage = Resources.simpleclock_simple_second_hand_1;
                }
                if (MinuteHandImage == null)
                {
                    //TMPainter.Interval = 60 * 60 * 1000;
                    MinuteHandImage = Resources.simpleclock_simple_minute_hand_1;
                }
                if (HourHandImage == null)
                {
                    HourHandImage = Resources.simpleclock_simple_hour_hand_1;
                }
            }
            catch { }
        }
        private void Draw()
        {
            try
            {
                if (Bmp != null && Graph != null)
                {
                    Time = DateTime.Now.AddHours(TimeShift);
                    Graph.ResetTransform();//恢复默认状态
                    Graph.Clear(Color.Transparent);
                    Graph.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
                    if (ClockBackImage != null) Graph.DrawImage(ClockBackImage, 0, 0, Width, Height);

                    //绘制时针
                    if (HourHandImage != null)
                    {
                        Graph.ResetTransform();//恢复默认状态
                        Graph.TranslateTransform(Width / 2, Height / 2);//设置原点
                        Graph.RotateTransform(Time.Hour * 30 + Time.Minute * 1 / 2);
                        Graph.DrawImage(HourHandImage, -(Width / 2), -(Height / 2), Width, Height);
                    }
                    //绘制分针
                    if (MinuteHandImage != null)
                    {
                        Graph.ResetTransform();//恢复默认状态
                        Graph.TranslateTransform(Width / 2, Height / 2);//设置原点
                        Graph.RotateTransform(Time.Minute * 6);
                        Graph.DrawImage(MinuteHandImage, -(Width / 2), -(Height / 2), Width, Height);
                    }
                    //绘制秒针
                    if (SecondHandImage != null)
                    {
                        Graph.ResetTransform();//恢复默认状态
                        Graph.TranslateTransform(Width / 2, Height / 2);//设置原点
                        Graph.RotateTransform(Time.Second * 6);//以水平线为x轴，从垂直上方开始旋转，每次旋转6度。
                        Graph.DrawImage(SecondHandImage, -(Width / 2), -(Height / 2), Width, Height);
                    }
                    BackgroundImage = Bmp;
                    Refresh();
                }
            }
            catch { }
        }
        ~SimpleClockControl()
        {
            Graph.Dispose();
            Bmp.Dispose();
        }
    }
}
