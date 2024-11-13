using EstimationPoker.ApiService.Models;
using EstimationPoker.ApiService.Repositories;
using System.Net;

namespace EstimationPoker.ApiService.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync();

        Task<bool> DeleteUserAsync(int userId);

    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user;
        }

        public async Task<User> GetUserAsync(string name)
        {
            return await _userRepository.GetUserAsync(name);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();

        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
            return true;
        }
    }
}

