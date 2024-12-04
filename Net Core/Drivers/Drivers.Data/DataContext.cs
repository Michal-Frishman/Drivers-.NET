using Drivers.Core.Entities;
using Microsoft.EntityFrameworkCore;
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
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<DriverEntity> drivers { get; set; }
        public DbSet<FeedbackEntity> feedbacks { get; set; }
        public DbSet<PassengerEntity> passengers { get; set; }
        public DbSet<TravelEntity> travels { get; set; }
      
    }
}

