﻿using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Microsoft.EntityFrameworkCore;
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

            return _dataContext.travels.Include(x => x.Passenger).Include(y => y.Driver).ToList();
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
            return _dataContext.travels.Where(t => t.Id == id).FirstOrDefault();
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
                int index = _dataContext.travels.ToList().FindIndex(d => d.Id == id);
                //IsPaid = isPaid;
                var travelToUpdate = _dataContext.travels.ToList()[index];

                travelToUpdate.DriverId = travel.DriverId;
                travelToUpdate.PassengerId = travel.PassengerId;
                travelToUpdate.Date = travel.Date;
                travelToUpdate.DeparturePoint = travel.DeparturePoint;
                travelToUpdate.DestinationPoint = travel.DestinationPoint;
                travelToUpdate.Length = travel.Length;
                travelToUpdate.Price = travel.Price;
                travelToUpdate.IsPaid = travel.IsPaid;


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
            if (_dataContext.travels.ToList().FindIndex(d => d.Id == id) == -1)
                return false;
            return true;
        }
    }


}
