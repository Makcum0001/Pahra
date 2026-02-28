using Pahra.Domain.Models;
using Pahra.Domain.Repositories;
using System;

namespace Pahra.Infrastructure.Data.Repositories;

public class ParticipantRepository : IParticipantRepository
{
    private readonly AppDbContext _context;

    public ParticipantRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Participant participant, CancellationToken cancellationToken = default)
    {
        _context.Participants.Add(participant);
        return _context.SaveChangesAsync(cancellationToken);
    }
}
