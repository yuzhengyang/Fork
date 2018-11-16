using Azylee.Core.DrawingUtils.ImageUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.ImageToolTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap b1 = new Bitmap(@"F:\图片压缩测试\未标题-1.jpg");
            byte[] b1_byte = IMG.Compression(b1, 30);
            File.WriteAllBytes(@"F:\图片压缩测试\未标题-1（Compression）.jpg", b1_byte);
        }
    }
}
