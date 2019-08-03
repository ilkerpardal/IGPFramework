using Igp.Business.Common.Repositories;
using Igp.Core.Helpers;
using Igp.Core.Security;
using Igp.Core.Security.Token;
using IgpFramework.Data;
using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Unit = Igp.Business.Common.UnitOfWork;

namespace Igp.Business.Common.BusinessLayers
{
    public class UserBL :IDisposable
    {
        ICrypto _crypto = null;
        IUserRepository _userRepository = null;
        Unit.IUnitOfWork _unitofWork = null;
        IGPCoreContext _context;

        public UserBL(IConfiguration configuration) {
            _crypto = new Crypto();
            _context = new IGPCoreContext(new DbContextOptions<IGPCoreContext>(), configuration);
            _userRepository = new UserRepository(_context);
            _unitofWork = new Unit.UnitOfWork(_context);
        }

        public async Task<UserDto> VerifyUser(string userName,string password) {
            var passwordHash = _crypto.Md5Hashing(password);
            User user = await _userRepository.FindUserByUserNameAsync(userName);

            if (user.IsAssigned())
            {
                if (user.Password == passwordHash)
                {
                    var userDto = user.Map<UserDto>();
                    return userDto;
                }
                else
                {
                    throw new Exception("Password error");//ToDo: Mesajlara taşınacak 
                }
            }
            else
            {
                throw new Exception("User not found");//ToDo: Mesajlara taşınacak 
            }
        }

        public void GetUser() { }

        public async void SaveUser(UserDto user)
        {
            User _user = new User();
            _user = user.Map<User>();
            await _userRepository.AddUserAsync(_user);
            await _unitofWork.CompleteAsync();
        }

        public async void DeleteUser(int userId) {
            await _userRepository.RemoveUserAsync(userId);
            await _unitofWork.CompleteAsync();
        }

        public void Dispose()
        {
        }
    }
}
