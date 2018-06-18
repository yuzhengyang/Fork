//************************************************************************
//      author:     yuzhengyang
//      date:       2017.6.10 - 2017.6.15
//      desc:       文件打包工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DelegateUtils.ProcessDelegateUtils;
using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Azylee.Core.IOUtils.FileUtils
{
    /// <summary>
    /// 文件打包工具
    /// </summary>
    public class FilePackageTool
    {
        const string FileType = "Y.Utils.FilePackage";//文件类型 禁止修改长度（19位）
        const string FileVersion = "100001";//类型的版本 禁止修改长度（6位）
        private static int FileBuffer = 1024 * 1024;

        /// <summary>
        /// 文件打包
        /// </summary>
        /// <param name="srcPath">要打包的路径</param>
        /// <param name="dstFile">打包后的文件</param>
        /// <param name="progress">回调进度</param>
        /// <param name="overwrite">覆盖打包后的文件（重复时）</param>
        /// <returns>
        /// -11;//要打包的路径不存在
        /// -12;//打包后的目标文件已存在
        /// -13;//要打包的路径中没有文件
        /// -14;//输出文件夹不存在
        /// -404;//未知错误，操作失败
        /// </returns>
        public static int Pack(string srcPath, string dstFile, ProgressDelegate.ProgressHandler progress = null, object sender = null, bool overwrite = true)
        {
            DateTime beginTime = DateTime.Now;
            if (!Directory.Exists(srcPath)) return -11;//要打包的路径不存在
            if (File.Exists(dstFile) && !overwrite) return -12;//打包后的目标文件已存在
            if (!DirTool.Create(DirTool.GetFilePath(dstFile))) return -14;//输出文件夹不存在

            List<string> tempfiles = FileTool.GetAllFile(srcPath);
            List<FilePackageModel> files = CreateFilePackageModel(tempfiles, srcPath);
            if (ListTool.HasElements(files))
            {
                long allfilesize = files.Sum(x => x.Size);//文件总大小
                long surplusfilesize = allfilesize;//剩余要写入的文件大小
                using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                {
                    try
                    {
                        //写入文件类型标识和版本号
                        byte[] filetypeandversion = Encoding.Default.GetBytes(FileType + FileVersion);
                        fsWrite.Write(filetypeandversion, 0, filetypeandversion.Length);

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
                            //读取文件（可访问被打开的exe文件）
                            using (FileStream fsRead = new FileStream(DirTool.Combine(srcPath, x.Path, x.Name), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                int readCount = 0;
                                byte[] buffer = new byte[FileBuffer];
                                while ((readCount = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fsWrite.Write(buffer, 0, readCount);
                                    surplusfilesize -= readCount;
                                    progress?.Invoke(sender, new ProgressEventArgs(allfilesize - surplusfilesize, allfilesize));
                                }
                            }
                        });
                    }
                    catch (Exception e) { }
                }
                if (surplusfilesize == 0)
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
        /// 拆包
        /// </summary>
        /// <param name="srcFile">包文件路径</param>
        /// <param name="dstPath">拆包到的目录 </param>
        /// <param name="progress">回调进度</param>
        /// <param name="overwrite">覆盖拆包后的文件（重复时）</param>
        /// <returns>
        /// -11; //要解包的文件不存在
        /// -12;//要解包的目标文件夹已存在
        /// -20;// 文件类型不匹配
        /// -99;//未知错误，操作失败
        /// </returns>
        public static int Unpack(string srcFile, string dstPath, ProgressDelegate.ProgressHandler progress = null, object sender = null, bool overwrite = true)
        {
            DateTime beginTime = DateTime.Now;
            if (!File.Exists(srcFile)) return -11; //要解包的文件不存在
            if (Directory.Exists(dstPath) && !overwrite) return -12;//要解包的目标文件夹已存在

            using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
            {
                try
                {
                    string version = GetFileVersion(fsRead);
                    if (version == null) return -20;// 文件类型不匹配

                    //读取头部总长度
                    byte[] headl = new byte[4];
                    int headlength = 0;
                    fsRead.Read(headl, 0, headl.Length);
                    headlength = BitConverter.ToInt32(headl, 0);
                    if (headlength > 0)
                    {
                        //读取文件列表信息
                        byte[] headdata = new byte[headlength];
                        fsRead.Read(headdata, 0, headlength);
                        List<FilePackageModel> files = GetFilePackageModel(headdata);
                        if (ListTool.HasElements(files))
                        {
                            long allfilesize = files.Sum(x => x.Size);//文件总大小
                            long current = 0;//当前进度
                            //读取写出所有文件
                            files.ForEach(x =>
                            {
                                if (DirTool.Create(DirTool.Combine(dstPath, x.Path)))
                                {
                                    try
                                    {
                                        using (FileStream fsWrite = new FileStream(DirTool.Combine(dstPath, x.Path, x.Name), FileMode.Create))
                                        {
                                            long size = x.Size;
                                            int readCount = 0;
                                            byte[] buffer = new byte[FileBuffer];

                                            while (size > FileBuffer)
                                            {
                                                readCount = fsRead.Read(buffer, 0, buffer.Length);
                                                fsWrite.Write(buffer, 0, readCount);
                                                size -= readCount;
                                                current += readCount;
                                                progress?.Invoke(sender, new ProgressEventArgs(current, allfilesize));
                                            }
                                            if (size <= FileBuffer)
                                            {
                                                readCount = fsRead.Read(buffer, 0, (int)size);
                                                fsWrite.Write(buffer, 0, readCount);
                                                current += readCount;
                                                progress?.Invoke(sender, new ProgressEventArgs(current, allfilesize));
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        fsRead.Seek(x.Size, SeekOrigin.Current);
                                        current += x.Size;
                                        progress?.Invoke(sender, new ProgressEventArgs(current, allfilesize));
                                    }
                                }
                            });
                            //验证文件列表
                            bool allCheck = true;
                            foreach (var file in files)
                            {
                                string temp = DirTool.Combine(dstPath, file.Path, file.Name);
                                string tempCk = FileTool.GetMD5(temp);
                                if (tempCk != file.MD5)//验证文件（Size：速度会快一些，MD5在大文件的验证上非常耗时）
                                {
                                    allCheck = false;
                                    break;
                                }
                            }
                            if (allCheck) return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
                        }
                    }
                }
                catch (Exception e) { }
            }
            return -99;//未知错误，操作失败
        }


        /// <summary>
        /// 获取文件类型的类型版本
        /// </summary>
        /// <param name="fs"></param>
        /// <returns>
        /// 如果文件类型不匹配，则返回null
        /// </returns>
        private static string GetFileVersion(FileStream fs)
        {
            string result = null;
            try
            {
                //读取文件类型标识和版本号
                byte[] filetype = Encoding.Default.GetBytes(FileType);
                fs.Read(filetype, 0, filetype.Length);
                string filetypestr = Encoding.Default.GetString(filetype);

                byte[] fileversion = Encoding.Default.GetBytes(FileVersion);
                fs.Read(fileversion, 0, fileversion.Length);
                string fileversionstr = Encoding.Default.GetString(fileversion);

                //如果文件类型匹配，则返回版本号
                if (filetypestr == FileType) result = fileversionstr;
            }
            catch (Exception e) { }
            return result;
        }
        /// <summary>
        /// 解析打包文件文件列表
        /// </summary>
        /// <param name="headdata"></param>
        /// <returns></returns>
        private static List<FilePackageModel> GetFilePackageModel(byte[] headdata)
        {
            List<FilePackageModel> files = new List<FilePackageModel>();
            int index = 0;
            try
            {
                while (index < headdata.Length)
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
                    long size = BitConverter.ToInt64(sizebyte, 0);
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
                return files;
            }
            catch (Exception e) { return null; }
        }
        /// <summary>
        /// 创建打包文件列表信息
        /// </summary>
        /// <param name="files"></param>
        /// <param name="srcPath"></param>
        /// <returns></returns>
        private static List<FilePackageModel> CreateFilePackageModel(List<string> files, string srcPath)
        {
            if (ListTool.IsNullOrEmpty(files)) return null;

            List<FilePackageModel> result = new List<FilePackageModel>();
            //汇总所有文件
            files.ForEach(x =>
            {
                result.Add(new FilePackageModel()
                {
                    Name = Path.GetFileName(x),
                    Path = DirTool.GetFilePath(x).Substring(srcPath.Count()),
                    Size = FileTool.Size(x),
                    MD5 = FileTool.GetMD5(x),
                });
            });
            return result;
        }
    }
}
