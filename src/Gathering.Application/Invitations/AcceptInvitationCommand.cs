using MediatR;

namespace Gathering.Application.Invitations;

public sealed record AcceptInvitationCommand(Guid invitationId) : IRequest;


