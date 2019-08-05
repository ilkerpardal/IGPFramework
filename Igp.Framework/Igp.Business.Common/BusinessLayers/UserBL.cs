using Igp.Core.Helpers;
using Igp.Core.Security;
using IgpFramework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Unit = Igp.Business.Common.UnitOfWork;
using Igp.Dto.Common.Users;
using Igp.Data.Common.Model.Users;

namespace Igp.Business.Common.BusinessLayers
{
    internal class UserBL :IDisposable
    {
        ICrypto _crypto = null;
        Unit.IUnitOfWork _unitofWork = null;
        IGPCoreContext _context;

        internal UserBL(IConfiguration configuration)
        {
            _crypto = new Crypto();
            _context = new IGPCoreContext(new DbContextOptions<IGPCoreContext>(), configuration);
            _unitofWork = new Unit.UnitOfWork(_context);
        }

        internal async Task<UserDto> VerifyUser(string userName, string password)
        {
            var passwordHash = _crypto.Md5Hashing(password);
            User user = await _context.User.FirstOrDefaultAsync(x => x.UserName == userName);

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

        //public void GetUser() { }

        //public async void SaveUser(UserDto user)
        //{
        //    User _user = user.Map<User>();
        //    _user.Password = _crypto.Md5Hashing(user.Password);
        //    if (_user.Id == 0)
        //    {
        //        _user.RecordUserId = UserHelper.UserIdentity.Id;
        //        _user.RecordDate = DateTime.Now;
        //    }
        //    else {
        //        _user.UpdateUserId= UserHelper.UserIdentity.Id;
        //        _user.UpdateDate = DateTime.Now;
        //    }

        //    await _userRepository.AddUserAsync(_user);
        //}

        //public async void DeleteUser(int userId)
        //{
        //    await _userRepository.RemoveUserAsync(userId);
        //}

        internal async void CompleteAsync()
        {
            await _unitofWork.CompleteAsync();
        }

        void IDisposable.Dispose()
        {
        }
    }
}
