using MediatR;
using PolicyService.Contracts.DTOs;

namespace PolicyService.Application.Commands
{
    public record RenewPolicyCommand(string Number) : IRequest<PolicyTimelineDto>;
}
