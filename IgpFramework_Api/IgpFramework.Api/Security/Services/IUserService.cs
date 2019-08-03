using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using System.Collections.Generic;

namespace IgpFramework.Api.Security.Services
{
    public interface IUserService
    {
        UserDto Authenticate(string userName, string password);
        IEnumerable<User> GetAll();
    }
}
