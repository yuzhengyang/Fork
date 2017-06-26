using SQLite.CodeFirst;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Oreo.FaultLog.DatabaseEngine
{
    public class SuperDb : DbContext
    {
        public SuperDb()
            : base(@"DefaultConnection")
        {
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
                : base(modelBuilder) { }

            protected override void Seed(SuperDb context)
            {
                //context.Set<Files>().Add(new Files { FileName = "123" });
                base.Seed(context);
            }
        }
    }
}