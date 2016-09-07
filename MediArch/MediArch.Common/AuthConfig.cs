using System;

namespace MediArch.Common
{
    public class AuthConfig
    {
        public static TimeSpan AccessTokenExpireTimeSpan => TimeSpan.Parse(ConfigurationReader.ReadAppSetting<string>("as:AccessTokenExpireTimeSpan"));

        public static string JwtBearerIssuer => ConfigurationReader.ReadAppSetting<string>("as:Issuer") ?? "self";

        public static string JwtBearerAudience => ConfigurationReader.ReadAppSetting<string>("as:Audience");

        public static string JwtBearerSecretKey=> ConfigurationReader.ReadAppSetting<string>("as:SecretKey");

        public class Scopes
        {
            public const string ClaimName = "scopes";

            public const string CreateOrder = "create:order";
            public const string ReadOrder = "read:order";
        }
    }
}
