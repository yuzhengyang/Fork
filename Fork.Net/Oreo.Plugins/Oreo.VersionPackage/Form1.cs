using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.IOUtils.TxtUtils;
using Y.Utils.UpdateUtils;

namespace Oreo.VersionPackage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btPackage_Click(object sender, EventArgs e)
        {
            string src = tbPath.Text;
            string file = tbName.Text + "-" + tbVersion.Text.Replace('.', '-') + ".udp";
            string dst = DirTool.Combine(DirTool.GetFilePath(tbPath.Text), file);

            if (FilePackageTool.Pack(src, dst) > 0 && File.Exists(dst))
            {
                string md5Code = FileTool.GetMD5(dst);
                //设置更新模型，14个属性
                AppUpdateInfo aui = new AppUpdateInfo()
                {
                    Name = tbName.Text,
                    Author = tbAuthor.Text,
                    Desc = tbDesc.Text,
                    Version = tbVersion.Text,
                    ReleasePath = tbReleasePath.Text,
                    Necessary = cbNecessary.Checked,
                    DateTime = DateTime.Now,
                    DownloadMode = rbHttpMode.Checked ? 0 : 1,
                    HttpUrl = tbHttpUrl.Text,
                    FtpIp = tbFtpIp.Text,
                    FtpAccount = tbFtpAccount.Text,
                    FtpPassword = tbFtpPassword.Text,
                    FtpFile = tbFtpFile.Text,
                    Md5 = md5Code,
                };
                string auiJson = JsonTool.ToStr(aui);
                TxtTool.Create(dst + ".txt", auiJson);
            }
        }
    }
}
