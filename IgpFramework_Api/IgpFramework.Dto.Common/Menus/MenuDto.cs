using IgpFramework.Dto.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IgpFramework.Dto.Common.Menus
{
    public class MenuDto : TableBaseDto
    {
        public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
    }
}
