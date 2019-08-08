using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Igp.Dto.Common.Base
{
    [DataContract]
    public abstract class TableBaseDto
    {
        [DataMember]
        public int Id { get; set; }
        public int RecordUserId { get; set; }
        public DateTime RecordDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
