using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repository
{
    public class TravelsRepository : IRepository<TravelEntity>
    {
        readonly DataContext _dataContext;
        public TravelsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<TravelEntity> GetAllData()
        {
            return _dataContext.travels;
        }
        public bool AddData(TravelEntity travel)
        {
            try
            {
                _dataContext.travels.Add(travel);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public TravelEntity GetByIdData(int id)
        {
            return _dataContext.travels.Where(t => t.TravelId == id).FirstOrDefault();
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
                _dataContext.travels.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateData(int id, TravelEntity driver)
        {
            try
            {
                int index = _dataContext.travels.FindIndex(d => d.TravelId == id);
                _dataContext.travels[index] = driver;
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
