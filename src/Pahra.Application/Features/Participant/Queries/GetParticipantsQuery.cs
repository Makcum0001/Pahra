using MediatR;
using Pahra.Domain.Models;
using Pahra.Domain.Repositories;

namespace Pahra.Application.Features.Participants.Queries;

public record GetParticipantsQuery : IRequest<List<Participant>>;

public class GetParticipantsQueryHandler : IRequestHandler<GetParticipantsQuery, List<Participant>>
{
    private readonly IParticipantRepository _participantRepository;

    public GetParticipantsQueryHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public Task<List<Participant>> Handle(GetParticipantsQuery request, CancellationToken cancellationToken)
    {
        return _participantRepository.GetAllAsync(cancellationToken);
    }
}
