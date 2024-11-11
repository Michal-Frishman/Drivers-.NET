using Drivers.Entities;
using System.Linq;

namespace Drivers.Services
{
    public class TravelsService
    {
        public TravelsService() 
        {
            DataContextManager.DataContext.travels = new List<Travel>();
        }
        public bool Add(Travel travel)
        {
            if (DataContextManager.DataContext.travels == null) return false;
            DataContextManager.DataContext.travels.Add(travel);
            return true;
        }
        public Travel GetById(int id)
        {
            if (DataContextManager.DataContext.travels == null) { return null; }
            return DataContextManager.DataContext.travels.Where(t => t.TravelId == id).FirstOrDefault<Travel>();
        }
        public bool Delete(int id)
        {
            if (DataContextManager.DataContext.travels.Find(d => d.TravelId == id) == null)
                return false;
            return DataContextManager.DataContext.travels.Remove(DataContextManager.DataContext.travels.Find(d => d.TravelId == id));
        }
        public bool Update(int id, Travel travel)
        {
            if (DataContextManager.DataContext.travels == null) return false;
            int index = DataContextManager.DataContext.travels.IndexOf(travel);
            DataContextManager.DataContext.travels.Insert(index, travel);
            DataContextManager.DataContext.travels[index] = travel;
            return true;
        }
    }
}
