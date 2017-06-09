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
                        if (FileEncryptTool.Encrypt(file, newfile, pwd) > 0)
                        {
                            MessageBox.Show("恭喜你，加密成功。", "加密成功");
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
            string pwd = "1234567890121";
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
                        if (FileEncryptTool.Decrypt(file, newfile, pwd) > 0)
                        {
                            MessageBox.Show("恭喜你，解密成功。", "解密成功");
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
        }
    }
}
