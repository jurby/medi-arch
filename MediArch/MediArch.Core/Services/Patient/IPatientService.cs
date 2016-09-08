using System.Collections.Generic;
using System.Threading.Tasks;
using PL = MediArch.Core.Domain.Patient;

namespace MediArch.Core.Services.Patient
{
    public interface IPatientService
    {
        PL.Patient GetById(string patientId);
        PL.Patient GetByEmail(string email);

        IEnumerable<PL.Patient> ActivePatients();

        Task<PL.Patient> RegisterClient(PL.Patient patient);
        Task<bool> UpdateClient(PL.Patient patient);
        Task SetAsDeleted(PL.Patient client, bool commitChanges = false);
    }
}
