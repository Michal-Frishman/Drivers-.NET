namespace Drivers.Entities
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
        public int Rating { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackContent { get; set; }
        public Feedback()
        {
            
        }

        public Feedback(int feedbackId, int driverId, int passengerId, int rating, DateTime feedbackDate, string feedbackContent)
        {
            FeedbackId = feedbackId;
            DriverId = driverId;
            PassengerId = passengerId;
            Rating = rating;
            FeedbackDate = feedbackDate;
            FeedbackContent = feedbackContent;
        }
    }
   
}
