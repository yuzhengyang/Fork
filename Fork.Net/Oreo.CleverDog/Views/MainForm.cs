using Oreo.CleverDog.Helpers;
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

namespace Oreo.CleverDog.Views
{
    public partial class MainForm : IrregularForm
    {
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                // 第一步 判断本机是否存在目标程序
                if (!FrisbeeHelper.IsSoftExist())
                {
                    // 第二步 下载程序
                    if (FrisbeeHelper.DownFileAndRun())
                    {
                        // 第三部 运行程序
                        FrisbeeHelper.RunOtherApp();
                        FrisbeeHelper.SuccGetUrl();
                    }
                }

                Invoke(new Action(() =>
                {
                    Close();
                }));
            });
        }
    }
}
