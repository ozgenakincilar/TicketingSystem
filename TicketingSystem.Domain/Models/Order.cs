using System;
using System.Collections.Generic;

namespace TicketingSystem.Domain.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; }
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; }  

        public ICollection<Transaction> Transactions { get; set; }
    }
}
