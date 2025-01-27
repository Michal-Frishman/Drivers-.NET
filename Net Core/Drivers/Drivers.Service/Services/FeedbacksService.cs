using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Drivers.Core.Iservice;




namespace Drivers.Service.Services
{
    public class FeedbacksService:IService<FeedbackEntity>
    {
        readonly IRepository<FeedbackEntity> _feedbackRepository;

        public FeedbacksService(IRepository<FeedbackEntity> repository)
        {
            _feedbackRepository = repository;
        }
        public List<FeedbackEntity> GetList()
        {
         
            var data = _feedbackRepository.GetAllData();
            if (data == null)
                return null;
            return data;
        }
        public FeedbackEntity GetById(int id)
        {
            var data = _feedbackRepository.GetByIdData(id);
            if (data == null)
                return null;
            return data;
        }
        public bool Update(int id, FeedbackEntity feedback)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            return (_feedbackRepository.UpdateData(id, feedback) == null);
        }
        public bool Add(FeedbackEntity feedback)
        {
            var data = _feedbackRepository.GetByIdData(feedback.Id);
            if (data != null)
                return false;
            return _feedbackRepository.AddData(feedback);
        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            return _feedbackRepository.RemoveItemFromData(id);
        }

    }
}
