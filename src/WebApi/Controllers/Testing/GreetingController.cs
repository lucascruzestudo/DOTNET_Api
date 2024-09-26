using Application.Features.Testing.Greeting;
using Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GreetingController : BaseController
{
    private readonly IMediator _mediator;

    public GreetingController(IMediator mediator, 
                              INotificationHandler<DomainNotification> notificationHandler,
                              INotificationHandler<DomainSuccessNotification> successNotificationHandler)
        : base(notificationHandler, successNotificationHandler, mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Greet"
    )]
    [ProducesResponseType(typeof(GreetingCommandResponse), 200)]
    public async Task<IActionResult> Greet([FromBody] GreetingCommand command)
    {
        var response = await _mediator.Send(command);
        return Response(response);
    }
}
