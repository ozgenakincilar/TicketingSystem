using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Domain.Models
{
    public class PaymentInfo
    {
        public string Id { get; set; }  // MongoDB'de Id genellikle string olur.
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Ödeme yöntemi: Kredi Kartı, PayPal, vs.
        public string TransactionId { get; set; } // Ödeme işlemine ait transaction ID
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }  // Ödeme durumu (Success, Failed, Pending, vs.)
    }

}
