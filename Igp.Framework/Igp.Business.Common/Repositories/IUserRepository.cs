﻿using Igp.Dto.Common.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igp.Business.Common.Repositories
{
    public interface IUserRepository : IDisposable
    {
        UserDto VerifyUser(string userName, string password);
        Task<UserDto> VerifyUserAsync(string userName, string password);

        //Task<List<User>> ListUserAsync();
        //Task AddUserAsync(User user);
        //void UpdateUserAsync(User user);
        //Task RemoveUserAsync(int userId);
        //Task<User> FindUserAsync(int userId);
        //Task<User> FindUserByUserNameAsync(string userName);
    }
}
