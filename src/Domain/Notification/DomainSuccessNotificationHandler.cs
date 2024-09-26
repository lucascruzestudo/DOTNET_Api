using MediatR;

namespace Domain.Notification;

public class DomainSuccessNotificationHandler : INotificationHandler<DomainSuccessNotification>
{
    private readonly List<DomainSuccessNotification> _notifications = [];

    public Task Handle(DomainSuccessNotification notification, CancellationToken cancellationToken)
    {
        _notifications.Add(notification);
        return Task.CompletedTask;
    }

    public List<DomainSuccessNotification> GetNotifications()
    {
        return _notifications;
    }

    public bool HasNotifications()
    {
        return _notifications.Any();
    }

    public void ClearNotifications()
    {
        _notifications.Clear();
    }
}
