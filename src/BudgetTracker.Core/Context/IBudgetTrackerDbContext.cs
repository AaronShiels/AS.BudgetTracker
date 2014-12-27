using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Context
{
    public interface IBudgetTrackerDbContext
    {
        void Insert<T>(params T[] entities) where T : class;
        void Delete<T>(params T[] entities) where T : class;
        IEnumerable<T> Query<T>(params IQuery<T>[] queries) where T : class;
    }
}
