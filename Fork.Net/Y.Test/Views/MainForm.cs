using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Skin.YoForm.Irregular;
using Y.Skin.YoForm.Toast;

namespace Y.Test.Views
{
    public partial class MainForm : IrregularForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        ToastForm _ToastForm = null;
        public void Toast(string s = "")
        {
            if (_ToastForm == null || _ToastForm.IsDisposed)
                _ToastForm = new ToastForm(this);

            _ToastForm.Toast(s);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Toast("");
        }
    }
}
