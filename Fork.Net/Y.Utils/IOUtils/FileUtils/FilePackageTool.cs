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

namespace Y.Utils.IOUtils.FileUtils
{
    /// <summary>
    /// 文件打包工具
    /// </summary>
    public class FilePackageTool
    {
        private static string FileTypeDesc = "FilePackage [文件打包]";
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
        /// -21;//读取文件大小异常
        /// </returns>
        public static int Pack(string srcPath, string dstFile, bool overwrite = true)
        {
            DateTime beginTime = DateTime.Now;
            if (!Directory.Exists(srcPath)) return -11;//要打包的路径不存在
            if (File.Exists(dstFile) && !overwrite) return -12;//打包后的目标文件已存在

            List<string> allfile = FileTool.GetAllFile(srcPath);
            if (ListTool.HasElements(allfile))
            {
                //读取所有文件的文件大小并检查
                long[] filesize = FileTool.Size(allfile);
                foreach (var fs in filesize) { if (fs < 0) return -21; }//读取文件大小异常
                //读取所有文件的MD5码
                string[] filemd5 = FileTool.GetMD5(allfile);

                using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                {
                    allfile.ForEach(x =>
                    {
                        using (FileStream fsRead = new FileStream(x, FileMode.Open))
                        {
                            fsRead.Close();
                        }
                    });
                    fsWrite.Close();
                }
            }
            else
            {
                return -13;//要打包的路径中没有文件
            }

            return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
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

            return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
        }
    }
}
