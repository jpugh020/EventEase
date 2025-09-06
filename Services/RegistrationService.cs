using EventEase.Models;

namespace EventEase.Services
{
    public interface IRegistrationService
    {
        Task<List<Registration>> GetEventRegistrationsAsync(int eventId);
        Task<Registration?> GetRegistrationAsync(int registrationId);
        Task<Registration> CreateRegistrationAsync(Registration registration);
        Task<bool> UpdateAttendanceAsync(int registrationId, bool hasAttended);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly List<Registration> _registrations = new();
        private int _nextId = 1;

        public Task<List<Registration>> GetEventRegistrationsAsync(int eventId)
        {
            return Task.FromResult(_registrations.Where(r => r.EventId == eventId).ToList());
        }

        public Task<Registration?> GetRegistrationAsync(int registrationId)
        {
            return Task.FromResult(_registrations.FirstOrDefault(r => r.Id == registrationId));
        }

        public Task<Registration> CreateRegistrationAsync(Registration registration)
        {
            registration.Id = _nextId++;
            registration.RegistrationDate = DateTime.Now;
            _registrations.Add(registration);
            return Task.FromResult(registration);
        }

        public Task<bool> UpdateAttendanceAsync(int registrationId, bool hasAttended)
        {
            var registration = _registrations.FirstOrDefault(r => r.Id == registrationId);
            if (registration == null)
                return Task.FromResult(false);

            registration.HasAttended = hasAttended;
            return Task.FromResult(true);
        }
    }
}
