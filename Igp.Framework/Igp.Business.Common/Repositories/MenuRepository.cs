using Igp.Business.Common.BusinessLayers;
using Igp.Dto.Common.Menus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igp.Business.Common.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        IConfiguration _configuration;

        public MenuRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<MenuDto>> GetUserMenus(int userId)
        {
            using (MenuBL menuBL = new MenuBL(_configuration))
            {
                return menuBL.GetUserMenus(userId);
            }
        }


        public void Dispose()
        {
        }
    }
}
