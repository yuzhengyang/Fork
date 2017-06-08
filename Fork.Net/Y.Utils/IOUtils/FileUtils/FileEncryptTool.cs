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
        private static int AESKeyLength = 32;//AES加密的密码为32位
        private static char AESFillChar = 'Y';//AES密码填充字符
        private static string FileTypeDesc = "Oreo.FileMan.EncryptFile";
        /// <summary>
        /// 文件加密
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="dstFile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Encrypt(string srcFile, string dstFile, string password)
        {
            string fmtPwd = FmtPassword(password);
            //检测文件存在
            if (File.Exists(srcFile) && !File.Exists(dstFile))
            {
                string md5 = FileTool.GetMD5(srcFile);
                using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
                {
                    using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                    {
                        try
                        {
                            //设置文件头部信息
                            byte[] typeByte = Encoding.Default.GetBytes(FileTypeDesc);
                            byte[] md5Byte = Encoding.Default.GetBytes(md5);
                            byte[] pwdByte = Encoding.Default.GetBytes(fmtPwd);
                            //设置文件头部数据长度信息
                            long[] headpart = new long[128];
                            headpart[0] = typeByte.Length;
                            headpart[1] = md5Byte.Length;
                            headpart[2] = pwdByte.Length;
                            //写入头部长度信息
                            foreach (var h in headpart)
                            {
                                byte[] temp = BitConverter.GetBytes(h);
                                fsWrite.Write(temp, 0, temp.Length);
                            }
                            //写入文件头部信息
                            fsWrite.Write(typeByte, 0, typeByte.Length);
                            fsWrite.Write(md5Byte, 0, md5Byte.Length);
                            fsWrite.Write(pwdByte, 0, pwdByte.Length);

                            //写入文件源数据
                            int readCount = 0;
                            byte[] buffer = new byte[1024 * 1024];
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
                            return true;
                        }
                        catch { }
                    }
                }
                //加密失败后，删除加密的文件
                try { File.Delete(dstFile); } catch { }
            }
            return false;
        }
        /// <summary>
        /// 文件解密
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="dstFile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Decrypt(string srcFile, string dstFile, string password)
        {
            string fmtPwd = FmtPassword(password);
            //检测文件存在
            if (File.Exists(srcFile) && !File.Exists(dstFile))
            {
                string[] fileInfo = new string[128];
                using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
                {
                    using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                    {
                        try
                        {
                            byte[] headpart = new byte[8 * 128];//fmk文件头
                            long[] dataLong = new long[128];//信息长度
                            if (fsRead.Read(headpart, 0, headpart.Length) == headpart.Length)
                            {
                                //读取信息长度
                                for (int i = 0; i < dataLong.Length; i++)
                                {
                                    dataLong[i] = BitConverter.ToInt64(headpart, i * 8);
                                }
                                byte[] typeByte = new byte[dataLong[0]];
                                byte[] md5Byte = new byte[dataLong[1]];
                                byte[] pwdByte = new byte[dataLong[2]];

                                fsRead.Read(typeByte, 0, typeByte.Length);
                                fsRead.Read(md5Byte, 0, md5Byte.Length);
                                fsRead.Read(pwdByte, 0, pwdByte.Length);

                                fileInfo[0] = Encoding.Default.GetString(typeByte);
                                fileInfo[1] = Encoding.Default.GetString(md5Byte);
                                fileInfo[2] = Encoding.Default.GetString(pwdByte);
                            }

                            if (fmtPwd == fileInfo[2])
                            {
                                int readCount = 0;
                                byte[] buffer = new byte[1024 * 1024 + 16];
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
                        }
                        catch { }
                    }
                }
                string md5 = FileTool.GetMD5(dstFile);
                if (md5 == fileInfo[1])
                {
                    return true;
                }
                else
                {
                    //解密失败后，删除解密的文件
                    try { File.Delete(dstFile); } catch { }
                }
            }
            return false;
        }

        /// <summary>
        /// 格式化密码
        /// </summary>
        /// <param name="s">要格式化的密码</param>
        /// <returns></returns>
        private static string FmtPassword(string s)
        {
            string password = s ?? "";

            //格式化密码
            if (password.Length < AESKeyLength)
            {
                //补足不够长的密码
                password = password + new string(AESFillChar, AESKeyLength - password.Length);
            }
            else if (password.Length > AESKeyLength)
            {
                //截取过长的密码
                password = password.Substring(0, AESKeyLength);
            }
            return password;
        }
    }
}
