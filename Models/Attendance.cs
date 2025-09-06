using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public Registration? Registration { get; set; }
        public DateTime CheckInTime { get; set; }
        public string? CheckInNotes { get; set; }
    }
}
