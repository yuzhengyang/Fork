using System;
using System.Windows.Forms;

namespace Y.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }
        void Application_Idle(object sender, EventArgs e)
        {
            //if (embedPanel1.IsStarted)
            //    MessageBox.Show(string.Format("{0}", embedPanel1.AppProcess.MainWindowHandle));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //flexiblePanel1.InitMouseAndContolStyle();
            //embedPanel1.AppFilename = @"D:\Temp\n.exe";
            embedPanel1.Start();
        }
    }
}
