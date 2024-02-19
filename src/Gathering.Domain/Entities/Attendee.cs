using Gathering.Domain.Primitives;
using System.Linq.Expressions;

namespace Gathering.Domain.Entities;
public class Attendee : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Attendee"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    protected Attendee(){ }

    public Attendee(Invitation invitation)
    {
        GatheringEventId = invitation.GatheringEventId;
        UserId = invitation.UserId;
        Id = Guid.NewGuid();
    }

    public Guid UserId { get; private set; }

    public Guid GatheringEventId { get; private set; }

}