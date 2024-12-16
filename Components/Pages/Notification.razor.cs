using AmentumExploratory.Logic;
using Microsoft.AspNetCore.Components;

namespace AmentumExploratory.Components.Pages
{
    public partial class Notification
    {
        [Inject]
        private INotificationService NotificationService { get; set; }

        private string Message { get; set; } = "";
        private string Heading { get; set; } = "";
        private bool IsHidden { get; set; } = true;
        private string NotificationClass { get; set; } = "alert-info";

        protected override void OnInitialized()
        {
            NotificationService.OnShow += ShowNotification;
        }

        private void ShowNotification(NotificationType type, string message, string heading)
        {
            InvokeAsync(() =>
            {
                Heading = heading;
                Message = message;
                NotificationClass = type switch
                {
                    NotificationType.Success => "alert alert-success",
                    NotificationType.Error => "alert alert-danger",
                    NotificationType.Warning => "alert alert-warning",
                    NotificationType.Info => "alert alert-info",
                    _ => "alert alert-secondary"
                };
                IsHidden = false;

                InvokeAsync(async () =>
                {
                    await Task.Delay(10000);
                    IsHidden = true;
                    StateHasChanged();
                });

                StateHasChanged();
            });
        }

        public void Dispose()
        {
            NotificationService.OnShow -= ShowNotification;
        }
    }
}
