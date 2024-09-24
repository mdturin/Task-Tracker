namespace Task_Tracker.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ExportCommandAttribute(string _name) : Attribute
{
    public string Name { get; } = _name;
}
