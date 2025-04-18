using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Domain.Models
{
    public class EventFeedback
    {
        public string Id { get; set; }  // MongoDB'deki benzersiz Id
        public string EventId { get; set; }  // Etkinlik ID'si
        public string UserId { get; set; }  // Geri bildirimde bulunan kullanıcının ID'si
        public int Rating { get; set; }  // Kullanıcının verdiği puan (1-5 arası)
        public string Comment { get; set; }  // Kullanıcının yazdığı yorum
        public DateTime FeedbackDate { get; set; }
    }

}
