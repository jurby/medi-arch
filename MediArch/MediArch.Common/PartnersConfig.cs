namespace MediArch.Common
{
    public class PartnersConfig
    {
        public class Partner1
        {
            public static string Endpoint => ConfigurationReader.ReadAppSetting<string>("Partner1.Endpoint");
            public static string Username => ConfigurationReader.ReadAppSetting<string>("Partner1.Username");
            public static string Password => ConfigurationReader.ReadAppSetting<string>("Partner1.Password");
            public static int TerminalId => ConfigurationReader.ReadAppSetting<int>("Partner1.TerminalId");
        }
    }
}
