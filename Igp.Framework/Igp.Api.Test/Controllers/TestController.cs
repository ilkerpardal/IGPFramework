 
using Igp.Api.Base.Attributes;
using Igp.Api.Base.Controllers.Base;
using Igp.Api.Base.Services;
using Igp.Business.Common.Repositories;
using Igp.Enums.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Igp.Api.Test.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TestController : BaseApiController
    {
        IUserService _userService = null;
        IConfiguration _configuration;

        public TestController(IUserService userService, IConfiguration configuration) {
            _userService = userService;
            _configuration = configuration;
        }

        [AuthorizationIGP( AuthorizationTypes.Modify | AuthorizationTypes.Read)]
        [Route("api/test")]
        public IActionResult test()
        {
            var user = UserIdentity;

            _userService.SaveUser(
            new Dto.Common.Users.UserDto()
            {
                Name = "Güleser",
                Surname = "Pardal",
                UserName = "Gules",
                Password = "123456"
            });

            return Ok("ok");
        }

        [AuthorizationIGP(AuthorizationTypes.Modify | AuthorizationTypes.Read)]
        [Route("api/GetUserMenus")]
        public IActionResult GetUserMenus()
        {
            using (IMenuRepository repo = new MenuRepository(_configuration))
            {
                var userMenus= repo.GetUserMenus(UserIdentity.Id).Result;
                return Ok(userMenus);
            }
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