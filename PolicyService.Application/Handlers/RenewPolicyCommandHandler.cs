using MediatR;
using PolicyService.Application.Commands;
using PolicyService.Contracts.DTOs;
using PolicyService.Domain.Interfaces;

namespace PolicyService.Application.Handlers
{
    public class RenewPolicyCommandHandler : IRequestHandler<RenewPolicyCommand, PolicyTimelineDto>
    {
        private readonly IPolicyRepository repo;
        private readonly IRatingEngine ratingEngine;

        public RenewPolicyCommandHandler(IPolicyRepository repo, IRatingEngine ratingEngine)
        {
            this.repo = repo;
            this.ratingEngine = ratingEngine;
        }

        public async Task<PolicyTimelineDto> Handle(RenewPolicyCommand request, CancellationToken cancellationToken)
        {
            var policy = await repo.GetByNumberAsync(request.Number, cancellationToken);
            if (policy is null)
                return null;

            policy.Renew(ratingEngine);

            await repo.SaveChangesAsync(cancellationToken);

            return new PolicyTimelineDto
            {
                Number = policy.Number,
                Periods = policy.Periods.Select(p => new PeriodDto
                {
                    Start = p.Start,
                    End = p.End,
                    Premium = p.Premium
                }).ToList()
            };
        }
    }
}
