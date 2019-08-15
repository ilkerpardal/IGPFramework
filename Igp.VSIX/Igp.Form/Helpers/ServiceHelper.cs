using Igp.Business.Common.Repositories;
using Igp.Core.Security.Token;
using Igp.Dto.Common.Menus;
using Igp.Dto.Common.Users;
using Igp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Igp.Form.Addin
{
    public static class ServiceHelper
    {
        static string _connectionString = Properties.Settings.Default.ConnectionString;

        public static UserDto VerifyUser()
        {
            return VerifyUser(_connectionString, Properties.Settings.Default.UserName, Properties.Settings.Default.Password);
        }

        public static UserDto VerifyUser(string connectionString, string userName, string password)
        {
            try
            {
                using (IUserRepository repo = new UserRepository(connectionString))
                {
                    var user = repo.VerifyUser(userName, password);
                    var identity = new IgpIdentity(user);
                    var principal = new IgpPrincipal(identity);
                    Thread.CurrentPrincipal = principal;
                    return user;
                }
            }
            catch (Exception ex)
            {
                Thread.CurrentPrincipal = null;
                throw ex;
            }
        }

        public static async Task<List<MenuDto>> GetMenus()
        {
            using (IMenuRepository repo=new MenuRepository(_connectionString))
            {
                return await repo.GetMenus();
            }
        }

        public static async Task SaveMenuTransaction(MenuTransactionDto model)
        {
            using (IMenuRepository repo = new MenuRepository(_connectionString))
            {
                await repo.SaveMenuTransaction(model);
            }
        }
    }
}
