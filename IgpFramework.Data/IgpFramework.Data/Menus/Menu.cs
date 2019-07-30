using IgpFramework.Data.Base;
using IgpFramework.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Menus
{
    [Table("IGP_MENU")]
    public class Menu : TableBase
    {
        [Column(TypeName = "varchar(100)")]
        public string MenuAdi { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Url { get; set; }

        public virtual ICollection<UserMenu> UserMenuPermissions { get; set; }
    }
}
