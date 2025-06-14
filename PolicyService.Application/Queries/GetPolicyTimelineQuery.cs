using MediatR;
using PolicyService.Contracts.DTOs;

namespace PolicyService.Application.Queries
{
    public record GetPolicyTimelineQuery(string Number) : IRequest<PolicyTimelineDto>;
}
