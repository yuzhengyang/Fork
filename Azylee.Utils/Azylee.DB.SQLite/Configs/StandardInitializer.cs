using Azylee.DB.SQLite.Engine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Azylee.DB.SQLite.Configs
{
    public class StandardInitializer : IDatabaseInitializer<SuperDB>//SqliteDropCreateDatabaseAlways
    { 
        public void InitializeDatabase(SuperDB context)
        {
            
        } 
    }
}
