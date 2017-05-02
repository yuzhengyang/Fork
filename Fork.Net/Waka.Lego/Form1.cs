using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Waka.Lego.Commons;
using Y.Utils.ReflectionUtils.AttributeUtils;
using Y.Utils.ReflectionUtils.ReflectionCoreUtils;

namespace Waka.Lego
{
    public partial class Form1 : Form
    {
        string x = "123123123";
        [Control(Widget = "button1", Click = "DoShowMsg")]
        public Button ShowMsg;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //DoTest();


        }
        [Conditional("DEBUG")]
        void DoTest()
        {
            AppDomain appDomain = DomainTool.CreateDomain(
                "SimpleReflectionDomain",
                @"I:\CoCo\GitHub\ShopSystem\ShopSystem\Waka.Lego\bin\Debug\Bin\Plugins\Waka.Lego.FileTool");

            SimpleReflection sr = DomainTool.CreateInstance<SimpleReflection>(appDomain);
            Form form = sr.Do<Form>(
                R.AppPath + @"Plugins\Waka.Lego.FileTool\Waka.Lego.FileTool.dll",
                "FileController",
                "FileList",
                new object[] { 100 },
                new object[] { R.AppPath + @"Plugins\Waka.Lego.FileTool" });
            form.Show();
        }

        void TestController(object[] values, string controller = "Controller", string method = "FileList")
        {
            string dllFile = @"I:\CoCo\GitHub\ShopSystem\ShopSystem\Waka.Lego.FileTool\bin\Debug\Waka.Lego.FileTool.dll";

            List<Type> controllers = new List<Type>();
            //var types = Assembly.GetExecutingAssembly().GetTypes();
            var types = Assembly.LoadFile(dllFile).GetTypes();
            foreach (var type in types)
            {
                if (type.FullName.Contains(controller))
                {
                    controllers.Add(type);
                }
            }

            controllers.ForEach(x =>
            {
                object instance = x.Assembly.CreateInstance(x.FullName);
                MethodInfo methodInfo = x.GetMethod(method);
                ParameterInfo[] param = methodInfo.GetParameters();

                List<Type> paramType = new List<Type>();
                foreach (var item in param)
                {
                    paramType.Add(item.ParameterType);
                }
                //执行方法
                object value = x.GetMethod(method, paramType.ToArray()).Invoke(instance, values);
                ((Form)value).Show();
            });
        }

        private void DoShowMsg(object sender, EventArgs e)
        {
            //this.button1.Click += new System.EventHandler(this.button1_Click_1);
            //((Button)sender).Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string xx = x;
            string orgText = ShowMsg.Text;
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ShowMsg.Text = date;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string orgText = ShowMsg.Text;
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ShowMsg.Text = date;
        }
    }
}
