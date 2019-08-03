
using IgpFramework.Data.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IgpFramework.Api.Controllers.Base
{
    public class BaseApiController : Controller
    {
        public User GetUserInfo()
        {
            return new User()
            {
                KullaniciAdi = HttpContext.User.FindFirst("userName").Value,
                Id = Convert.ToInt32(HttpContext.User.FindFirst("userId").Value)
            };
        }

    }
}