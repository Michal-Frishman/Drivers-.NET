namespace Drivers.Entities
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Passenger(int passengerId, string firstName, string lastName, string phoneNumber)
        {
            PassengerId = passengerId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
     
       }
        public Passenger()
        {
            
        }
    }
}
