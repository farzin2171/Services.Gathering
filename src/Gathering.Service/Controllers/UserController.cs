using Microsoft.AspNetCore.Mvc;
using MediatR;
using Gathering.Application.Users.CreateUser;

namespace Gathering.Service.Controllers;

[Route("api/users")]
public sealed class UserController : ApiController
{
    public UserController(ISender sender) : base(sender) { }

    [HttpPost]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand("hoori", "ho", "ho@gmail.com",Guid.NewGuid().ToString());
        await Sender.Send(command,cancellationToken);

        return Ok();    

    }

}



