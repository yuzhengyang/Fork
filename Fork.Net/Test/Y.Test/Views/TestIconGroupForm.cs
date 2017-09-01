using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Test.Properties;
using Y.Utils.IOUtils.ImageUtils;

namespace Y.Test.Views
{
    public partial class TestIconGroupForm : Form
    {
        public TestIconGroupForm()
        {
            InitializeComponent();
        }

        private void TestIconGroupForm_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = ImageSpliter.Get(Resources.icongroup_01, 50, 50, 1, 1);
            //pictureBox2.Image = ImageSpliter.Get(Resources.icongroup_01, 50, 50, 2, 1);
            //pictureBox3.Image = ImageSpliter.Get(Resources.icongroup_01, 50, 50, 3, 1);
        }
    }
}
