using Task_Tracker.commands;
using Task_Tracker.services;

if (args.Length == 0)
{
    Console.WriteLine("Action required!");
    return;
}

var commandManager = CommandManager.Instance;
commandManager.LoadAllCommands();

var loadTasksCommand = commandManager
    .GetCommand(nameof(LoadAllTasksCommand));
loadTasksCommand.Execute();

try
{
    var command = commandManager.GetCommand(args[0]);
    command.Execute(args);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}