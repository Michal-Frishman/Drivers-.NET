using Drivers.Entities;
using System.Linq;

namespace Drivers.Services
{
    public class FeedbacksService
    {
        public FeedbacksService() 
        {
            DataContextManager.DataContext.feedbacks = new List<Feedback>();
        }
        public Feedback GetById(int id)
        {
            if (DataContextManager.DataContext.feedbacks == null) { return null; }
            return DataContextManager.DataContext.feedbacks.Where(f => f.FeedbackId == id).FirstOrDefault<Feedback>();
        }
        public bool Add(Feedback feedback)
        {
            if (DataContextManager.DataContext.feedbacks == null) return false;
            DataContextManager.DataContext.feedbacks.Add(feedback);
            return true;
        }
        public bool Delete(int id)
        {
            if (DataContextManager.DataContext.feedbacks.Find(d => d.DriverId == id) == null)
                return false;
            return DataContextManager.DataContext.feedbacks.Remove(DataContextManager.DataContext.feedbacks.Find(f => f.FeedbackId == id));
        }
        public bool Update(int id, Feedback feedback)
        {
            if (DataContextManager.DataContext.feedbacks == null) return false;
            int index = DataContextManager.DataContext.feedbacks.IndexOf(feedback);
            DataContextManager.DataContext.feedbacks[index] = feedback;
            return true;
        }

    }
}
