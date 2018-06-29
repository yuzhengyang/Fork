//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Drawing;
using System.Text;

namespace Azylee.Core.IOUtils.ImageUtils
{
    public class ExifHelper : IDisposable
    {
        private Bitmap Image;
        private Encoding Encoding = Encoding.UTF8;
        private string DefaultValue = "";
        public ExifHelper(string fileName)
        {
            Image = (Bitmap)Bitmap.FromFile(fileName);
        }
        public ExifHelper(string fileName, string defaultValue)
        {
            Image = (Bitmap)Bitmap.FromFile(fileName);
            DefaultValue = defaultValue;
        }
        public string GetPropertyString(Int32 pid)
        {
            if (IsPropertyDefined(pid))
                return GetString(Image.GetPropertyItem(pid).Value);
            else
                return DefaultValue;
        }
        public double GetPropertyDouble(Int32 pid)
        {
            double result = 0;
            if (IsPropertyDefined(pid))
            {
                byte[] value = Image.GetPropertyItem(pid).Value;
                if (value.Length == 24)
                {
                    double d = BitConverter.ToUInt32(value, 0) * 1.0d / BitConverter.ToUInt32(value, 4);
                    double m = BitConverter.ToUInt32(value, 8) * 1.0d / BitConverter.ToUInt32(value, 12);
                    double s = BitConverter.ToUInt32(value, 16) * 1.0d / BitConverter.ToUInt32(value, 20);
                    result = (((s / 60 + m) / 60) + d);
                }
            }
            return result;
        }
        public char GetPropertyChar(Int32 pid)
        {
            char result = ' ';
            if (IsPropertyDefined(pid))
            {
                byte[] value = Image.GetPropertyItem(pid).Value;
                result = BitConverter.ToChar(value, 0);
            }
            return result;
        }

        private string GetString(byte[] bt)
        {
            string result = Encoding.GetString(bt);
            if (result.EndsWith("\0"))
                result = result.Substring(0, result.Length - 1);
            return result;
        }
        private bool IsPropertyDefined(Int32 pid)
        {
            return (Array.IndexOf(Image.PropertyIdList, pid) > -1);
        }
        public void Dispose()
        {
            Image.Dispose();
        }
    }
}
