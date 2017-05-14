using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waka.Lego.Commons;
using Y.Utils.IOUtils.LogUtils;

namespace Waka.Lego.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            R.Log.IsWriteFile = true;
            R.Log.LogLevel = LogLevel.Warning | LogLevel.Debug;
            Log.AllocConsole();

            R.Log.v("this is v 啰嗦");
            R.Log.d("this is d 调试");
            R.Log.i("this is i 重要");
            R.Log.w("this is w 警告");
            R.Log.e("this is e 错误");
        }
    }
}
