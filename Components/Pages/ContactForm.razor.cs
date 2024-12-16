using AmentumExploratory.Data;
using AmentumExploratory.Data.Entities;
using AmentumExploratory.Logic;
using Microsoft.AspNetCore.Components;

namespace AmentumExploratory.Components.Pages
{
    public partial class ContactForm
    {
        [Inject]
        public required NavigationManager NavigationManager { get; set; }
        [Inject]
        public required DataAccessService DataAccessService { get; set; }
        [Inject]
        public INotificationService NotificationService { get; set; } = default!;
        public Contact ContactInformation { get; set; } = new();
        public List<ContactReason> ContactReasons { get; set; } = 
        [
            ContactReason.General,
            ContactReason.Inquiry,
            ContactReason.Pricing,
            ContactReason.Other
        ];

        public string NotificationMessage { get; set; } = "";
        public bool NotificationHidden { get; set; } = true;
        public NotificationType NotificationType { get; set; }

        public async Task SubmitForm()
        {
            try
            {
                await DataAccessService.AddContact(ContactInformation);
                NotificationMessage = "Contact form submitted successfully!";
                NotificationService.ShowSuccess("Contact form submitted successfully!", "Success");
                NavigationManager.NavigateTo("ContactList");
            }
            catch (Exception ex)
            {
                NotificationService.ShowError($"Error: {ex.Message}", "Error");
            }
        }
    }
}
