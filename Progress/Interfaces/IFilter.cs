using System.Linq.Expressions;

namespace Progress.Interfaces
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>>  GetFilter();
    }
}