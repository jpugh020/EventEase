using EventEase.Models;

namespace EventEase.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
    }

    public class EventService : IEventService
    {
        private readonly List<Event> _events = new()
        {
            new Event
            {
                Id = 1,
                Name = "Tech Conference 2025",
                Description = "Annual technology conference featuring the latest innovations",
                Date = DateTime.Parse("2025-10-15"),
                Location = "Convention Center",
                MaxAttendees = 500,
                Price = 299.99m,
                ImageUrl = "/images/tech-conf.jpg"
            },
            new Event
            {
                Id = 2,
                Name = "Business Summit 2025",
                Description = "Connect with industry leaders and explore business opportunities",
                Date = DateTime.Parse("2025-11-20"),
                Location = "Grand Hotel",
                MaxAttendees = 300,
                Price = 399.99m,
                ImageUrl = "/images/business-summit.jpg"
            },
            new Event
            {
                Id = 3,
                Name = "Design Workshop",
                Description = "Hands-on workshop for UX/UI designers",
                Date = DateTime.Parse("2025-09-30"),
                Location = "Creative Hub",
                MaxAttendees = 50,
                Price = 149.99m,
                ImageUrl = "/images/design-workshop.jpg"
            }
        };

        public Task<List<Event>> GetEventsAsync()
        {
            return Task.FromResult(_events);
        }

        public Task<Event?> GetEventByIdAsync(int id)
        {
            return Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
        }
    }
}
