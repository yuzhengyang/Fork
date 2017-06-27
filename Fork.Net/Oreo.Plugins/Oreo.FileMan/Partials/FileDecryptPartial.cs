using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DelegateUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.DataUtils.Collections;
using System.IO;

namespace Oreo.FileMan.Partials
{
    public partial class FileDecryptPartial : UserControl
    {
        public FileDecryptPartial()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 执行文件解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileDecrypt_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            string password = TbFileDecryptPassword.Text;
            Task.Factory.StartNew(() =>
            {
                int index = 0;
                foreach (DataGridViewRow row in DgvFileDecryptList.Rows)
                {
                    string file = row.Cells["CoFileDecryptName"].Value.ToString();
                    string newfile = file.Substring(0, file.Length - FileEncryptTool.FileExt.Length);
                    int flag;
                    UIFileDecryptStatus(index, "分析文件...");
                    if ((flag = FileEncryptTool.Decrypt(file, newfile, password, UIFileDecryptProgress, index)) > 0)
                    {
                        UIFileDecryptStatus(index, "成功");
                        if (CbFileDecryptDelete.Checked)
                        {
                            FileTool.Delete(file);
                        }
                    }
                    else
                    {
                        UIFileDecryptStatus(index, "失败:" + flag);
                    }
                    index++;
                }
                BeginInvoke(new Action(() => { ((Button)sender).Enabled = true; }));
            });
        }
        /// <summary>
        /// 添加要解密的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileDecryptAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择要解密的文件";
            fileDialog.Filter = "加密文件|*" + FileEncryptTool.FileExt;
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (ListTool.HasElements(fileDialog.FileNames))
                    foreach (var file in fileDialog.FileNames)
                    {
                        DgvFileDecryptList.Rows.Add(new object[] { file, "准备" });
                    }
            }
        }
        /// <summary>
        /// 批量导入要解密的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileDecryptAdds_Click(object sender, EventArgs e)
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
                        if (Path.GetExtension(x) == FileEncryptTool.FileExt)
                            DgvFileDecryptList.Rows.Add(new object[] { x, "准备" });
                    });
                }
            }
        }
        /// <summary>
        /// 清空文件列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFileDecryptClear_Click(object sender, EventArgs e)
        {
            DgvFileDecryptList.Rows.Clear();
        }
        /// <summary>
        /// 更新解密进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIFileDecryptProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                DgvFileDecryptList.Rows[(int)sender].Cells["CoFileDecryptStatus"].Value =
                (e.Current * 100 / e.Total) + " %";
            }));
        }
        /// <summary>
        /// 更新解密文件的状态
        /// </summary>
        /// <param name="index"></param>
        /// <param name="status"></param>
        private void UIFileDecryptStatus(int index, string status)
        {
            BeginInvoke(new Action(() =>
            {
                DgvFileDecryptList.Rows[index].Cells["CoFileDecryptStatus"].Value = status;
            }));
        }
        void UIEnableButton(bool enable)
        {
            BeginInvoke(new Action(() =>
            {
                BtFileDecrypt.Enabled = enable;
                BtFileDecryptAdd.Enabled = enable;
                BtFileDecryptAdds.Enabled = enable;
                BtFileDecryptClear.Enabled = enable;
            }));
        }
    }
}
