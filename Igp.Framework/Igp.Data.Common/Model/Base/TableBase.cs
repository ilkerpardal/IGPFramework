using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IgpFramework.Data.Model.Base
{
    public class TableBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RecordUserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime RecordDate { get; set; }
        public int? UpdateUserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
