using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManagement.Mobile.Enums;
using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Services.Interfaces;

namespace TaskManagement.Mobile.ViewModels;

[QueryProperty(nameof(SelectedTask), "Task")]
public partial class EditTaskViewModel(ITaskService _taskService) : ObservableObject
{
    [ObservableProperty]
    private TaskModel? selectedTask;

    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private DateTime dueDate = DateTime.Today;

    [ObservableProperty]
    private PriorityEnum priority;

    [ObservableProperty]
    private StatusEnum status;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    public PriorityEnum[] Priorities { get; } =
        Enum.GetValues<PriorityEnum>();

    public StatusEnum[] Statuses { get; } =
        Enum.GetValues<StatusEnum>();


    [RelayCommand]
    private async Task SaveAsync()
    {
        try
        {
            if (SelectedTask is null)
                return;

            var updatedTask = new TaskModel
            {
                Title = Title,
                Description = Description,
                DueDate = DueDate,
                Priority = Priority,
                Status = Status,
                Id = SelectedTask.Id
            };

            var result = await _taskService.UpdateTaskAsync(SelectedTask.Id,updatedTask);

            if (!result)
                return;


            var navParams = new Dictionary<string, object>();
            navParams.Add("SelectedItem", updatedTask);

            await Shell.Current.GoToAsync("..", navParams);

        }
        catch (Exception)
        {
            ErrorMessage = "An error occurred while saving the task. Please try again."; 
        }
    }


    partial void OnSelectedTaskChanged(TaskModel? value)
    {
        if (value is null)
            return;

        Title = value.Title;
        Description = value.Description;
        DueDate = value.DueDate ?? DateTime.Today;
        Priority = value.Priority;
        Status = value.Status;
    }
}

