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
                string foldPath = dialog.SelectedPath;
                BackupFolder.Add(foldPath);
                DgvPath.Rows.Add(new object[] { Path.GetFileName(foldPath), "0KB" });
            }
        }
    }
}
