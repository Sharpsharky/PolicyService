using MediatR;
using PolicyService.Application.Commands;
using PolicyService.Contracts.DTOs;
using PolicyService.Domain.Interfaces;
using PolicyService.Domain.Models;

namespace PolicyService.Application.Handlers
{
    public class CreatePolicyCommandHandler : IRequestHandler<CreatePolicyCommand, PolicyTimelineDto>
    {
        private readonly IPolicyRepository repo;

        public CreatePolicyCommandHandler(IPolicyRepository repo)
        {
            this.repo = repo;
        }

        public async Task<PolicyTimelineDto> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
        {
            if (request.Start > request.End)
                throw new ArgumentException("Start date cannot be after end date");

            var initialPeriod = new PolicyPeriod(request.Start, request.End, request.Premium);
            var policy = new Policy(request.Number, initialPeriod);

            await repo.AddAsync(policy, cancellationToken);
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
