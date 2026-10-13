using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Services.Interfaces;

namespace TaskManagement.Mobile.Services;

public class TaskService : ITaskService
{
    private readonly IApiClient _apiClient;

    public TaskService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<TaskModel>> GetMyTasksAsync()
    {
        var response = await _apiClient.GetAsync<IEnumerable<TaskModelDto>>(
            "api/tasks/");

        if (!response.IsSuccess)
        {
            return [];
        }

        return response.Data?
            .Select(t => new TaskModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
                Status = t.Status,
                CreatedAt = t.CreatedAt
            })
            .ToList() ?? [];
    }

    public async Task<bool> UpdateTaskAsync(int id, TaskModel task)
    {
        var updateTaskModel = new TaskModelDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Priority = task.Priority,
            Status = task.Status,
        };
        var result = await _apiClient.PutAsync<TaskModelDto, bool>($"api/tasks/{id}", updateTaskModel);
        return result.IsSuccess;
    }
}