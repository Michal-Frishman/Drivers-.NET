using Drivers.Entities;
using System.Linq;

namespace Drivers.Services
{
    public class PassengersService
    {
        public List<Passenger> passengers { get; set; }
        public PassengersService() { }
        public bool PostPassenger(Passenger passenger)
        {
            if (passengers == null) return false;
            passengers.Add(passenger);
            return true;
        }
        public Passenger GetPassengerById(int id)
        {
            if (passengers == null) { return null; }
            return passengers.Where(p => p.PassengerId == id).FirstOrDefault<Passenger>();
        }

        public bool DeletePassenger(int id)
        {
            if (passengers.Find(p => p.PassengerId == id) == null)
                return false;
            return passengers.Remove(passengers.Find(p => p.PassengerId == id));
        }
        public bool PutPassenger(int id, Passenger passenger)
        {
            if (passengers == null) return false;
            int index = passengers.IndexOf(passenger);
            passengers.Insert(index, passenger);
            passengers[index] = passenger;
            return true;
        }
    }
}
