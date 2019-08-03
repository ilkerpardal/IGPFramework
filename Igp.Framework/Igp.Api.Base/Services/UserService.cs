using System.Collections.Generic;
using System.Threading.Tasks;
using IgpFramework.Api.Model;
using IgpFramework.Dto.Common.Users;
using Microsoft.Extensions.Options;
using Igp.Business.Common.BusinessLayers;
using Microsoft.Extensions.Configuration;
using Igp.Core.Security.Token;
using System.Threading;
using System;
using Igp.Core.Helpers;

namespace IgpFramework.Api.Security.Services
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
                using (UserBL userBl = new UserBL(_configuration))
                {
                    var user = await userBl.VerifyUser(userName, password);
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
            using (UserBL userBl = new UserBL(_configuration))
            {
                userBl.SaveUser(user);
                userBl.CompleteAsync();
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            return null;// users.Map<IEnumerable<UserDto>>();
        }
    }
}
