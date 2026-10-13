using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}
