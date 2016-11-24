using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Y.Utils.OfficeUtils
{
    class WordHelperTester
    {
        static void Main(string[] args)
        {
            int tsize = 5;
            List<Dictionary<string, object>> test = new List<Dictionary<string, object>>();
            for (int i = 0; i < 10; i++)
            {
                Dictionary<string, object> q = new Dictionary<string, object>();
                q.Add("title", string.Format("第{0}题：{0}{0}{0}{0}", i));
                q.Add("content", "长期从事电脑操作者，应多吃一些新鲜的蔬菜和水果，同时增加维生素A、B1、C、E的摄入。为预防角膜干燥、眼干涩、视力下降、甚至出现夜盲等，电 脑操作者应多吃富含维生素A的食物，如豆制品、鱼、牛奶、核桃、青菜、大白菜、空心菜、西红柿及新鲜水果等。");
                q.Add("image", @"C:\Users\Administrator\Pictures\1.jpg");
                test.Add(q);
            }

            WordHelper report = new WordHelper();
            report.CreateNewDocument(@"F:\模板1.docx"); //模板路径
            report.InsertValue("name", "测试考试");//在书签“Bookmark_value”处插入值
            Table table = report.InsertTable("content", test.Count() * tsize, 1, 0); //在书签“Bookmark_table”处插入2行3列行宽最大的表
            report.UseBorder(1, 0); //模板中第一个表格使用实线边框

            for (int i = 0; i < test.Count(); i++)
            {


                //string picturePath = t["image"].ToString();
                //report.InsertPicture("content", picturePath, 150, 150); //书签位置，图片路径，图片宽度，图片高度

                //string content = t["content"].ToString();
                //report.InsertText("content", content);

                //string title = t["title"].ToString();
                //report.InsertText("content", title);

                report.InsertCell(table, 1 + (i * tsize), 1, test[i]["title"].ToString());//表名,行号,列号,值
                report.InsertCell(table, 2 + (i * tsize), 1, test[i]["content"].ToString());//表名,行号,列号,值
                report.InsertCell(table, 3 + (i * tsize), 1, test[i]["image"].ToString(), 150, 150, i + 1);//表名,行号,列号,值

            }

            report.SaveDocument(@"F:\doc1.doc"); //文档路径
            Console.WriteLine("please input enter to exit.");
            Console.ReadLine();
        }
    }
}
