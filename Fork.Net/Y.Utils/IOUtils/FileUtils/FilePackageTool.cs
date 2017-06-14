//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.6.10 - 2017.6.12
//      desc:       文件打包工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Y.Utils.DataUtils.Collections;
using Y.Utils.IOUtils.PathUtils;

namespace Y.Utils.IOUtils.FileUtils
{
    /// <summary>
    /// 文件打包工具
    /// </summary>
    public class FilePackageTool
    {
        private static string FileTypeDesc = "FilePackage";
        private static int FileBuffer = 1024 * 1024;

        #region 类型单一，文件处理复杂，加载占用超大内存（这都是辣鸡）
        /// <summary>
        /// 批量打包任意对象到资源文件
        /// </summary>
        /// <param name="objCollection">被打包对象的列表。键值对中键为其在资源文件中的唯一标示名。</param>
        /// <param name="targetFilePath">目标资源文件。默认参数为当前目录下的"MyRes.pck"文件。</param>
        /// <param name="overwrite">是否覆盖已存在的目标文件。默认=True</param>
        public static void ResourcePackage(IDictionary<string, object> objCollection, string targetFilePath, bool overwrite = true)
        {
            if (overwrite) File.Delete(targetFilePath);
            using (ResourceWriter rw = new ResourceWriter(targetFilePath))
            {
                foreach (KeyValuePair<string, object> pair in objCollection)
                    //为了防传进来的资源名有数字开头，资源名都加了前缀_
                    rw.AddResource("_" + pair.Key, pair.Value);
                rw.Generate();
                rw.Close();
            }
        }
        /// <summary>
        /// 解包资源文件，返回所有资源及其资源名
        /// </summary>
        /// <param name="targetFilePath">要解包的资源文件。默认为当前目录下的"MyRes.pck"</param>
        /// <returns>资源字典，键值为资源唯一标示名。若无资源返回空集合。</returns>
        public static Dictionary<string, object> ResourceUnpack(string targetFilePath)
        {
            Dictionary<string, object> rtn = new Dictionary<string, object>();
            using (ResourceReader rr = new ResourceReader(targetFilePath))
            {
                foreach (DictionaryEntry entry in rr)
                    rtn.Add(((string)entry.Key).Substring(1), entry.Value);
            }
            return rtn;
        }
        /// <summary>
        /// 根据资源名在指定的资源文件中检索资源
        /// </summary>
        /// <param name="resName">资源名</param>
        /// <param name="targetFilePath">要在其中检索的资源文件名，默认为"MyRes.pck"</param>
        /// <returns>资源名对应的资源</returns>
        public static object ResourceSearch(string resName, string targetFilePath)
        {
            object rtn = null;
            using (ResourceReader rr = new ResourceReader(targetFilePath))
            {
                foreach (DictionaryEntry entry in rr)
                    if ((string)entry.Key == '_' + resName)
                    {
                        rtn = entry.Value;
                        break;
                    }
            }
            return rtn;
        }
        /// <summary>
        /// 将对象序列化
        /// </summary>
        /// <param name="FilePath">文件(支持绝大多数数据类型)</param>
        /// <param name="obj">要序列化的对象(如哈希表,数组等等)</param>
        public static void FileSerialize(string FilePath, object obj)
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    FileStream fs = new FileStream(FilePath, FileMode.Create);
                    BinaryFormatter sl = new BinaryFormatter();
                    sl.Serialize(fs, obj);
                    fs.Close();
                }
                catch
                {
                    //序列化存储失败！
                }
            }
            else
            {
                //您读取的文件对象不存在
            }
        }
        /// <summary>
        /// 将文件反序列化
        /// </summary>
        /// <param name="FilePath">文件路径(必须是经过当前序列化后的文件)</param>
        /// <returns>返回 null 表示序列反解失败或者目标文件不存在</returns>
        public static object FileDeSerialize(string FilePath)
        {
            if (System.IO.File.Exists(FilePath))
            {
                try
                {
                    FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    BinaryFormatter sl = new BinaryFormatter();
                    object obg = sl.Deserialize(fs);
                    fs.Close();
                    return obg;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 打包
        /// </summary>
        /// <returns>
        /// -11;//要打包的路径不存在
        /// -12;//打包后的目标文件已存在
        /// -13;//要打包的路径中没有文件
        /// -404;//未知错误，操作失败
        /// </returns>
        public static int Pack(string srcPath, string dstFile, bool overwrite = true)
        {
            DateTime beginTime = DateTime.Now;
            if (!Directory.Exists(srcPath)) return -11;//要打包的路径不存在
            if (File.Exists(dstFile) && !overwrite) return -12;//打包后的目标文件已存在

            List<string> tempfiles = FileTool.GetAllFile(srcPath);
            List<FilePackageModel> files = new List<FilePackageModel>();
            if (ListTool.HasElements(tempfiles))
            {
                //汇总所有文件
                tempfiles.ForEach(x =>
                {
                    files.Add(new FilePackageModel()
                    {
                        Name = Path.GetFileName(x),
                        Path = DirTool.GetFilePath(x),
                        Size = FileTool.Size(x),
                        MD5 = FileTool.GetMD5(x),
                    });
                });

                long allfilesize = files.Sum(x => x.Size);
                using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                {
                    //写入头部总长度
                    int headl = files.Sum(x => x.AllByteLength);
                    byte[] headlength = BitConverter.GetBytes(headl);
                    fsWrite.Write(headlength, 0, headlength.Length);
                    //循环写入文件信息
                    files.ForEach(x =>
                    {
                        fsWrite.Write(x.NameLengthByte, 0, x.NameLengthByte.Length);
                        fsWrite.Write(x.NameByte, 0, x.NameByte.Length);
                        fsWrite.Write(x.PathLengthByte, 0, x.PathLengthByte.Length);
                        fsWrite.Write(x.PathByte, 0, x.PathByte.Length);
                        fsWrite.Write(x.SizeLengthByte, 0, x.SizeLengthByte.Length);
                        fsWrite.Write(x.SizeByte, 0, x.SizeByte.Length);
                        fsWrite.Write(x.MD5LengthByte, 0, x.MD5LengthByte.Length);
                        fsWrite.Write(x.MD5Byte, 0, x.MD5Byte.Length);
                    });
                    //循环写入文件
                    files.ForEach(x =>
                    {
                        using (FileStream fsRead = new FileStream(DirTool.Combine(x.Path, x.Name), FileMode.Open))
                        {
                            int readCount = 0;
                            byte[] buffer = new byte[FileBuffer];
                            while ((readCount = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fsWrite.Write(buffer, 0, readCount);
                                allfilesize -= readCount;
                            }
                            fsRead.Close();
                        }
                    });
                    fsWrite.Close();
                }
                if (allfilesize == 0)
                {
                    return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
                }
            }
            else
            {
                return -13;//要打包的路径中没有文件
            }
            //打包失败后，删除打包后的文件
            try { File.Delete(dstFile); } catch (Exception e) { }
            return -404;//未知错误，操作失败
        }
        /// <summary>
        /// 解包
        /// </summary>
        /// <returns></returns>
        public static int Unpack(string srcFile, string dstPath, bool overwrite = true)
        {
            DateTime beginTime = DateTime.Now;
            if (!File.Exists(srcFile)) return -11; //要解包的文件不存在
            if (Directory.Exists(dstPath) && !overwrite) return -12;//要解包的目标文件夹已存在

            using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
            {
                //读取头部总长度
                byte[] headl = new byte[4];
                int headlength = 0;
                fsRead.Read(headl, 0, headl.Length);
                headlength = BitConverter.ToInt32(headl, 0);
                if (headlength > 0)
                {
                    //读取文件列表信息
                    byte[] headdata = new byte[headlength];
                    List<FilePackageModel> files = new List<FilePackageModel>();
                    fsRead.Read(headdata, 0, headlength);

                    int index = 0;
                    while (index < headlength)
                    {
                        #region 读取文件名长度和内容
                        //文件名长度
                        byte[] namelengthbyte = new byte[4];
                        Buffer.BlockCopy(headdata, index, namelengthbyte, 0, namelengthbyte.Length);
                        int namelength = BitConverter.ToInt32(namelengthbyte, 0);
                        index += namelengthbyte.Length;

                        //文件名内容
                        byte[] namebyte = new byte[namelength];
                        Buffer.BlockCopy(headdata, index, namebyte, 0, namelength);
                        string name = Encoding.Default.GetString(namebyte);
                        index += namebyte.Length;
                        #endregion

                        #region 读取路径长度和内容
                        //路径长度
                        byte[] pathlengthbyte = new byte[4];
                        Buffer.BlockCopy(headdata, index, pathlengthbyte, 0, pathlengthbyte.Length);
                        int pathlength = BitConverter.ToInt32(pathlengthbyte, 0);
                        index += pathlengthbyte.Length;

                        //路径内容
                        byte[] pathbyte = new byte[pathlength];
                        Buffer.BlockCopy(headdata, index, pathbyte, 0, pathlength);
                        string path = Encoding.Default.GetString(pathbyte);
                        index += pathbyte.Length;
                        #endregion

                        #region 读取文件大小长度和内容
                        //文件大小长度
                        byte[] sizelengthbyte = new byte[4];
                        Buffer.BlockCopy(headdata, index, sizelengthbyte, 0, sizelengthbyte.Length);
                        int sizelength = BitConverter.ToInt32(sizelengthbyte, 0);
                        index += sizelengthbyte.Length;

                        //文件大小
                        byte[] sizebyte = new byte[sizelength];
                        Buffer.BlockCopy(headdata, index, sizebyte, 0, sizelength);
                        int size = BitConverter.ToInt32(sizebyte, 4);
                        index += sizebyte.Length;
                        #endregion

                        #region 读取文件MD5码长度和内容
                        //文件大小长度
                        byte[] md5lengthbyte = new byte[4];
                        Buffer.BlockCopy(headdata, index, md5lengthbyte, 0, md5lengthbyte.Length);
                        int md5length = BitConverter.ToInt32(md5lengthbyte, 0);
                        index += md5lengthbyte.Length;

                        //文件大小
                        byte[] md5byte = new byte[md5length];
                        Buffer.BlockCopy(headdata, index, md5byte, 0, md5length);
                        string md5 = Encoding.Default.GetString(md5byte);
                        index += md5byte.Length;
                        #endregion

                        files.Add(new FilePackageModel()
                        {
                            Name = name,
                            Path = path,
                            Size = size,
                            MD5 = md5,
                        });
                    }

                    int a = 111;

                    //fsWrite.Write(x.SizeLengthByte, 0, x.SizeLengthByte.Length);
                    //fsWrite.Write(x.SizeByte, 0, x.SizeByte.Length);
                    //fsWrite.Write(x.MD5LengthByte, 0, x.MD5LengthByte.Length);
                    //fsWrite.Write(x.MD5Byte, 0, x.MD5Byte.Length);
                }
            }
            return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
        }
    }
}
