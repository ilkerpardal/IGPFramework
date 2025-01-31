﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Igp.Business.Common.BusinessLayers;
using Igp.Dto.Common.Users;

namespace Igp.Business.Common.Repositories
{
    public class UserRepository : IUserRepository
    {
        IConfiguration _configuration;
        string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("sqlConnection");
        }

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task<UserDto> VerifyUserAsync(string userName, string password)
        {
            using (UserBL userBl = new UserBL(_connectionString))
            {
                return await userBl.VerifyUserAsync(userName, password);
            }
        }
        public UserDto VerifyUser(string userName, string password)
        {
            using (UserBL userBl = new UserBL(_connectionString))
            {
                return userBl.VerifyUser(userName, password);
            }
        }
        public void Dispose()
        {

        }


        //public async Task AddUserAsync(User user)
        //{
        //    await _context.User.AddAsync(user);
        //}

        //public  Task<List<User>> ListUserAsync()
        //{
        //    return  _context.User.ToListAsync();
        //}

        //public async Task RemoveUserAsync(int userId)
        //{
        //    var user = await _context.User.FindAsync(userId);
        //    _context.User.Remove(user);
        //}

        //public void UpdateUserAsync(User user)
        //{
        //    _context.User.Update(user);
        //}

        //public  Task<User> FindUserAsync(int userId)
        //{
        //   return _context.User.FindAsync(userId);
        //}

        //public Task<User> FindUserByUserNameAsync(string userName)
        //{
        //    return _context.User.FirstOrDefaultAsync(x => x.UserName == userName);
        //}
    }
}
