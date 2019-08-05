using Igp.Dto.Common.Base;
using Igp.Dto.Common.Menus;
using Igp.Dto.Common.Users;
using System.Collections.Generic;

namespace Igp.Dto.Common.Menus
{
    public class MenuTransactionDto : TableBaseDto
    {
        public int MenuId { get; set; }
        
        public string TransactionName { get; set; }
        public string Description { get; set; }

        public MenuDto Menu { get; set; }
        public virtual ICollection<UserTransactionDto> UserTransactions { get; set; }
    }
}
