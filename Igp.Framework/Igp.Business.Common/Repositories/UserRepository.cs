using System.Collections.Generic;
using System.Threading.Tasks;
using IgpFramework.Data;
using Microsoft.EntityFrameworkCore;
using IgpFramework.Data.Model.Users;

namespace Igp.Business.Common.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IGPCoreContext _context;

        public UserRepository(IGPCoreContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.User.AddAsync(user);
        }

        public  Task<List<User>> ListUserAsync()
        {
            return  _context.User.ToListAsync();
        }

        public async Task RemoveUserAsync(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            _context.User.Remove(user);
        }

        public void UpdateUserAsync(User user)
        {
            _context.User.Update(user);
        }

        public  Task<User> FindUserAsync(int userId)
        {
           return _context.User.FindAsync(userId);
        }

        public Task<User> FindUserByUserNameAsync(string userName)
        {
            return _context.User.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
