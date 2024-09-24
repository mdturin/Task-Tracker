using System.Text.Json;
using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.models;
using Task_Tracker.services;
using Task = Task_Tracker.models.Task;

namespace Task_Tracker.commands;

[ExportCommand(nameof(LoadAllTasksCommand))]
public class LoadAllTasksCommand : ICommand
{
    public void Execute(DynamicItem args)
    {
        var instance = ConfigurationService.Instance;
        var storePath = instance.GetConfig("StorePath");
        var fileName = instance.GetConfig("FileName");
        var filePath = Path.Join(storePath, fileName);
        filePath = Path.ChangeExtension(filePath, "json");

        if (!Directory.Exists(storePath))
        {
            Console.WriteLine("Creating your directory...");
            Directory.CreateDirectory(storePath);
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Creating your store file...");
            File.WriteAllText(filePath, JsonSerializer.Serialize(new List<Task>()));
            return;
        }

        var jsonStr = File.ReadAllText(filePath);
        var tasks = JsonSerializer.Deserialize<List<Task>>(jsonStr);
        TaskManager.Instance.LoadAllTasks(tasks);
    }
}
