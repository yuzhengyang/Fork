//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.IOUtils.FileUtils
{
     class FilePackageModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string MD5 { get; set; }
        public long Size { get; set; }
        public byte[] NameByte { get { return Encoding.Default.GetBytes(Name); } }
        public byte[] PathByte { get { return Encoding.Default.GetBytes(Path); } }
        public byte[] MD5Byte { get { return Encoding.Default.GetBytes(MD5); } }
        public byte[] SizeByte { get { return BitConverter.GetBytes(Size); } }
        public byte[] NameLengthByte { get { return BitConverter.GetBytes(NameByte.Length); } }
        public byte[] PathLengthByte { get { return BitConverter.GetBytes(PathByte.Length); } }
        public byte[] MD5LengthByte { get { return BitConverter.GetBytes(MD5Byte.Length); } }
        public byte[] SizeLengthByte { get { return BitConverter.GetBytes(SizeByte.Length); } }
        public int AllByteLength
        {
            get
            {
                return NameByte.Length + PathByte.Length +
                    MD5Byte.Length + SizeByte.Length +
                    NameLengthByte.Length + PathLengthByte.Length +
                    MD5LengthByte.Length + SizeLengthByte.Length;
            }
        }
    }
}
