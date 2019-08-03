using IgpFramework.Dto.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgpFramework.Dto.Common.Users
{
    public class UserPasswordDto : TableBaseDto
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public virtual UserDto User { get; set; }
    }
}
