
using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Igp.Core.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using Igp.Security;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Igp.Api.Base.Common
{
    public static class BaseApiCommon 
    {
        public  static UserDto UserIdentity(ClaimsPrincipal principal)
        {
            var identity = principal.FindFirst("UserIdentity");
            if (identity.IsAssigned())
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(identity.Value);
            else return new UserDto();
        }
    }
}
