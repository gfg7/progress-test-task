using System.Linq.Expressions;
using Progress.Interfaces;
using Progress.Models;

namespace Progress.Services
{
    public class VisitManagementService
    {
        private readonly IRepository<Visit, string> _repository;
        public VisitManagementService(IRepository<Visit, string> repository)
        {
            _repository = repository;
        }

        public async Task AppointVisit(Visit visit) => await _repository.Add(visit);

        public async Task<IEnumerable<Visit>> GetVisits(string patientId) {
            Expression<Func<Visit,object>> include = x=> x.Reason;

            return await _repository.GetByFilter(x => x.PatientId == patientId, includes: include);
        }
    }
}