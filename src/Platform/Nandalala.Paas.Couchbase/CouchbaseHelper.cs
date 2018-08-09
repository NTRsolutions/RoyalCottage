using System;
using System.Collections.Generic;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core.Serialization;
using Unity;
using Unity.Resolution;

namespace Nandalala.Framework.Couchbase
{
    /// <summary>
    /// CouchbaseHelper
    /// Make sure ICacheClient is registered in Unity with name as
    /// UnityUtil.RegisterType ICacheClient, CouchbaseClient (container, "couchbase", new InjectionConstructor(typeof(string)));
    /// Naming constructor is needed as ICacheClient is used for both Couchbase and Memcached buckets
    /// </summary>
    public static class CouchbaseHelper
    {
        /// <summary>
        /// The couchbase client collection
        /// </summary>
        private static Dictionary<string, ICouchbaseClient> _couchbaseClients;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize(params string[] configSections)
        {
            _couchbaseClients = new Dictionary<string, ICouchbaseClient>();
            foreach (var configSection in configSections)
            {
                _couchbaseClients.Add(configSection, ResolveCouchbaseClient(configSection));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configSections"></param>
        public static void Initialize(Dictionary<string, ITypeSerializer> configSections)
        {
            _couchbaseClients = new Dictionary<string, ICouchbaseClient>();
            foreach (var configSection in configSections)
            {
                _couchbaseClients.Add(configSection.Key, ResolveCouchbaseClient(configSection));
            }
        }

        public static void Close()
        {
            foreach (var client in _couchbaseClients)
            {
                client.Value.Dispose();
            }
        }

        /// <summary>
        /// Get Client
        /// </summary>
        /// <param name="configSection">Configuration Section Name</param>
        /// <param name="client">ICache Client</param>
        public static void TryGet(string configSection, out ICouchbaseClient client)
        {
            _couchbaseClients.TryGetValue(configSection, out client);
        }

        public static void TryGet(string serverUri, string userName, string password, out ICouchbaseClient client)
        {
            client = new CouchbaseClient(
                new ClientConfiguration
                {
                    Servers = new List<Uri>
                    {
                      new Uri(serverUri)
                    }
                },
                new PasswordAuthenticator(userName, password));
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public static void Dispose()
        {
            if (_couchbaseClients.Count > 0)
            {
                foreach (var couchbaseClient in _couchbaseClients)
                {
                    couchbaseClient.Value.Dispose();
                }
            }
        }

        private static ICouchbaseClient ResolveCouchbaseClient(string configSection)
        {
            //TODO: Use Unity
            return Paas.Core.IoC.IoCResolver.Current.Resolve<ICouchbaseClient>("couchbase", new ParameterOverride("config", configSection));
            //return new CouchbaseClient(configSection);
        }

        private static ICouchbaseClient ResolveCouchbaseClient(KeyValuePair<string, ITypeSerializer> configSection)
        {
            if (configSection.Value == null)
            {
                return ResolveCouchbaseClient(configSection.Key);
            }

            return Paas.Core.IoC.IoCResolver.Current.Resolve<ICouchbaseClient>("couchbaseserialize", new ParameterOverride("configSection", configSection.Key), new ParameterOverride("serializer", configSection.Value));
        }
    }
}
