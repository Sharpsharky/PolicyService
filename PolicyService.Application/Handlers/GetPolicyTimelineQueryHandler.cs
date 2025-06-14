using MediatR;
using PolicyService.Application.Queries;
using PolicyService.Contracts.DTOs;
using PolicyService.Domain.Interfaces;

namespace PolicyService.Application.Handlers
{
    public class GetPolicyTimelineQueryHandler : IRequestHandler<GetPolicyTimelineQuery, PolicyTimelineDto>
    {
        private readonly IPolicyRepository repo;

        public GetPolicyTimelineQueryHandler(IPolicyRepository repo)
        {
            this.repo = repo;
        }

        public async Task<PolicyTimelineDto> Handle(GetPolicyTimelineQuery request, CancellationToken cancellationToken)
        {
            var policy = await repo.GetByNumberAsync(request.Number, cancellationToken);
            if (policy is null)
                return null;

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
