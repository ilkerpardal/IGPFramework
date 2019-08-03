using System.Collections.Generic;
using System.Threading.Tasks;
using IgpFramework.Api.Model;
using IgpFramework.Data;
using IgpFramework.Dto.Common.Users;
using Microsoft.Extensions.Options;
using Igp.Business.Common.BusinessLayers;
using Microsoft.Extensions.Configuration;

namespace IgpFramework.Api.Security.Services
{
    public class UserService : IUserService
    {
        private readonly IGPCoreContext _context;
        private readonly TokenManagement _tokenManagement;
        private readonly IConfiguration _configuration;

        public UserService(IOptions<TokenManagement> tokenManagement,IConfiguration configuration)
        {
            _tokenManagement = tokenManagement.Value;
            _configuration = configuration;
        }

        public async Task<UserDto> Authenticate(string userName, string password)
        {
            using (UserBL userBl = new UserBL(_configuration))
            {
                return await userBl.VerifyUser(userName, password);
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            return null;// users.Map<IEnumerable<UserDto>>();
        }
    }
}
