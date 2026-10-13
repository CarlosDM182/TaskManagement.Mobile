using TaskManagement.Mobile.Enums;

namespace TaskManagement.Mobile.Models;

public class TaskModelDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime? DueDate { get; set; }

    public PriorityEnum Priority { get; set; } = PriorityEnum.Low;

    public StatusEnum Status { get; set; } = StatusEnum.Pending;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }

}