using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.WinformSkin.UserWidgets.PageWidgets
{
    public class PageDataProviderArgs
    {
        public PageDataProviderArgs()
        {

        }
        public PageDataProviderArgs(int current, int pageSize)
        {
            Current = current;
            PageSize = pageSize;
        }
        public PageDataProviderArgs(int current, int pageSize, int total)
        {
            Current = current;
            Total = total;
            PageSize = pageSize;
        }
        public int Current { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
    }
}
