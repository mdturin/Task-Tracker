using System.ComponentModel;
using System.Reflection;
using Task_Tracker.enums;
using Task = Task_Tracker.models.Task;
using TaskStatus = Task_Tracker.enums.TaskStatus;

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

    public Task GetTask(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public List<Task> GetTasks(params int[] taskIds)
    {
        return _tasks.FindAll(t => taskIds.Contains(t.Id));
    }

    public List<Task> GetAllTasks() => _tasks;

    public List<Task> GetAllTasks(TaskStatus taskStatus)
    {
        return _tasks.FindAll(t => t.Status == taskStatus);
    }

    public bool UpdateTask(int taskId, string description)
    {
        var task = GetTask(taskId);
        if (task != null)
            task.Description = description;
        return task != null;
    }

    public bool DeleteTask(int taskId)
    {
        var task = GetTask(taskId);
        if (task != null)
            _tasks.Remove(task);
        return task != null;
    }

    public bool MarkTaskStatus(TaskStatus status, params int[] taskIds)
    {
        var tasks = GetTasks(taskIds);
        tasks.ForEach(t => t.Status = status);
        return tasks.Count > 0;
    }

    public bool GetValidTaskStatus(string taskStatusValue, out TaskStatus taskStatus)
    {
        foreach (TaskStatus status in Enum.GetValues(typeof(TaskStatus)))
        {
            var description = GetEnumDescription(status);
            if (description.Equals(taskStatusValue, StringComparison.OrdinalIgnoreCase))
            {
                taskStatus = status;
                return true;
            }
        }

        taskStatus = TaskStatus.ToDo;
        return false;
    }

    private string GetEnumDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }
}
