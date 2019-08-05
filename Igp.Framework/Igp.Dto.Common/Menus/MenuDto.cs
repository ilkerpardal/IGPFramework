using Igp.Dto.Common.Base;

namespace Igp.Dto.Common.Menus
{
    public class MenuDto : TableBaseDto
    {
        public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
    }
}
