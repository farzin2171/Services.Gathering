using EventReminder.Domain.Core.Errors;
using EventReminder.Domain.Core.Primitives;
using EventReminder.Domain.Core.Primitives.Result;
using Gathering.Domain.Core.Exceptions;
using Gathering.Domain.Enumerations;
using Gathering.Domain.Primitives;
using Gathering.Domain.Repositories;
using MediatR;
using System.Threading;

namespace Gathering.Domain.Entities;
public class GatheringEvent:Entity
{
    private readonly List<Invitation> _invitations = new();

    private readonly List<Attendee> _attendees = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="GatheringEvent"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    protected GatheringEvent(){}

    public GatheringEvent(Guid id,
                          User creator,
                          GatheringType gatheringType,
                          DateTime scheduledAtUtc,
                          string name,
                          string location)
    {
        Id = id;
        CreatorId = creator.Id;
        Type = gatheringType;
        ScheduledAtUtc = scheduledAtUtc;
        Name = name;
        Location = location;
    }

    public Guid CreatorId { get; private set; }

    public GatheringType Type { get; private set; }

    public string Name { get; private set; } = String.Empty;

    public DateTime ScheduledAtUtc { get; private set; }

    public string? Location { get; private set; }

    public int? MaximumNumberOfAttendees { get;  private set; }

    public DateTime? InvetiationExpireAtUtc { get;  private set; }

    public int NumberOfAttendees { get; set; }
   

    public IReadOnlyCollection<Attendee> Attendees => _attendees;

    public IReadOnlyCollection<Invitation> Invitations => _invitations;

    //Static factory method
    public static GatheringEvent Create(Guid id,
                          User creator,
                          GatheringType gatheringType,
                          DateTime scheduledAtUtc,
                          string name,
                          string location,
                          int? maximumNumberOfAttendees,
                          int? invitationsValidBeforeInHours)
    {

        var gathering = new GatheringEvent(id,
                                          creator,
                                          gatheringType,
                                          scheduledAtUtc,
                                          name,
                                          location);

        switch (gatheringType)
        {
            case GatheringType.WithFixedNumberOfAttendees:
                if (maximumNumberOfAttendees is null)
                {
                    throw new GattheringMaximumNumberOfAtteniesIsNullDomainException($"{nameof(maximumNumberOfAttendees)} can't be null");
                }
                gathering.MaximumNumberOfAttendees = maximumNumberOfAttendees;
                break;
            case GatheringType.WithExpirationForInvitation:
                if (invitationsValidBeforeInHours is null)
                {
                    throw new InvitationsValidBeforeInHoursException($"{nameof(invitationsValidBeforeInHours)} can't be null");
                }
                gathering.InvetiationExpireAtUtc = scheduledAtUtc.AddHours(-invitationsValidBeforeInHours.Value);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(GatheringType));
        }

        return gathering;
    }

    public Result<Invitation> SendInvitation(User user)
    {
        if (CreatorId == user.Id)
        {
           return Result.Failure<Invitation>(DomainErrors.Invitation.NotFound);
        }

        //if (ScheduledAtUtc < DateTime.UtcNow)
        //{
        //    throw new Exception("can't send invitation for gathering past");
        //}

        var invitation = new Invitation(Guid.NewGuid(),this, user);

        _invitations.Add(invitation);

        return invitation;

    }

    public Attendee? AcceptInvitation(Invitation invitation)
    {

        var expired = (Type == GatheringType.WithFixedNumberOfAttendees &&
                     NumberOfAttendees == MaximumNumberOfAttendees) ||
                     (Type == GatheringType.WithExpirationForInvitation &&
                      InvetiationExpireAtUtc < DateTime.UtcNow);
        if (expired)
        {
            invitation.Expire();
            return null;
        }
        var attendee = invitation.Accept();
        _attendees.Add(attendee);
        this.NumberOfAttendees++;

        return attendee;
    }

}
