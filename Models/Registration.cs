using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Event is required")]
        public int EventId { get; set; }

        public Event? Event { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [StringLength(500, ErrorMessage = "Special requirements cannot exceed 500 characters")]
        public string? SpecialRequirements { get; set; }

        public bool HasAttended { get; set; }
    }
    
}