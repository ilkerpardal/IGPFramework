using Igp.Dto.Common.Base;
using Igp.Dto.Common.Menus;

namespace Igp.Dto.Common.Users
{
    public class UserMenuDto : TableBaseDto
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }

        public int Read { get; set; }
        public int Write { get; set; }
        public int Modify { get; set; }
        public int Report { get; set; }

        public virtual MenuDto Menu { get; set; }
        public virtual UserDto User { get; set; }
    }
}
