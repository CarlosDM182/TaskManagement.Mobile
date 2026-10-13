#if ANDROID
using TaskManagement.Mobile.Platforms.Android;
#endif
using TaskManagement.Mobile.ViewModels;

namespace TaskManagement.Mobile.Views;

public partial class TaskPage : ContentPage
{
    public TaskPage(TaskViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        var status = await Permissions.CheckStatusAsync<NotificationPermission>();

        if (status != PermissionStatus.Granted)
        {
            await Permissions.RequestAsync<NotificationPermission>();
        }
#endif

        if (BindingContext is TaskViewModel viewModel)
        {
            await viewModel.LoadTasksCommand.ExecuteAsync(null);
        }
    }
}