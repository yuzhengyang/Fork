using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Y.Skin.YoButton
{
    public partial class ImageButton : PictureBox
    {
        #region 属性
        private Image _MouseHoverImage = null;
        [Category("状态切换")]
        [Description("鼠标悬停时的图片")]
        [DefaultValue(typeof(bool), "true")]
        public Image MouseHoverImage
        {
            get { return _MouseHoverImage; }
            set { _MouseHoverImage = value; }
        }
        private Image _MouseDownImage = null;
        [Category("状态切换")]
        [Description("鼠标按下时的图片")]
        [DefaultValue(typeof(bool), "true")]
        public Image MouseDownImage
        {
            get { return _MouseDownImage; }
            set { _MouseDownImage = value; }
        }
        private Image _DefaultImage = null;
        [Category("状态切换")]
        [Description("鼠标按下时的图片")]
        [DefaultValue(typeof(bool), "true")]
        public Image DefaultImage
        {
            get { return _DefaultImage; }
            set
            {
                SizeMode = PictureBoxSizeMode.StretchImage;
                _DefaultImage = value;
                Image = _DefaultImage;
            }
        }
        #endregion
        public ImageButton()
        {
            InitializeComponent();
        }
        void Hover()
        {
            if (MouseHoverImage != null)
            {
                Image = MouseHoverImage;
            }
            else
            {
                Image = DefaultImage;
            }
        }
        void Down()
        {
            if (MouseDownImage != null)
                Image = MouseDownImage;
        }
        void Default()
        {
            Image = DefaultImage;
        }

        private void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            Down();
        }

        private void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            Hover();
        }

        private void ImageButton_MouseHover(object sender, EventArgs e)
        {
            Hover();
        }

        private void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            Default();
        }

        private void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            Hover();
        }

    }
}
