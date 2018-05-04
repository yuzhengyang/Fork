using Azylee.WinformSkin.FormUI.CustomTitle;
using Oreo.BigBirdDeployer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views
{
    public partial class MainForm : BigIconForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            projectItemPart1.SetProject(new ProjectModel()
            {
                Name = "server",
                Folder = @"F:\2018_5_2\temp\noah_cloud_supply_platform_jar",
                JarFile = "noah-cloud-supply-platform.jar",
                Port = 9090,
            });

            projectItemPart2.SetProject(new ProjectModel()
            {
                Name = "web",
                Folder = @"F:\2018_5_2\temp\noah_cloud_supply_platform_web_jar",
                JarFile = "noah-cloud-supply-platform-web.jar",
                Port = 9091,
            });
        }
    }
}
