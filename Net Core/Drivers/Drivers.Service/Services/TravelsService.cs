using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Drivers.Core.Iservice;


namespace Drivers.Service.Services
{
    public class TravelsService:IService<TravelEntity>
    {
        readonly IRepository<TravelEntity> _travelsRepository;

        public TravelsService(IRepository<TravelEntity> dataContext)
        {
            _travelsRepository = dataContext;
        }
        public List<TravelEntity> GetList()
        {
            var data = _travelsRepository.GetAllData();
            if (data == null)
                return null;
            return data;
        }
        public TravelEntity GetById(int id)
        {
            var data = _travelsRepository.GetByIdData(id);
            if (data == null)
                return null;
            return data;
        }
        public bool Update(int id, TravelEntity travel)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            return (_travelsRepository.UpdateData(id, travel) == null);
        }
        public bool Add(TravelEntity travel)
        {
            var data = _travelsRepository.GetByIdData(travel.TravelId);
            if (data != null)
                return false;
            return _travelsRepository.AddData(travel);
        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            return _travelsRepository.RemoveItemFromData(id);

        }
    }
}
