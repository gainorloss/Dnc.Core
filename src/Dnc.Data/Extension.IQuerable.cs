using Dnc.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace Dnc.Data
{
    public static class Extension
    {
        public static int BatchUpdate<T>(this IQueryable<T> query, Expression<Func<T, T>> updateFactory)
            where T : class => query.Update(updateFactory);

        public static int BatchDelete<T>(this IQueryable<T> query, int batchSize = 1000)
            where T : class => query.Delete(x => x.BatchSize = batchSize);
    }
}
