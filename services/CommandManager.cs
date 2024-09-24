using System.Reflection;
using Task_Tracker.attributes;
using Task_Tracker.interfaces;

namespace Task_Tracker.services;

public class CommandManager
{
    private readonly Dictionary<string, Type> _commandTypes =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly static Lazy<CommandManager> _instance
        = new(() => new CommandManager());

    public static CommandManager Instance { get => _instance.Value; }

    private CommandManager()
    {
        if (_instance.IsValueCreated)
            throw new Exception("Duplication of CommandManager");
    }

    public void LoadAllCommands()
    {
        Console.WriteLine("Registering all commands...");
        Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t =>
            {
                return t.IsClass &&
                    t.GetCustomAttribute(typeof(ExportCommandAttribute)) != null;
            })
            .ToList()
            .ForEach(type =>
            {
                var commandAttribute = type
                    .GetCustomAttribute<ExportCommandAttribute>();
                _commandTypes.Add(commandAttribute.Name, type);
                Console.WriteLine($"Command Registered: {commandAttribute.Name}");
            });
    }

    public ICommand GetCommand(string name)
    {
        if (!_commandTypes.TryGetValue(name, out var type))
            throw new KeyNotFoundException($"Command not found with name: {name}");

        var command = Activator.CreateInstance(type) as ICommand;
        return command ?? throw new Exception("Couldn't invoke your action!");
    }
}
