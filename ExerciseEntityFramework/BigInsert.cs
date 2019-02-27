using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityFramework.Utilities;

namespace ExerciseEntityFramework
{
    public class BigInsert
    {
        private readonly TestDbContext _testDbContext;

        public BigInsert()
        {
            _testDbContext = new TestDbContext();
        }

        public void Addrange(List<User> tableTests)
        {
            _testDbContext.Users.AddRange(tableTests);
            _testDbContext.SaveChanges();
        }

        public void AddrangeDetectChanges(List<User> tableTests)
        {
            _testDbContext.Users.AddRange(tableTests);
            _testDbContext.ChangeTracker.DetectChanges();
            _testDbContext.SaveChanges();
        }

        public void AddrangeOptimization(List<User> users)
        {
            using (var transaction = _testDbContext.Database.BeginTransaction())
            {
                //    using (TransactionScope scope = new TransactionScope())
                //{
                TestDbContext context = null;
                try
                {
                    context = new TestDbContext();
                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Configuration.LazyLoadingEnabled = false;

                    int count = 0;
                    foreach (var entityToInsert in users)
                    {
                        ++count;
                        context = AddToContext(context, entityToInsert, count, 100, true);
                    }

                    context.SaveChanges();
                }
                finally
                {
                    if (context != null)
                        context.Dispose();
                }

                //scope.Complete();
                transaction.Commit();
            }
        }

        private TestDbContext AddToContext<TEntity>(TestDbContext context,
            TEntity entity, int count, int commitCount, bool recreateContext) where TEntity : class
        {
            context.Set<TEntity>().Add(entity);

            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = new TestDbContext();
                    context.Configuration.AutoDetectChangesEnabled = false;
                }
            }

            return context;
        }

        public void BulkInsert_entityframeworkextensions(List<User> users)
        {
            _testDbContext.BulkInsert(users);
        }

        public void AddrangeOptimizationExtensions(List<User> getData)
        {
            // 1. CREATE a batchSize variable
            int batchSize = 100;

            var context = new TestDbContext();

            for (int i = 0; i <= getData.Count; i++)
            {
                // 2. CALL SaveChanges before creating a new batch
                if (i != 0 && i % batchSize == 0)
                {
                    context.SaveChanges();
                    context = new TestDbContext();
                }

                var customer = new User();
                // ...code...

                context.Users.Add(customer);
            }

            // 3. CALL SaveChanges
            context.SaveChanges();

            // 4. Done!
        }

        public void AddrangeEFUtilities(List<User> getData)
        {
            using (var db = new TestDbContext())
            {
                EFBatchOperation.For(db, db.Users).InsertAll(getData);
            }
        }
    }
}
