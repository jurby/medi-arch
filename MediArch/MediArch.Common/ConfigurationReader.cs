using System;

namespace MediArch.Common
{
    public static class ConfigurationReader
    {
        public static T ReadAppSetting<T>(string settingName, T defaultValue = default(T))
        {
            var settingValue = ReadAppSetting(settingName, defaultValue as string, Equals(defaultValue, default(T)));
            return (T)Convert.ChangeType(settingValue, typeof(T));
        }

        public static string ReadAppSetting(string settingName, string defaultValue = default(string), bool useDefaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(settingName))
            {
                throw new ArgumentNullException(nameof(settingName));
            }

            // TODO: Need refactoring to .Net Core Configuraton
            //var settingValue = ConfigurationManager.AppSettings[settingName];
            var settingValue = string.Empty;
            if (string.IsNullOrEmpty(settingValue))
            {
                settingValue = Environment.GetEnvironmentVariable(settingName);
            }

            if (string.IsNullOrEmpty(settingValue) && useDefaultValue)
            {
                return defaultValue;
            }

            if (string.IsNullOrEmpty(settingValue))
            {
                throw new InvalidOperationException($"Could not find the value for setting {settingName}");
            }

            return settingValue;
        }

        public static string ReadConnectionString(string connectionStringName)
        {
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }

            // TODO: Need refactoring to .Net Core Configuraton
            //var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            var connectionString = string.Empty;
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = Environment.GetEnvironmentVariable(connectionStringName);
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Could not find the value for connection string {connectionStringName}");
            }

            return connectionString;
        }
    }
}
