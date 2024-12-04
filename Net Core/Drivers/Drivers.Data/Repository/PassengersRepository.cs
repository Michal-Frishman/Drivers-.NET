using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repository
{
    public class PassengersRepository : IRepository<PassengerEntity>
    {
        readonly DataContext _dataContext;
        public PassengersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<PassengerEntity> GetAllData()
        {
            return _dataContext.passengers.ToList();
        }
        public bool AddData(PassengerEntity passenger)
        {
            try
            {
                _dataContext.passengers.Add(passenger);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public PassengerEntity GetByIdData(int id)
        {
            return _dataContext.passengers.Where(t => t.PassengerId == id).FirstOrDefault();
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
                _dataContext.passengers.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateData(int id, PassengerEntity passenger)
        {
            try
            {
                int index = _dataContext.passengers.ToList().FindIndex(d => d.PassengerId == id);

                if (!string.IsNullOrEmpty(passenger.FirstName))
                    _dataContext.passengers.ToList()[index].FirstName = passenger.FirstName;

                if (!string.IsNullOrEmpty(passenger.LastName))
                    _dataContext.passengers.ToList()[index].LastName = passenger.LastName;

                if (!string.IsNullOrEmpty(passenger.PhoneNumber))
                    _dataContext.passengers.ToList()[index].PhoneNumber = passenger.PhoneNumber;

                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool isExist(int id)
        {
            if (_dataContext.passengers.ToList().FindIndex(d => d.PassengerId == id) == -1)
                return false;
            return true;
        }
    }
}
