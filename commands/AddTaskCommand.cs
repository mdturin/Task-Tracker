using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.models;
using Task_Tracker.services;

namespace Task_Tracker.commands;

[ExportCommand("Add")]
public class AddTaskCommand : ICommand
{
    public void Execute(DynamicItem args)
    {
        var commandArgs = args.GetValue<string[]>("args") 
            ?? throw new ArgumentNullException(nameof(args));

        if (commandArgs.Length < 1)
            throw new KeyNotFoundException("Description is required!");

        var description = commandArgs[1];
        var taskManager = TaskManager.Instance;

        var newTask = taskManager.CreateTask(description);
        args.SetValue("Task", newTask);

        taskManager.SaveAll();
        Console.WriteLine($"Task added successfully (ID: ${newTask.Id})");
    }
}
