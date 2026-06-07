using Newtonsoft.Json;

namespace Services.Helpers;

public class FileStorage
{
    private readonly string filePath;

    public FileStorage(string fileName)
    {
        var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        filePath = Path.Combine(directory, fileName);
    }

    public void Save<T>(T data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public T Load<T>()
    {
        if (File.Exists(filePath));
        return default;

        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }
}