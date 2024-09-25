using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.services;

namespace Task_Tracker.commands;

[ExportCommand("Delete")]
public class DeleteTaskCommand : ICommand
{
    public void Execute(params string[] args)
    {
        if (args.Length < 2)
            throw new KeyNotFoundException("Id is required!");

        var taskId = int.Parse(args[1]);
        var taskManager = TaskManager.Instance;
        if (taskManager.DeleteTask(taskId))
        {
            taskManager.SaveAll();
            Console.WriteLine($"Task successfully deleted (ID: {taskId})");
        }
        else
        {
            Console.WriteLine($"Task not found (ID: {taskId})");
        }
    }
}
