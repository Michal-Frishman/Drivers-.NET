namespace Drivers.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string DriverTz { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LicensePlate { get; set; }
        public string CarModel { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int SeatsNumber   { get; set; }
        public Driver()
        {
            
        }
        public Driver(int driverId,string driverTz, string firstName, string lastName, int licensePlate, string carModel, string phoneNumber, bool isAvailable, int seatsNumber)
        {
            DriverId = driverId;
            DriverTz = driverTz;
            FirstName = firstName;
            LastName = lastName;
            LicensePlate = licensePlate;
            CarModel = carModel;
            PhoneNumber = phoneNumber;
            IsAvailable = isAvailable;
            SeatsNumber = seatsNumber;
        }
    }
}
