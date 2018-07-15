using Azylee.DB.SQLite.Configs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Azylee.DB.SQLite.Engine
{
    [DbConfigurationType(typeof(BaseConfig))]
    public class SuperDB : DbContext
    {
        public SuperDB(string connect) : base(connect)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.AddFromAssembly(typeof(SuperDb).Assembly);

            BaseConfig.Configuer(modelBuilder);
            Database.SetInitializer(new MyDbInitializer(Database.Connection.ConnectionString, modelBuilder));
        }
    }
}
