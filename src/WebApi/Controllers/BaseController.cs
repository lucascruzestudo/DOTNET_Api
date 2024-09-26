using Domain.Common;
using Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
    private readonly DomainNotificationHandler _notificationHandler;
    private readonly DomainSuccessNotificationHandler _successNotificationHandler;
    private readonly IMediator _mediator;

    protected BaseController(INotificationHandler<DomainNotification> notificationHandler,
                             INotificationHandler<DomainSuccessNotification> successNotificationHandler,
                             IMediator mediator)
    {
        _notificationHandler = (DomainNotificationHandler)notificationHandler;
        _successNotificationHandler = (DomainSuccessNotificationHandler)successNotificationHandler;
        _mediator = mediator;
    }

    /// <summary>
    /// Checks if the operation is valid by verifying if there are any notifications.
    /// </summary>
    /// <returns>True if the operation is valid, otherwise false.</returns>
    protected bool IsOperationValid()
    {
        return !_notificationHandler.HasNotifications();
    }

    /// <summary>
    /// Gets all error messages from notifications.
    /// </summary>
    /// <returns>A list of error messages.</returns>
    protected IEnumerable<string> GetErrorMessages()
    {
        return _notificationHandler.GetNotifications().Select(n => n.Value).ToList();
    }

    /// <summary>
    /// Gets all success messages from success notifications.
    /// </summary>
    /// <returns>A list of success messages.</returns>
    protected IEnumerable<string> GetSuccessMessages()
    {
        return _successNotificationHandler.GetNotifications().Select(n => n.Value).ToList();
    }

    /// <summary>
    /// Notifies an error using the mediator.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    protected void NotifyError(string code, string message)
    {
        _mediator.Publish(new DomainNotification(code, message));
    }

    /// <summary>
    /// Formats the API response based on the validation of the operation.
    /// </summary>
    /// <param name="result">Optional result data to be included in the response.</param>
    /// <returns>An IActionResult representing the result of the operation.</returns>
    protected new IActionResult Response(object? result = null)
    {
        if (IsOperationValid())
            return Ok(ResponseBase<object?>.Success(result, GetSuccessMessages()));

        return BadRequest(ResponseBase<object>.Failure(GetErrorMessages()));
    }
}