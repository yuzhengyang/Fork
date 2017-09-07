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
            R.Forms.GetUnique<ChineseCalendarForm>().Show();
        }

        private void TestComputerInfoForm_Click(object sender, EventArgs e)
        {
            R.Forms.GetUnique<TestComputerInfoForm>().Show();
        }

        private void TestUpdateForm_Click(object sender, EventArgs e)
        {
            R.Forms.GetUnique<TestUpdateForm>().Show();
        }

        private void TestPackForm_Click(object sender, EventArgs e)
        {
            R.Forms.GetUnique<TestPackForm>().Show();
        }

        private void TestIconGroupForm_Click(object sender, EventArgs e)
        {
            R.Forms.GetUnique<TestIconGroupForm>().Show();
        }

        private void TestShadowForm_Click(object sender, EventArgs e)
        {
            R.Forms.GetUnique<TestShadowForm>().Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
