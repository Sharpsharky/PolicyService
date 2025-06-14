using MediatR;
using PolicyService.Contracts.DTOs;

namespace PolicyService.Application.Commands
{
    public record CreatePolicyCommand(
        string Number,
        DateTime Start,
        DateTime End,
        decimal Premium
    ) : IRequest<PolicyTimelineDto>;
}