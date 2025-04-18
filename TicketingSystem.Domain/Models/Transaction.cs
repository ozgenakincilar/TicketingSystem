using System;

namespace TicketingSystem.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }  // Transaction ID
        public int OrderId { get; set; }  // Bu işlem hangi siparişle ilişkili (foreign key)
        public Order Order { get; set; }  // Bu işlemle ilişkili sipariş (Navigation property)
        public decimal Amount { get; set; }  // İşlem tutarı
        public string Status { get; set; }  // İşlem durumu (Ödeme başarılı, başarısız vb.)
        public DateTime DateCreated { get; set; }  // İşlem tarihi
    }
}
