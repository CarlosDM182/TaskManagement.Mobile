using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile.Services.Interfaces;

public interface ITaskService
{
    Task<List<TaskModel>> GetMyTasksAsync();
    Task<bool> UpdateTaskAsync(int id, TaskModel task);
}