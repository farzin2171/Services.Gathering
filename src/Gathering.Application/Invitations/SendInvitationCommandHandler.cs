using EventReminder.Domain.Core.Primitives.Result;
using Gathering.Domain.Entities;
using Gathering.Domain.Enumerations;
using Gathering.Domain.Repositories;
using MediatR;

namespace Gathering.Application.Invitations;

internal sealed class SendInvitationCommandHandler : IRequestHandler<SendInvitationCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IGatheringRepository _gatheringRepository;
    private readonly IInvitationRepository _invitationRepository;
    private readonly IUnitOfWork _unitOfWork;
    public SendInvitationCommandHandler(IInvitationRepository invitationRepository,
                                        IGatheringRepository gatheringRepository,
                                        IUserRepository userRepository,
                                        IUnitOfWork unitOfWork)
    {

        _invitationRepository = invitationRepository;
        _gatheringRepository = gatheringRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;

    }
    public async Task Handle(SendInvitationCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.userId);
        var gathering = await _gatheringRepository.GetByIdWithCreator(request.gatheringId);

        if (user is null || gathering is null)
        {
            throw new Exception("user or gathering is not found");
        }

       
        

        Result<Invitation> invitationResult = gathering.SendInvitation(user);

        if(invitationResult.IsFailure)
        {
            //log
            
        }

        await _invitationRepository.InsertAsync(invitationResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

