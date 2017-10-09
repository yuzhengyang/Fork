using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Y.Skin.YoControl
{
    public partial class UserControlPlus : UserControl
    {
        public UserControlPlus()
        {
            InitializeComponent();
        }

        private void UserControlPlus_Load(object sender, EventArgs e)
        {

        }
        protected void UIVisible(Control ctrl, bool visible = true)
        {
            Invoke(new Action(() =>
            {
                ctrl.Visible = visible;
            }));
        }
        protected void UIEnable(Control ctrl, bool enable = true)
        {
            Invoke(new Action(() =>
            {
                ctrl.Enabled = enable;
            }));
        }
    }
}
