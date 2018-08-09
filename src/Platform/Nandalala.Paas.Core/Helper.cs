using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nandalala.Paas.Core
{
    public sealed class Helper
    {
        public static void GetStaticGuidPropertiesFromType(Type type, IDictionary<Guid, string> namesByGuid,
                                                           IDictionary<string, Guid> guidsByName)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead && property.PropertyType == typeof(Guid))
                {
                    MethodInfo getMethod = property.GetGetMethod();
                    if (getMethod.GetParameters().Length == 0)
                    {
                        var guid = (Guid)getMethod.Invoke(null, null);
                        String str = property.Name;

                        if (namesByGuid != null)
                            namesByGuid.Add(guid, str);

                        if (guidsByName != null)
                            guidsByName.Add(str, guid);
                    }
                }
            }
        }
        
    }
}
