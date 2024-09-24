using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.models;

namespace Task_Tracker.commands;

[ExportCommand("Add")]
public class AddTaskCommand : ICommand
{
    public void Execute(DynamicItem args)
    {

    }
}
