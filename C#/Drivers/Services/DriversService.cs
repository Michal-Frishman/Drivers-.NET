using Drivers.Entities;
using Microsoft.Extensions.Logging;

namespace Drivers.Services
{
    public class DriversService
    {
        readonly IDataContext _dataContext;

        public DriversService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Driver> GetList()
        {
            var data = _dataContext.LoadData();
            if (data == null)
                return null;
            return data;

        }
        public Driver GetById(int id)
        {
            var data = _dataContext.LoadData();
            if (data == null)
                return null;
            return data.Where(d => d.DriverId == id).FirstOrDefault<Driver>();
            //if (DataContextManager.DataContext.drivers == null) { return null; }
            //return DataContextManager.DataContext.drivers.Where(d => d.DriverId == id).FirstOrDefault<Driver>();
        }
        public bool Update(int id, Driver driver)
        {
            //if (DataContextManager.DataContext.drivers == null) return false;
            //int index = DataContextManager.DataContext.drivers.FindIndex(d => d.DriverId == id);
            //DataContextManager.DataContext.drivers[index] = driver;
            //return true;

            if (_dataContext.LoadData() == null) return false;
            int index = _dataContext.LoadData().FindIndex(d => d.DriverId == id);
            _dataContext.LoadData()[index] = driver;
            return true;
        }
        public bool Add(Driver driver)
        {
            var data = _dataContext.LoadData();
            if (data == null)
                return false;
            data.Add(driver);
            return _dataContext.SaveData(data);
        }
        public bool Delete(int id)
        {
            var data = _dataContext.LoadData();
            if (data == null || data.Find(d => d.DriverId == id) == null)
                return false;
            data.Remove(data.Find(d => d.DriverId == id));
            return _dataContext.SaveData(data);
        }

    }
}
