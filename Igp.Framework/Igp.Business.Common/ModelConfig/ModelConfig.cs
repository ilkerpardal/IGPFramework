using Igp.Data.Common.Model.Menus;
using Igp.Data.Common.Model.Users;
using Igp.Dto.Common.Menus;
using Igp.Dto.Common.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igp.Business.Common
{
    public static class ModelConfig
    {
        public static Dictionary<Type , Type> GetAllModelConfigrations()
        {
            return new Dictionary<Type, Type>
            {
                {typeof(User) , typeof(UserDto) },
                {typeof(UserMenu) , typeof(UserMenuDto) },
                {typeof(Menu) , typeof(MenuDto) },
                {typeof(MenuTransaction) , typeof(MenuTransactionDto) },
                {typeof(UserSession) , typeof(UserSessionDto) },
                {typeof(UserPassword) , typeof(UserPasswordDto) }
            };
        }
    }
}
