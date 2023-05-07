using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Progress.Interfaces;

namespace Progress.Services.Database
{
    public class Repository<T, K> : IRepository<T, K> where T : class, IEntity<K> where K : notnull
    {
        private readonly DBContext _context;
        private IDbContextTransaction _transaction;
        public Repository(DBContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T obj)
        {
            try
            {
                _transaction = _context.Database.BeginTransaction();
                var result = await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();

                return result.Entity;
            }
            catch (System.Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<IQueryable<T>> GetByFilter(Expression<Func<T, bool>>? filter = null, int take = 10, int page = 0)
        {
            return await GetAllByFilter(take, page, filter);
        }

        private Task<IQueryable<T>> GetAllByFilter(int take, int page, Expression<Func<T, bool>>? filter = null, IQueryable<T> set = null)
        {
            if (filter is null)
            {
                filter = x => true;
            }

            if (set is null)
            {
                set = _context.Set<T>();
            }

            var result = set.Where(filter).Skip(take * page).Take(take);

            return Task.FromResult(result);
        }

        public async Task<IQueryable<T>> GetByFilter(Expression<Func<T, bool>>? filter = null, int take = 10, int page = 0, params Expression<Func<T, object>>[] includes)
        {
            var set = IncludeEntities(_context.Set<T>(), includes);

            return await GetAllByFilter(take, page, filter, set);
        }

        public async Task<T?> GetByKey(K key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        public async Task<T?> GetByKey(K key, params Expression<Func<T, object>>[] includes)
        {
            var set = IncludeEntities(_context.Set<T>(), includes);

            return await set.FirstOrDefaultAsync(x => x.GetKey().Equals(key));
        }

        private IQueryable<T> IncludeEntities(IQueryable<T> set, params Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate(set, (data, entity) => data.Include(entity));
        }
    }
}