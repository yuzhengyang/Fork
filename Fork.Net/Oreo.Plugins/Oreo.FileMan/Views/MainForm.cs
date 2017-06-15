using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
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
            bool flag = CanUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilePackageTool.Pack(@"D:\Temp\测试压缩\Root", @"D:\Temp\测试压缩\Root.pkg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilePackageTool.Unpack(@"D:\Temp\测试压缩\Root.pkg", @"D:\Temp\测试压缩\Root");
        }

        private bool CanUpdate()
        {
            string key = "TodayUpdateTimes";
            DateTime today = DateTime.Parse(string.Format("{0}-{1}-{2} 00:00:00", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            DateTime setday = today;

            //读取配置
            string temp = ConfigurationManager.AppSettings[key];
            if (DateTime.TryParse(temp, out setday) && setday >= today && setday <= today.AddDays(1))
            {
                if (setday.Hour < 5)
                    CanUpdateSetConfig(key, setday.AddHours(1).ToString());//累加hour记录次数
                else
                    return false;
            }
            else
            {
                //配置失效，设置为默认值
                CanUpdateSetConfig(key, today.ToString());
            }
            return true;
        }
        private bool CanUpdateSetConfig(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings.AllKeys.Contains(key))
                {
                    config.AppSettings.Settings[key].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add(key, value);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
