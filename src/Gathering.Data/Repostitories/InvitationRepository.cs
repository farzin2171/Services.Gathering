using Gathering.Data.Database;
using Gathering.Domain.Entities;
using Gathering.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gathering.Data.Repostitories;

public class InvitationRepository : IInvitationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InvitationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Invitation> GetByIdAsync(Guid invitationId)
    {
        return _dbContext.Invitations.FirstOrDefaultAsync(c=>c.Id == invitationId);
    }

    public async Task InsertAsync(Invitation invitation)
    {
       await _dbContext.Invitations.AddAsync(invitation);
    }

    public void Update(Invitation invitation)
    {
       _dbContext.Invitations.Update(invitation);
    }
}

