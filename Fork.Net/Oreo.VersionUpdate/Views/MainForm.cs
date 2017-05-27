using Oreo.VersionUpdate.Commons;
using Oreo.VersionUpdate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;

namespace Oreo.VersionUpdate.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void StartUpdate()
        {
            Task.Factory.StartNew(() =>
            {
                //读取标准更新最新版本号 获取需要标准更新的配置
                StartUpdateStandard();

                //使用本地插件名称和版本号 获取需要更新插件的配置
                StartUpdatePlugin();
            });
        }
        private void StartUpdateStandard()
        {
            R.Log.i("读取标准更新版本号");
            string versionNumber = GetStandardVersionNumber();
        }
        private void StartUpdatePlugin()
        {
            R.Log.i("读取本地插件列表（名称、版本号）");
            List<PluginModel> pluginList = GetPluginList();
            if (ListTool.HasElements(pluginList))
            {
                R.Log.i("共读取到 " + pluginList.Count + " 个插件");
                pluginList.ForEach(x =>
                {
                    R.Log.i("请求 " + x.Name + " / " + x.Version + " 插件的更新");
                    VersionModel pluginNewVersion = GetPluginNewVersion(x);
                    if (pluginNewVersion != null)
                    {
                        R.Log.i(x.Name + " / " + x.Version + " 插件有新版本 " + pluginNewVersion.VersionNumber + " 需要更新，准备更新");
                        bool flag = Update(pluginNewVersion);
                        if (flag)
                        {
                            R.Log.i(x.Name + " 更新成功，当前版本" + pluginNewVersion.VersionNumber);
                        }
                        else
                        {
                            R.Log.w(x.Name + " 更新失败");
                        }
                    }
                });
            }
            else
            {
                R.Log.w("本地插件列表为空");
            }
            R.Log.i("本地插件更新操作结束");
        }
        #region 读取本地数据操作
        private List<PluginModel> GetPluginList()
        {
            List<PluginModel> rs = null;
            return rs;
        }
        private string GetStandardVersionNumber()
        {
            string rs = "";
            return rs;
        }
        #endregion
        #region 读取网络数据操作
        private VersionModel GetPluginNewVersion(PluginModel pm)
        {
            VersionModel rs = null;
            return rs;
        }
        #endregion
        #region 更新操作
        private bool Update(VersionModel vm)
        {
            return false;
        }
        #endregion
        #region UI操作
        /// <summary>
        /// 退出程序
        /// </summary>
        void UIClose()
        {
            Invoke(new Action(() =>
            {
                Close();
            }));
        }
        #endregion


    }
}
