using System;
using System.Collections.Generic;

namespace TicketingSystem.Domain.Models
{
    public class Seat
    {
        public int Id { get; set; }  // Seat ID (Benzersiz kimlik)
        public string SeatNumber { get; set; }  // Koltuk numarası
        public bool IsAvailable { get; set; }  // Koltuk mevcut mu (True = Mevcut, False = Satıldı)
        public int EventId { get; set; }  // Bu koltuğun ait olduğu etkinlik (foreign key)

        // Navigation property to Event (Bu koltuk bir etkinliğe ait)
        public Event Event { get; set; }

        // ICollection for UserSeatReservations (Bu koltuğun rezervasyonu yapılmış kullanıcıları tutar)
        public ICollection<UserSeatReservation> SeatReservations { get; set; }
    }
}
