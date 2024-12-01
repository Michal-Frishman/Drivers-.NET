using Drivers.Entities;

namespace Drivers.Services
{
    public interface IDataContext
    {
        public List<Driver> LoadData();
        public bool SaveData(List<Driver> data);
    }
}
