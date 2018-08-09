using System;
using System.Security.Principal;

namespace Nandalala.Paas.Core
{
    public sealed class SecurityIdentity : IIdentity
    {
        private readonly EntityTenant _identityUnit;
        private readonly DateTime _lastLoginDateUtc;
        private readonly AuthenticationStatus _status;

        public SecurityIdentity(EntityTenant identityUnit)
        {
            _status = AuthenticationStatus.Success;
            _identityUnit = identityUnit;
        }

        public SecurityIdentity() : this(AuthenticationStatus.Failure)
        {
        }

        public SecurityIdentity(AuthenticationStatus status)
        {
            _status = status;
            _identityUnit = null;
            _lastLoginDateUtc = DateTime.MinValue;
            Name = null;
        }

        public EntityTenant IdentityUnit
        {
            get { return _identityUnit; }
        }

        public AuthenticationStatus AuthenticationStatus
        {
            get { return _status; }
        }

        public DateTime LastLoginDateUtc
        {
            get { return _lastLoginDateUtc; }
        }

        public bool IsAuthenticated
        {
            get { return (_status & AuthenticationStatus.Success) > 0; }
        }

        public string Name { get; set; }

        public string AuthenticationType
        {
            get { return "SecurityAuthenticationSystem"; }
        }
    }
}
