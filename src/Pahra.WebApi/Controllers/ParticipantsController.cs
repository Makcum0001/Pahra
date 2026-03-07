using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pahra.Application.Features.Participants.Commands;
using Pahra.Application.Features.Participants.Queries;
using Pahra.Domain.Models;

namespace Pahra.WebApi.Controllers;

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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Participant>>> GetAsync(CancellationToken cancellationToken)
    {
        var participants = await _mediator.Send(new GetParticipantsQuery(), cancellationToken);
        return Ok(participants);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Participant>> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var participant = await _mediator.Send(new GetParticipantByIdQuery(id));

        return Ok(participant);
    }   

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> CreateAsync([FromBody] CreateParticipantCommand command)
    {
        if (command is null)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);

        return Created($"/api/participants/{id}", id);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateParticipantCommand command)
    {
        if (command is null)
        {
            return BadRequest();
        }

        await _mediator.Send(command);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        await _mediator.Send(new DeleteParticipantCommand(id));

        return NoContent();
    }
}
