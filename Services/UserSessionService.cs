using EventEase.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace EventEase.Services
{
    public interface IUserSessionService
    {
        Task<UserSession> GetCurrentSessionAsync();
        Task UpdateSessionAsync(UserSession session);
        Task ClearSessionAsync();
    }

    public class UserSessionService : IUserSessionService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string StorageKey = "eventease_session";
        private UserSession? _currentSession;

        public UserSessionService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<UserSession> GetCurrentSessionAsync()
        {
            if (_currentSession != null)
            {
                return _currentSession;
            }

            try
            {
                var storedSession = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
                if (!string.IsNullOrEmpty(storedSession))
                {
                    _currentSession = JsonSerializer.Deserialize<UserSession>(storedSession);
                    if (_currentSession != null)
                    {
                        // Update last activity
                        _currentSession.LastActivity = DateTime.Now;
                        await UpdateSessionAsync(_currentSession);
                        return _currentSession;
                    }
                }
            }
            catch
            {
                // If there's any error, create a new session
            }

            _currentSession = new UserSession();
            await UpdateSessionAsync(_currentSession);
            return _currentSession;
        }

        public async Task UpdateSessionAsync(UserSession session)
        {
            _currentSession = session;
            var serialized = JsonSerializer.Serialize(session);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, serialized);
        }

        public async Task ClearSessionAsync()
        {
            _currentSession = null;
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", StorageKey);
        }
    }
}
