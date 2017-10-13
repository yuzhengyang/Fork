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
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;

namespace Oreo.FilePackage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTPack_Click(object sender, EventArgs e)
        {
            string src = TBPath.Text;
            string file = Path.GetFileName(src) + ".package";
            string dst = DirTool.Combine(DirTool.GetFilePath(TBPath.Text), file);
            FilePackageTool.Pack(src, dst);
        }

        private void TBPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
