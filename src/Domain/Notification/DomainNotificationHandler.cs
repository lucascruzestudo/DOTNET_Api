using MediatR;

namespace Domain.Notification;
public class DomainNotificationHandler : INotificationHandler<DomainNotification>
{
    private readonly List<DomainNotification> _notifications = [];

    public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
    {
        _notifications.Add(notification);
        return Task.CompletedTask;
    }

    public List<DomainNotification> GetNotifications()
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