using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserSeatReservation> UserSeatReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserSeatReservation -> Composite Key
            modelBuilder.Entity<UserSeatReservation>()
                .HasKey(usr => new { usr.UserId, usr.SeatId });

            modelBuilder.Entity<UserSeatReservation>()
                .HasOne(usr => usr.User)
                .WithMany(u => u.SeatReservations)
                .HasForeignKey(usr => usr.UserId);

            modelBuilder.Entity<UserSeatReservation>()
                .HasOne(usr => usr.Seat)
                .WithMany(s => s.SeatReservations)
                .HasForeignKey(usr => usr.SeatId);

            // Seat -> Event relationship
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Event)
                .WithMany(e => e.Seats)
                .HasForeignKey(s => s.EventId);

            // Order -> User relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            // Transaction -> Order relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Order)
                .WithMany(o => o.Transactions)
                .HasForeignKey(t => t.OrderId);
        }
    }
}
