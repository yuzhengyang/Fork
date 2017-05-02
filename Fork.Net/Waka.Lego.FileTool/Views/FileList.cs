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
    public partial class FileList : Form
    {
        public List<string> Files { get; set; }
        public FileList(List<string> files)
        {
            InitializeComponent();
            Files = files;
        }

        private void FileList_Load(object sender, EventArgs e)
        {
            Files.ForEach(x =>
            {
                listBox1.Items.Add(x);
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            throw new Exception();
        }
    }
}
