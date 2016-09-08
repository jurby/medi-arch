using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediArch.Core.Data;
using MediArch.Core.Data.Patient;

namespace MediArch.Core.Services.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _uow;

        public PatientService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private IRepository<Domain.Patient.Patient> PatientRepository => _uow.Repository<Domain.Patient.Patient>();

        public Domain.Patient.Patient GetById(string patientId)
        {
            return PatientRepository.ActivePatients().SingleOrDefault(x => x.Id == patientId);
        }

        public IEnumerable<Domain.Patient.Patient> ActivePatients()
        {
            return PatientRepository.ActivePatients().AsEnumerable();
        }

        public Domain.Patient.Patient GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Patient.Patient> RegisterClient(Domain.Patient.Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateClient(Domain.Patient.Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task SetAsDeleted(Domain.Patient.Patient client, bool commitChanges = false)
        {
            throw new NotImplementedException();
        }
    }
}
