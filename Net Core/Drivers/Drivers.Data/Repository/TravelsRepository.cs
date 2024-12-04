using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repository
{
    public class TravelsRepository : IRepository<TravelEntity>
    {
        readonly DataContext _dataContext;
        public TravelsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<TravelEntity> GetAllData()
        {
            return _dataContext.travels.ToList();
        }
        public bool AddData(TravelEntity travel)
        {
            try
            {
                _dataContext.travels.Add(travel);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public TravelEntity GetByIdData(int id)
        {
            return _dataContext.travels.Where(t => t.TravelId == id).FirstOrDefault();
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
                _dataContext.travels.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateData(int id, TravelEntity travel)
        {
            try
            {
                int index = _dataContext.travels.ToList().FindIndex(d => d.TravelId == id);
                //IsPaid = isPaid;
                if (travel.DriverId != 0)
                    _dataContext.travels.ToList()[index].DriverId = travel.DriverId;
                if (travel.PassengerId != 0)
                    _dataContext.travels.ToList()[index].PassengerId = travel.PassengerId;
                if (DateTime.Compare(travel.TravelDate, DateTime.Now) != 0)
                    _dataContext.travels.ToList()[index].TravelDate = travel.TravelDate;
                if (!string.IsNullOrEmpty(travel.DeparturePoint))
                    _dataContext.travels.ToList()[index].DeparturePoint = travel.DeparturePoint;
                if (!string.IsNullOrEmpty(travel.DestinationPoint))
                    _dataContext.travels.ToList()[index].DestinationPoint = travel.DestinationPoint;
                if (travel.TravelLength != 0)
                    _dataContext.travels.ToList()[index].TravelLength = travel.TravelLength;
                if (travel.Price != 0)
                    _dataContext.travels.ToList()[index].Price = travel.Price;
                if (travel.IsPaid != _dataContext.travels.ToList()[index].IsPaid)
                    _dataContext.travels.ToList()[index].IsPaid = travel.IsPaid;

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
            if (_dataContext.travels.ToList().FindIndex(d => d.TravelId == id) == -1)
                return false;
            return true;
        }
    }


}
