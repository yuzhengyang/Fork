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
        private int Border = 1;
        Color BorderColor = Color.Black;
        public NoTitleForm()
        {
            InitializeComponent();
        }
        private void NoTitleForm_Load(object sender, EventArgs e)
        {
            SetBorder();
        }
        /// <summary>
        /// 设置无标题窗口可拖动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            FormStyleAPI.ReleaseCapture();
            FormStyleAPI.SendMessage(Handle, FormStyleAPI.WM_NCLBUTTONDOWN, FormStyleAPI.HTCAPTION, 0);
        }
        /// <summary>
        /// 设置窗口边框
        /// </summary>
        protected void SetBorder()
        {
            Label BorderTop = new Label();
            BorderTop.BackColor = BorderColor;
            BorderTop.Width = Width;
            BorderTop.Height = Border;
            Controls.Add(BorderTop);
            BorderTop.BringToFront();
            BorderTop.Top = 0;
            BorderTop.Left = 0;

            Label BorderBottom = new Label();
            BorderBottom.BackColor = BorderColor;
            BorderBottom.Width = Width;
            BorderBottom.Height = Border;
            Controls.Add(BorderBottom);
            BorderBottom.BringToFront();
            BorderBottom.Top = Height - Border;
            BorderBottom.Left = 0;

            Label BorderLeft = new Label();
            BorderLeft.BackColor = BorderColor;
            BorderLeft.Width = Border;
            BorderLeft.Height = Height;
            Controls.Add(BorderLeft);
            BorderLeft.BringToFront();
            BorderLeft.Top = 0;
            BorderLeft.Left = 0;

            Label BorderRight = new Label();
            BorderRight.BackColor = BorderColor;
            BorderRight.Width = Border;
            BorderRight.Height = Height;
            Controls.Add(BorderRight);
            BorderRight.BringToFront();
            BorderRight.Top = 0;
            BorderRight.Left = Width - Border;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Graphics g = CreateGraphics();
            //g.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(0, 0, Width, Height));
        }

    }
}
