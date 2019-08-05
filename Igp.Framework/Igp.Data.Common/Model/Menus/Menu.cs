using Igp.Data.Common.Model.Base;
using Igp.Data.Common.Model.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igp.Data.Common.Model.Menus
{
    [Table("IGP_MENU")]
    public class Menu : TableBase
    {
        public int? ParentId { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string MenuName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string MenuUrl { get; set; }

        public virtual ICollection<UserMenu> UserMenuPermissions { get; set; }
        public virtual ICollection<MenuTransaction> MenuTransactions { get; set; }
    }
}
