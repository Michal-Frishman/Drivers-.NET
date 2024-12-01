using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data
{
    internal class Lists
    {
        public List<DriverEntity> drivers { get; set; }
        public List<FeedbackEntity> feedbacks { get; set; }
        public List<PassengerEntity> passengers { get; set; }
        public List<TravelEntity> travels { get; set; }
    }
}
