using System.Data.Entity.Migrations;

namespace Azylee.BlackBox.DBEngine
{
    public class Configuration : DbMigrationsConfiguration<SuperDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
        protected override void Seed(SuperDb context)
        { }
    }
}
