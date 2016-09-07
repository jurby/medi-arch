namespace MediArch.Common
{
    public class ConnectionStrings
    {
        #region AzureWebJobsStorage

        public static string CreaditRechargingStorageConnectionString => ConfigurationReader.ReadConnectionString("AzureWebJobsStorage");

        #endregion

        #region AzureWebJobsDashboard

        public static string CreaditRechargingDashboardConnectionString => ConfigurationReader.ReadConnectionString("AzureWebJobsDashboard");

        #endregion
    }
}
