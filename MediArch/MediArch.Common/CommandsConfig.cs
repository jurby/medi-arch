using System;

namespace MediArch.Common
{
    public class CommandsConfig
    {
        public static int MaximumNumberOfAttempts => ConfigurationReader.ReadAppSetting<int>("Commands.MaximumNumberOfAttempts");

        public static int MaximumBackoff => 10;
        public static TimeSpan SleepTimeoutMinimum = TimeSpan.FromSeconds(1.0);
        public static TimeSpan SleepTimeoutMaximum = TimeSpan.FromSeconds(60.0);
        public static TimeSpan SleepTimeoutDelta = TimeSpan.FromSeconds(2.0);

        public static int MessageVisibilityTimeoutInMinutes => 2;
        public static TimeSpan MessageVisibilityTimeoutMinimum = TimeSpan.FromMinutes(10.0);
        public static TimeSpan MessageVisibilityTimeoutMaximum = TimeSpan.FromDays(1.0);
        public static TimeSpan MessageVisibilityTimeoutDelta = TimeSpan.FromMinutes(10.0);
    }
}
