
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using Igp.Security;
using Igp.Api.Base.Common;
using Igp.Dto.Common.Users;

namespace Igp.Api.Base.Controllers.Base
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