using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Test.Commons;

namespace Y.Test.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChineseCalendarForm_Click(object sender, EventArgs e)
        {
            R.Forms.Get<ChineseCalendarForm>().Show();
        }

        private void TestComputerInfoForm_Click(object sender, EventArgs e)
        {
            R.Forms.Get<TestComputerInfoForm>().Show();
        }
    }
}
