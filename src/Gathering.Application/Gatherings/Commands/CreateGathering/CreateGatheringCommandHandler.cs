using Gathering.Domain.Repositories;
using Gathering.Domain;
using MediatR;
using System;
using Gathering.Domain.Entities;
using Gathering.Domain.Enumerations;

namespace Gathering.Application.Gatherings.Commands.CreateGathering;

public sealed class CreateGatheringCommandHandler : IRequestHandler<CreateGatheringCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IGatheringRepository _gatheringRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGatheringCommandHandler(IUserRepository userRepository,
                                         IGatheringRepository gatheringRepository,
                                         IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _gatheringRepository = gatheringRepository;
        _unitOfWork = unitOfWork;

    }

    public async Task Handle(CreateGatheringCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var gathering = GatheringEvent.Create(Guid.NewGuid(),
                                               user,
                                               request.Type,
                                               request.ScheduledAtUtc,
                                               request.Name,
                                               request.Location,
                                               request.MaximumNumberOfAttendees,
                                               request.InvitationsValidBeforeInHours);

        await _gatheringRepository.InsertAsync(gathering, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

