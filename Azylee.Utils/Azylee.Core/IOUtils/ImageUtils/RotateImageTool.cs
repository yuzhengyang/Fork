using Azylee.Core.IOUtils.ExifUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Azylee.Core.IOUtils.ImageUtils
{
    public static class RotateImageTool
    {
        /// <summary>
        /// 旋转照片
        /// </summary>
        /// <param name="originalImagePath"></param>
        /// <param name="saveImagePath"></param>
        /// <returns></returns>
        public static bool RotateImg(string originalImagePath, string saveImagePath)
        { 
            Image img = Image.FromFile(originalImagePath);
            var exif = img.PropertyItems;
            byte orien = 0;
            var item = exif.Where(m => m.Id == 274).ToArray();
            if (item.Length > 0)
                orien = item[0].Value[0];
            switch (orien)
            {
                case 2:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);//horizontal flip
                    break;
                case 3:
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone);//right-top
                    break;
                case 4:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipY);//vertical flip
                    break;
                case 5:
                    img.RotateFlip(RotateFlipType.Rotate90FlipX);
                    break;
                case 6:
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);//right-top
                    break;
                case 7:
                    img.RotateFlip(RotateFlipType.Rotate270FlipX);
                    break;
                case 8:
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);//left-bottom
                    break;
                default:
                    break;
            } 
            try
            {
                img.Save(saveImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return true;
            }
            catch (Exception e) { return false; }
            finally
            {
                img.Dispose();
            }
        }
        /// <summary>
        /// 逆时针旋转图像
        /// </summary>
        /// <param name="originalImagePath">原始图像路径</param>
        /// <param name="saveImagePath">保存图像的路径</param>
        /// <param name = "angle" > 旋转角度[0, 360](前台给的) </ param >
        /// <returns></returns>
        public static bool RotateImg(string originalImagePath, string saveImagePath, int angle)
        {
            Image originalImage = Image.FromFile(originalImagePath);
            angle = angle % 360;
            //弧度转换  
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高  
            int w = originalImage.Width;
            int h = originalImage.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图  
            Bitmap saveImage = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(saveImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量  
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致  
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移  
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(originalImage, rect);
            //重至绘图的所有变换  
            g.ResetTransform();
            g.Save();
            //保存旋转后的图片  
            originalImage.Dispose();
            try
            {
                saveImage.Save(saveImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return true;
            }
            catch (Exception e) { return false; }
            finally
            {
                originalImage.Dispose();
                saveImage.Dispose();
                g.Dispose();
            }
        }
    }
}
