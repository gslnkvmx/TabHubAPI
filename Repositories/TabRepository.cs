using Microsoft.EntityFrameworkCore;
using System.Threading;
using TabHubAPI.DataAccess;
using TabHubAPI.Models;

namespace TabHubAPI.Repositories
{
    public class TabRepository : ITabRepository
    {
        private readonly ThDbContext _dbContext;
        public TabRepository(ThDbContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(Tab entity, CancellationToken cancellationToken)
        {
            await _dbContext.Tabs.AddAsync(entity, cancellationToken);
        }

        public async Task<List<Tab>> GetAllAsync(CancellationToken cancellationToken)
        {
            var tabs = _dbContext.Tabs;

            return await tabs.ToListAsync(cancellationToken);
        }

        public async Task<Tab?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Tab? tab = null;
            try
            {
                tab = await _dbContext.Tabs.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"При поиске tab с ID {id} возникла ошибка:", ex);
            }

            return tab;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(Tab entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Tab entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
