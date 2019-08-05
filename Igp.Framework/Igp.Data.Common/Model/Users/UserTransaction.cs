using Igp.Data.Common.Model.Base;
using Igp.Data.Common.Model.Menus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igp.Data.Common.Model.Users
{
    [Table("IGP_USER_TRANSACTION")]
    public class UserTransaction : TableBase
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TransactionId { get; set; }

        public User User { get; set; }
        public MenuTransaction Transaction { get; set; }
    }
}
