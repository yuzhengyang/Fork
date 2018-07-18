//************************************************************************
//      author:     yuzhengyang
//      date:       2018.5.20 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.DataUtils.CollectionUtils
{
    public static class ArrayTool
    {
        /// <summary>
        /// 格式化[]数组个数
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="size">要格式化为多少个</param>
        /// <returns></returns>
        public static T[] Formatter<T>(T[] array, int size = 10)
        {
            T[] rs = new T[size];
            if (ListTool.HasElements(array))
            {
                for (int i = 0; i < rs.Length; i++)
                {
                    if (array.Length > i) rs[i] = array[i];
                }
            }
            return rs;
        }
        /// <summary>
        /// 格式化[]数组个数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">数组</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="size">要格式化为多少个</param>
        /// <returns></returns>
        public static T[] Formatter<T>(T[] array, T defaultValue, int size = 10)
        {
            T[] rs = new T[size];
            for (int i = 0; i < size; i++) rs[i] = defaultValue;

            if (ListTool.HasElements(array))
            {
                for (int i = 0; i < rs.Length; i++)
                {
                    if (array.Length > i) rs[i] = array[i];
                }
            }
            return rs;
        }
    }
}
