//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Windows.Forms;

namespace Y.Skin.YoForm.Toast
{
    public partial class ToastForm : Form
    {
        #region How to use?
        //ToastForm _ToastForm = null;
        //public void Toast(string s = "")
        //{
        //    if (_ToastForm == null || _ToastForm.IsDisposed)
        //        _ToastForm = new ToastForm(this);

        //    _ToastForm.Toast(s);
        //}
        #endregion

        Form BaseForm;
        DateTime HideTime = DateTime.Now;
        int Showtime = 5;
        public ToastForm(Form form)
        {
            InitializeComponent();
            BaseForm = form;
        }

        private void ToastForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            ShowInTaskbar = false;
        }
        private void SetPosition()
        {
            Top = BaseForm.Top + (BaseForm.Height / 2) - (Height / 2);
            Left = BaseForm.Left + (BaseForm.Width / 2) - (Width / 2);
        }
        public void Toast()
        {
            BaseForm.BeginInvoke(new Action(() =>
            {
                Show();
                HideTime = DateTime.Now.AddSeconds(Showtime);
                SetPosition();
                TmActor.Interval = 1000;
                TmActor.Enabled = true;
            }));
        }
        public void Toast(string s)
        {
            BaseForm.BeginInvoke(new Action(() =>
            {
                LbMsg.Text = s;
                Show();
                HideTime = DateTime.Now.AddSeconds(Showtime);
                SetPosition();
                TmActor.Interval = 1000;
                TmActor.Enabled = true;
            }));
        }

        private void TmActor_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > HideTime)
            {
                Hide();
                TmActor.Enabled = false;
            }
        }
    }
}
