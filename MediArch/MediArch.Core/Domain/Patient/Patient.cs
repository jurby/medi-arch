using System;

namespace MediArch.Core.Domain.Patient
{
    public sealed class Patient
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FamilyName { get; set; }

        public DateTimeOffset? BirthDate { get; set; }

        public DateTimeOffset Created { get; set; }

        public PatientStatus Status { get; set; } = PatientStatus.None;
    }
}
