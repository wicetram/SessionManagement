using Management.Entity.Dto;
using Microsoft.Extensions.Configuration;

namespace Management.Core.Utility
{
    public static class JWTKeyService
    {
        /// <summary>
        /// JWT için gerekli olan parametreleri döner
        /// </summary>
        /// <returns></returns>
        public static JWTResponseDto? GetJWT()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var jwtSection = configuration.GetSection("Jwt");
            if (jwtSection == null)
            {
                return null;
            }

            var jwtResponseDto = new JWTResponseDto
            {
                Key = jwtSection["Key"] ?? "",
                Issuer = jwtSection["Issuer"],
                Audience = jwtSection["Audience"]
            };

            return jwtResponseDto;
        }
    }
}
