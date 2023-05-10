using Microsoft.EntityFrameworkCore;
using Progress.Interfaces;
using Progress.Models;

namespace Progress.Services.Database
{
    public class MBKRepository : IMBKDictionary
    {
        private readonly DbContext _database;
        public MBKRepository(DbContext database)
        {
            _database = database;
        }

        public IEnumerable<Diagnosis> GetDiagnoses(string? search)
        {
            search = search?.ToLower().Trim() ?? string.Empty;
            return _database.Set<Diagnosis>().Where(x => (!string.IsNullOrEmpty(search) && (x.Name.ToLower().Contains(search) || x.Id.ToLower().Contains(search))) || true);
        }
    }
}