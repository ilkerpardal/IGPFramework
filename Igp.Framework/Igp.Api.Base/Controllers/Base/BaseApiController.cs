
using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Igp.Core.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using Igp.Security;

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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var identity = new IgpIdentity(UserIdentity);
            var principal = new IgpPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            base.OnActionExecuting(context);
        }
    }
}