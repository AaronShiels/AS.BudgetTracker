using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnum.Extensions;
using BudgetTracker.Core.Mapping;
using BudgetTracker.Core.Entities;

namespace BudgetTracker.Core.Context
{
    public class BudgetTrackerDbContext : DbContext, IBudgetTrackerDbContext
    {
        static BudgetTrackerDbContext()
        {
            Database.SetInitializer<BudgetTrackerDbContext>(null);
        }

        public BudgetTrackerDbContext()
            : base("BudgetTrackerDatabase")
        {
            
        }

        public void Insert<T>(params T[] entities) where T : class
        {
            var set = Set<T>();

            entities.Each(e => set.Add(e));
        }

        public void Delete<T>(params T[] entities) where T : class
        {
            var set = Set<T>();

            entities.Each(e => set.Remove(e));
        }

        public IEnumerable<T> Query<T>(params Queries.IQuery<T>[] queries) where T : class
        {
            return queries.Aggregate(Set<T>().AsQueryable(), (current, query) => query.Filter(current));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TransactionMapping());
            modelBuilder.Configurations.Add(new ScheduledItemMapping());
        }
    }
}
