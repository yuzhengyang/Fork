using Azylee.DB.SQLite.Engine;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Azylee.DB.SQLite.Configs
{
    public class MyDbInitializer : SqliteCreateDatabaseIfNotExists<SuperDB>//SqliteDropCreateDatabaseAlways
    {
        public MyDbInitializer(string connectionString, DbModelBuilder modelBuilder)
            : base(modelBuilder)
        {
        }

        protected override void Seed(SuperDB context)
        {
            //context.Set<Files>().Add(new Files { FileName = "123" });
            base.Seed(context);
        }
    }
}
