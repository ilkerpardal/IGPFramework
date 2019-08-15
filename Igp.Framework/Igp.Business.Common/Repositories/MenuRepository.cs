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
        string _connectionString;

        public MenuRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("sqlConnection");
        }

        public MenuRepository(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task<List<MenuDto>> GetUserMenus(int userId)
        {
            using (MenuBL menuBL = new MenuBL(_configuration))
            {
                return menuBL.GetUserMenus(userId);
            }
        }

        public async Task<List<MenuDto>> GetMenus()
        {
            using (MenuBL menuBL = new MenuBL(_connectionString))
            {
                return menuBL.GetMenus();
            }
        }

        public async Task SaveMenuTransaction(MenuTransactionDto model)
        {
            using (MenuBL menuBL = new MenuBL(_connectionString))
            {
                await menuBL.SaveMenuTransaction(model);
            }
        }

        public void Dispose()
        {
        }
    }
}
