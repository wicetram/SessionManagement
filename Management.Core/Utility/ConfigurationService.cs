using Microsoft.Extensions.Configuration;

namespace Management.Core.Utility
{
    public  static class ConfigurationService
    {
        private static IConfiguration? _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string? GetConnectionString(string name)
        {
            return _configuration?.GetConnectionString(name);
        }
    }
}
