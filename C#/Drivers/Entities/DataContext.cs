namespace Drivers.Entities
{
    public class DataContext
    {
        public List<Driver> drivers { get; set; }
        public List<Feedback> feedbacks { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Travel> travels { get; set; }

    } 

}
