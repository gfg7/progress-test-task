using System.Linq.Expressions;
using Progress.Interfaces;
using Progress.Models;

namespace Progress.Services
{
    public class PatientManagementService
    {
        private IRepository<Patient, string> _repository;
        private IExport<string> _export;
        public PatientManagementService(IRepository<Patient, string> repository, IExport<string> export)
        {
            _repository = repository;
            _export = export;
        }

        public async Task<IEnumerable<Patient>> GetPatients(PatientFilter filter) => await _repository.GetByFilter(filter.GetFilter());

        public async Task<Patient> GetPatient(string patientId) => await _repository.GetByKey(patientId);

        public async Task<string> AddPatient(Patient patient)
        {
            await _repository.Add(patient);

            return patient.GetKey();
        }

        public async Task<string> ExportXml(string patientId)
        {
            Expression<Func<Patient, object>> include = x => x.Visits;
            var patient = await _repository.GetByKey(patientId, include);

            return await _export.Export(patient);
        }
    }
}