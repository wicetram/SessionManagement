using Management.Core.Utility;
using Management.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Management.DataAccess.Concrete.EntityFramework.Contexts
{
    public class DatabaseContext : DbContext
    {
        private static string? Connection => ConfigurationService.GetConnectionString("MyConn");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection);
            }
        }

        public DbSet<MerchantDto> MerchantList { get; set; }
    }
}
