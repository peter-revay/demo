using Microsoft.Extensions.Configuration;

namespace LocationRisk_Variants
{
    public class Configuration
    {
        static bool IsLocal = true;
        static bool IsTest = true;
        static bool IsLive = false;

        private static IConfigurationRoot _configurationRoot { get; set; }
        private static IConfigurationRoot GetConfiguration()
        {
            if (_configurationRoot != null)
            {
                return _configurationRoot;
            }
            else
            {
                string appsettingsDir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                _configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(appsettingsDir)
                    .AddJsonFile("variants.json", optional: false, reloadOnChange: false)
                    .Build();

                return _configurationRoot;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static class Settings
        {
            private static IConfigurationSection SettingsSection() => GetConfiguration().GetSection("Settings");

        }

        public static class Services
        {
            private static IConfigurationSection ServicesSection() => GetConfiguration().GetSection("Services");

            public static string? SERVICE_OPENSTREETMAP
            {
                get
                {
                    if (IsLocal)
                        return ServicesSection().GetValue<string>("SERVICE_OPENSTREETMAP_LOCAL");
                    else if (IsTest)
                        return ServicesSection().GetValue<string>("SERVICE_OPENSTREETMAP_TEST");
                    else if (IsLive)
                        return ServicesSection().GetValue<string>("SERVICE_OPENSTREETMAP_LIVE");
                    else
                        throw new Exception("Value missing!");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static class ConnectionStrings
        {
            private static IConfigurationSection ConnectionStringsSection() => GetConfiguration().GetSection("ConnectionStrings");

            public static string? CS_BANKA
            {
                get
                {
                    if (IsLocal)
                    {
                        if (IsTest)
                            return ConnectionStringsSection().GetValue<string>("CS_BANKA_TEST");
                        else if (IsLive)
                            return ConnectionStringsSection().GetValue<string>("CS_BANKA_LIVE");
                        else
                            throw new Exception("Value missing!");
                    }
                    else // server
                    {
                        if (IsTest)
                            return ConnectionStringsSection().GetValue<string>("CS_BANKA_PUB_TEST");
                        else if (IsLive)
                            return ConnectionStringsSection().GetValue<string>("CS_BANKA_PUB_LIVE");
                        else
                            throw new Exception("Value missing!");
                    }
                }
            }
           

        }
    }
}
