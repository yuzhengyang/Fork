using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azylee.WinformSkin.UserWidgets
{
    public partial class SuperUserControl : UserControl
    {
        public SuperUserControl()
        {
            InitializeComponent();
        }

        private void SuperUserControl_Load(object sender, EventArgs e)
        {

        }
        #region 界面优化
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN  
                return parms;
            }
        }
        #endregion
    }
}
