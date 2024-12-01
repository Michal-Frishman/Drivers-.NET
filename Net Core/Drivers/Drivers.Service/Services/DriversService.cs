using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Drivers.Core.Iservice;


namespace Drivers.Service.Services
{

    public class DriversService: IService<DriverEntity>
    {
        readonly IRepository<DriverEntity> _driversRepository;
        public DriversService(IRepository<DriverEntity> dataContext)
        {
            _driversRepository = dataContext;
        }
        public List<DriverEntity> GetList()
        {
            var data = _driversRepository.GetAllData();
            if (data == null)
                return null;
            return data;
        }
        public DriverEntity GetById(int id)
        {
            var data = _driversRepository.GetByIdData(id);
            if (data == null)
                return null;
            return data;
        }
        public bool Update(int id, DriverEntity driver)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            return (_driversRepository.UpdateData(id, driver) == null);
        }
        public bool Add(DriverEntity driver)
        {
            var data = _driversRepository.GetByIdData(driver.DriverId);
            if (data != null)
                return false;
            return _driversRepository.AddData(driver);
        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            return _driversRepository.RemoveItemFromData(id);
        }

    }
}
