using Igp.Dto.Common.Base;
using Igp.Dto.Common.Users;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Igp.Dto.Common.Menus
{
    [DataContract]
    public class MenuDto : TableBaseDto
    {
        [DataMember]
        public int? ParentId { get; set; }

        [DataMember]
        public string MenuName { get; set; }

        [DataMember]
        public string MenuUrl { get; set; }

        [DataMember]
        public virtual ICollection<UserMenuDto> UserMenuPermissions { get; set; }

        [DataMember]
        public virtual ICollection<MenuTransactionDto> MenuTransactions { get; set; }
    }
}
