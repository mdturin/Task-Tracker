using System.Text.Json;
using System.Text.Json.Serialization;
using Task = Task_Tracker.models.Task;

namespace Task_Tracker.services;

public class StoreService
{
    private readonly string _filePath;
    private readonly string _storePath;
    private readonly static Lazy<StoreService> _instance
        = new(() => new StoreService());

    public static StoreService Instance { get => _instance.Value; }

    private StoreService()
    {
        if (_instance.IsValueCreated)
            throw new Exception("Duplication of StoreService");

        var instance = ConfigurationService.Instance;
        _storePath = instance.GetConfig("StorePath");

        var fileName = instance.GetConfig("FileName");
        _filePath = Path.Join(_storePath, fileName);
        _filePath = Path.ChangeExtension(_filePath, "json");
    }

    public List<Task> ReadAll()
    {
        if (!Directory.Exists(_storePath))
        {
            Console.WriteLine("Creating your directory...");
            Directory.CreateDirectory(_storePath);
        }

        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Creating your store file...");
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Task>()));
            return [];
        }

        var jsonStr = File.ReadAllText(_filePath);
        var tasks = JsonSerializer.Deserialize<List<Task>>(jsonStr, new JsonSerializerOptions()
        {
            WriteIndented = true,
            IncludeFields = true
        });

        return tasks;
    }

    public void Write(List<Task> tasks)
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };

        var jsonString = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(_filePath, jsonString);
    }
}