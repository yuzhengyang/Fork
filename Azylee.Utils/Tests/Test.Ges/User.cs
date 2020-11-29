using Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels;
using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ges
{
    public class User : IAppConfigModel
    {
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public List<Tuple<string, string>> School { get; set; }
        public List<Tuple<string, string>> Job { get; set; }
        public AppConfigRegionModel<UserBook> Book { get; set; }

        public User()
        {
            School = new List<Tuple<string, string>>();
            School.Add(new Tuple<string, string>("2000", "幼儿园"));
            School.Add(new Tuple<string, string>("2005", "小学"));
            School.Add(new Tuple<string, string>("2010", "初中"));
            School.Add(new Tuple<string, string>("2013", "高中"));
            Job = new List<Tuple<string, string>>();
            Book = new AppConfigRegionModel<UserBook>();
        }

        public void ForceSet()
        {
            this.Name = "张无忌";
            if (!Ls.ok(Job))
            {
                Job = new List<Tuple<string, string>>();
                Job.Add(new Tuple<string, string>("2010", "志愿者工作-01"));
                Job.Add(new Tuple<string, string>("2015", "志愿者工作-02"));
            }

            if (Book == null) 
            Book.AddItem(new UserBook() { Number = 0, Name = "三国演义", Page = 5000, Price = 200 });
            Book.AddItem(new UserBook() { Number = 1, Name = "红楼梦", Page = 8000, Price = 260 });
            Book.AddItem(new UserBook() { Number = 2, Name = "西游记", Page = 9000, Price = 180 });
            Book.AddItem(new UserBook() { Number = 3, Name = "水浒传", Page = 2000, Price = 100 });
            Book.AddItem(new UserBook() { Name = "C#", Page = 1000, Price = 80 });
            Book.AddItem(new UserBook() { Number = 15, Name = "JAVA", Page = 1200, Price = 20.99 });
            Book.OrderByNumber();


            Job.Add(new Tuple<string, string>("2010", "志愿者工作-99"));
        }
    }
}
