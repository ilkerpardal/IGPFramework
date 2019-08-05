using System.Threading.Tasks;
using Igp.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Igp.Api.Base.Controllers.Base;
using Igp.Api.Base.Services;
using Igp.Api.Base.Common;
using Igp.Dto.Common.Users;

namespace Igp.Api.Base.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class LoginController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IResourceManagerIGP _resourceManager;
        public LoginController(IUserService userService , IResourceManagerIGP resourceManager)
        {
            _userService = userService;
            _resourceManager = resourceManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]UserDto userParam)
        {
            var user = await _userService.Authenticate(userParam.UserName, userParam.Password);
            if (!user.IsAssigned()) return BadRequest(new { Massage = _resourceManager.GetResourceValue("InvalidPasswordOrUsername") });
            return Ok(user);
        }


    }
}

