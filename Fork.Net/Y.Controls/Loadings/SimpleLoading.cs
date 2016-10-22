using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y.Controls.Loadings
{
    public partial class SimpleLoading : UserControl
    {
        private int _opacity = 125;

        public SimpleLoading()
        {
            InitializeComponent();
        }

        private void SimpleLoading_Load(object sender, EventArgs e)
        {
            
        }

        [Bindable(true), Category("Custom"), DefaultValue(125), Description("背景的透明度. 有效值0-255")]
        public int Opacity
        {
            get { return _opacity; }
            set
            {
                if (value > 255) value = 255;
                else if (value < 0) value = 0;
                _opacity = value;
                this.Invalidate();
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (this._opacity > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(this._opacity, this.BackColor)),
                                         this.ClientRectangle);
            }
        }
        public void Show() {
             
        }
    }
}
