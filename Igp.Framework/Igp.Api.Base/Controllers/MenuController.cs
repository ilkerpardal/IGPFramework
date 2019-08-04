using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgpFramework.Api.Controllers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Igp.Security;
using IgpFramework.Enums.Common;

namespace IgpFramework.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MenuController : BaseApiController
    {
        [Route("api/menu")]
        public IActionResult Menus()
        {
            return Ok("ok");
        }
    }
}