using Microsoft.EntityFrameworkCore;
using TabHubAPI.Models;

namespace TabHubAPI.DataAccess
{
    public class ThDbContext: DbContext
    {
        public ThDbContext(DbContextOptions<ThDbContext> options) : base(options)
        {
        }

        public DbSet<Tab> Tabs => Set<Tab>();
        public DbSet<TabCollection> TabCollections => Set<TabCollection>();
    }
}
