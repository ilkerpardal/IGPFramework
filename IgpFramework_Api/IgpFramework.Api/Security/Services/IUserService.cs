using IgpFramework.Data.Users;
using System.Collections.Generic;

namespace IgpFramework.Api.Security.Services
{
    public interface IUserService
    {
        User Authenticate(string userName, string password);
        IEnumerable<User> GetAll();
    }
}
