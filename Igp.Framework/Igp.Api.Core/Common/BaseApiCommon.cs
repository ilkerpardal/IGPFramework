using Igp.Core.Helpers;
using System.Security.Claims;
using Igp.Dto.Common.Users;

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
