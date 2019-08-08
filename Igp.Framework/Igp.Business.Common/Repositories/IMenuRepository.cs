using Igp.Dto.Common.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igp.Business.Common.Repositories
{
    public interface IMenuRepository : IDisposable
    {
        Task<List<MenuDto>> GetUserMenus(int userId);
    }
}
