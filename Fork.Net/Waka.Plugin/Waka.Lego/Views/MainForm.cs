using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waka.Lego.Commons;
using Y.Utils.IOUtils.LogUtils;
using Y.Utils.ReflectionUtils.ReflectionCoreUtils;

namespace Waka.Lego.Views
{
    public partial class MainForm : Form
    {
        string[] plugins = new string[] {
                @"D:\CoCo\GitHub\Fork\Fork.Net\Waka.Lego\bin\Debug\Bin\Plugins\Waka.Lego.Baidu\Waka.Lego.Baidu.dll" ,
                @"D:\CoCo\GitHub\Fork\Fork.Net\Waka.Lego\bin\Debug\Bin\Plugins\Waka.Lego.Icon\Waka.Lego.Icon.exe",
                @"D:\CoCo\GitHub\Fork\Fork.Net\Waka.Lego\bin\Debug\Bin\Plugins\Waka.Lego.Music\Waka.Lego.Music.dll"};

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            foreach (var p in plugins)
            {
                Assembly ass = Assembly.LoadFile(p);
                dataGridView1.Rows.Add(string.Format("Name:{0}, Path:{1}", ass.FullName, p));
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index < plugins.Count())
            {
                try
                {
                    SimpleReflection sr = new SimpleReflection();
                    Form form = sr.Do<Form>(plugins[dataGridView1.CurrentRow.Index], "LegoRun", "Run", null, null);
                    form.Show();
                }
                catch { }
            }
        }
    }
}
