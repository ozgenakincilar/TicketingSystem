using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Persistence.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            // MongoDB Connection String'ini appsettings.json'dan alıyoruz
            var client = new MongoClient(configuration.GetConnectionString("MongoDbConnection"));
            _database = client.GetDatabase("TicketingSystemDb");  // MongoDB veritabanı ismi
        }

        // MongoDB Koleksiyonlarına erişim sağlayan properties
        public IMongoCollection<PaymentInfo> PaymentInfos => _database.GetCollection<PaymentInfo>("PaymentInfos");
        public IMongoCollection<EventFeedback> EventFeedbacks => _database.GetCollection<EventFeedback>("EventFeedbacks");
    }
}
