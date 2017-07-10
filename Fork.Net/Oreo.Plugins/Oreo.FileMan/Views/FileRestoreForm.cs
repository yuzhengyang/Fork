using Oreo.FileMan.Commons;
using Oreo.FileMan.DatabaseEngine;
using Oreo.FileMan.Models;
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
using Y.Skin.YoForm.NoTitle;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;
using Y.Utils.IOUtils.PathUtils;

namespace Oreo.FileMan.Views
{
    public partial class FileRestoreForm : NoTitleForm
    {
        public string FilePath { get; set; }
        public List<BackupFiles> Files { get; set; }
        public FileRestoreForm(string path)
        {
            InitializeComponent();
            FilePath = path;
        }

        private void FileRestoreForm_Load(object sender, EventArgs e)
        {
            //读取该文件的备份记录
            using (var db = new Muse())
            {
                Files = db.Gets<BackupFiles>(x => x.FullPath == FilePath, null).OrderBy(x => x.Id).ToList();
            }
            if (ListTool.HasElements(Files))
            {
                //获取文件名及路径信息
                var first = Files.FirstOrDefault();
                LbFileName.Text = Path.GetFileName(first.FullPath);
                LbPath.Text = first.FullPath;
                LbVersion.Text = "共 " + Files.Count + " 版";

                TtLabel.SetToolTip(LbFileName, Path.GetFileName(first.FullPath));
                TtLabel.SetToolTip(LbPath, first.FullPath);

                //显示所有备份记录
                int index = 1;
                foreach (var file in Files)
                {
                    DgvFiles.Rows.Add(string.Format("第 {0} 版", index++), file.LastWriteTime, ByteConvertTool.Fmt(file.Size));
                }
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtRestoreToNew_Click(object sender, EventArgs e)
        {
            if (DgvFiles.CurrentRow != null && DgvFiles.CurrentRow.Index >= 0)
            {
                BackupFiles file = Files[DgvFiles.CurrentRow.Index];
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//设置默认目录
                sfd.FileName = Path.GetFileName(file.FullPath);//设置默认文件名
                sfd.Filter = "还原文件|*" + Path.GetExtension(file.FullPath);//设置默认文件类型
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string from = file.BackupFullPath;
                    string to = sfd.FileName;
                    File.Copy(from, to, true);
                }
            }
        }

        private void BtRestoreToOld_Click(object sender, EventArgs e)
        {
            if (DgvFiles.CurrentRow != null && DgvFiles.CurrentRow.Index >= 0)
            {
                BackupFiles file = Files[DgvFiles.CurrentRow.Index];
                string title = string.Format("文件还原", file.LastWriteTime);
                string text = string.Format("您确定将文件：{0} [ {1} ]{2}还原到：{2}{3} 吗？", Path.GetFileName(file.FullPath), file.LastWriteTime, Environment.NewLine, file.FullPath);
                if (MessageBox.Show(text, title, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string from = file.BackupFullPath;
                    string to = file.FullPath;
                    string topath = DirTool.GetFilePath(to);
                    if (DirTool.Create(topath))
                    {
                        File.Copy(from, to, true);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("路径：{0} 不存在，请还原到其他路径。", topath), "路径不存在");
                    }
                }
            }
        }
    }
}
