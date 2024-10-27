using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EduVentureMubarakWebApp.Client.Components;

public partial class ContactForm : ComponentBase
{
    private IReadOnlyDictionary<string, object>? _formAttr = new Dictionary<string, object>
    {
        { "class", "contact-form" }
    };

    private bool _formSubmitted;
    private Contact _model = new();

    private async Task HandleSubmit(EditContext context)
    {
        using (HttpClient http = new())
        {       
            // Formspree endpoint URL
            string formspreeUrl = "https://formspree.io/f/mdkoazor"; // Replace with your Formspree URL
            var response = await http.PostAsJsonAsync(formspreeUrl, _model);
            if (response.IsSuccessStatusCode) 
            { 
                _formSubmitted = true; 
            }
            StateHasChanged();
        }
    }

    public class Contact
    {
        [Required]
        [StringLength(16, ErrorMessage = "First Name length can't be more than 16.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Last Name length can't be more than 16.")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
            , ErrorMessage = "The field Email must match the example@example.com format.")]
        public string? Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$"
            , ErrorMessage = "The field Phone must match the +1234567890 format.")]
        public string? Phone { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Your Message must be at least 50 characters long.", MinimumLength = 50)]
        public string? Message { get; set; }
    }
}