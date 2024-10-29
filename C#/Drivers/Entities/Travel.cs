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



    }
}
