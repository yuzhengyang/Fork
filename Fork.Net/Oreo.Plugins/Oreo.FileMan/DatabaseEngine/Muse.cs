using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Oreo.FileMan.DatabaseEngine
{
    class Muse : IDisposable
    {
        public SuperDb Context;
        public Muse()
        {
            Context = new SuperDb();
        }

        public int Add<T>(T EntityObj, bool isSave = true) where T : class
        {
            try
            {
                this.Context.Set<T>().Add(EntityObj);
                if (isSave)
                {
                    return Save();
                }
            }
            catch (Exception e) { }
            return 0;
        }
        public int Adds<T>(IEnumerable<T> EntityObjs) where T : class
        {
            try
            {
                Context.Set<T>().AddRange(EntityObjs);
                return Save();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public int Del<T>(T EntityObj, bool isSave) where T : class
        {
            try
            {
                this.Context.Set<T>().Remove(EntityObj);
                if (isSave)
                {
                    return Save();
                }
            }
            catch (Exception e) { }
            return 0;
        }
        public int Dels<T>(IEnumerable<T> EntityObjs) where T : class
        {
            try
            {
                this.Context.Set<T>().RemoveRange(EntityObjs);
                return Save();
            }
            catch (Exception e) { }
            return 0;
        }
        public int Update<T>(T EntityObj, bool isSave) where T : class
        {
            try
            {
                this.Context.Entry(EntityObj).State = EntityState.Modified;
                if (isSave)
                {
                    return Save();
                }
            }
            catch (Exception e) { }
            return 0;
        }
        public int Save()
        {
            return Context.SaveChanges();
        }

        public T Get<T>(Expression<Func<T, bool>> expression, string[] include) where T : class
        {
            try
            {
                if (include != null && include.Count() > 0)
                {
                    DbQuery<T> query = GetInclude<T>(include);
                    if (query != null)
                        return query.FirstOrDefault(expression);
                }
                return this.Context.Set<T>().FirstOrDefault(expression);
            }
            catch (Exception e)
            {
            }
            return null;
        }
        public IEnumerable<T> Gets<T>(Expression<Func<T, bool>> expression, string[] include) where T : class
        {
            try
            {
                if (include != null && include.Count() > 0)
                {
                    DbQuery<T> query = GetInclude<T>(include);
                    if (query != null)
                        return query.Where(expression).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Context.Set<T>().Where(expression).ToList();
        }
        public IEnumerable<T> GetAll<T>(string[] include, bool track) where T : class
        {
            if (include != null && include.Count() > 0)
            {
                DbQuery<T> query = GetInclude<T>(include);
                if (query != null)
                    if (track)
                        return query.ToList();
                    else
                        return query.AsNoTracking().ToList();
            }
            if (!track)
                Context.Set<T>().AsNoTracking().ToList();
            return Context.Set<T>().ToList();
        }
        private DbQuery<T> GetInclude<T>(string[] include) where T : class
        {
            DbQuery<T> searchCondition = null;
            foreach (var item in include)
            {
                if (searchCondition == null)
                    searchCondition = this.Context.Set<T>().Include(item);
                else
                    searchCondition = searchCondition.Include(item);
            }
            return searchCondition;
        }

        public bool Any<T>(Expression<Func<T, bool>> expression, string[] include) where T : class
        {
            try
            {
                if (include != null && include.Count() > 0)
                {
                    DbQuery<T> query = GetInclude<T>(include);
                    if (query != null)
                        return query.Any(expression);
                }
                return this.Context.Set<T>().Any(expression);
            }
            catch (Exception e)
            {
            }
            return false;
        }
        public DbSet<T> Do<T>() where T : class
        {
            return Context.Set<T>();
        }
        public IEnumerable<T> ExecuteSqlCom<T, U>(string sql, U paramObjs)
            where U : class
            where T : class
        {
            return Context.Set<T>().SqlQuery(sql, paramObjs);
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
