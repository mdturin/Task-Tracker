using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.services;
using TaskStatus = Task_Tracker.enums.TaskStatus;

namespace Task_Tracker.commands;

[ExportCommand("Mark-Done")]
public class MarkDoneCommand : ICommand
{
    public void Execute(params string[] args)
    {
        if (args.Length < 2)
            throw new KeyNotFoundException("Id is required!");

        var taskId = int.Parse(args[1]);
        var taskManager = TaskManager.Instance;
        if (taskManager.MarkTaskStatus(TaskStatus.Done, taskId))
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
