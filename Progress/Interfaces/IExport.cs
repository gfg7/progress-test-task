using System.Threading.Tasks;
namespace Progress.Interfaces
{
    public interface IExport<O>
    {
        Task<O> Export<I>(I obj);
    }
}