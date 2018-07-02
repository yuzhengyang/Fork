using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Azylee.DB.SQLite.Engine
{
    /// <summary>
    /// 数据接口
    /// </summary>
    public interface IDBContext : IDisposable
    {
        int Add<T>(T EntityObj, bool isSave) where T : class;
        int Del<T>(T EntityObj, bool isSave) where T : class;
        int Update<T>(T EntityObj, bool isSave) where T : class;
        int Save();
        T Get<T>(Expression<Func<T, bool>> expression, string[] include) where T : class;
        IEnumerable<T> Gets<T>(Expression<Func<T, bool>> expression, string[] include) where T : class;
        IEnumerable<T> GetAll<T>(string[] include, bool track) where T : class;
        IEnumerable<T> ExecuteSqlCom<T, U>(string sql, U paramObjs) where T : class where U : class;
    }
}
