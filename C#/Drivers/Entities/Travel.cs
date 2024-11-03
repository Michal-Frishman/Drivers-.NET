namespace Drivers.Entities
{
    public class Travel
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

        public Travel()
        {
            
        }

        public Travel(int travelId, string passengerId, string driverId, DateTime travelDate, string departurePoint, string destinationPoint, int travelLength, int price, bool isPaid)
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
