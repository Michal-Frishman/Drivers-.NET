using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Drivers.Data
{
    public class DataContext
    {
        public List<DriverEntity> drivers { get; set; }
        public List<FeedbackEntity> feedbacks { get; set; }
        public List<PassengerEntity> passengers { get; set; }
        public List<TravelEntity> travels { get; set; }
        public DataContext()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "drivers.json");
            string jsonString = File.ReadAllText(path);
            drivers = JsonSerializer.Deserialize<List<DriverEntity>>(jsonString); 
            //string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");

            //string jsonString = File.ReadAllText(path);

            ////Lists lists = JsonSerializer.Deserialize<Lists>(jsonString);
            //if (lists != null)
            //{
            //    drivers = lists.drivers;
            //    feedbacks = lists.feedbacks;
            //    passengers = lists.passengers;
            //    travels = lists.travels;
            //}
        }

        public bool SaveChanges()
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "Drivers.json");
                string jsonString = JsonSerializer.Serialize<List<DriverEntity>>(drivers);
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch { return false; }
            //try
            //{

            //    Lists lists = new Lists();
            //    lists.feedbacks = feedbacks;
            //    lists.passengers = passengers;
            //    lists.travels = travels;
            //    lists.drivers = drivers;
            //    string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
            //    string jsonString = JsonSerializer.Serialize<Lists>(lists);
            //    File.WriteAllText(path, jsonString);
            //    return true;
            //}
            //catch (Exception e) { return false; }
        }
    }
}

