using Task = Task_Tracker.models.Task;

namespace Task_Tracker.services;

public class TaskManager
{
    private readonly List<Task> _tasks = [];
    private readonly static Lazy<TaskManager> _instance
        = new(() => new TaskManager());

    public static TaskManager Instance { get => _instance.Value; }

    private TaskManager()
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
