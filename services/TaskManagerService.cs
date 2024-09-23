using Task = Task_Tracker.models.Task;

namespace Task_Tracker.services;

public class TaskManagerService
{
    private readonly List<Task> _tasks = [];
    private readonly static Lazy<TaskManagerService> _instance
        = new(() => new TaskManagerService());

    public static TaskManagerService Instance { get => _instance.Value; }

    private TaskManagerService()
    {
        if (_instance.IsValueCreated)
            throw new Exception("Duplication of TaskManagerService");
    }

    public void LoadAllTasks(List<Task> tasks)
    {
        Console.WriteLine("Loading your all tasks...");

        _tasks.Clear();
        _tasks.AddRange(tasks);
    }
}
