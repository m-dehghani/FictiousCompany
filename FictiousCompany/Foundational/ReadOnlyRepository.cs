using FictiousCompany.Infrastructure;
using FictiousCompany.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FictiousCompany.Foundational
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, new()
    {
        protected readonly Context _context;
        protected readonly DbSet<TEntity> _dbSet;

        public ReadOnlyRepository(Context context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected IEnumerable<TEntity> GetAll(IEnumerable<TEntity> source, int take, ref int pageNumber, out int count)
        {
            count = source.Count();

        GetAgain:
            int skip = (pageNumber - 1) * take;

            if (count != 0 && skip >= count)
            {
                pageNumber--;
                goto GetAgain;
            }

            if (pageNumber <= 0 || count == 0)
            {
                pageNumber = 1;
                skip = 0;
            }

            var result = source.Select(t => t)
                .Skip(skip)
                .Take(take)
                .GroupBy(t => new { Count = source.Count() })
                .FirstOrDefault();

            if (result != null)
            {
                count = result.Key.Count;
                return result.Select(t => t).AsEnumerable();
            }

            return new List<TEntity>().AsEnumerable();
        }

        protected IEnumerable<T> GetAll<T>(IEnumerable<T> source, int take, ref int pageNumber, out int count)
        {
            count = source.Count();

        GetAgain:
            int skip = (pageNumber - 1) * take;

            if (count != 0 && skip >= count)
            {
                pageNumber--;
                goto GetAgain;
            }

            if (pageNumber <= 0 || count == 0)
            {
                pageNumber = 1;
                skip = 0;
            }

            var result = source.Select(t => t)
                .Skip(skip)
                .Take(take)
                .GroupBy(t => new { Count = source.Count() })
                .FirstOrDefault();

            if (result != null)
            {
                count = result.Key.Count;
                return result.Select(t => t).AsEnumerable();
            }

            return new List<T>().AsEnumerable();
        }

        protected virtual IQueryable<TEntity> GetEntities(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null, params string[] includes)
        {
            includes ??= new string[] { };

            IQueryable<TEntity> entities = _dbSet.AsQueryable();

            if (predicate != null)
                entities = entities.Where(predicate);

            var includeNames = includes.Where(t => !string.IsNullOrEmpty(t) && !string.IsNullOrWhiteSpace(t)).Distinct().ToList();
            foreach (var include in includeNames)
                entities = entities.Include(include);

            if (orderBy != null)
                entities = orderBy(entities);

            if (skip.HasValue)
                entities = entities.Skip(skip.Value);

            if (take.HasValue)
                entities = entities.Take(take.Value);

            return entities.AsQueryable();
        }

        protected virtual IEnumerable<TEntity> Order<TKey>(IEnumerable<TEntity> source, Func<TEntity, TKey> keySelector, SortOrderType orderType)
        {
            switch (orderType)
            {
                case SortOrderType.Ascending:
                    return source.OrderBy(keySelector);

                case SortOrderType.Descending:
                    return source.OrderByDescending(keySelector);

                case SortOrderType.None:
                default:
                    return source;
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetEntities(predicate, null, null, null, null).Count();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetEntities(predicate, null, null, null, null).Any();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate = null, params string[] include)
        {
            return GetEntities(predicate, null, null, null, include).SingleOrDefault();
        }

        public virtual TEntity Find(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params string[] includes)
        {
            return GetEntities(predicate, orderBy, null, null, includes).FirstOrDefault();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params string[] includes)
        {
            return await GetEntities(predicate, orderBy, null, null, includes).FirstOrDefaultAsync();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate = null, params string[] includes)
        {
            return GetEntities(predicate, null, null, null, includes).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null, params string[] includes)
        {
            return GetEntities(predicate, orderBy, skip, take, includes).AsEnumerable();
        }

        public virtual TEntity LastOrDefault(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params string[] includes)
        {
            return GetEntities(predicate, orderBy, null, null, includes).LastOrDefault();
        }

        public virtual void Load(TEntity entity, string include)
        {
            _context.Entry<TEntity>(entity).Reference(include).Load();
        }

        public virtual void LoadCollection(TEntity entity, string include)
        {
            _context.Entry<TEntity>(entity).Collection(include).Load();
        }

        public TResult Max<TResult>(Func<TEntity, TResult> selector, Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetAll(predicate).Max(selector);
        }

        public TResult Min<TResult>(Func<TEntity, TResult> selector, Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetAll(predicate).Min(selector);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null, params string[] includes)
        {
            return GetEntities(predicate, null, null, null, includes).SingleOrDefault();
        }
    }
}
