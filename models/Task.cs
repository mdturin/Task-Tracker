using TaskStatus = Task_Tracker.enums.TaskStatus;

namespace Task_Tracker.models;

public class Task(int _id, string description)
{
    public int Id { get; set; } = _id;
    public string Description { get; set; } = description;
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
