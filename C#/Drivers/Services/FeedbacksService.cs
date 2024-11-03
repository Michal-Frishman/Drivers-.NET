using Drivers.Entities;
using System.Linq;

namespace Drivers.Services
{
    public class FeedbacksService
    {
        public  List<Feedback> feedbacks { get; set; }
        public FeedbacksService() 
        { 
            feedbacks = new List<Feedback>();
        }
        public Feedback GetFeedbackById(int id)
        {
            if (feedbacks == null) { return null; }
            return feedbacks.Where(f => f.FeedbackId == id).FirstOrDefault<Feedback>();
        }
        public bool PostFeedback(Feedback feedback)
        {
            if (feedbacks == null) return false;
            feedbacks.Add(feedback);
            return true;
        }
        public bool DeleteFeedback(int id)
        {
            if (feedbacks.Find(d => d.DriverId == id) == null)
                return false;
            return feedbacks.Remove(feedbacks.Find(f => f.FeedbackId == id));
        }
        public bool PutFeedback(int id, Feedback feedback)
        {
            if (feedbacks == null) return false;
            int index = feedbacks.IndexOf(feedback);
            //----------
            feedbacks.Insert(index, feedback);
            feedbacks[index] = feedback;
            return true;
        }

    }
}
