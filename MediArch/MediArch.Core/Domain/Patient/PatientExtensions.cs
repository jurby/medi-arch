namespace MediArch.Core.Domain.Patient
{
    public static class PatientExtensions
    {
        public static string FullName(this Patient patient)
        {  
            return string.IsNullOrWhiteSpace(patient.FamilyName)
                ? $"{patient.FirstName} {patient.FamilyName}"
                : $"{patient.FirstName} {patient.FamilyName} {patient.LastName}";
        }
    }
}
