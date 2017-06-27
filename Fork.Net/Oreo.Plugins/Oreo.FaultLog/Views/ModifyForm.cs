using Oreo.FaultLog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Skin.YoForm.NoTitle;

namespace Oreo.FaultLog.Views
{
    public partial class ModifyForm : NoTitleForm
    {
        public int Id { get; set; }
        public ModifyForm(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
            faultLogModifyPartial1.InitInfo(Id);
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (faultLogModifyPartial1.SaveInfo())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
