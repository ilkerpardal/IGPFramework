
using Igp.Api.Base.Attributes;
using Igp.Api.Base.Controllers.Base;
using Igp.Business.Common.Repositories;
using Igp.Enums.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Igp.Api.Test.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MenuController : BaseApiController
    {
        IConfiguration _configuration;

        public MenuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AuthorizationIGP(AuthorizationTypes.Modify | AuthorizationTypes.Read)]
        [Route("api/GetMenus")]
        public IActionResult GetMenus()
        {
            using (IMenuRepository repo = new MenuRepository(_configuration))
            {
                var userMenus = repo.GetMenus().Result;
                return Ok(userMenus);
            }
        }
    }
}