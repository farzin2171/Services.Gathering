using Gathering.Data.Database;
using Gathering.Domain.Entities;
using Gathering.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gathering.Data.Repostitories;

public class GatheringRepository : IGatheringRepository
{
    private readonly ApplicationDbContext _dbContext;

    public GatheringRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async  Task<GatheringEvent> GetByIdWithCreator(Guid id)
    {
        return await _dbContext.GatheringEvents
            .FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task InsertAsync(GatheringEvent gatheringEvent, CancellationToken cancellationToken)
    {
        await _dbContext.GatheringEvents.AddAsync(gatheringEvent,cancellationToken);
    }

    public void Update(GatheringEvent gatheringEvent)
    {
        _dbContext.GatheringEvents.Update(gatheringEvent);
    }
}

