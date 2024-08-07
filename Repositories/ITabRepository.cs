using TabHubAPI.Models;

namespace TabHubAPI.Repositories
{
    public interface ITabRepository
    {
        Task<List<Tab>> GetAllAsync(CancellationToken cancellationToken);
        Task<Tab?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(Tab entity, CancellationToken cancellationToken);
        Task UpdateAsync(Tab entity, CancellationToken cancellationToken);
        Task DeleteAsync(Tab entity, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
