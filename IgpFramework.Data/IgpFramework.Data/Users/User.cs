using IgpFramework.Data.Base;
using IgpFramework.Data.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Users
{
    [Table("IGP_USER")]
    public class User : TableBase
    {
        [Column(TypeName = "varchar(200)")]
        public string Adi { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Soyadi { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string KullaniciAdi { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Sifresi { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string CepTelefonu { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Eposta { get; set; }
        [Column(TypeName = "decimal(11)")]
        public decimal TcKimlikNo { get; set; }
        [Column(TypeName = "date")]
        public DateTime DogumTarihi { get; set; }
        [Column(TypeName = "int")]
        public int Cinsiyeti { get; set; }
        public virtual ICollection<UserPassword> UserPasswords { get; set; }
        public virtual ICollection<UserMenu> UserMenuPermissions { get; set; }
        public virtual ICollection<UserSession> UserSessions{ get; set; }

    }
}
