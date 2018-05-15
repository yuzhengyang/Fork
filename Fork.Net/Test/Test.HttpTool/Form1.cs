using Azylee.Core.Plus.DataUtils.JsonUtils;
using Azylee.YeahWeb.HttpUtils;
using EasyHttp.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Test.HttpTool.Models;

namespace Test.HttpTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserModel user = new UserModel()
            {
                Account = "123",
                Mac = "999",
                Data = "ajfgdkvjdhgrewiuyhnb数据"
            };

            string s = JsonTool.ToStr(user);
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                { "account","account"},{ "mac","mac123"},{ "data","somedata"},
            };
            CookieCollection cookie = new CookieCollection();
            string html = HttpToolPlus.Post("http://localhost:9091/xtest/post1", ref cookie, data, Encoding.UTF8);


            var http = new HttpClient();
            var httpRs = http.Post("http://localhost:9091/xtest/post3", user, HttpContentTypes.ApplicationJson);
        }
    }
}
