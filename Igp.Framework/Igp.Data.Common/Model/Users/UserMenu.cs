using Igp.Data.Common.Model.Base;
using Igp.Data.Common.Model.Menus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igp.Data.Common.Model.Users
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
