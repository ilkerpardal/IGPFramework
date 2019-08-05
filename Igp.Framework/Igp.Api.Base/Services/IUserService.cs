using Igp.Dto.Common.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igp.Api.Base.Services
{
    public interface IUserService
    {
        void SaveUser( UserDto user);
        Task<UserDto> Authenticate(string userName, string password);
        IEnumerable<UserDto> GetAll();
    }
}
