//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.IOUtils.ImageUtils
{
    public class IconTool
    {

        /// <summary>
        /// 将 Image 保存到指定目录文件名的 Icon
        /// </summary>
        /// <param name="image"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool Save(Image image, string file)
        {
            if (image != null)
            {
                using (Icon icon = ConvertToIcon(image))
                {
                    try
                    {
                        FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
                        icon.Save(fs);
                        fs.Flush();
                        fs.Close();
                        fs.Dispose();
                        return true;
                    }
                    catch { }
                }
            }
            return false;
        }

        /// <summary>
        /// 转换Image为Icon
        /// </summary>
        /// <param name="image">要转换为图标的Image对象</param>
        /// <param name="nullTonull">当image为null时是否返回null。false则抛空引用异常</param>
        /// <exception cref="ArgumentNullException" />
        public static Icon ConvertToIcon(Image image, bool nullTonull = false)
        {
            if (image == null)
            {
                if (nullTonull) { return null; }
                throw new ArgumentNullException("image");
            }

            using (MemoryStream msImg = new MemoryStream()
                                , msIco = new MemoryStream())
            {
                image.Save(msImg, ImageFormat.Png);

                using (var bin = new BinaryWriter(msIco))
                {
                    //写图标头部
                    bin.Write((short)0);           //0-1保留
                    bin.Write((short)1);           //2-3文件类型。1=图标, 2=光标
                    bin.Write((short)1);           //4-5图像数量（图标可以包含多个图像）

                    bin.Write((byte)image.Width);  //6图标宽度
                    bin.Write((byte)image.Height); //7图标高度
                    bin.Write((byte)0);            //8颜色数（若像素位深>=8，填0。这是显然的，达到8bpp的颜色数最少是256，byte不够表示）
                    bin.Write((byte)0);            //9保留。必须为0
                    bin.Write((short)0);           //10-11调色板
                    bin.Write((short)32);          //12-13位深
                    bin.Write((int)msImg.Length);  //14-17位图数据大小
                    bin.Write(22);                 //18-21位图数据起始字节

                    //写图像数据
                    bin.Write(msImg.ToArray());

                    bin.Flush();
                    bin.Seek(0, SeekOrigin.Begin);
                    return new Icon(msIco);
                }
            }
        }


    }
}
