using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repository
{
    public class DriversRepository : IRepository<DriverEntity>
    {
        readonly DataContext _dataContext;
        public DriversRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<DriverEntity> GetAllData()
        {
            return _dataContext.drivers;
        }
        public bool AddData(DriverEntity driver)
        {
            try
            {
                _dataContext.drivers.Add(driver);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DriverEntity GetByIdData(int id)
        {
            return _dataContext.drivers.Where(t => t.DriverId == id).FirstOrDefault();
        }

        public bool RemoveItemFromData(int id)
        {
            try
            {
                var item = GetByIdData(id);
                if (item == null)
                {
                    return false;
                }
                _dataContext.drivers.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateData(int id, DriverEntity driver)
        {
            try
            {
                int index = _dataContext.drivers.FindIndex(d => d.DriverId == id);
                _dataContext.drivers[index] = driver;
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }

}

