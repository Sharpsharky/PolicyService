using MediatR;
using Microsoft.AspNetCore.Mvc;
using PolicyService.Application.Commands;
using PolicyService.Application.Queries;
using PolicyService.Contracts.DTOs;

namespace PolicyService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly IMediator mediator;

        public PolicyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<PolicyTimelineDto>> Create([FromBody] CreatePolicyCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{number}/renew")]
        public async Task<ActionResult<PolicyTimelineDto>> Renew(string number)
        {
            var result = await mediator.Send(new RenewPolicyCommand(number));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<PolicyTimelineDto>> Get(string number)
        {
            var result = await mediator.Send(new GetPolicyTimelineQuery(number));

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
