using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pahra.Application.Features.Participants.Commands;

[ApiController]
[Route("api/[controller]")]
public class ParticipantsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ParticipantsController> _logger;

    public ParticipantsController(IMediator mediator, ILogger<ParticipantsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> CreateAsync([FromBody] CreateParticipantCommand command)
    {
        if (command == null)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);

        return Created($"/api/participants/{id}", id);
    }
}
