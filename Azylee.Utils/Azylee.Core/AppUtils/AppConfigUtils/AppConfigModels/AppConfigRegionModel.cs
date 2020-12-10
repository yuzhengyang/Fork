using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels
{
    public class AppConfigRegionModel<T> where T : IAppConfigItemModel
    {
        public List<T> Items { get; set; }

        public AppConfigRegionModel()
        {
            this.Items = new List<T>();
        }
        public bool HasItems()
        {
            return Ls.Ok(Items);
        }
        public void AddItem(T item, bool overwrite = false)
        {
            bool repeat = false;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].GetUniqueName() == item.GetUniqueName())
                {
                    if (overwrite) { Items[i] = item; }
                    repeat = true;
                }
            }
            if (!repeat) { this.Items.Add(item); }
        }
        public void RemoveItem(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].GetUniqueName() == name)
                {
                    Items.RemoveAt(i);
                    break;
                }
            }
        }
        public T GetItem(string name)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].GetUniqueName() == name)
                {
                    return Items[i];
                }
            }
            return default(T);
        }
        public void OrderByNumber()
        {
            Items = Items.OrderBy(x => x.GetOrderNumber()).ThenBy(x => x.GetUniqueName()).ToList();
        }
        public List<string> GetNames()
        {
            List<string> rs = new List<string>();
            foreach (var item in Items)
            {
                rs.Add(item.GetUniqueName());
            }
            return rs;
        }
    }
}
