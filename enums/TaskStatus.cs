using System.ComponentModel;

namespace Task_Tracker.enums;

public enum TaskStatus
{
    [Description("todo")]
    ToDo,

    [Description("in-progress")]
    InProgress,

    [Description("done")]
    Done
}
