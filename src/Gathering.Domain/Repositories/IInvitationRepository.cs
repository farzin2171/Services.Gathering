using Gathering.Domain.Entities;

namespace Gathering.Domain.Repositories
{
    public interface IInvitationRepository
    {
        Task<Invitation> GetByIdAsync(Guid invitationId);
        Task InsertAsync(Invitation invitation);

        void Update(Invitation invitation);
    }
}
