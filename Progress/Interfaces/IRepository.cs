using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Progress.Interfaces
{
    public interface IRepository<T,K> where T : IEntity<K>
    {
        Task<T> Add(T obj);
        Task<T> GetByKey(K key);
        Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>>? filter = null, int take = 10, int page = 0);
    }
}