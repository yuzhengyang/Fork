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
using Y.Utils.WindowsUtils.HookUtils;

namespace Y.Test.Views
{
    public partial class TestInputForm : Form
    {
        private static UserActivityHook Hook;
        public TestInputForm()
        {
            InitializeComponent();
        }

        private void TestInputForm_Load(object sender, EventArgs e)
        {
            Hook = new UserActivityHook(Assembly.GetExecutingAssembly().GetModules()[0]);
            Hook.OnMouseActivity += new MouseEventHandler(mouseHandler);
            Hook.KeyDown += new KeyEventHandler(keyHandler);
            Hook.Start();
        }
        private void mouseHandler(object sender, MouseEventArgs e)
        {
            Invoke(new Action(() =>
            {
                //textBox1.AppendText("[click1]");
            }));
        }
        private void keyHandler(object sender, KeyEventArgs e)
        {
            Invoke(new Action(() =>
            {
                textBox1.AppendText("[press" + e.KeyCode + "]");
            }));
        }
    }
}
