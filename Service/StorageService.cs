using System.Text.Json;

namespace StoreManagement.Service
{
    public class StorageService
    {
        private readonly string _dataFolder = "Data";

        public StorageService()
        {
            string baseDir = AppContext.BaseDirectory;
            var projectRoot = Path.GetFullPath(Path.Combine(baseDir, "..", "..", ".."));
            _dataFolder = Path.Combine(projectRoot, "Data");

            if (!Directory.Exists(_dataFolder))
            {
                Directory.CreateDirectory(_dataFolder);
            }
        }

        public void SaveData<T>(string fileName, T data)
        {
            try
            {
                string filePath = Path.Combine(_dataFolder, fileName);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error Saving Data]: {ex.Message}");
            }
        }

        public T? LoadData<T>(string fileName)
        {
            try
            {
                string filePath = Path.Combine(_dataFolder, fileName);

                if (!File.Exists(filePath))
                {
                    return default;
                }

                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error Loading Data]: {ex.Message}");
                return default;
            }
        }
    }
}