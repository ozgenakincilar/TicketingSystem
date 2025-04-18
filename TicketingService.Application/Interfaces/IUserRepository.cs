// TicketingSystem.Application/Interfaces/IUserRepository.cs
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Application.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersWithReservationsAsync();
    }
}
