using Igp.Dto.Common.Base;
using System;

namespace Igp.Dto.Common.Users
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
