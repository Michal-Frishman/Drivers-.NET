using Drivers.Entities;
using System.Linq;

namespace Drivers.Services
{
    public class TravelsService
    {
        public  List<Travel> travels { get; set; }
        public TravelsService() 
        { 
         travels = new List<Travel>();
        }
        public bool PostTravel(Travel travel)
        {
            if (travels == null) return false;
            travels.Add(travel);
            return true;
        }
        public Travel GetTravelById(int id)
        {
            if (travels == null) { return null; }
            return travels.Where(t => t.TravelId == id).FirstOrDefault<Travel>();
        }
        public bool DeleteTravel(int id)
        {
            if (travels.Find(d => d.TravelId == id) == null)
                return false;
            return travels.Remove(travels.Find(d => d.TravelId == id));
        }
        public bool PutTravel(int id, Travel travel)
        {
            if (travels == null) return false;
            int index = travels.IndexOf(travel);
            travels.Insert(index, travel);
            travels[index] = travel;
            return true;
        }
    }
}
