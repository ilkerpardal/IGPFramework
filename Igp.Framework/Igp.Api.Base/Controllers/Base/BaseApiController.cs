
using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Igp.Core.Helpers;

namespace IgpFramework.Api.Controllers.Base
{
    public class BaseApiController : Controller
    {
        public UserDto UserIdentity
        {
            get
            {
                return GetUserInfo();
            }
        }

        private UserDto GetUserInfo()
        {
            var identity = HttpContext.User.FindFirst("UserIdentity");
            if (identity.IsAssigned())
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(HttpContext.User.FindFirst("UserIdentity")?.Value);
            else return new UserDto();
        }
    }
}