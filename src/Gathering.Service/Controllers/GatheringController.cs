using Microsoft.AspNetCore.Mvc;
using MediatR;
using Gathering.Application.Gatherings;
using Gathering.Application.Users.CreateUser;
using Gathering.Application.Gatherings.Commands.CreateGathering;

namespace Gathering.Service.Controllers;

[Route("api/gathering")]
public sealed class GatheringController : ApiController
{
    public GatheringController(ISender sender) : base(sender) { }

    [HttpPost]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var command = new CreateGatheringCommand
        {
            InvitationsValidBeforeInHours = 2,
            Location = "test",
            MaximumNumberOfAttendees = 3,
            Name = "name",
            ScheduledAtUtc = DateTime.UtcNow,
            Type = Domain.Enumerations.GatheringType.WithFixedNumberOfAttendees,
            UserId = Guid.Parse("BACDED35-1057-43B8-99FF-65DE1F2F9F54")
        };
        await Sender.Send(command, cancellationToken);

        return Ok();

    }

}

