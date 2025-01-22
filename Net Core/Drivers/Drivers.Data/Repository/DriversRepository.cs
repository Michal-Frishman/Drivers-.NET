using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            return _dataContext.drivers.ToList();
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
                Console.WriteLine(e.Message);

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
                int index = _dataContext.drivers.ToList().FindIndex(d => d.DriverId == id);

                var driverToUpdate = _dataContext.drivers.ToList()[index];

                driverToUpdate.CarModel = driver.CarModel;
                driverToUpdate.FirstName = driver.FirstName;
                driverToUpdate.LastName = driver.LastName;
                driverToUpdate.SeatsNumber = driver.SeatsNumber;
                driverToUpdate.PhoneNumber = driver.PhoneNumber;
                driverToUpdate.LicensePlate = driver.LicensePlate;
                driverToUpdate.IsAvailable = driver.IsAvailable;


                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool isExist(int id)
        {
            if (_dataContext.drivers.ToList().FindIndex(d => d.DriverId == id) == -1)
                return false;
            return true;
        }
    }

}

