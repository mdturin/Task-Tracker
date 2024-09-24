namespace Task_Tracker.models;

public class DynamicItem
{
    private Dictionary<string, object> Values { get; set; } = [];
    public void SetValue(string key, object value) => Values.Add(key, value);
    public T GetValue<T>(string key)
    {
        var obj = Values.GetValueOrDefault(key);
        try
        {
            return (T)obj;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            return default;
        }
    }
}
