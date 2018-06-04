//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.IOUtils.BinaryUtils
{
    public static class BinaryFileTool
    {
        public static bool write(string file, byte[] bytes)
        {
            try
            {
                DirTool.Create(Path.GetDirectoryName(file));
                //创建一个文件流
                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                {
                    //将byte数组写入文件中
                    fs.Write(bytes, 0, bytes.Length);
                }
                return true;
            }
            catch { }
            return false;
        }
        public static byte[] read(string file)
        {
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    long size = fs.Length; //获取文件大小
                    byte[] array = new byte[size];
                    fs.Read(array, 0, array.Length); //将文件读到byte数组中
                    return array;
                }
            }
            catch { }
            return null;
        }
    }
}
