using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.DrawingUtils.ImageUtils
{
    /// <summary>
    /// 图片操作工具类
    /// </summary>
    public static class IMG
    {
        /// <summary>
        /// 创建缩略图
        /// </summary>
        /// <param name="img"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="interpolation"></param>
        /// <param name="smoothing"></param>
        /// <returns></returns>
        public static Bitmap Thumbnail(Image img, int width, int height,
           InterpolationMode interpolation = InterpolationMode.High,
            SmoothingMode smoothing = SmoothingMode.HighSpeed)
        {
            int ow = img.Width;
            int oh = img.Height;

            //新建一个bmp图片
            Bitmap bitmap = new Bitmap(width, height);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置低质量,高速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighSpeed;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, ow, oh), GraphicsUnit.Pixel);
            return bitmap;
        }

        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="quality">0-100</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static byte[] CompressionToByte(Image image, int quality)
        {
            try
            {
                ImageFormat format = ImageFormat.Jpeg;

                //获取图像编码解码器
                ImageCodecInfo CodecInfo = null;
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                foreach (ImageCodecInfo codec in codecs)
                    if (codec.FormatID == format.Guid) CodecInfo = codec;

                //转换图片质量
                if (CodecInfo != null)
                {
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, CodecInfo, myEncoderParameters);
                        myEncoderParameters.Dispose();
                        myEncoderParameter.Dispose();
                        return ms.ToArray();
                    }
                }
            }
            catch { }
            return null;
        }
    }
}
