using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.DB.Migrations;

namespace Y.DB.DAO
{
    /// <summary>
    /// SuperDb 中完成数据库的配置
    /// </summary>
    public class SuperDb : DbContext
    {
        public SuperDb()
            : base("SQLServerConnection")//SQLServerConnection//DefaultConnection
        {
            //设置数据迁移配置
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbTable, MigraConf>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //去掉复数映射
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
