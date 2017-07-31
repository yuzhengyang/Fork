//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.7.31 - 2017.7.31
//      desc:       Form唯一字典工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Y.Utils.DataUtils.Collections
{
    /// <summary>
    /// Form唯一字典工具
    /// </summary>
    public class FormDictionaryTool
    {
        protected ConcurrentDictionary<Type, Form> dictionary = new ConcurrentDictionary<Type, Form>();

        public T Get<T>() where T : Form
        {
            if (dictionary.ContainsKey(typeof(T)))
            {
                Form value;
                if (dictionary.TryGetValue(typeof(T), out value))
                {
                    if (value != null && !value.IsDisposed)
                    {
                        return (T)value;
                    }
                }
            }

            T form = default(T);
            if (dictionary.TryAdd(typeof(T), form))
            {
                return form;
            }

            return null;
        }
    }
}
