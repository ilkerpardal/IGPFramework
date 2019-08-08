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
            _context = new IGPCoreContext(new DbContextOptions<IGPCoreContext>(), configuration);
        }

        internal List<MenuDto> GetUserMenus(int userId)
        {
            var userMenus = _context.Menu.Include(x => x.UserMenuPermissions).Include(x=> x.MenuTransactions)
                                         .Where(x => x.UserMenuPermissions.Any(y => y.UserId == userId))
                                        // .Where(x=> x.MenuTransactions.Any(y=> y.UserTransactions.Any(z=>z.UserId==userId)))
                                         .ToList();
            
            var dict = new Dictionary<Type, Type>();
            dict.Add(typeof(Menu), typeof(MenuDto));
            dict.Add(typeof(UserMenu), typeof(UserMenuDto));
            dict.Add(typeof(MenuTransaction), typeof(MenuTransactionDto));

            return userMenus.Map<List<MenuDto>>(dict);
        }

        void IDisposable.Dispose()
        {
            
        }
    }
}
