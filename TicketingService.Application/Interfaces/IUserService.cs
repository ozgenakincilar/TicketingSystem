using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingSystem.Domain.Models;

namespace TicketingSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

        Task<IEnumerable<UserSeatReservation>> GetUserReservationsAsync(int userId);
    }
}
