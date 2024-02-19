using Gathering.Domain.Enumerations;
using MediatR;

namespace Gathering.Application.Gatherings.Commands.CreateGathering;

public sealed class CreateGatheringCommand : IRequest
{
    public Guid UserId { get; set; }
    public DateTime ScheduledAtUtc { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    public GatheringType Type { get; set; }

    public int? MaximumNumberOfAttendees { get; set; }

    public int? InvitationsValidBeforeInHours { get; set; }
}

