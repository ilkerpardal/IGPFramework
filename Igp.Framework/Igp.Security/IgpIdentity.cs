using Igp.Dto.Common.Users;
using System;
using System.Security.Principal;

namespace Igp.Security
{
    [Serializable]
    public sealed class IgpIdentity : IIdentity
    {
        private readonly UserDto _user;
        public IgpIdentity(UserDto user)
        {
            _user = user;
        }

        public UserDto User
        {
            get { return _user; }
        }

        public string AuthenticationType => "IgpIdentity";

        public bool IsAuthenticated => !String.IsNullOrEmpty(_user.UserName);

        public string Name => _user.UserName;
    }

    
}
