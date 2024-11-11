using Drivers.Entities;
using Microsoft.Extensions.Logging;

namespace Drivers.Services
{
    public class DriversService
    {
        public DriversService()
        {
            DataContextManager.DataContext.drivers = new List<Driver>();
        }

        public Driver GetById(int id)
        {
            if (DataContextManager.DataContext.drivers == null) { return null; }
            return DataContextManager.DataContext.drivers.Where(d => d.DriverId == id).FirstOrDefault<Driver>();
        }
        public bool Update(int id, Driver driver)
        {
            if (DataContextManager.DataContext.drivers == null) return false;
            int index = DataContextManager.DataContext.drivers.FindIndex(d => d.DriverId == id);
            DataContextManager.DataContext.drivers[index] = driver;
            return true;
        }
        public bool Add(Driver driver)
        {
            if (DataContextManager.DataContext.drivers == null) return false;
            DataContextManager.DataContext.drivers.Add(driver);
            return true;
        }
        public bool Delete(int id)
        {
            if (DataContextManager.DataContext.drivers.Find(d => d.DriverId == id) == null)
                return false;
            return DataContextManager.DataContext.drivers.Remove(DataContextManager.DataContext.drivers.Find(d => d.DriverId == id));
        }

    }
}
