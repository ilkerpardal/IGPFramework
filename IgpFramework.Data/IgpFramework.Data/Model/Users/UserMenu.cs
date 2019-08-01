using IgpFramework.Data.Model.Base;
using IgpFramework.Data.Model.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Model.Users
{
    [Table("IGP_USER_MENU_PERMISSIONS")]
    public class UserMenu : TableBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MenuId { get; set; }

        public int Read { get; set; }
        public int Write { get; set; }
        public int Modify { get; set; }
        public int Report { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
    }
}
