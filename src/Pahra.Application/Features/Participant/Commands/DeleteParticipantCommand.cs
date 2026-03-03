using MediatR;
using Pahra.Domain.Repositories;

namespace Pahra.Application.Features.Participants.Commands;

public record DeleteParticipantCommand(int Id) : IRequest;

public class DeleteParticipantCommandHandler: IRequestHandler<DeleteParticipantCommand>
{   
    private readonly IParticipantRepository _participantRepository;

    public DeleteParticipantCommandHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
    {
        var participant = await _participantRepository.GetByIdAsync(request.Id, cancellationToken);

        await _participantRepository.DeleteAsync(participant, cancellationToken);
        
        await _participantRepository.SaveChangesAsync(cancellationToken);
    }
}
