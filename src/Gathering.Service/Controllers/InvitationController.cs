using Microsoft.AspNetCore.Mvc;
using MediatR;
using Gathering.Application.Invitations;
using Gathering.Application.Users.CreateUser;

namespace Gathering.Service.Controllers;

[Route("api/invitation")]
public class InvitationController : ApiController
{
    public InvitationController(ISender sender) : base(sender) { }

    [HttpPost("Send")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var command = new SendInvitationCommand(Guid.Parse("71C22BCA-A638-476B-BF21-BE9B68467550"),Guid.Parse("DA28C737-93FC-4D01-8CA8-2DA2BCABCD74"));
        await Sender.Send(command, cancellationToken);

        return Ok();

    }

    [HttpPost("Accept")]
    public async Task<IActionResult> Accept(CancellationToken cancellationToken)
    {
        var command = new AcceptInvitationCommand(Guid.Parse("594299E4-8CC1-4BE7-8B65-B1BFFD7C20CB"));
        await Sender.Send(command, cancellationToken);

        return Ok();

    }

}

