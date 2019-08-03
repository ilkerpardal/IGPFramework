using IgpFramework.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgpFramework.Api.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> ListUserAsync();
        Task AddUserAsync(User user);
        void UpdateUserAsync(User user);
        Task RemoveUserAsync(int userId);
        Task<User> FindUserAsync(int userId);
        Task<User> FindUserByUserNameAsync(string userName);
    }
}
