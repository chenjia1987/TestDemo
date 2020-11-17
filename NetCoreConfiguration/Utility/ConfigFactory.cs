using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Utility
{
    public class ConfigFactory
    {
        public static IConfiguration config = null;
        public static IHostingEnvironment hosting = null;
        public T GetAppSettings<T>(string key) where T : class, new()
        {
            var currentClassDir = Directory.GetCurrentDirectory();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var indexSrc = currentClassDir.IndexOf("bin");
                if (indexSrc > 0) currentClassDir = currentClassDir.Substring(0, indexSrc - 1);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (!currentClassDir.Contains("Yiku.OMS.API")) currentClassDir += "/Yiku.OMS.API";
            }

            config = new ConfigurationBuilder().SetBasePath(currentClassDir).AddJsonFile("appsettings.json", false, true).Build();

            var appconfig = new ServiceCollection().AddOptions().Configure<T>(config.GetSection(key)).BuildServiceProvider().GetService<IOptions<T>>().Value;
            return appconfig;
        }
    }

    public class ConfigEntity
    {
        public ConnectionStringsEntity ConnectionStrings { get; set; }
        public APIURIEntity APIUrl { get; set; }
    }

    public class ConnectionStringsEntity
    {
        public string PostgreSqlConnection { get; set; }

        public string MySqlConnection { get; set; }

        public string MsSqlConnection { get; set; }
    }

    public class APIURIEntity
    {
        public string LogAPIURI { get; set; }

        public string OMSAPIURI { get; set; }
    }
}
