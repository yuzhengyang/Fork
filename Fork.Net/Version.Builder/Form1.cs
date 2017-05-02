using ShopSystem.Model.Sys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.BaseUtils;
using Y.Utils.FileUtils;
using Y.Utils.JsonUtils;
using Y.Utils.TxtUtils;

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
                this.Invoke(new Action(() => { LbResult.Text = "开始检索并生成目录文件，请稍候……"; }));
                beginTime = DateTime.Now;
                string path = TbPath.Text;
                string parentPath = DirTool.Parent(path);
                FileCodeHelper fcode = new FileCodeHelper();
                if (Directory.Exists(path) && Directory.Exists(parentPath))
                {
                    List<string> fileList = FileTool.GetAllFile(path);
                    if (!ListTool.IsNullOrEmpty(fileList))
                    {
                        VersionModel version = new VersionModel()
                        { Number = DateTime.Now.Second, Path = path, FileList = new List<VersionFile>(), };
                        foreach (var item in fileList)
                        {
                            version.FileList.Add(new VersionFile()
                            {
                                File = item.Replace(path, ""),
                                MD5 = fcode.GetMD5(item),
                            });
                        }
                        string file = string.Format(@"{0}\version.txt", parentPath);
                        string json = JsonTool.ToStr(version);
                        TxtTool.Create(file, json);
                    }
                }
                endTime = DateTime.Now;
                this.Invoke(new Action(() => { LbResult.Text = string.Format("生成完成，用时：{0}秒。", (endTime - beginTime).TotalSeconds); }));
            });
        }
    }
}
