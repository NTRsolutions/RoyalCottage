using System;

namespace Nandalala.Paas.Core
{
    public static class TypeDescriptor
    {
        public static StringConverter GetStringConverter(Type t)
        {
            return new DefaultStringConverter(t);
        }

        public static StringConverter GetStringConverterForEntityTenant()
        {
            return new EntityTenantStringConverter();
        }
    }
}
