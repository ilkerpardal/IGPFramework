using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Igp.Api.Base.Controllers.Base;

namespace Igp.Api.Base.Controllers
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