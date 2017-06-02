using Oreo.VersionBuilder.Commons;
using Oreo.VersionBuilder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.TxtUtils;

namespace Oreo.VersionBuilder.Views
{
    public partial class MainForm : Form
    {
        string NowOpenFile = "";
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        #region 菜单项
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            TsslRunStatus.Text = "新建版本文件";
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "版本文件|*.version|文本文档|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                NowOpenFile = file;
                if (!string.IsNullOrWhiteSpace(file))
                {
                    VersionModel vm = JsonTool.ToObjFromFile<VersionModel>(file);
                    if (vm != null)
                    {
                        TbCodeName.Text = vm.CodeName;
                        TbVersionNumber.Text = vm.VersionNumber;
                        TbVersionDesc.Text = vm.VersionDesc;
                        TbServerPath.Text = vm.ServerPath;
                        TbPluginName.Text = vm.PluginName;
                        TbPluginEntry.Text = vm.PluginEntry;
                        TbBeforeUpdateStartProcess.Text = string.Join(",", vm.BeforeUpdateStartProcess);
                        TbBeforeUpdateKillProcess.Text = string.Join(",", vm.BeforeUpdateKillProcess);
                        TbAfterUpdateStartProcess.Text = string.Join(",", vm.AfterUpdateStartProcess);
                        TbAfterUpdateKillProcess.Text = string.Join(",", vm.AfterUpdateKillProcess);
                        if (ListTool.HasElements(vm.FileList))
                        {
                            vm.FileList.ForEach(f =>
                            {
                                DgFileList.Rows.Add(new object[] {
                                    f.ServerFile,f.LocalFile,f.FileMD5,f.IsClean
                                });
                            });
                        }
                        TsslRunStatus.Text = "已打开：" + Path.GetFileName(NowOpenFile);
                    }
                    else
                    {
                        TsslRunStatus.Text = "打开：" + Path.GetFileName(NowOpenFile) + " 失败！";
                    }
                }
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void 生成配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionModel vm = GatherModel();
            string vmJson = JsonTool.ToStr(vm);
            string vmFile = string.IsNullOrWhiteSpace(NowOpenFile) ?
                R.Paths.VersionFile + string.Format("{0}.version", DateTime.Now.ToString("MMddHHmmss")) :
                NowOpenFile;

            TxtTool.Create(vmFile, vmJson);
            TsslRunStatus.Text = "构建成功：" + Path.GetFileName(vmFile);
        }
        private void 生成配置到指定目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = R.Paths.VersionFile;
            fileDialog.Filter = "版本文件|*.version";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                VersionModel vm = GatherModel();
                string vmJson = JsonTool.ToStr(vm);
                TxtTool.Create(fileDialog.FileName, vmJson);
                TsslRunStatus.Text = "构建成功：" + Path.GetFileName(fileDialog.FileName);
            }
        }
        private void 打开默认配置目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", R.Paths.VersionFile);
            TsslRunStatus.Text = "已打开默认输出目录";
        }
        #endregion

        #region 按钮项
        private void BtImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择要导入的文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                List<string> fileList = FileTool.GetAllFile(foldPath);
                if (ListTool.HasElements(fileList))
                {
                    FileCodeTool fc = new FileCodeTool();
                    fileList.ForEach(x =>
                    {
                        string relativePath = x.Replace(foldPath, "");
                        DgFileList.Rows.Add(new object[] {
                            relativePath, relativePath,fc.GetMD5(x), false });
                    });
                }
            }
        }
        private void BtAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FileCodeTool fc = new FileCodeTool();
                DgFileList.Rows.Add(new object[] {
                    fileDialog.FileName, fileDialog.FileName,
                    fc.GetMD5(fileDialog.FileName),  false });
            }
        }
        private void BtClear_Click(object sender, EventArgs e)
        {
            DgFileList.Rows.Clear();
        }
        #endregion
        private VersionModel GatherModel()
        {
            VersionModel rs = new VersionModel()
            {
                CodeName = TbCodeName.Text.Trim(),
                VersionNumber = TbVersionNumber.Text.Trim(),
                VersionDesc = TbVersionDesc.Text.Trim(),
                ServerPath = TbServerPath.Text.Trim(),
                PluginName = TbPluginName.Text.Trim(),
                PluginEntry = TbPluginEntry.Text.Trim(),
                BeforeUpdateStartProcess = TbBeforeUpdateStartProcess.Text.Trim().Split(','),
                BeforeUpdateKillProcess = TbBeforeUpdateKillProcess.Text.Trim().Split(','),
                AfterUpdateStartProcess = TbAfterUpdateStartProcess.Text.Trim().Split(','),
                AfterUpdateKillProcess = TbAfterUpdateKillProcess.Text.Trim().Split(','),
            };
            if (DgFileList.Rows.Count > 0)
            {
                rs.FileList = new List<VersionFile>();
                foreach (DataGridViewRow row in DgFileList.Rows)
                {
                    rs.FileList.Add(new VersionFile()
                    {
                        ServerFile = row.Cells["ClFileListServer"].Value.ToString(),
                        LocalFile = row.Cells["ClFileListLocal"].Value.ToString(),
                        FileMD5 = row.Cells["ClFileListMD5"].Value.ToString(),
                        IsClean = (bool)row.Cells["ClFileListClean"].Value,
                    });
                }
            }
            return rs;
        }
        private void Clear()
        {
            NowOpenFile = "";
            TbCodeName.Text = "";
            TbVersionNumber.Text = "";
            TbVersionDesc.Text = "";
            TbServerPath.Text = "";
            TbPluginName.Text = "";
            TbPluginEntry.Text = "";
            TbBeforeUpdateStartProcess.Text = "";
            TbBeforeUpdateKillProcess.Text = "";
            TbAfterUpdateStartProcess.Text = "";
            TbAfterUpdateKillProcess.Text = "";
            DgFileList.Rows.Clear();
        }


    }
}
