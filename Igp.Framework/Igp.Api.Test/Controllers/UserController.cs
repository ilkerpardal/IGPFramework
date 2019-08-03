
using IgpFramework.Api.Controllers.Base;
using IgpFramework.Api.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IgpFramework.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        IUserService _userService = null;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        [Route("api/test")]
        public IActionResult test()
        {
            _userService.SaveUser(new Dto.Common.Users.UserDto()
            {
                Name = "Güleser",
                Surname = "Pardal",
                UserName = "Gules",
                Password = "123456",
                RecordUserId = 1,
                RecordDate = DateTime.Now
            });

            return Ok("ok");
        }
    }
}