using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Progress.Interfaces
{
    public interface IRepository<T,K> where T : IEntity<K>
    {
        Task<T> Add(T obj);
        Task<T?> GetByKey(K key);
        Task<T?> GetByKey(K key,params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetByFilter(Expression<Func<T, bool>>? filter = null, int take = 10, int page = 0);
        Task<IQueryable<T>> GetByFilter(Expression<Func<T, bool>>? filter = null, int take = 10, int page = 0, params Expression<Func<T, object>>[] includes);
    }
}