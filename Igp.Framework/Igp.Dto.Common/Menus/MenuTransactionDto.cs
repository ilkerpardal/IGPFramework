using Igp.Dto.Common.Base;
using Igp.Dto.Common.Menus;
using Igp.Dto.Common.Users;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Igp.Dto.Common.Menus
{
    [DataContract]
    public class MenuTransactionDto : TableBaseDto
    {
        public int MenuId { get; set; }
        
        [DataMember]
        public string TransactionName { get; set; }

        [DataMember]
        public string Description { get; set; }

        public MenuDto Menu { get; set; }
        public virtual ICollection<UserTransactionDto> UserTransactions { get; set; }
    }
}
