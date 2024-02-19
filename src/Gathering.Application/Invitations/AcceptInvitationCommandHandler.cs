

using Gathering.Data.Repostitories;
using Gathering.Domain.Entities;
using Gathering.Domain.Enumerations;
using Gathering.Domain.Repositories;
using MediatR;

namespace Gathering.Application.Invitations;

public class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand>
{
    private readonly IInvitationRepository _invitationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IGatheringRepository _gatheringRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAttendeeRepository _attendeeRepository;

    public AcceptInvitationCommandHandler(IInvitationRepository invitationRepository,
                                          IUserRepository userRepository,
                                          IGatheringRepository gatheringRepository,
                                          IUnitOfWork unitOfWork,
                                          IAttendeeRepository attendeeRepository)
    {
        _invitationRepository = invitationRepository;
        _userRepository = userRepository;
        _gatheringRepository = gatheringRepository;
        _unitOfWork = unitOfWork;
        _attendeeRepository = attendeeRepository;
    }
    public async Task Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
    {
        var invitation = await _invitationRepository.GetByIdAsync(request.invitationId);

        if (invitation is null || invitation.Status != InvitationStatus.Pending)
        {
            throw new Exception("not acceptabel");
        }

        var user = await _userRepository.GetByIdAsync(invitation.UserId);

        var gattering = await _gatheringRepository.GetByIdWithCreator(invitation.GatheringEventId);

        if (user is null || gattering is null)
        {
            throw new Exception("gathering is null");
        }

        var attendee = gattering.AcceptInvitation(invitation);

        if(attendee is not null)
        {
            await _attendeeRepository.InsertAsync(attendee);
        }

        _invitationRepository.Update(invitation);
        _gatheringRepository.Update(gattering);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }
}

