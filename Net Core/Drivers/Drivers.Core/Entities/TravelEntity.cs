using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    [Table("Travels")]
    public class TravelEntity
    {
        [Key]
        public int Id { get; set; }
        public int PassengerId { get; set; }
        [ForeignKey(nameof(PassengerId))]
        public PassengerEntity Passenger { get; set; }
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public DriverEntity Driver { get; set; }
        public DateTime Date { get; set; }
        public string DeparturePoint { get; set; }
        public string DestinationPoint { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Length { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public bool? IsPaid { get; set; }


    }
}
