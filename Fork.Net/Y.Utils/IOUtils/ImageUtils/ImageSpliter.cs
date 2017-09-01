//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.9.1 - 2017.9.1
//      desc:       图片分块工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Y.Utils.IOUtils.ImageUtils
{
    public class ImageSpliter
    {
        private int Width = 0;
        private int Height = 0;
        private Image Image;
        public ImageSpliter(string file, int width, int height)
        {
            Image = Image.FromFile(file);
            Width = width;
            Height = height;
        }
        public ImageSpliter(Image src, int width, int height)
        {
            Image = src;
            Width = width;
            Height = height;
        }
        public Bitmap Get(int x, int y)
        {
            if (Image != null && Image.Width >= x * Width && Image.Height >= y * Height)
            {
                //创建新图位图   
                Bitmap bitmap = new Bitmap(Width, Height);
                //创建作图区域   
                using (Graphics graphic = Graphics.FromImage(bitmap))
                {
                    //截取原图相应区域写入作图区   
                    graphic.DrawImage(Image, 0, 0, new Rectangle((x - 1) * Width, (y - 1) * Height, Width, Height), GraphicsUnit.Point);
                }
            }
            return null;
        }
        public static Bitmap Get(Image img, int height, int width, int x, int y)
        {
            try
            {
                if (img != null && img.Width >= x * width && img.Height >= y * height)
                {
                    //创建新图位图   
                    Bitmap rs = new Bitmap(width, height);
                    //创建作图区域   
                    Graphics graphic = Graphics.FromImage(rs);
                    //截取原图相应区域写入作图区   
                    graphic.DrawImage(img, 0, 0, new Rectangle((x - 1) * width, (y - 1) * height, width, height), GraphicsUnit.Pixel);
                    graphic.Dispose();
                    img.Dispose();
                    return rs;
                }
            }
            catch { }
            return null;
        }
    }
}
