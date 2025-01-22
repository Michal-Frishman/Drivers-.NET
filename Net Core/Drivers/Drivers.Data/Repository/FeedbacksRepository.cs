﻿using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repository
{
    public class FeedbacksRepository  : IRepository<FeedbackEntity>
    {
        readonly DataContext _dataContext;
        public FeedbacksRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<FeedbackEntity> GetAllData()
        {
            return _dataContext.feedbacks.ToList();
        }
        public bool AddData(FeedbackEntity feedback)
        {
            try
            {
                _dataContext.feedbacks.Add(feedback);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public FeedbackEntity GetByIdData(int id)
        {
            return _dataContext.feedbacks.Where(t => t.FeedbackId == id).FirstOrDefault();
        }

        public bool RemoveItemFromData(int id)
        {
            try
            {
                var item = GetByIdData(id);
                if (item == null)
                {
                    return false;
                }
                _dataContext.feedbacks.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateData(int id, FeedbackEntity feedback)
        {
            try
            {
                int index = _dataContext.feedbacks.ToList().FindIndex(d => d.FeedbackId == id);
                var feedbackToUpdate = _dataContext.feedbacks.ToList()[index];

                feedbackToUpdate.DriverId = feedback.DriverId;
                feedbackToUpdate.PassengerId = feedback.PassengerId;
                feedbackToUpdate.Rating = feedback.Rating;
                feedbackToUpdate.FeedbackDate = feedback.FeedbackDate;
                feedbackToUpdate.FeedbackContent = feedback.FeedbackContent;

                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool isExist(int id)
        {
            if (_dataContext.feedbacks.ToList().FindIndex(d => d.FeedbackId == id) == -1)
                return false;
            return true;
        }
    }
}

