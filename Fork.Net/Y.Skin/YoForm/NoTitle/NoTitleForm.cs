using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Utils.WindowsUtils.APIUtils;

namespace Y.Skin.YoForm.NoTitle
{
    public partial class NoTitleForm : Form
    {
        public NoTitleForm()
        {
            InitializeComponent();
        }
        private void NoTitleForm_Load(object sender, EventArgs e)
        {

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            FormStyleAPI.ReleaseCapture();
            FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = CreateGraphics();
            g.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(0, 0, Width, Height));
        }
    }
}
