using Oreo.FileMan.Commons;
using Oreo.FileMan.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreo.FileMan.DatabaseEngine
{
    public class SuperDb : DbContext
    {
        public SuperDb() : base(@"DefaultConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperDb, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(SuperDb).Assembly);

            Database.SetInitializer(new MyDbInitializer(Database.Connection.ConnectionString, modelBuilder));
        }

        public class MyDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<SuperDb>//SqliteDropCreateDatabaseAlways
        {
            public MyDbInitializer(string connectionString, DbModelBuilder modelBuilder)
                : base(modelBuilder)
            {
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperDb, Configuration>());
            }

            protected override void Seed(SuperDb context)
            {
                //context.Set<Files>().Add(new Files { FileName = "123" });
                base.Seed(context);
            }
        }
    }
}