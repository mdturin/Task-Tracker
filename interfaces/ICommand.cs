using Task_Tracker.models;

namespace Task_Tracker.interfaces;

public interface ICommand
{
    void Execute(DynamicItem args);
}
