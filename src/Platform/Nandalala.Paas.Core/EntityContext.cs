using System;
using System.Collections.Generic;

namespace Nandalala.Paas.Core
{
    public sealed class EntityContext
        {
            public static Guid Product { get { return new Guid("6f3af85b-b33b-4951-9077-ff57cd027f29"); } }
            public static Guid ProductType { get { return new Guid("15f358d2-5d16-4bce-a9aa-64779352235e"); } }

        private static Dictionary<Guid, string> namesByGuid;
            private static Dictionary<string, Guid> guidsByName;

            public static Dictionary<string, Guid> GetContexts()
            {
                namesByGuid = new Dictionary<Guid, string>();
                guidsByName = new Dictionary<string, Guid>();
                Helper.GetStaticGuidPropertiesFromType(typeof(EntityContext), namesByGuid, guidsByName);
                return guidsByName;
            }

            public static Dictionary<Guid, string> GetTypeContexts()
            {
                namesByGuid = new Dictionary<Guid, string>();
                guidsByName = new Dictionary<string, Guid>();
                Helper.GetStaticGuidPropertiesFromType(typeof(EntityContext), namesByGuid, guidsByName);
                return namesByGuid;
            }

            public static string GetTypeById(Guid context)
            {
                namesByGuid = new Dictionary<Guid, string>();
                guidsByName = new Dictionary<string, Guid>();

                Helper.GetStaticGuidPropertiesFromType(typeof(EntityContext), namesByGuid, guidsByName);
                foreach (var partnerType in guidsByName)
                {
                    if (partnerType.Value == context)
                        return partnerType.Key;
                }
                return String.Empty;
            }

            public static Guid GetContextByName(string name)
            {
                namesByGuid = new Dictionary<Guid, string>();
                guidsByName = new Dictionary<string, Guid>();

                Helper.GetStaticGuidPropertiesFromType(typeof(EntityContext), namesByGuid, guidsByName);
                foreach (var partnerType in guidsByName)
                {
                    if (partnerType.Key == name)
                        return partnerType.Value;
                }
                return Guid.Empty;
            }
        }
}
