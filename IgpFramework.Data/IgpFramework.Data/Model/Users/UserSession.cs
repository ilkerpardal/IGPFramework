using IgpFramework.Data.Model.Base;
using IgpFramework.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Model.Users
{
    [Table("IGP_USER_SESSIONS")]
    public class UserSession : TableBase
    {
        [Required]
        public int UserId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string SessionId { get; set; }
        [Column(TypeName = "date")]
        public DateTime LoginDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime LogoutDate { get; set; }
        public virtual User User { get; set; }
    }
}
