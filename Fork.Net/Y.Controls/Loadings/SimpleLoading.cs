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
        public SimpleLoading()
        {
            InitializeComponent();
        }

        private void SimpleLoading_Load(object sender, EventArgs e)
        {

        }
        public void ShowIt()
        {
            Dock = DockStyle.Fill;
            Show();
        }
        public void HideIt()
        {
            Dock = DockStyle.None;
            Hide();
        }
    }
}
