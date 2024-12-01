using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    public class PassengerEntity
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public PassengerEntity(int passengerId, string firstName, string lastName, string phoneNumber)
        {
            PassengerId = passengerId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;

        }
        public PassengerEntity()
        {

        }
    }
}
