using System.Linq;
using MediArch.Core.Domain.Patient;

namespace MediArch.Core.Data.Patient
{
    public static class PatientRepositoryExtensions
    {
        public static IQueryable<Domain.Patient.Patient> ActivePatients(this IRepository<Domain.Patient.Patient> repository)
        {
            return repository.All().ActivePatients();
        }

        public static IQueryable<Domain.Patient.Patient> ActivePatients(this IQueryable<Domain.Patient.Patient> patients)
        {
            return patients.Where(x => x.Status == PatientStatus.Active);
        }
    }
}
