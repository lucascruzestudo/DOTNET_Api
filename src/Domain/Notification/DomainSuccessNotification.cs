using MediatR;

namespace Domain.Notification;
public class DomainSuccessNotification : INotification
    {
        public DateTime Timestamp { get; private set; }
        public Guid NotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainSuccessNotification(string key, string value)
        {
            Timestamp = DateTime.UtcNow;
            NotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }
    }