using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FictiousCompany.Services
{
    public interface IReadOnlyRepository<T> where T : class, new()
    {
        int Count(Expression<Func<T, bool>> predicate = null);

        bool Exists(Expression<Func<T, bool>> predicate = null);

        T Find(Expression<Func<T, bool>> predicate = null, params string[] include);

        T Find(object id);

        T FirstOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includes);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includes);

        T Get(Expression<Func<T, bool>> predicate = null, params string[] includes);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, params string[] includes);

        T LastOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includes);

        TResult Max<TResult>(Func<T, TResult> selector, Expression<Func<T, bool>> predicate = null);

        TResult Min<TResult>(Func<T, TResult> selector, Expression<Func<T, bool>> predicate = null);

        T SingleOrDefault(Expression<Func<T, bool>> predicate = null, params string[] includes);
    }
}
