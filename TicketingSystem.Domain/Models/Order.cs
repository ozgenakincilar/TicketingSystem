using System;
using System.Collections.Generic;

namespace TicketingSystem.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }  // Sipariş ID
        public int UserId { get; set; }  // Siparişi veren kullanıcı (foreign key)
        public User User { get; set; }  // Siparişi veren kullanıcı (Navigation property)
        public DateTime OrderDate { get; set; }  // Sipariş tarihi
        public decimal TotalAmount { get; set; }  // Toplam tutar

        // ICollection<Transaction> --> Bir siparişin birden fazla işlemi olabilir (ödeme vb.)
        public ICollection<Transaction> Transactions { get; set; }
    }
}
