using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;

namespace Oreo.FileMan.Partials
{
    public partial class FileBackupPartial : UserControl
    {
        List<string> BackupFolder = new List<string>();
        public FileBackupPartial()
        {
            InitializeComponent();
        }

        private void BtAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择要备份的文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int row = DgvPath.Rows.Count;
                UIEnableButton(false);
                string foldPath = dialog.SelectedPath;
                BackupFolder.Add(foldPath);
                UIDgvPathAdd(Path.GetFileName(foldPath));
                long size = 0;

                Task.Factory.StartNew(() =>
                {
                    List<string> files = FileTool.GetAllFile(foldPath);
                    if (ListTool.HasElements(files))
                    {
                        foreach (var f in files)
                        {
                            size += FileTool.Size(f);
                            UIDgvPathUpdate(row, Path.GetFileName(foldPath), ByteConvertTool.Fmt(size));
                        }
                    }
                    UIEnableButton(true);
                });
            }
        }
        private void BtDelFolder_Click(object sender, EventArgs e)
        {
            UIDgvPathDel();
        }
        void UIEnableButton(bool enable)
        {
            BeginInvoke(new Action(() =>
            {
                BtAddFolder.Enabled = enable;
            }));
        }
        void UIDgvPathAdd(string path)
        {
            BeginInvoke(new Action(() =>
            {
                DgvPath.Rows.Add(new object[] { Path.GetFileName(path), "-" });
            }));
        }
        void UIDgvPathDel()
        {
            BeginInvoke(new Action(() =>
            {
                if (DgvPath.CurrentRow != null)
                {
                    int row = DgvPath.CurrentRow.Index;
                    if (row >= 0)
                    {
                        DgvPath.Rows.RemoveAt(row);
                    }
                }
            }));
        }
        void UIDgvPathUpdate(int row, string path, string size)
        {
            BeginInvoke(new Action(() =>
            {
                DgvPath.Rows[row].SetValues(new object[] { Path.GetFileName(path), size });
            }));
        }


    }
}
