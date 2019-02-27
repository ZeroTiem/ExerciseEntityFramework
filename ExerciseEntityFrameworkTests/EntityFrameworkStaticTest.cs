using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseEntityFramework.Static;
using ExerciseEntityFrameworkTests.TestUtility;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExerciseEntityFrameworkTests
{
    [TestClass()]
    public class EntityFrameworkStaticTest
    {
        private RepositoryStatic _repositoryStatic;

        public EntityFrameworkStaticTest()
        {
            _repositoryStatic = new RepositoryStatic();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            DataBase.ClearAllData();
        }

        [TestMethod()]
        public void Mix()
        {
            //TestA
            //arrange
            var actA = new List<dynamic>
            {
                new {Name = "Hank1",Phone="0911"},
            };

            //act
            _repositoryStatic.AddA();

            //assert
            var users = EntityFrameworkStatic.staticTestDbContext.Users.ToList();
            users.Should().BeEquivalentTo(actA);

            var userA = EntityFrameworkStatic.staticTestDbContext.Users.FirstOrDefault();
            userA.Name = "Hank3";

            //TestB
            //arrange
            var actB = new List<dynamic>
            {
                new {Name = "Hank1",Phone="0911"},
                new {Name = "Hank2",Phone="0922"},
            };

            //act
            _repositoryStatic.AddB();

            //assert
            users = EntityFrameworkStatic.staticTestDbContext.Users.ToList();
            users.Should().BeEquivalentTo(actB);
        }


    }
}
