using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Routes;
using TaskManagement.Mobile.Services;
using TaskManagement.Mobile.Services.Interfaces;

namespace TaskManagement.Mobile.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    public LoginViewModel(
        IAuthService authService,
        ITokenService tokenService
        )
    {
        _authService = authService;
        _tokenService = tokenService;
        
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            var request = new LoginRequest
            {
                Email = Email,
                Password = Password
            };

            var result = await _authService.LoginAsync(request);

            if (result is null)
            {
                ErrorMessage = "Correo o contraseña incorrectos.";
                return;
            }

            var token = await _tokenService.GetTokenAsync();

            await Shell.Current.GoToAsync(nameof(AppRoute.Task));
        }
        catch (Exception ex)
        {
            ErrorMessage = "No fue posible conectar con el servidor.";
        }
        finally
        {
            IsBusy = false;
        }
    }
}