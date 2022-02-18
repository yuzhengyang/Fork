using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azylee.Core.FormUtils.FormModuleUtils
{
    public class FormModuleManTool
    {

        protected ConcurrentDictionary<Type, Form> UniqueForms = new ConcurrentDictionary<Type, Form>();

        public List<Form> AllForms { get { return _AllForms; } }
        private List<Form> _AllForms = new List<Form>();


        public bool Add<T>(T form) where T : Form, IModuleForm
        {
            _AllForms.Add(form);
            return true;
        }
        /// <summary>
        /// 获取唯一窗体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetUnique<T>(Dictionary<string,object> args) where T : Form, IModuleForm ,new()
        {
            if (UniqueForms.ContainsKey(typeof(T)))
            {
                // 字典中有该窗体，则读取窗体对象
                Form value;
                if (UniqueForms.TryGetValue(typeof(T), out value))
                {
                    if (value != null && !value.IsDisposed)
                    {
                        // 窗体对象可用（不为空、没释放），反馈窗体对象
                        return (T)value;
                    }
                    else
                    {
                        // 窗体对象不可用，从字典中移除窗体对象
                        Form temp;
                        UniqueForms.TryRemove(typeof(T), out temp);
                    }
                }
            }

            // 未能返回正确的窗体，则创建新窗体（使用默认new方法）
            T form = new T();
            form.Init(args);
            if (AddUnique(form)) return form;
            return null;
        }
        private bool AddUnique<T>(T value) where T : Form, IModuleForm, new()
        {
            if (!UniqueForms.ContainsKey(typeof(T)))
            {
                if (UniqueForms.TryAdd(typeof(T), value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
