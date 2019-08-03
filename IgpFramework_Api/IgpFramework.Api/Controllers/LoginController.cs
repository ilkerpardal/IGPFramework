using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using IgpFramework.Api.Common;
using IgpFramework.Api.Controllers.Base;
using IgpFramework.Api.Helpers;
using IgpFramework.Api.Security.Services;
using IgpFramework.Data.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IgpFramework.Api.Controllers
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
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _userService.Authenticate(userParam.UserName, userParam.Password);
            if (!user.IsAssigned()) return BadRequest(new { Massage = _resourceManager.GetResourceValue("InvalidPasswordOrUsername") });
            return Ok(user);
        }


    }
}

