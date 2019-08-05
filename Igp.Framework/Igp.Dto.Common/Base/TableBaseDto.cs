using System;
using System.Collections.Generic;
using System.Text;

namespace Igp.Dto.Common.Base
{
    public class TableBaseDto
    {
        public int Id { get; set; }
        public int RecordUserId { get; set; }
        public DateTime RecordDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
