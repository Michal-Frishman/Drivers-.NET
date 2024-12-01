using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Drivers.Core.Iservice;


namespace Drivers.Service.Services
{
    public class PassengersService:IService<PassengerEntity>
    {
        readonly IRepository<PassengerEntity> _passangersRepository;

        public PassengersService(IRepository<PassengerEntity> repository)
        {
            _passangersRepository = repository;
        }
        public List<PassengerEntity> GetList()
        {
            var data = _passangersRepository.GetAllData();
            if (data == null)
                return null;
            return data;

        }
        public bool Add(PassengerEntity passenger)
        {
            var data = _passangersRepository.GetByIdData(passenger.PassengerId);
            if (data != null)
                return false;
            return _passangersRepository.AddData(passenger);
        }
        public PassengerEntity GetById(int id)
        {
            var data = _passangersRepository.GetByIdData(id);
            if (data == null)
                return null;
            return data;
        }
        public bool Update(int id, PassengerEntity passenger)
        {
            var data = _passangersRepository.GetByIdData(passenger.PassengerId);
            if (data != null)
                return false;
            return _passangersRepository.AddData(passenger);

        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            return _passangersRepository.RemoveItemFromData(id);
        }

    }
}

