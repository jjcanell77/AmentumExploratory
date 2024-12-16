using Microsoft.EntityFrameworkCore.Migrations;

namespace AmentumExploratory
{
    public enum ContactReason
    {
        General,
        Inquiry,
        Pricing,
        Other
    }
    public enum NotificationType
    {
        Info,
        Success,
        Warning,
        Error
    }
}