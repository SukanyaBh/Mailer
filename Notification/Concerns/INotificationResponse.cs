namespace Notification.Concerns
{
    /// <summary>
    /// Base response interface for all types of notifications
    /// </summary>
    public interface INotificationResponse
    {
        NotificationStatus Status { get; set; }
    }
}
