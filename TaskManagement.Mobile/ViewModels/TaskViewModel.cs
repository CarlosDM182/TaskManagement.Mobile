using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Routes;
using TaskManagement.Mobile.Services;
using TaskManagement.Mobile.Services.Interfaces;

namespace TaskManagement.Mobile.ViewModels;

public partial class TaskViewModel : ObservableObject
{
    private readonly ITaskService _taskService;

    public ObservableCollection<TaskModel> Tasks { get; } = [];

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    [ObservableProperty]
    private bool isRefreshing;

    public TaskViewModel(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [RelayCommand]
    private async Task LoadTasksAsync()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            var tasks = await _taskService.GetMyTasksAsync();

            Tasks.Clear();

            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }
        catch (Exception)
        {
            ErrorMessage = "No se pudieron cargar las tareas.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task RefreshTasksAsync()
    {
        IsRefreshing = true;

        try
        {
            await LoadTasksAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    private async Task TaskSelectedAsync(TaskModel task)
    {
        var navParams = new Dictionary<string, object>();
        navParams.Add("SelectedItem", task);

        await Shell.Current.GoToAsync(nameof(AppRoute.TaskDetail), navParams);
    }
}

