using IgpFramework.Data.Base;
using IgpFramework.Data.Menus;
using IgpFramework.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Users
{
    [Table("IGP_USER_MENU_PERMISSIONS")]
    public class UserMenu : TableBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
    }
}
