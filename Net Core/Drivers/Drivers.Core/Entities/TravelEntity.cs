using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    public class TravelEntity
    {
        public int TravelId { get; set; }
        public string PassengerId { get; set; }
        public string DriverId { get; set; }
        public DateTime TravelDate { get; set; }
        public string DeparturePoint { get; set; }
        public string DestinationPoint { get; set; }
        public int TravelLength { get; set; }
        public int Price { get; set; }
        public bool IsPaid { get; set; }

        public TravelEntity()
        {

        }

        public TravelEntity(int travelId, string passengerId, string driverId, DateTime travelDate, string departurePoint, string destinationPoint, int travelLength, int price, bool isPaid)
        {
            TravelId = travelId;
            PassengerId = passengerId;
            DriverId = driverId;
            TravelDate = travelDate;
            DeparturePoint = departurePoint;
            DestinationPoint = destinationPoint;
            TravelLength = travelLength;
            Price = price;
            IsPaid = isPaid;
        }
    }
}
