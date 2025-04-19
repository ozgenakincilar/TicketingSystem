using System;
using System.Collections.Generic;

namespace TicketingSystem.Domain.Models
{
    public class Seat
    {
        public int Id { get; set; } 
        public string SeatNumber { get; set; } 
        public bool IsAvailable { get; set; } 
        public int EventId { get; set; } 

        public Event Event { get; set; }

        public ICollection<UserSeatReservation> SeatReservations { get; set; }
    }
}
