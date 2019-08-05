using Igp.Dto.Common.Base;
using Igp.Dto.Common.Menus;

namespace Igp.Dto.Common.Users
{
    public class UserTransactionDto : TableBaseDto
    {
        public int UserId { get; set; }
        
        public int TransactionId { get; set; }

        public UserDto User { get; set; }
        public MenuTransactionDto Transaction { get; set; }
    }
}
