using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y.Test.Views
{
    public partial class TestMove : Form
    {
        public TestMove()
        {
            InitializeComponent();
        }

        private void TestMove_Load(object sender, EventArgs e)
        {

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ReleaseCapture();
            SendMessage(Handle, 0x00A1, 2, 0);
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}
