using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class UserSession
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime LastActivity { get; set; } = DateTime.Now;
        public bool IsAuthenticated { get; set; }
    }
}
