using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    public class FeedbackEntity
    {
        public int FeedbackId { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
        public int Rating { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackContent { get; set; }
        public FeedbackEntity()
        {

        }

        public FeedbackEntity(int feedbackId, int driverId, int passengerId, int rating, DateTime feedbackDate, string feedbackContent)
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
