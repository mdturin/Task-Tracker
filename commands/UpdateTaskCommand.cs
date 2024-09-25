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

        int taskId = int.Parse(args[1]);
        var taskManager = TaskManager.Instance;
        if (taskManager.UpdateTask(taskId, args[2]))
        {
            taskManager.SaveAll();
            Console.WriteLine($"Task successfully updated (ID: {taskId})");
        }
        else
        {
            Console.WriteLine($"Task not found (ID: {taskId})");
        }
    }
}
