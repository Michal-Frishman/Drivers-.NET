using Drivers.Entities;
using Drivers.Services;


namespace TestProject1
{
    public class TestContext : IDataContext
    {
        public List<Driver> LoadData()

        {
            Driver driver1 = new Driver()
            {
                DriverId = 1,
                DriverTz = "123456789",
                FirstName = "John",
                LastName = "Doe",
                LicensePlate = 1234567,
                CarModel = "Toyota Corolla",
                PhoneNumber = "054-1234567",
                IsAvailable = true,
                SeatsNumber = 4
            };

            Driver driver2 = new Driver()
            {
                DriverId = 2,
                DriverTz = "987654321",
                FirstName = "Jane",
                LastName = "Smith",
                LicensePlate = 7654321,
                CarModel = "Honda Civic",
                PhoneNumber = "052-7654321",
                IsAvailable = false,
                SeatsNumber = 5
            };

            List<Driver> data = new List<Driver>();
            data.Add(driver1);
            data.Add(driver2);

            return data;
        }

        public bool SaveData(List<Driver> data)
        {
            return true;
        }
    }
}
