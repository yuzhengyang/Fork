using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;

namespace Oreo.FaultLog.DatabaseEngine
{
    public class Configuration : DbMigrationsConfiguration<SuperDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
        protected override void Seed(SuperDb context)
        { }
    }
}
