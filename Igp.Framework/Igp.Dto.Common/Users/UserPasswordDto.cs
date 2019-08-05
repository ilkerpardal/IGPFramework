using Igp.Dto.Common.Base;

namespace Igp.Dto.Common.Users
{
    public class UserPasswordDto : TableBaseDto
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public virtual UserDto User { get; set; }
    }
}
