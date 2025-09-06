using System;
using System.ComponentModel.DataAnnotations;
using EventEase.Models.Validation;

namespace EventEase.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required")]
        [FutureDate(ErrorMessage = "Event date must be in the future")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Range(1, 10000, ErrorMessage = "Maximum attendees must be between 1 and 10000")]
        public int MaxAttendees { get; set; }

        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000")]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "Please provide a valid URL for the image")]
        public string ImageUrl { get; set; } = string.Empty;

        public string OrganizerId { get; set; } = string.Empty;

        public bool IsAvailable => MaxAttendees > 0;
    }
}
