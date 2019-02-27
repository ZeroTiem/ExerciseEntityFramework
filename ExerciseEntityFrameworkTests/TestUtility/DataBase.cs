using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseEntityFramework;

namespace ExerciseEntityFrameworkTests.TestUtility
{
    public static class DataBase
    {
        public static void ClearAllData()
        {
            using (var dbcontext = new TestDbContext())
            {
                List<string> tableNames = dbcontext.Database.SqlQuery<string>("SELECT name FROM sys.tables ORDER BY name").ToList();
                foreach (var tableName in tableNames)
                {
                    dbcontext.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + tableName + "]");
                }
            }
        }
    }
}
