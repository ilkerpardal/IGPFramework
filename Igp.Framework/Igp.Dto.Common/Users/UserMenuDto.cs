using Igp.Dto.Common.Base;
using Igp.Dto.Common.Menus;
using System.Runtime.Serialization;

namespace Igp.Dto.Common.Users
{
    [DataContract]
    public class UserMenuDto : TableBaseDto
    {
        public int UserId { get; set; }

        [DataMember]
        public int MenuId { get; set; }

        [DataMember]
        public int Read { get; set; }

        [DataMember]
        public int Write { get; set; }

        [DataMember]
        public int Modify { get; set; }

        [DataMember]
        public int Report { get; set; }

        public virtual MenuDto Menu { get; set; }
        public virtual UserDto User { get; set; }
    }
}
