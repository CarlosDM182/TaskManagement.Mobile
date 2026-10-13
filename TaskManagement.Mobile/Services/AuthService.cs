using System.Net.Http.Json;
using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Services.Interfaces;

namespace TaskManagement.Mobile.Services;

public class AuthService : IAuthService
{
    private readonly IApiClient _apiClient;
    private readonly ITokenService _tokenService;

    public AuthService(
    IApiClient apiClient,
    ITokenService tokenService)
    {
        _apiClient = apiClient;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var result = await _apiClient.PostAsync<LoginRequest, LoginResponse>(
            "api/auth/login",
            request);

        if (result is not null)
        {
            await _tokenService.SaveTokenAsync(result?.Data?.Token ?? default!);
        }

        return result?.Data;
    }
}