using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Igp.Security
{
    public sealed class IgpPrincipal : IPrincipal
    {
        private readonly IgpIdentity _identity;
        IIdentity IPrincipal.Identity => _identity;
        public IgpIdentity Identity => _identity;

        public IgpPrincipal(IgpIdentity identity) {
            _identity = identity;
        }

        public bool IsInRole(string role)
        {
            return _identity != null &&
                   _identity.IsAuthenticated &&
                   !string.IsNullOrWhiteSpace(role);
        }

    }
}
