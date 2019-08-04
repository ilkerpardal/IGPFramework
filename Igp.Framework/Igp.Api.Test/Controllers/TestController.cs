
using Igp.Security;
using IgpFramework.Api.Controllers.Base;
using IgpFramework.Api.Security.Services;
using IgpFramework.Enums.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IgpFramework.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TestController : BaseApiController
    {
        IUserService _userService = null;
        public TestController(IUserService userService) {
            _userService = userService;
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
    }
}