using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Waka.Lego.FileTool.Views
{
    public partial class SearchFile : Form
    {
        public bool IsExist { get; set; }
        public SearchFile(bool isExist)
        {
            InitializeComponent();
            IsExist = isExist;
        }

        private void SearchFile_Load(object sender, EventArgs e)
        {
            label1.Text = "您查找的文件：" + (IsExist ? "存在" : "不存在");
        }
    }
}
