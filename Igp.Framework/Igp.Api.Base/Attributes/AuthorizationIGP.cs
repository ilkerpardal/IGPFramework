using IgpFramework.Enums.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Igp.Security
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
         var test =   Igp.Core.Helpers.UserHelper.UserIdentity;
            
            context.Result = new JsonResult("")
            {
                Value = new { Status = "Yetki yok" },
                StatusCode = (int)HttpStatusCode.Unauthorized 
            };
        }
    }
}

