using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Routes;

namespace TaskManagement.Mobile.ViewModels;

[QueryProperty(nameof(SelectedItem), "SelectedItem")]

public partial class TaskDetailViewModel : ObservableObject
{
    [ObservableProperty]
    TaskModel selectedItem;

    [RelayCommand]
    private async Task EditAsync()
    {
        if (SelectedItem is null)
            return;

        var navParams = new Dictionary<string, object>();
        navParams.Add("Task", SelectedItem);
        await Shell.Current.GoToAsync(nameof(AppRoute.EditTask), navParams);
    }

}

