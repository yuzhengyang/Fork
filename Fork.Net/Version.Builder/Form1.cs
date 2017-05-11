using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version.Builder.Models;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.IOUtils.TxtUtils;

namespace Version.Builder
{
    public partial class Form1 : Form
    {
        DateTime beginTime = DateTime.Now;
        DateTime endTime = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtBuild_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                beginTime = DateTime.Now;
                Toast("开始检索并生成目录文件，请稍候……");

                CreateVersionMap();

                Toast(string.Format("生成完成，用时：{0:f2} 毫秒。",
                    (DateTime.Now - beginTime).TotalMilliseconds));
            });
        }
        private void CreateVersionMap()
        {
            string versionNumber = TbVersionNumber.Text;
            string ftpPath = TbFtpPath.Text;
            string[] beginClose = TbBeginClose.Text.Split(';');
            string[] endRun = TbEndRun.Text.Split(';');

            string path = TbPath.Text;
            string parentPath = DirTool.Parent(path);
            FileCodeTool fcode = new FileCodeTool();
            if (Directory.Exists(path) && Directory.Exists(parentPath))
            {
                List<string> fileList = FileTool.GetAllFile(path);
                if (!ListTool.IsNullOrEmpty(fileList))
                {
                    VersionModel version = new VersionModel()
                    {
                        Number = versionNumber,
                        ServerPath = ftpPath,
                        BeginCloseProcess = beginClose,
                        EndRunProcess = endRun,
                        FileList = new List<VersionFile>()
                    };

                    foreach (var item in fileList)
                    {
                        version.FileList.Add(new VersionFile()
                        {
                            File = item.Replace(path, ""),
                            MD5 = fcode.GetMD5(item),
                        });
                    }
                    string file = string.Format(@"{0}\update.version", parentPath, versionNumber);
                    string json = JsonTool.ToStr(version);
                    TxtTool.Create(file, json);
                }
            }
        }
        public void Toast(string msg)
        {
            Invoke(new Action(() =>
            {
                LbResult.Text = msg;
            }));
        }
    }
}
