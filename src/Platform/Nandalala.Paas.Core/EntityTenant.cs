using Newtonsoft.Json;
using System;
using System.Threading;

namespace Nandalala.Paas.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EntityTenant : GuidKeyValuePair, IComparable
    {
       
        public EntityTenant(Guid tenantId, Guid entityId)
            : base(tenantId, entityId)
        {
        }

        public static EntityTenant Empty
        {
            get { return new EntityTenant(Guid.Empty, Guid.Empty); }
        }

        protected Guid TypeId { get; set; }

        [JsonProperty]
        public Guid TenantId
        {
            get { return Key; }
        }

        [JsonProperty]
        public Guid EntityTypeId
        {
            get { return TypeId; }
        }

        [JsonProperty]
        public Guid EntityId
        {
            get { return Value; }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is EntityTenant)
            {
                var otherTemperature = (EntityTenant)obj;
                if (this == otherTemperature)
                    return 0;
                return 1;
            }

            throw new ArgumentException("Object is not a EntityTenant");
        }

        #endregion

        public static bool operator ==(EntityTenant x, EntityTenant y)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(x, y))
                return true;

            // If one is null, but not both, return false.
            if (((object)x == null) || ((object)y == null))
                return false;

            return x.EntityId == y.EntityId && x.TenantId == y.TenantId;
        }

        public static bool operator !=(EntityTenant x, EntityTenant y)
        {
            return !(x == y);
        }

        public override bool Equals(Object obj)
        {
            return obj is EntityTenant && this == (EntityTenant)obj;
        }

        public override int GetHashCode()
        {
            return TenantId.GetHashCode() ^ EntityId.GetHashCode();
        }

        public override string ToString()
        {
            var converter = TypeDescriptor.GetStringConverterForEntityTenant();
            return converter.ConvertToString(this, Thread.CurrentThread.CurrentCulture);
        }
    }
}
