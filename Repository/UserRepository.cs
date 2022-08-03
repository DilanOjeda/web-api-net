using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            this._context = context;
        }
        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public async Task<User> SearchUser(int id)
        {
            return await _context.Users
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> SearchUsers()
        {
            return await _context.Users.ToListAsync();
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}