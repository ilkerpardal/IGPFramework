using Igp.Api.Base.Common;
using Igp.Enums.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Igp.Api.Base.Attributes
{

    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class AuthorizationIGP : Attribute, IAuthorizationFilter
    {    
        private readonly AuthorizationTypes _type;
        public AuthorizationIGP(AuthorizationTypes types)
        {
            _type = types;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var test = BaseApiCommon.UserIdentity(context.HttpContext.User);

            //context.Result = new JsonResult("")
            //{
            //    Value = new { Status = "Yetki yok" },
            //    StatusCode = (int)HttpStatusCode.Unauthorized 
            //};
        }
    }
}

