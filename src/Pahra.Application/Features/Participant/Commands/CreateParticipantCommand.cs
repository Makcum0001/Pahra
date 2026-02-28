using MediatR;
using Pahra.Domain.Models;
using Pahra.Domain.Repositories;

namespace Pahra.Application.Features.Participants.Commands;

public record CreateParticipantCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber) : IRequest<int>;

public class CreateParticipantCommandHandler : IRequestHandler<CreateParticipantCommand, int>
{
    private readonly IParticipantRepository _participantRepository;

    public CreateParticipantCommandHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<int> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
    {
        var participant = new Participant
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        await _participantRepository.AddAsync(participant, cancellationToken);

        return participant.Id;
    }
}
