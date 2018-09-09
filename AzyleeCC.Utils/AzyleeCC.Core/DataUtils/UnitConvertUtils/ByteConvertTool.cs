//************************************************************************
//      author:     yuzhengyang
//      date:       2017.5.18 - 2017.6.10
//      desc:       计算机字节单位转换工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

using System;

namespace AzyleeCC.Core.DataUtils.UnitConvertUtils
{
    /// <summary>
    /// 计算机字节单位转换工具
    /// </summary>
    public class ByteConvertTool
    {
        /// <summary>
        /// 自动格式化字节单位
        /// </summary>
        /// <param name="size"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string Fmt(long size, int digits = 2)
        {
            string rs = "";
            if (size >= 1024 * 1024 * 1024)
            {
                rs = Math.Round((double)size / 1024 / 1024 / 1024, digits) + " GB";
            }
            else if (size >= 1024 * 1024)
            {
                rs = Math.Round((double)size / 1024 / 1024, digits) + " MB";
            }
            else if (size >= 1024)
            {
                rs = Math.Round((double)size / 1024, digits) + " KB";
            }
            else
            {
                rs = size + " B";
            }
            return rs;
        }
        /// <summary>
        /// 自动格式化字节单位
        /// </summary>
        /// <param name="size"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string Fmt(double size, int digits = 2)
        {
            string rs = "";
            if (size >= 1024 * 1024 * 1024)
            {
                rs = Math.Round(size / 1024 / 1024 / 1024, digits) + " GB";
            }
            else if (size >= 1024 * 1024)
            {
                rs = Math.Round(size / 1024 / 1024, digits) + " MB";
            }
            else if (size >= 1024)
            {
                rs = Math.Round(size / 1024, digits) + " KB";
            }
            else
            {
                rs = size + " B";
            }
            return rs;
        }
        /// <summary>
        /// 根据单位换算
        /// </summary>
        /// <param name="size"></param>
        /// <param name="unit"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double Cvt(long size, string unit, int digits = 2)
        {
            double rs = 0;
            switch (unit)
            {
                case "B": rs = size; break;
                case "KB": rs = (double)size / 1024; break;
                case "MB": rs = (double)size / 1024 / 1024; break;
                case "GB": rs = (double)size / 1024 / 1024 / 1024; break;
                default: rs = size; break;
            }
            return Math.Round(rs, digits);
        }
        /// <summary>
        /// 根据单位换算
        /// </summary>
        /// <param name="size"></param>
        /// <param name="unit"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double Cvt(double size, string unit, int digits = 2)
        {
            double rs = 0;
            switch (unit)
            {
                case "B": rs = size; break;
                case "KB": rs = size / 1024; break;
                case "MB": rs = size / 1024 / 1024; break;
                case "GB": rs = size / 1024 / 1024 / 1024; break;
                default: rs = size; break;
            }
            return Math.Round(rs, digits);
        }
    }
}
