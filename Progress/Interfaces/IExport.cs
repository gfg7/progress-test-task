using System.Threading.Tasks;
namespace Progress.Interfaces
{
    public interface IExport<O,I>
    {
        Task<O> Export(I obj);
    }
}