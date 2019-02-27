using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExerciseEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseEntityFramework.Tests
{
    [TestClass()]
    public class InsertTests
    {
        private readonly TestDbContext _testDbContext;
        private readonly BigInsert _insert;

        public InsertTests()
        {
            _insert = new BigInsert();
            _testDbContext = new TestDbContext();
        }

        private List<User> GetData()
        {
            var data = new List<User>();
            for (int i = 0; i < 10000; i++)
            {
                data.Add(new User
                {
                    Name = i.ToString(),
                    Phone = i.ToString()
                });
            }
            return data;
        }

        [TestMethod()]
        public void Addrange()
        {
            _testDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableTest]");
            _insert.Addrange(GetData());
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void AddrangeDetectChanges()
        {
            _testDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableTest]");
            _insert.AddrangeDetectChanges(GetData());
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Addranges the optimization.(https://entityframework.net/improve-ef-add-performance)
        /// </summary>
        [TestMethod()]
        public void Addrange_Optimization()
        {
            _testDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableTest]");
            _insert.AddrangeOptimization(GetData());
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Addranges the optimization extensions.(https://entityframework.net/improve-ef-add-performance)
        /// </summary>
        [TestMethod()]
        public void Addrange_OptimizationExtensions()
        {
            _testDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableTest]");
            _insert.AddrangeOptimizationExtensions(GetData());
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Addranges the optimization extensions.(https://entityframework.net/improve-ef-add-performance)
        /// </summary>
        [TestMethod()]
        public void Addrange_EFUtilities()
        {
            _testDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableTest]");
            _insert.AddrangeEFUtilities(GetData());
            Assert.IsTrue(true);
        }

        

        [TestMethod()]
        public void BulkInsert_entityframeworkextensions()
        {
            _testDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableTest]");
            _insert.BulkInsert_entityframeworkextensions(GetData());
            Assert.IsTrue(true);
        }
    }
}