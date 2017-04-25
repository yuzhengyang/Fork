//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y.Utils.ReflectionUtils.AttributeUtils
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ControlAttribute : Attribute
    {
        public string Widget { get; set; }
        public string Click { get; set; }
        public ControlAttributeEvent Event { get; set; }

        public static void Band(Form form)
        {
            string buttonName = "ShowMsg";
            Type type = form.GetType();
            FieldInfo fieldShowMsg = type.GetField(buttonName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            ControlAttribute controlAttribute = (ControlAttribute)fieldShowMsg.GetCustomAttribute(typeof(ControlAttribute));

            FieldInfo fieldButton1 = type.GetField(controlAttribute.Widget, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            fieldShowMsg.SetValue(form, fieldButton1.GetValue(form));

            MethodInfo method = type.GetMethod(controlAttribute.Click, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            EventInfo evt = fieldShowMsg.FieldType.GetEvent("Click", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            evt.AddEventHandler(fieldShowMsg.GetValue(form), Delegate.CreateDelegate(typeof(EventHandler), form, method));

            int a = 0;
        }
    }
}
