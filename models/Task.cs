using TaskStatus = Task_Tracker.enums.TaskStatus;

namespace Task_Tracker.models;

public class Task {
    public int Id { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Task()
    {
    }

    public Task(int _id, string description)
    {
        Id = _id;
        Description = description;
        Status = TaskStatus.ToDo;
        CreateAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
