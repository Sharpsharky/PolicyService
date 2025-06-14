using PolicyService.Domain.Models;

namespace PolicyService.Domain.Interfaces
{
    public interface IPolicyRepository
    {
        Task<Policy?> GetByNumberAsync(string number, CancellationToken cancellationToken);
        Task AddAsync(Policy policy, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}