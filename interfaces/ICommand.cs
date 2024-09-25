using Task_Tracker.models;

namespace Task_Tracker.interfaces;

public interface ICommand
{
    void Execute(params string[] args);
}
