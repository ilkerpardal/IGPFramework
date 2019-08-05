using Igp.Data.Common.Model.Base;
using Igp.Data.Common.Model.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igp.Data.Common.Model.Menus
{
    [Table("IGP_MENU_TRANSACTION")]
    public class MenuTransaction : TableBase
    {
        public int MenuId { get; set; }

        [Required]
        public string TransactionName { get; set; }
        public string Description { get; set; }

        public Menu Menu { get; set; }
        public virtual ICollection<UserTransaction> UserTransactions { get; set; }
    }
}
