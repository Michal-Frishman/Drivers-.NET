using Drivers.Entities;
using System.Linq;

namespace Drivers.Services
{
    public class PassengersService
    {
        public PassengersService() 
        {
            DataContextManager.DataContext.passengers = new List<Passenger>();
        }
        public bool Add(Passenger passenger)
        {
            if (DataContextManager.DataContext.passengers == null) return false;
            DataContextManager.DataContext.passengers.Add(passenger);
            return true;
        }
        public Passenger GetById(int id)
        {
            if (DataContextManager.DataContext.passengers == null) { return null; }
            return DataContextManager.DataContext.passengers.Where(p => p.PassengerId == id).FirstOrDefault<Passenger>();
        }

        public bool Delete(int id)
        {
            if (DataContextManager.DataContext.passengers.Find(p => p.PassengerId == id) == null)
                return false;
            return DataContextManager.DataContext.passengers.Remove(DataContextManager.DataContext.passengers.Find(p => p.PassengerId == id));
        }
        public bool Update(int id, Passenger passenger)
        {
            if (DataContextManager.DataContext.passengers == null) return false;
            int index = DataContextManager.DataContext.passengers.IndexOf(passenger);
            DataContextManager.DataContext.passengers.Insert(index, passenger);
            DataContextManager.DataContext.passengers[index] = passenger;
            return true;
        }
    }
}
