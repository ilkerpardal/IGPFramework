﻿using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IgpFramework.Api.Security.Services
{
    public interface IUserService
    {
        void SaveUser(UserDto user);
        Task<UserDto> Authenticate(string userName, string password);
        IEnumerable<UserDto> GetAll();
    }
}
