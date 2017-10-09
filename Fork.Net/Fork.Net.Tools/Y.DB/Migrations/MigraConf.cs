using System.Data.Entity.Migrations;
using Y.DB.DAO;

namespace Y.DB.Migrations
{
    internal sealed class MigraConf : DbMigrationsConfiguration<DbTable>
    {
        public MigraConf()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "ContextKey";
        }

        protected override void Seed(DbTable context)
        {
        }
    }
}
