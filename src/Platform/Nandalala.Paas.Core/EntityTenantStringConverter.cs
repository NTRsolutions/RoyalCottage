using System;
using System.Globalization;

namespace Nandalala.Paas.Core
{
    public class EntityTenantStringConverter : StringConverter
    {
        public override string ConvertToString(object o, CultureInfo culture)
        {
            var entityTenant = o as EntityTenant;
            if (entityTenant == null)
                return String.Empty;

            return entityTenant.TenantId + ":"+ entityTenant.EntityTypeId+":" + entityTenant.EntityId;
        }

        public override object ConvertFromString(string s, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(s))
                return EntityTenant.Empty;

            string[] entityId = s.Split(':');
            return new EntityTenant(new Guid(entityId[0]), new Guid(entityId[1]));
        }
    }
}
