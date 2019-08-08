using Igp.Data.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Igp.Data.Common.Model.Users
{
    [Table("IGP_USER")]
    public class User : TableBase
    {
        [Required, Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Required, Column(TypeName = "varchar(200)")]
        public string Surname { get; set; }
        [Required, Column(TypeName = "varchar(200)")]
        public string UserName { get; set; }
        [Required, Column(TypeName = "varchar(200)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "decimal(11)")]
        public decimal? IdentityKey { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }
        [Column(TypeName = "int")]
        public int? Sex { get; set; }
        public virtual ICollection<UserPassword> UserPasswords { get; set; }
        public virtual ICollection<UserMenu> UserMenuPermissions { get; set; }
        public virtual ICollection<UserSession> UserSessions{ get; set; }
        public virtual ICollection<UserTransaction> UserTransactions { get; set; }

    }
}
