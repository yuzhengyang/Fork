using Oreo.VersionBuilder.Commons;
using Oreo.VersionBuilder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.TxtUtils;

namespace Oreo.VersionBuilder.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void 生成配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionModel vm = GatherModel();
            string vmJson = JsonTool.ToStr(vm);
            TxtTool.Create(R.Paths.VersionFile + string.Format("{0}.version", DateTime.Now.ToString("MMddHHmmss")), vmJson);
        }



        private void 打开默认配置目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", R.Paths.VersionFile);
        }

        private VersionModel GatherModel()
        {
            VersionModel rs = new VersionModel()
            {
                CodeName = TbCodeName.Text.Trim(),
                VersionNumber = TbVersionNumber.Text.Trim(),
                VersionDesc = TbVersionDesc.Text.Trim(),
                ServerPath = TbServerPath.Text.Trim(),
                IsPlugin = CbIsPlugin.Checked,
                PluginName = TbPluginName.Text.Trim(),
                PluginEntry = TbPluginEntry.Text.Trim(),
                BeforeUpdateStartProcess = TbBeforeUpdateStartProcess.Text.Trim().Split(','),
                BeforeUpdateKillProcess = TbBeforeUpdateKillProcess.Text.Trim().Split(','),
                AfterUpdateStartProcess = TbAfterUpdateStartProcess.Text.Trim().Split(','),
                AfterUpdateKillProcess = TbAfterUpdateKillProcess.Text.Trim().Split(','),
            };
            return rs;
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TbCodeName.Text = "";
            TbVersionNumber.Text = "";
            TbVersionDesc.Text = "";
            TbServerPath.Text = "";
            CbIsPlugin.Checked = false;
            TbPluginName.Text = "";
            TbPluginEntry.Text = "";
            TbBeforeUpdateStartProcess.Text = "";
            TbBeforeUpdateKillProcess.Text = "";
            TbAfterUpdateStartProcess.Text = "";
            TbAfterUpdateKillProcess.Text = "";
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "版本文件|*.version|文本文档|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                if (!string.IsNullOrWhiteSpace(file))
                {
                    VersionModel vm = JsonTool.ToObjFromFile<VersionModel>(file);
                    if (vm != null)
                    {
                        TbCodeName.Text = vm.CodeName;
                        TbVersionNumber.Text = vm.VersionNumber;
                        TbVersionDesc.Text = vm.VersionDesc;
                        TbServerPath.Text = vm.ServerPath;
                        CbIsPlugin.Checked = vm.IsPlugin;
                        TbPluginName.Text = vm.PluginName;
                        TbPluginEntry.Text = vm.PluginEntry;
                        TbBeforeUpdateStartProcess.Text = string.Join(",", vm.BeforeUpdateStartProcess);
                        TbBeforeUpdateKillProcess.Text = string.Join(",", vm.BeforeUpdateKillProcess.ToString());
                        TbAfterUpdateStartProcess.Text = string.Join(",", vm.AfterUpdateStartProcess.ToString());
                        TbAfterUpdateKillProcess.Text = string.Join(",", vm.AfterUpdateKillProcess.ToString());
                    }
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
