using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waka.Lego.Views;
using Y.Utils.ReflectionUtils.AttributeUtils;

namespace Waka.Lego
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Form1 form = new Form1();
            //ControlAttribute.Band(form);
            //Application.Run(form);
            Application.Run(new MainForm());
        }
    }
}
