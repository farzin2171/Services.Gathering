using Gathering.Domain.Enumerations;
using Gathering.Domain.Primitives;

namespace Gathering.Domain.Entities;
public class Invitation : Entity
{
    internal Invitation(){ }

    public Invitation(Guid id, GatheringEvent gatheringEvent, User user)
    {
        Id = id;
        UserId = user.Id;
        GatheringEventId = gatheringEvent.Id;
        Status = InvitationStatus.Pending;
    }

    public Guid UserId { get; private set; }

    public Guid GatheringEventId { get; private set; }

    public InvitationStatus Status { get; private set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public void Expire()
    {
        Status = InvitationStatus.Expired;
        ModifiedOnUtc = DateTime.UtcNow;
    }

    public Attendee Accept()
    {
        Status = InvitationStatus.Accepted;
        ModifiedOnUtc = DateTime.UtcNow;

        return new Attendee(this);
    }
}
