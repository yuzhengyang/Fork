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
using System.Xml.Linq;
using Y.Utils.DataUtils.EncryptUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.NetUtils.HttpUtils;

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
                        Task.Factory.StartNew(() =>
                        {
                            int spendtime = 0;
                            if ((spendtime = FileEncryptTool.Encrypt(file, newfile, pwd, UIProgress)) > 0)
                            {
                                MessageBox.Show("恭喜你，加密成功。共耗时：" + spendtime, "加密成功");
                            }
                        });
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
                        Task.Factory.StartNew(() =>
                        {
                            int spendtime = 0;
                            if ((spendtime = FileEncryptTool.Decrypt(file, newfile, pwd, UIProgress)) > 0)
                            {
                                MessageBox.Show("恭喜你，解密成功。共耗时：" + spendtime, "解密成功");
                            }
                        });
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

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                int flag = FilePackageTool.Pack(@"D:\temp\测试打包\新建文件夹", @"D:\temp\测试打包\新建文件夹.pkg", UIProgress);
                if (flag > 0)
                    MessageBox.Show("打包成功");
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                int flag = FilePackageTool.Unpack(@"D:\temp\测试打包\新建文件夹.pkg", @"D:\temp\测试打包\新建文件夹", UIProgress);
                if (flag > 0)
                    MessageBox.Show("拆包成功");
            });
        }
        private void UIProgress(long current, long total)
        {
            BeginInvoke(new Action(() =>
            {
                progressBar1.Maximum = 100;
                progressBar1.Value = (int)(current * 100 / total);
                label1.Text = current + "/" + total;
            }));
        }

        private bool CanUpdate()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + "Settings";
            string key = "TodayUpdateTimes";
            DateTime today = DateTime.Parse(string.Format("{0}-{1}-{2} 00:00:00", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            DateTime setday = today;

            //读取配置
            string temp = CanUpdateGetConfig(file, key);
            if (DateTime.TryParse(temp, out setday) && setday >= today && setday <= today.AddDays(1))
            {
                if (setday.Hour < 3)
                    CanUpdateSetConfig(file, key, setday.AddHours(1).ToString());//累加hour记录次数
                else
                    return false;
            }
            else
            {
                //配置失效，设置为默认值
                CanUpdateSetConfig(file, key, today.ToString());
            }
            return true;
        }
        private bool CanUpdateSetConfig(string file, string key, string value)
        {
            try
            {
                //文件不存在则创建
                if (!File.Exists(file + ".config"))
                {
                    XElement xe = new XElement("configuration");
                    xe.Save(file + ".config");
                }
                Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                if (config.AppSettings.Settings.AllKeys.Contains(key))
                {
                    config.AppSettings.Settings[key].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add(key, value);
                }
                config.Save(ConfigurationSaveMode.Modified);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private string CanUpdateGetConfig(string file, string key)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                if (config.AppSettings.Settings.AllKeys.Contains(key))
                {
                    return config.AppSettings.Settings[key].Value;
                }
            }
            catch (Exception e) { }
            return null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                HttpTool.Download("http://sw.bos.baidu.com/sw-search-sp/software/5b71d074792c3/googleearth_7.1.8.3036.exe", @"D:\temp\测试加密\googleearth_7.1.8.3036.exe", UIProgress);
            });
        }
    }
}
