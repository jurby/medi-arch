namespace MediArch.Core.Domain.Patient
{
    public enum PatientStatus
    {
        None = 0,

        Created,
        Registered,
        Active,
        Nonactive,
        Deleted
    }
}
