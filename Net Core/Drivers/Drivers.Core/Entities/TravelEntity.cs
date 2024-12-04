using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    [Table("Travels")]
    public class TravelEntity
    {
        [Key]
        public int TravelId { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }
        public DateTime TravelDate { get; set; }
        public string DeparturePoint { get; set; }
        public string DestinationPoint { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TravelLength { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }

        public TravelEntity()
        {

        }

        public TravelEntity(int travelId, int passengerId, int driverId, DateTime travelDate, string departurePoint, string destinationPoint, int travelLength, int price, bool isPaid)
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
