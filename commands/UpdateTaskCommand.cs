using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.services;

namespace Task_Tracker.commands;

[ExportCommand("Update")]
public class UpdateTaskCommand : ICommand
{
    public void Execute(params string[] args)
    {
        if (args.Length < 3)
            throw new KeyNotFoundException("Id and Description is required!");

        var taskManager = TaskManager.Instance;
        if (taskManager.UpdateTask(int.Parse(args[1]), args[2]))
            taskManager.SaveAll();
    }
}
