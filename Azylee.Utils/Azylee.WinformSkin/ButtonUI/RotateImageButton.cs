using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Azylee.WinformSkin.ButtonUI
{
    public partial class RotateImageButton : PictureBox
    {
        #region 属性
        #region 背景
        private Image _BackImageDefault = null;
        [Category("自定义属性")]
        [Description("正常显示背景")]
        public Image BackImageDefault
        {
            get { return _BackImageDefault; }
            set
            {
                _BackImageDefault = value;
                BackgroundImage = _BackImageDefault;
            }
        }

        private Image _BackImageHover = null;
        [Category("自定义属性")]
        [Description("鼠标悬停背景")]
        public Image BackImageHover
        {
            get { return _BackImageHover; }
            set { _BackImageHover = value; }
        }

        private Image _BackImageDown = null;
        [Category("自定义属性")]
        [Description("鼠标按下背景")]
        public Image BackImageDown
        {
            get { return _BackImageDown; }
            set { _BackImageDown = value; }
        }
        #endregion
        #region 前景
        private Image _ForeImageDefault = null;
        [Category("自定义属性")]
        [Description("正常显示前景")]
        public Image ForeImageDefault
        {
            get { return _ForeImageDefault; }
            set
            {
                _ForeImageDefault = value;
                Image = _ForeImageDefault;
            }
        }
        #endregion
        #endregion

        Graphics Graph = null;
        Timer TMPainter = new Timer();
        const int Interval = 50;
        int AnimaAngle = 0;
        const int AngleStep = 5;
        Bitmap Bmp = null;
        Graphics BmpGraph = null;
        bool IsInit = false;

        public RotateImageButton()
        {
            InitializeComponent();
            //采用双缓冲技术的控件必需的设置
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            if (!DesignMode)
            {
                Graph = CreateGraphics();
                Graph.SmoothingMode = SmoothingMode.AntiAlias;

                TMPainter.Interval = Interval;
                TMPainter.Tick += TMPainter_Tick;
            }
        }
        private void RotateImageButton_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        #region 事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            if (BackImageHover != null)
                BackgroundImage = BackImageHover;
            else
                Stop();
        }
        /// <summary>
        /// 鼠标悬停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageButton_MouseHover(object sender, EventArgs e)
        {
            if (BackImageHover != null)
                BackgroundImage = BackImageHover;
            else
                Stop();

            Start();
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            Stop();
        }
        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            Stop();

            if (BackImageDown != null) BackgroundImage = BackImageDown;
        }
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (BackImageHover != null)
                BackgroundImage = BackImageHover;
            else
                Stop();
        }
        private void TMPainter_Tick(object sender, EventArgs e)
        {
            Draw();
        }
        #endregion  


        /// <summary>
        /// 开始动画
        /// </summary>
        private void Start()
        {
            if (ForeImageDefault != null && !TMPainter.Enabled)
            {
                //之前设置为0，导致开始执行到18次时会抽搐一下子
                AnimaAngle = 360;
                TMPainter.Enabled = true;
            }
        }
        /// <summary>
        /// 停止并恢复到默认状态
        /// </summary>
        private void Stop()
        {
            TMPainter.Enabled = false;
            Image = ForeImageDefault;
            BackgroundImage = BackImageDefault;
        }
        private void Init()
        {
            try
            {
                if (!IsInit)
                {
                    Bmp = new Bitmap(Width, Height);
                    BmpGraph = Graphics.FromImage(Bmp);
                    BmpGraph.SmoothingMode = SmoothingMode.AntiAlias;
                    IsInit = true;
                }
            }
            catch { }
        }
        private void Draw()
        {
            try
            {
                Init();
                if (Graph != null && Bmp != null && BmpGraph != null)
                {
                    BmpGraph.Clear(Color.Transparent);
                    //绘制
                    if (ForeImageDefault != null)
                    {
                        BmpGraph.ResetTransform();//恢复默认状态
                        BmpGraph.TranslateTransform(Width / 2, Height / 2);//设置原点
                        BmpGraph.RotateTransform(AnimaAngle += AngleStep);//以水平线为x轴，从垂直上方开始旋转，每次旋转6度。
                        BmpGraph.DrawImage(ForeImageDefault, -(Width / 2), -(Height / 2), Width, Height);
                    }
                    Image = Bmp;
                }
            }
            catch { }
        }
        ~RotateImageButton()
        {
            BmpGraph.Dispose();
            Bmp.Dispose();
            Graph.Dispose();
        }
    }
}
