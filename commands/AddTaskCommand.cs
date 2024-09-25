using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.services;

namespace Task_Tracker.commands;

[ExportCommand("Add")]
public class AddTaskCommand : ICommand
{
    public void Execute(params string[] args)
    {
        if (args.Length < 1)
            throw new KeyNotFoundException("Description is required!");

        var description = args[1];
        var taskManager = TaskManager.Instance;
        var newTask = taskManager.CreateTask(description);

        taskManager.SaveAll();

        Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
    }
}
