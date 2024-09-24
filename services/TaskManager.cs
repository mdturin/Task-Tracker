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
        //Console.WriteLine("Loading your all tasks...");

        _tasks.Clear();
        _tasks.AddRange(tasks);
    }

    public Task CreateTask(string description)
    {
        var maxId = _tasks.Count > 0 ? _tasks.Last().Id : 0;
        _tasks.Add(new Task(maxId + 1, description));
        return _tasks.Last();
    }

    public void SaveAll() => StoreService.Instance.Write(_tasks);
}
