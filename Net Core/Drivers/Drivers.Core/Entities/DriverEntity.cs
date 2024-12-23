using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    [Table("Drivers")]
    public class DriverEntity
    {
        [Key]
        public int DriverId { get; set; }
        public string DriverTz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public int LicensePlate { get; set; }
        public string? CarModel { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsAvailable { get; set; }
        public int SeatsNumber { get; set; }


    }
}

