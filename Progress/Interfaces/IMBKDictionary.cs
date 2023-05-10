using Progress.Models;

namespace Progress.Interfaces
{
    public interface IMBKDictionary
    {
        IEnumerable<Diagnosis> GetDiagnoses(string illness);
    }
}