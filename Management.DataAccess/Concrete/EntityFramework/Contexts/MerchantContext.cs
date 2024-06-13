using Management.Core.Utility;
using Management.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Management.DataAccess.Concrete.EntityFramework.Contexts
{
    public class MerchantContext : DbContext
    {
        private static string? Connection => ConfigurationService.GetConnectionString("MerchantDb");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection);
            }
        }

        public DbSet<Merchant> MerchantList { get; set; }
    }
}
