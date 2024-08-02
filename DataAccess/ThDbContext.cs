using Microsoft.EntityFrameworkCore;
using TabHubAPI.Models;

namespace TabHubAPI.DataAccess
{
    public class ThDbContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public ThDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Tab> Tabs => Set<Tab>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }
    }
}
