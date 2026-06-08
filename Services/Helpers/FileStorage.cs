using System;
using System.IO;
using Newtonsoft.Json;

namespace RestaurantReservationSystem.Services.Helpers
{
    public class FileStorage
    {
        private readonly string _filePath;
        
        public FileStorage(string fileName)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            
            _filePath = Path.Combine(directory, fileName);
        }
        
        public void Save<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
        
        public T Load<T>()
        {
            if (!File.Exists(_filePath))
                return default;
            
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}