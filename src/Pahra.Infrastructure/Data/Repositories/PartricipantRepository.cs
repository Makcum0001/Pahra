using Microsoft.EntityFrameworkCore;
using Pahra.Domain.Models;
using Pahra.Domain.Repositories;

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

    public async Task DeleteAsync(Participant participant, CancellationToken cancellationToken = default)
    {
        _context.Participants.Remove(participant);
    }

    public async Task<List<Participant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Participants.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Participant> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var participant = await _context.Participants.FindAsync(id, cancellationToken);
        return participant;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
