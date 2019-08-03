using IgpFramework.Dto.Common.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Igp.Core.Helpers
{
    public static class UserHelper
    {
        public static UserDto UserIdentity
        {
            get { return Thread.CurrentPrincipal.Identity as UserDto; }
        }
    }
}
