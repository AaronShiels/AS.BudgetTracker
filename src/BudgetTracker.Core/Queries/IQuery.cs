using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.Queries
{
    public interface IQuery<T> where T : class
    {
        IQueryable<T> Filter(IQueryable<T> items);
    }
}
