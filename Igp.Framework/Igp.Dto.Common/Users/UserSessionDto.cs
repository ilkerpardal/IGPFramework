using IgpFramework.Dto.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgpFramework.Dto.Common.Users
{
    public class UserSessionDto : TableBaseDto
    {
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public virtual UserDto User { get; set; }
    }
}
