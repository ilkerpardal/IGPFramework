
using IgpFramework.Data.Model.Users;
using IgpFramework.Dto.Common.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Igp.Core.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using Igp.Security;
using Igp.Api.Base.Common;

namespace IgpFramework.Api.Controllers.Base
{
    public class BaseApiController : Controller
    {
        public UserDto UserIdentity
        {
            get
            {
                return BaseApiCommon.UserIdentity(HttpContext.User);
            }
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