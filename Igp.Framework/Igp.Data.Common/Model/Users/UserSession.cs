using Igp.Data.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Igp.Data.Common.Model.Users
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
