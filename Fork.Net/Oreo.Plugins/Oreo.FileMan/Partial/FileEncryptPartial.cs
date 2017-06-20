using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DelegateUtils;

namespace Oreo.FileMan.Partial
{
    public partial class FileEncryptPartial : UserControl
    {
        public FileEncryptPartial()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 文件批量加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileEncrypt_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            string password = TbFileEncryptPassword.Text;
            Task.Factory.StartNew(() =>
            {
                int index = 0;
                foreach (DataGridViewRow row in DgvFileEncryptList.Rows)
                {
                    string file = row.Cells["CoFileEncryptName"].Value.ToString();
                    int flag;
                    UIFileEncryptStatus(index, "分析文件...");
                    if ((flag = FileEncryptTool.Encrypt(file, file + FileEncryptTool.FileExt, password, UIFileEncryptProgress, index)) > 0)
                    {
                        UIFileEncryptStatus(index, "成功");
                        if (CbFileEncryptDelete.Checked)
                        {
                            FileTool.Delete(file);
                        }
                    }
                    else
                    {
                        UIFileEncryptStatus(index, "失败:" + flag);
                    }
                    index++;
                }
                BeginInvoke(new Action(() => { ((Button)sender).Enabled = true; }));
            });
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileEncryptAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择要加密的文件";
            fileDialog.Filter = "所有文件|*.*";
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (ListTool.HasElements(fileDialog.FileNames))
                    foreach (var file in fileDialog.FileNames)
                    {
                        DgvFileEncryptList.Rows.Add(new object[] { file, "准备" });
                    }
            }
        }
        /// <summary>
        /// 批量导入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileEncryptAdds_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择要导入的文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                List<string> fileList = FileTool.GetAllFile(foldPath);
                if (ListTool.HasElements(fileList))
                {
                    fileList.ForEach(x =>
                    {
                        DgvFileEncryptList.Rows.Add(new object[] { x, "准备" });
                    });
                }
            }
        }
        /// <summary>
        /// 清空文件列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileEncryptClear_Click(object sender, EventArgs e)
        {
            DgvFileEncryptList.Rows.Clear();
        }
        /// <summary>
        /// 显示当前加密的文件进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIFileEncryptProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                DgvFileEncryptList.Rows[(int)sender].Cells["CoFileEncryptStatus"].Value =
                (e.Current * 100 / e.Total) + " %";
            }));
        }
        /// <summary>
        /// 更新文件状态
        /// </summary>
        /// <param name="index"></param>
        /// <param name="status"></param>
        private void UIFileEncryptStatus(int index, string status)
        {
            BeginInvoke(new Action(() =>
            {
                DgvFileEncryptList.Rows[index].Cells["CoFileEncryptStatus"].Value = status;
            }));
        }
    }
}
