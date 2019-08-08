using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Igp.Business.Common.BusinessLayers;
using Microsoft.Extensions.Configuration;
using Igp.Core.Security.Token;
using System.Threading;
using System;
using Igp.Core.Helpers;
using Igp.Business.Common.Repositories;
using Igp.Api.Base.Model;
using Igp.Dto.Common.Users;

namespace Igp.Api.Base.Services
{
    public class UserService : IUserService
    {
        private readonly TokenManagement _tokenManagement;
        private readonly IConfiguration _configuration;

        public UserService(IOptions<TokenManagement> tokenManagement,IConfiguration configuration)
        {
            _tokenManagement = tokenManagement.Value;
            _configuration = configuration;
        }

        public async Task<UserDto> Authenticate(string userName, string password)
        {
            try
            {
                using (IUserRepository userRepo = new UserRepository(_configuration))
                {
                    var user = await userRepo.VerifyUser(userName, password);
                    if (user.IsAssigned())
                        user.Token = TokenHelper.GetToken(user);
                    return user;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void SaveUser(UserDto user)
        {
            using (IUserRepository userRepo = new UserRepository(_configuration))
            {
                //userRepo.SaveUser(user);
                //userRepo.CompleteAsync();
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            return null;// users.Map<IEnumerable<UserDto>>();
        }
    }
}
