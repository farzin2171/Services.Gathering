using MediatR;

namespace Gathering.Application.Invitations
{
    public sealed record SendInvitationCommand(Guid userId, Guid gatheringId) : IRequest;
}
