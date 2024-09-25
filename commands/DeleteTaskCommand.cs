using Task_Tracker.attributes;
using Task_Tracker.interfaces;
using Task_Tracker.models;

namespace Task_Tracker.commands;

[ExportCommand("Delete")]
public class DeleteTaskCommand : ICommand
{
    public void Execute(params string[] args)
    {
        if (args.Length < 2)
            throw new KeyNotFoundException("Id is required!");


    }
}
