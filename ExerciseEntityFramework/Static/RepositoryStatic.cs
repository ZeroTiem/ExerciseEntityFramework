using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseEntityFramework.Static
{
    public class RepositoryStatic
    {
        public void AddA()
        {
            EntityFrameworkStatic.staticTestDbContext.Users.Add(
                new User
                {
                    Name = "Hank1",
                    Phone = "0911"
                });
            EntityFrameworkStatic.staticTestDbContext.SaveChanges();
        }

        public void AddB()
        {
            EntityFrameworkStatic.staticTestDbContext.Users.Add(
                new User
                {
                    Name = "Hank2",
                    Phone = "0922"
                });
            EntityFrameworkStatic.staticTestDbContext.SaveChanges();
        }
    }
}
