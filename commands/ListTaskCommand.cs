﻿using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.services;
using Task = Task_Tracker.models.Task;

namespace Task_Tracker.commands;

[ExportCommand("List")]
public class ListTaskCommand : ICommand
{
    public void Execute(params string[] args)
    {
        var tasks = new List<Task>();
        var taskManager = TaskManager.Instance;

        if (args.Length == 1)
        {
            tasks = taskManager.GetAllTasks();
        }
        else if (taskManager.GetValidTaskStatus(args[1], out var taskStatus))
        {
            tasks = taskManager.GetAllTasks(taskStatus);
        }
        else
        {
            throw new Exception($"{args[1]} is not valid list command args!");
        }

        tasks.ForEach(t =>
        {
            Console.WriteLine($"{t.Id}\t{t.Description}\t{t.Status}\t");
        });
    }
}
