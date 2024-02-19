using Gathering.Domain.Entities;

namespace Gathering.Domain.Repositories
{
    public interface IGatheringRepository
    {
        Task<GatheringEvent> GetByIdWithCreator(Guid id);
        Task InsertAsync(GatheringEvent gatheringEvent,CancellationToken cancellationToken);
        void Update(GatheringEvent gatheringEvent);

    }
}
