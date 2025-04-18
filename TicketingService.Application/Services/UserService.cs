using TicketingSystem.Application.Interfaces;
using TicketingSystem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingSystem.Repositories.Interfaces;

namespace TicketingSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserSeatReservation> _userSeatReservationRepository;

        public UserService(IRepository<User> userRepository, IRepository<UserSeatReservation> userSeatReservationRepository)
        {
            _userRepository = userRepository;
            _userSeatReservationRepository = userSeatReservationRepository;
        }

        // Get User By ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // Get All Users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // Create User
        public async Task CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        // Update User
        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        // Delete User
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        // Get User Reservations
        public async Task<IEnumerable<UserSeatReservation>> GetUserReservationsAsync(int userId)
        {
            return await _userSeatReservationRepository.FindAsync(r => r.UserId == userId);
        }
    }
}
