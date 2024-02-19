using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Gathering.Service.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    public ApiController(ISender sender)
    {
        Sender = sender; 
    }
}

