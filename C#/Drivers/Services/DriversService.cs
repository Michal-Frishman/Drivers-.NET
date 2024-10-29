using Drivers.Entities;
using Microsoft.Extensions.Logging;

namespace Drivers.Services
{
    public class DriversService
    {
        public List<Driver> drivers { get; set; }
        public DriversService() 
        { 
            drivers = new List<Driver>();
        }
        public Driver GetDriverById(int id)
        {
            if (drivers == null) { return null; }
            return drivers.Where(d => d.DriverId == id).FirstOrDefault<Driver>();
        }
        public bool PutDriver(int id, Driver driver)
        {
            if (drivers == null) return false;
            int index = drivers.FindIndex(d=>d.DriverId==id);
            drivers.Insert(index, driver);
            drivers[index] = driver;
            return true;
        }
        public bool PostDriver(Driver driver)
        {
            if (drivers == null) return false;
            drivers.Add(driver);
            return true;
        }
        public bool DeleteDriver(int id)
        {
            if(drivers.Find(d => d.DriverId == id) == null)
                return false;
           return drivers.Remove(drivers.Find(d => d.DriverId == id));
        }

    }
}
