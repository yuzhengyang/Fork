using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.EncryptUtils;

namespace Y.Utils.IOUtils.FileUtils
{
    public class FileEncryptTool
    {
        private static string FileTypeDesc = "Oreo.FileMan.EncryptFile";
        private static int FileHeadLength = 256;
        private static int FileBuffer = 1024 * 1024;

        /// <summary>
        /// 文件加密
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="dstFile"></param>
        /// <param name="password"></param>
        /// <returns>
        /// 1：操作成功
        /// -11：要加密的文件不存在
        /// -12：加密后的目标文件已存在
        /// -404：未知错误，操作失败
        /// </returns>
        public static int Encrypt(string srcFile, string dstFile, string password)
        {
            DateTime begin = DateTime.Now;
            if (!File.Exists(srcFile)) return -11; //要加密的文件不存在
            if (File.Exists(dstFile)) return -12;//加密后的目标文件已存在

            string fmtPwd = AesTool.FmtPassword(password);
            string pwdMd5 = MD5Tool.Encrypt(MD5Tool.Encrypt(fmtPwd));

            string md5 = FileTool.GetMD5(srcFile);
            using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
            {
                using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                {
                    try
                    {
                        //文件头部数据定义
                        List<byte[]> headdata = new List<byte[]>()
                            {
                                Encoding.Default.GetBytes(FileTypeDesc),
                                Encoding.Default.GetBytes(md5),
                                Encoding.Default.GetBytes(AesTool.Encrypt(fmtPwd,AesTool.DefaultPassword)),
                                Encoding.Default.GetBytes(pwdMd5),
                                Encoding.Default.GetBytes(DateTime.Now.ToString())
                            };
                        //写入长度
                        for (int i = 0; i < FileHeadLength; i++)
                        {
                            if (headdata.Count > i)
                            {
                                byte[] length = BitConverter.GetBytes(headdata[i].Length);
                                fsWrite.Write(length, 0, length.Length);
                            }
                            else
                            {
                                byte[] length = BitConverter.GetBytes(0);
                                fsWrite.Write(length, 0, length.Length);
                            }
                        }
                        //写入数据
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
                        }
                        return 1;//操作成功
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
        /// <param name="srcFile"></param>
        /// <param name="dstFile"></param>
        /// <param name="password"></param>
        /// <returns>
        /// 1：操作成功
        /// -11：要解密的文件不存在
        /// -12：解密后的目标文件已存在
        /// -90：解锁密码错误
        /// -404：未知错误，操作失败
        /// </returns>
        public static int Decrypt(string srcFile, string dstFile, string password)
        {
            if (!File.Exists(srcFile)) return -11;//要解密的文件不存在
            if (File.Exists(dstFile)) return -12;//解密后的目标文件已存在

            string fmtPwd = AesTool.FmtPassword(password);
            string pwdMd5 = MD5Tool.Encrypt(MD5Tool.Encrypt(fmtPwd));
            List<string> headdata = new List<string>();
            using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
            {
                using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                {
                    try
                    {
                        byte[] headlength = new byte[4 * FileHeadLength];
                        if (fsRead.Read(headlength, 0, headlength.Length) == headlength.Length)
                        {
                            for (int i = 0; i < FileHeadLength; i++)
                            {
                                int datalong = BitConverter.ToInt32(headlength, i * 4);
                                byte[] tempdata = new byte[datalong];
                                fsRead.Read(tempdata, 0, datalong);
                                headdata.Add(Encoding.Default.GetString(tempdata));
                            }
                        }
                        if (pwdMd5 != headdata[3]) return -90;//解锁密码错误

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
                        }
                    }
                    catch (Exception e) { }
                }
            }
            string md5 = FileTool.GetMD5(dstFile);
            if (md5 == headdata[1])
            {
                return 1;//操作成功
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
