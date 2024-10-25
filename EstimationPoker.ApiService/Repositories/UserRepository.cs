using EstimationPoker.ApiService.Database;
using EstimationPoker.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EstimationPoker.ApiService.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserAsync(string name);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task DeleteUserAsync(int id);
    }
    public class UserReposotory : IUserRepository
    {
        private readonly EstimationPokerDbContext _context;

        public UserReposotory(EstimationPokerDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var user = await _context.Users
                .ToListAsync();

            return user;
        }


        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}


