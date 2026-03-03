using MediatR;
using Pahra.Domain.Repositories;

namespace Pahra.Application.Features.Participants.Commands;

public record UpdateParticipantCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
) : IRequest;

public class UpdateParticipantCommandHandler : IRequestHandler<UpdateParticipantCommand>
{
    private readonly IParticipantRepository _participantRepository;

    public UpdateParticipantCommandHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
    {
        var participant = await _participantRepository.GetByIdAsync(request.Id, cancellationToken);

        participant.FirstName= request.FirstName;
        participant.LastName = request.LastName;
        participant.Email = request.Email;
        participant.PhoneNumber = request.PhoneNumber;

        await _participantRepository.SaveChangesAsync(cancellationToken);
    }
}
