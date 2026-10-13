using TaskManagement.Mobile.ViewModels;

namespace TaskManagement.Mobile.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}