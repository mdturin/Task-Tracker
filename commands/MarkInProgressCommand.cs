using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.services;
using TaskStatus = Task_Tracker.enums.TaskStatus;

namespace Task_Tracker.commands;

[ExportCommand("Mark-In-Progress")]
public class MarkInProgressCommand : ICommand
{
    public void Execute(params string[] args)
    {
        if (args.Length < 2)
            throw new KeyNotFoundException("Id is required!");

        var taskId = int.Parse(args[1]);
        var taskManager = TaskManager.Instance;
        if (taskManager.MarkTaskStatus(TaskStatus.InProgress, taskId))
            taskManager.SaveAll();
    }
}
