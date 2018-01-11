using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azylee.WinformSkin.UserWidgets.PageWidgets
{
    public partial class PageToolBar : SuperUserControl
    {
        public delegate void PageDataProvider(object sender, PageDataProviderArgs e);

        PageDataProvider Provider;
        int PageIndex = 0;
        int PageTotal = 0;
        int PageSize = 0;
        int DataCount = 0;
        bool IsInit = false;

        public PageToolBar()
        {
            InitializeComponent();
        }

        private void PageToolBar_Load(object sender, EventArgs e)
        {

        }
        #region 初始化和修改参数
        public void Init(PageDataProvider provider, int pageIndex, int dataCount, int pageSize)
        {
            if (!IsInit)
            {
                Provider += provider;

                PageIndex = pageIndex;
                PageSize = pageSize;
                DataCount = dataCount;
                PageTotal = DataCount % pageSize == 0 ? DataCount / pageSize : (DataCount / pageSize) + 1;
                IsInit = true;
            }
        }
        public void Init(PageDataProvider provider, int pageIndex, int pageSize)
        {
            Init(provider, pageIndex, pageSize, pageSize);
        }
        /// <summary>
        /// 更新数据总数和页总数
        /// </summary>
        /// <param name="dataCount"></param>
        public void SetDataCount(int dataCount)
        {
            DataCount = dataCount;
            PageTotal = DataCount % PageSize == 0 ? DataCount / PageSize : (DataCount / PageSize) + 1;
            if (!ParentForm.IsDisposed)
            {
                ParentForm.Invoke(new Action(() =>
                {
                    //调整控件展示界面（第几页，共几页）
                    LBPageDesc.Text = string.Format("第 {0} 页，共 {1} 页", PageIndex, PageTotal);
                }));
            }
        }
        #endregion

        #region 操作
        /// <summary>
        /// 加载第一页
        /// </summary>
        public void ReadFirstPage()
        {
            PageIndex = 1;
            QueryPageData(new PageDataProviderArgs(PageIndex, PageSize));
        }
        /// <summary>
        /// 加载默认页（或刷新）
        /// </summary>
        public void ReadDefaultPage()
        {
            PageIndex = PageIndex >= 1 ? PageIndex : 1;
            QueryPageData(new PageDataProviderArgs(PageIndex, PageSize));
        }
        #endregion

        #region 快速跳转按钮
        private void BTPageUpFirst_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            QueryPageData(new PageDataProviderArgs(PageIndex, PageSize));
        }

        private void BTPageUpOne_Click(object sender, EventArgs e)
        {
            PageIndex = PageIndex <= 1 ? 1 : PageIndex - 1;
            QueryPageData(new PageDataProviderArgs(PageIndex, PageSize));
        }

        private void BTPageDownOne_Click(object sender, EventArgs e)
        {
            PageIndex = PageIndex >= PageTotal ? PageTotal : PageIndex + 1;
            QueryPageData(new PageDataProviderArgs(PageIndex, PageSize));
        }

        private void BTPageDownLast_Click(object sender, EventArgs e)
        {
            PageIndex = PageTotal;
            QueryPageData(new PageDataProviderArgs(PageIndex, PageSize));
        }
        #endregion

        #region 获取数据
        private void QueryPageData(PageDataProviderArgs args)
        {
            Provider?.Invoke(this, args);
            //if (dataCount != null) SetDataCount(dataCount.Value);
        }
        #endregion
    }
}
