using Task_Tracker.commands;
using Task_Tracker.models;
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
loadTasksCommand.Execute(new DynamicItem());

var command = commandManager.GetCommand(args[0]);
var commandArgs = new DynamicItem();
commandArgs.SetValue("args", args);
command.Execute(commandArgs);