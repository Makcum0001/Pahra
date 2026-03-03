using MediatR;
using Pahra.Domain.Models;
using Pahra.Domain.Repositories;

namespace Pahra.Application.Features.Participants.Queries;

public record GetParticipantByIdQuery(int id) : IRequest<Participant>;

public class GetParticipantByIdQueryHandler : IRequestHandler<GetParticipantByIdQuery, Participant>
{
    private readonly IParticipantRepository _participantRepository;
    
    public GetParticipantByIdQueryHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<Participant> Handle(GetParticipantByIdQuery request, CancellationToken cancellationToken)
    {
        return await _participantRepository.GetByIdAsync(request.id, cancellationToken);
    }
}

