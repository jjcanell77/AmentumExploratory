namespace AmentumExploratory.Logic
{
    public interface INotificationService
    {
        event Action<NotificationType, string, string> OnShow;
        void ShowInfo(string message, string heading = "");
        void ShowSuccess(string message, string heading = "");
        void ShowError(string message, string heading = "");
        void ShowWarning(string message, string heading = "");
        void ShowNotification(NotificationType type, string message, string heading = "");
    }
}
