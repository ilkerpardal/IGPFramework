using IgpFramework.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Users
{
    [Table("IGP_USER_PASSWORDS")]
    public class UserPassword : TableBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        public virtual User User { get; set; }
    }
}
