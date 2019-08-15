using Igp.Core.Helpers;
using Igp.Data.Common.Model.Menus;
using Igp.Data.Common.Model.Users;
using Igp.Dto.Common.Menus;
using Igp.Dto.Common.Users;
using IgpFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igp.Business.Common.BusinessLayers
{
    internal class MenuBL : IDisposable
    {
        IGPCoreContext _context;

        internal MenuBL(IConfiguration configuration)
        {
            _context = new IGPCoreContext(new DbContextOptions<IGPCoreContext>(), configuration.GetConnectionString("sqlConnection"));
        }

        internal MenuBL(string connectionString)
        {
            _context = new IGPCoreContext(new DbContextOptions<IGPCoreContext>(), connectionString);
        }

        internal List<MenuDto> GetUserMenus(int userId)
        {
            var userMenus = _context.Menu.Select(x =>
            new Menu
            {
                UserMenuPermissions = _context.UserMenu.Where(y => y.MenuId == x.Id && y.UserId == userId).ToList(),
                MenuTransactions = _context.MenuTransaction.Where(y => y.MenuId == x.Id && y.UserTransactions.Any(ut => ut.UserId == userId)).ToList(),
                Id = x.Id,
                MenuName = x.MenuName,
                MenuUrl = x.MenuUrl,
                ParentId = x.ParentId
            });
            return userMenus.Map<List<MenuDto>>(ModelConfig.GetAllModelConfigrations());
        }

        internal List<MenuDto> GetMenus()
        {
            var userMenus = _context.Menu.Select(x =>
            new Menu
            {
                 Id = x.Id,
                MenuName = x.MenuName,
                MenuUrl = x.MenuUrl,
                ParentId = x.ParentId
            });
            return userMenus.Map<List<MenuDto>>(ModelConfig.GetAllModelConfigrations());
        }

        internal async Task SaveMenuTransaction(MenuTransactionDto menuTransaction)
        {
            MenuTransaction transaction = menuTransaction.Map<MenuTransaction>();
            transaction.RecordUserId = UserHelper.UserIdentity.Id;
            transaction.RecordDate = DateTime.Now;
            await _context.MenuTransaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {

        }
    }
}
