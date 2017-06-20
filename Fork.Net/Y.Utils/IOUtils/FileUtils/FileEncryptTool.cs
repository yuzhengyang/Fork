//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.6.8 - 2017.6.16
//      desc:       文件加密工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.EncryptUtils;
using Y.Utils.DelegateUtils;

namespace Y.Utils.IOUtils.FileUtils
{
    /// <summary>
    /// 文件加密工具
    /// </summary>
    public class FileEncryptTool
    {
        const string FileType = "Y.Utils.FileEncrypt";//文件类型 禁止修改长度（19位）
        const string FileVersion = "100001";//类型的版本 禁止修改长度（6位）
        private static int FileBuffer = 1024 * 1024;

        public static string FileExt = ".fmencrypt";

        /// <summary>
        /// 文件加密
        /// </summary>
        /// <param name="srcFile">源文件</param>
        /// <param name="dstFile">目标文件</param>
        /// <param name="password">加密密码</param>
        /// <param name="progress">回调进度</param>
        /// <param name="overwrite">是否覆盖已有目标文件</param>
        /// <returns>
        /// >0：操作成功（操作共计秒数）
        /// -11：要加密的文件不存在
        /// -12：加密后的目标文件已存在
        /// -404：未知错误，操作失败
        /// </returns>
        public static int Encrypt(string srcFile, string dstFile, string password, ProgressDelegate.ProgressHandler progress = null, object sender = null, bool overwrite = true)
        {
            DateTime beginTime = DateTime.Now;
            if (!File.Exists(srcFile)) return -11; //要加密的文件不存在
            if (File.Exists(dstFile) && !overwrite) return -12;//加密后的目标文件已存在

            string fmtPwd = AesTool.FmtPassword(password);
            string pwdMd5 = MD5Tool.Encrypt(MD5Tool.Encrypt(fmtPwd));

            string md5 = FileTool.GetMD5(srcFile);
            using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
            {
                using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                {
                    try
                    {
                        //写入文件类型标识和版本号
                        byte[] filetypeandversion = Encoding.Default.GetBytes(FileType + FileVersion);
                        fsWrite.Write(filetypeandversion, 0, filetypeandversion.Length);

                        //文件头部数据定义
                        List<byte[]> headdata = new List<byte[]>()
                            {
                                Encoding.Default.GetBytes(FileType),
                                Encoding.Default.GetBytes(md5),
                                Encoding.Default.GetBytes(AesTool.Encrypt(fmtPwd,AesTool.DefaultPassword)),
                                Encoding.Default.GetBytes(pwdMd5),
                                Encoding.Default.GetBytes(DateTime.Now.ToString())
                            };
                        //写入头部信息个数
                        byte[] count = BitConverter.GetBytes(headdata.Count);
                        fsWrite.Write(count, 0, count.Length);
                        //写入各部分长度
                        for (int i = 0; i < headdata.Count; i++)
                        {
                            byte[] length = BitConverter.GetBytes(headdata[i].Length);
                            fsWrite.Write(length, 0, length.Length);
                        }
                        //写入各部分数据
                        for (int i = 0; i < headdata.Count; i++)
                        {
                            fsWrite.Write(headdata[i], 0, headdata[i].Length);
                        }

                        //写入文件源数据
                        int readCount = 0;
                        byte[] buffer = new byte[FileBuffer];
                        while ((readCount = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            if (readCount != buffer.Length)
                            {
                                byte[] temp = new byte[readCount];
                                Buffer.BlockCopy(buffer, 0, temp, 0, readCount);
                                byte[] enbyte = AesTool.Encrypt(temp, fmtPwd);
                                fsWrite.Write(enbyte, 0, enbyte.Length);
                            }
                            else
                            {
                                byte[] enbyte = AesTool.Encrypt(buffer, fmtPwd);
                                fsWrite.Write(enbyte, 0, enbyte.Length);
                            }
                            progress?.Invoke(sender, new ProgressEventArgs(fsRead.Position, fsRead.Length));
                        }
                        return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
                    }
                    catch (Exception e) { }
                }
                //加密失败后，删除加密的文件
                try { File.Delete(dstFile); } catch (Exception e) { }
            }
            return -404;//未知错误，操作失败
        }
        /// <summary>
        /// 文件解密
        /// </summary>
        /// <param name="srcFile">源文件</param>
        /// <param name="dstFile">目标文件</param>
        /// <param name="password">解密密码</param>
        /// <param name="progress">回调进度</param>
        /// <param name="overwrite">是否覆盖已有目标文件</param>
        /// <returns>
        /// >0：操作成功（操作共计秒数）
        /// -11：要解密的文件不存在
        /// -12：解密后的目标文件已存在
        /// -20：文件类型不匹配
        /// -30：文件头不长度不吻合
        /// -90：解锁密码错误
        /// -404：未知错误，操作失败
        /// </returns>
        public static int Decrypt(string srcFile, string dstFile, string password, ProgressDelegate.ProgressHandler progress = null, object sender = null, bool overwrite = true)
        {
            DateTime beginTime = DateTime.Now;
            if (!File.Exists(srcFile)) return -11;//要解密的文件不存在
            if (File.Exists(dstFile) && !overwrite) return -12;//解密后的目标文件已存在

            string fmtPwd = AesTool.FmtPassword(password);
            string pwdMd5 = MD5Tool.Encrypt(MD5Tool.Encrypt(fmtPwd));
            List<string> headdata = new List<string>();

            using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
            {
                try
                {
                    //读取文件类型标识和版本号
                    byte[] filetype = Encoding.Default.GetBytes(FileType);
                    fsRead.Read(filetype, 0, filetype.Length);
                    string filetypestr = Encoding.Default.GetString(filetype);
                    byte[] fileversion = Encoding.Default.GetBytes(FileVersion);
                    fsRead.Read(fileversion, 0, fileversion.Length);
                    string fileversionstr = Encoding.Default.GetString(fileversion);
                    if (filetypestr != FileType && fileversionstr != FileVersion) return -20;//文件类型不匹配

                    //读取头部信息个数
                    byte[] count = new byte[4];
                    fsRead.Read(count, 0, count.Length);
                    int countint = BitConverter.ToInt32(count, 0);
                    //读取各部分长度和数据
                    byte[] headlength = new byte[4 * countint];
                    if (fsRead.Read(headlength, 0, headlength.Length) == headlength.Length)
                    {
                        for (int i = 0; i < countint; i++)
                        {
                            int datalong = BitConverter.ToInt32(headlength, i * 4);
                            byte[] tempdata = new byte[datalong];
                            fsRead.Read(tempdata, 0, datalong);
                            headdata.Add(Encoding.Default.GetString(tempdata));
                        }
                    }
                    if (headdata.Count < 5) return -30;//文件头不长度不吻合
                    if (pwdMd5 != headdata[3]) return -90;//解锁密码错误

                    using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                    {
                        int readCount = 0;
                        byte[] buffer = new byte[FileBuffer + 16];
                        while ((readCount = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            if (readCount != buffer.Length)
                            {
                                byte[] temp = new byte[readCount];
                                Buffer.BlockCopy(buffer, 0, temp, 0, readCount);
                                byte[] debyte = AesTool.Decrypt(temp, fmtPwd);
                                fsWrite.Write(debyte, 0, debyte.Length);
                            }
                            else
                            {
                                byte[] debyte = AesTool.Decrypt(buffer, fmtPwd);
                                fsWrite.Write(debyte, 0, debyte.Length);
                            }
                            progress?.Invoke(sender, new ProgressEventArgs(fsRead.Position, fsRead.Length));
                        }
                    }
                }
                catch (Exception e) { }
            }
            string md5 = FileTool.GetMD5(dstFile);
            if (headdata.Count > 1 && md5 == headdata[1])
            {
                return (int)Math.Ceiling((DateTime.Now - beginTime).TotalSeconds);//操作成功
            }
            else
            {
                //解密失败后，删除解密的文件
                try { File.Delete(dstFile); } catch (Exception e) { }
            }
            return -404;//未知错误，操作失败
        }
    }
}
