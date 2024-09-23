namespace Task_Tracker.models;

public class DynamicItem
{
    private Dictionary<string, object> Values { get; set; } = [];
    public void SetValue(string key, object value) => Values.Add(key, value);
    public object GetValue(string key) => Values.GetValueOrDefault(key);
}
