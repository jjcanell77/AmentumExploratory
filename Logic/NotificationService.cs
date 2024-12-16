namespace AmentumExploratory.Logic
{
    public class NotificationService : INotificationService
    {
        public NotificationService() { }
        public event Action<NotificationType, string, string> OnShow;
        public void ShowInfo(string message, string heading = "")
        {
            ShowNotification(NotificationType.Info, message, heading);
        }
        public void ShowSuccess(string message, string heading = "")
        {
            ShowNotification(NotificationType.Success, message, heading);
        }
        public void ShowError(string message, string heading = "")
        {
            ShowNotification(NotificationType.Error, message, heading);
        }
        public void ShowWarning(string message, string heading = "")
        {
            ShowNotification(NotificationType.Warning, message, heading);
        }
        public void ShowNotification(NotificationType type, string message, string heading = "")
        {
            OnShow?.Invoke(type, message, heading);
        }
    }
}
