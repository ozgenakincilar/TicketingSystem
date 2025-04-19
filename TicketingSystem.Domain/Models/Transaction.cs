using System;

namespace TicketingSystem.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; } 
        public int OrderId { get; set; } 
        public Order Order { get; set; }  
        public decimal Amount { get; set; }  
        public string Status { get; set; }  
        public DateTime DateCreated { get; set; } 
    }
}
