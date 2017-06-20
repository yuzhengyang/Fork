using Oreo.FileMan.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreo.FileMan.DatabaseEngine
{
    public class Muse : DbContext
    {
        public Muse()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(Muse).Assembly);

            Database.SetInitializer(new MyDbInitializer(Database.Connection.ConnectionString, modelBuilder));
            //var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<Muse>(modelBuilder);
            //Database.SetInitializer(sqliteConnectionInitializer);
        }
    }

    public class MyDbInitializer : SqliteDropCreateDatabaseAlways<Muse>
    {
        public MyDbInitializer(string connectionString, DbModelBuilder modelBuilder)
            : base(modelBuilder) { }

        protected override void Seed(Muse context)
        {
            //context.Set<Files>().Add(new Files { FileName = "123" });
            base.Seed(context);
        }
    }
}
