using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Skin.YoForm.NoTitle;

namespace Oreo.FileMan.Views
{
    public partial class FileRestoreForm : NoTitleForm
    {
        public FileRestoreForm()
        {
            InitializeComponent();
        }

        private void FileRestoreForm_Load(object sender, EventArgs e)
        {

        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
