using Drivers.Services;
using System.Text.Json;

namespace Drivers.Entities
{
    public class DataContextDrivers : IDataContext
    {
        public List<Driver> LoadData()

        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "Drivers.json");
                string jsonString = File.ReadAllText(path);
                var AllDrivers = JsonSerializer.Deserialize<List<Driver>>(jsonString);// typeof(DataCoins)); ;
                if (AllDrivers == null) { return null; }
                return AllDrivers;
            }
            catch
            {
                return null;
            }
        }
        public bool SaveData(List<Driver> data)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "Drivers.json");
                string jsonString = JsonSerializer.Serialize<List<Driver>>(data);
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch { return false; }
        }

    }
}
