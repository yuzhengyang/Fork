using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Runrun
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string errorCode = "";
            string sqlFile = @"D:\code\workspace\histone\cmp7\svn\CMP7_02_工程域\03_SRC\Scripts\04_提交测试脚本\CMP7.3.1\7.3.1.33_0105\hicmp_report(pg+adbpg)\2023-12-25\福建高速专用\fjgsrpt_0302_pur_dt_进货明细报表.sql";
            Encoding encoding1 = GetFileEncoding(sqlFile);
            List<string> lines = TxtTool.ReadLine(sqlFile, Encoding.UTF8); // Encoding.GetEncoding("gb2312")
            foreach (string l in lines)
            {
                if (l.Contains("�"))
                {
                    errorCode = "乱码";
                    break;
                }
            }

            byte[] bytes = Encoding.UTF8.GetBytes("�");



            sqlFile = @"D:\code\workspace\histone\cmp7\svn\CMP7_02_工程域\03_SRC\Scripts\04_提交测试脚本\CMP7.3.1\7.3.1.33_0105\hicmp_report(pg+adbpg)\2023-12-25\福建高速专用\fjgsrpt_0501_stk_sum_库存汇总报表.sql";
            Encoding encoding2 = GetFileEncoding(sqlFile);
            List<string> lines2 = TxtTool.ReadLine(sqlFile, Encoding.Default);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// 获取指定文件的编码
        /// 以防止在不知道文件编码格式的情况下处理文件而造成的乱码问题
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static Encoding GetFileEncoding(string filename)
        {
            Encoding ReturnReturn = Encoding.Default;
            if (!File.Exists(filename)) return ReturnReturn;

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] buffer = br.ReadBytes(4);
                        if (buffer.Length > 0 && buffer[0] >= 0xEF)
                        {
                            if (buffer[0] == 0xEF && buffer[1] == 0xBB) ReturnReturn = Encoding.UTF8;
                            else if (buffer[0] == 0xFE && buffer[1] == 0xFF) ReturnReturn = Encoding.BigEndianUnicode;
                            else if (buffer[0] == 0xFF && buffer[1] == 0xFE) ReturnReturn = Encoding.Unicode;
                            else ReturnReturn = Encoding.Default;
                        }
                        else if (buffer.Length > 0 && buffer[0] == 0xe4 && buffer[1] == 0xbd)
                            ReturnReturn = Encoding.UTF8;
                        else
                            ReturnReturn = Encoding.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                ReturnReturn = Encoding.Default;
            }
            return ReturnReturn;
        }
    }
}
