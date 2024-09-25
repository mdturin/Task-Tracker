using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.services;

namespace Task_Tracker.commands;

[ExportCommand(nameof(LoadAllTasksCommand))]
public class LoadAllTasksCommand : ICommand
{
    public void Execute(params string[] args)
    {
        var tasks = StoreService.Instance.ReadAll();
        TaskManager.Instance.LoadAllTasks(tasks);
    }
}
