using Microsoft.Extensions.Configuration;

namespace Management.Core.Utility
{
    public static class ConfigurationService
    {
        /// <summary>
        /// Parametrik olarak kayıtlı olan ConnectionString değerini getirir
        /// </summary>
        /// <param name="name">MerchantDb, VPosDb, BillPayDb</param>
        /// <returns></returns>
        public static string? GetConnectionString(string name)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string? connection = configuration.GetConnectionString(name);
            return connection;
        }
    }
}
