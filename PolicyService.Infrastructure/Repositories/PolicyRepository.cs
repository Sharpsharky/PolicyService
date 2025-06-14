using Microsoft.EntityFrameworkCore;
using PolicyService.Domain.Interfaces;
using PolicyService.Domain.Models;
using PolicyService.Infrastructure.Persistence;

namespace PolicyService.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly PolicyDbContext context;

        public PolicyRepository(PolicyDbContext context)
        {
            this.context = context;
        }

        public Task<Policy?> GetByNumberAsync(string number, CancellationToken cancellationToken)
        {
            return context.Policies
                .Include(p => p.Periods)
                .FirstOrDefaultAsync(p => p.Number == number, cancellationToken);
        }

        public async Task AddAsync(Policy policy, CancellationToken cancellationToken)
        {
            await context.Policies.AddAsync(policy, cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
