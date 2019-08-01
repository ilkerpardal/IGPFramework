﻿using IgpFramework.Data.Base;
using IgpFramework.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Menus
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
    }
}
