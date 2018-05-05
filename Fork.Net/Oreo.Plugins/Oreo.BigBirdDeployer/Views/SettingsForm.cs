using Azylee.Core.IOUtils.TxtUtils;
using Oreo.BigBirdDeployer.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TBPublishStorage.Text = R.Paths.PublishStorage;
            TBNewStorage.Text = R.Paths.NewStorage;
        }
        private void BTSave_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void BTCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool Save()
        {
            bool flag = false;
            if (!string.IsNullOrWhiteSpace(TBPublishStorage.Text))
            {
                if (Directory.Exists(TBPublishStorage.Text))
                {
                    R.Paths.PublishStorage = TBPublishStorage.Text;
                    IniTool.WriteValue(R.Files.Settings, "Paths", "PublishStorage", R.Paths.PublishStorage);
                    flag = true;
                }
                else
                {
                    LBDesc.Text = "发布资料库目录不存在";
                }
            }
            else
            {
                R.Paths.PublishStorage = R.Paths.DefaultPublishStorage;
                IniTool.WriteValue(R.Files.Settings, "Paths", "PublishStorage", R.Paths.PublishStorage);
                flag = true;
            }

            if (!string.IsNullOrWhiteSpace(TBNewStorage.Text))
            {
                if (Directory.Exists(TBNewStorage.Text))
                {
                    R.Paths.NewStorage = TBNewStorage.Text;
                    IniTool.WriteValue(R.Files.Settings, "Paths", "NewStorage", R.Paths.NewStorage);
                    flag = true;
                }
                else
                {
                    LBDesc.Text = "新增资料库目录不存在";
                }
            }
            else
            {
                R.Paths.NewStorage = R.Paths.DefaultNewStorage;
                IniTool.WriteValue(R.Files.Settings, "Paths", "NewStorage", R.Paths.NewStorage);
                flag = true;
            }
            return flag;
        }


    }
}
