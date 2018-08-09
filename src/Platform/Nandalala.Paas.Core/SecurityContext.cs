using System;

namespace Nandalala.Paas.Core
{
    public interface ISecurityContext { }

    public sealed class SecurityContext : ISecurityContext
    {
        private readonly Guid _entityId;
        private readonly Guid _tenantId;
        
        private SecurityContext()
        {
            
        }

        public SecurityContext(Guid entityId, Guid tenantId)
        {
            _entityId = entityId;
            _tenantId = tenantId;
        }

        public static SecurityContext Empty
        {
            get { return new SecurityContext(); }
        }

        public Guid EntityId { get { return _entityId; } }
        public Guid TenantId { get { return _tenantId; } }

    }
}
