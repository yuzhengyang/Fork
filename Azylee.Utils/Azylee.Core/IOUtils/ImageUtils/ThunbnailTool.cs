//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azylee.Core.IOUtils.ImageUtils
{
    public class ThunbnailTool
    {
        /// <summary>
        /// 标准缩略图生成
        /// </summary>
        /// <param name="originalImage">原始图像</param>
        /// <param name="width">指定宽度</param>
        /// <param name="height">指定高度</param>
        /// <param name="mode">缩略图模式</param>
        /// <param name="im">差值模式</param>
        /// <param name="sm">平滑模式</param>
        /// <returns></returns>
        public static Bitmap Normal(Bitmap originalImage, int width, int height, string mode,
            InterpolationMode im = InterpolationMode.High, SmoothingMode sm = SmoothingMode.HighQuality)
        {
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                 
                    break;
                case "W"://指定宽，高按比例                     
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例 
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片 
            Bitmap bitmap = new Bitmap(towidth, toheight);
            //新建一个画板 
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法 
            g.InterpolationMode = im;
            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = sm;
            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
            return bitmap;
        }
    }
}
