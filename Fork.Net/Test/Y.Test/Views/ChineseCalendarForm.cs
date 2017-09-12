using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Skin.YoForm.CustomTitle;

namespace Y.Test.Views
{
    public partial class ChineseCalendarForm : DarkTitleShadowForm
    {
        public ChineseCalendarForm()
        {
            InitializeComponent();
        }

        private void ChineseCalendarForm_Load(object sender, EventArgs e)
        {
            ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();
            label1.Text = string.Format("{0}年{1}月{2}日", clc.GetYear(DateTime.Now), clc.GetMonth(DateTime.Now), clc.GetDayOfMonth(DateTime.Now));
        }
    }
}
