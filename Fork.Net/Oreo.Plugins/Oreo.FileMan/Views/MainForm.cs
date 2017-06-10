using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.EncryptUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;

namespace Oreo.FileMan.Views
{
    public partial class MainForm : Form
    {
        FileCodeTool fct = new FileCodeTool();
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtFileEncrypt_Click(object sender, EventArgs e)
        {
            string pwd = "123456789012";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择要加密的文件";
            fileDialog.Filter = "所有文件|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                if (File.Exists(file))
                {
                    string newfile = file + ".fmk";

                    if (!File.Exists(newfile))
                    {
                        int spendtime = 0;
                        if ((spendtime = FileEncryptTool.Encrypt(file, newfile, pwd)) > 0)
                        {
                            MessageBox.Show("恭喜你，加密成功。共耗时：" + spendtime, "加密成功");
                        }
                    }
                    else
                    {
                        MessageBox.Show("您选择的文件已存在加密文件", "？？");
                    }
                }
            }
        }

        private void BtFileDecrypt_Click(object sender, EventArgs e)
        {
            string pwd = "123456789012";
            string[] fileInfo = new string[128];
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择要解密的文件";
            fileDialog.Filter = "加密文件|*.fmk";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                if (File.Exists(file))
                {
                    string newfile = file.Substring(0, file.Length - ".fmk".Length);
                    if (!File.Exists(newfile))
                    {
                        int spendtime = 0;
                        if ((spendtime = FileEncryptTool.Decrypt(file, newfile, pwd)) > 0)
                        {
                            MessageBox.Show("恭喜你，解密成功。共耗时：" + spendtime, "解密成功");
                        }
                    }
                    else
                    {
                        MessageBox.Show("您选择的文件已存在解密文件", "？？");
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ////打包
            //Dictionary<string, object> dicToPack = new Dictionary<string, object>();
            ////dicToPack.Add("key1", Image.FromFile(@"D:\temp\测试打包\1511925984.jpeg"));
            ////dicToPack.Add("key2", Image.FromFile(@"D:\temp\测试打包\1555714799.jpeg"));
            //dicToPack.Add("key1", FilePackageTool.FileDeSerialize(@"D:\temp\测试打包\新建文件夹\新建文本文档 1.txt"));
            //dicToPack.Add("key2", FilePackageTool.FileDeSerialize(@"D:\temp\测试打包\新建文件夹\新建文本文档 2.txt"));
            //dicToPack.Add("key3", "hello world");
            //FilePackageTool.ResourcePackage(dicToPack, @"D:\temp\测试打包\pkg1.pkg");
            ////解包
            ////Dictionary<string, object> dicRcv = FilePackageTool.ResourceUnpack(@"D:\temp\测试打包\pkg1.pkg");
        }

    }
}
