using System;

namespace MediArch.Common
{
    [Flags]
    public enum AppEnvironment : byte
    {
        None = 0,

        Development = 1 << 0,
        Test = Development << 1,
        Staging = Test << 1,
        Production = Staging << 1,

        NonProduction = Development | Test | Staging
    }
}
