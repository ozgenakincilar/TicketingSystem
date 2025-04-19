using System;
using System.Collections.Generic;

namespace TicketingSystem.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public DateTime DateOfBirth { get; set; }  

        public ICollection<UserSeatReservation> SeatReservations { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
