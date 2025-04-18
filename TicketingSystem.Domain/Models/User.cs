using System;
using System.Collections.Generic;

namespace TicketingSystem.Domain.Models
{
    public class User
    {
        public int Id { get; set; }  // User ID
        public string FirstName { get; set; }  // First Name of the User
        public string LastName { get; set; }  // Last Name of the User
        public string Email { get; set; }  // Email Address
        public string PhoneNumber { get; set; }  // Phone Number
        public DateTime DateOfBirth { get; set; }  // Date of Birth

        // ICollection for UserSeatReservations (This will be used to store the user's reserved seats)
        public ICollection<UserSeatReservation> SeatReservations { get; set; }

        // ICollection for Orders (This will be used to store orders placed by the user)
        public ICollection<Order> Orders { get; set; }
    }
}
