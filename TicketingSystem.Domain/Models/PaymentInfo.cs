using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Domain.Models
{
    public class PaymentInfo
    {
        public string Id { get; set; }  
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } 
        public string TransactionId { get; set; } 
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } 
    }

}
