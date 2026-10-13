using TaskManagement.Mobile.Services.Interfaces;

namespace TaskManagement.Mobile.Services;

public class TokenService : ITokenService
{
    private const string TokenKey = "auth_token";

    public async Task SaveTokenAsync(string token)
    {
        await SecureStorage.SetAsync(TokenKey, token);
    }

    public async Task<string?> GetTokenAsync()
    {
        return await SecureStorage.GetAsync(TokenKey);
    }

    public Task RemoveTokenAsync()
    {
        SecureStorage.Remove(TokenKey);

        return Task.CompletedTask;
    }
}