using Igp.Dto.Common.Base;
using Igp.Dto.Common.Menus;
using System.Runtime.Serialization;

namespace Igp.Dto.Common.Users
{
    [DataContract]
    public class UserTransactionDto : TableBaseDto
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int TransactionId { get; set; }

        public UserDto User { get; set; }
        public MenuTransactionDto Transaction { get; set; }
    }
}
