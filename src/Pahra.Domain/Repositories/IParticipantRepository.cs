using Pahra.Domain.Models;

namespace Pahra.Domain.Repositories;

public interface IParticipantRepository
{
    public Task AddAsync(Participant participant, CancellationToken cancellationToken = default);
    public Task<List<Participant>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<Participant> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    public Task DeleteAsync(Participant participant, CancellationToken cancellationToken = default);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
