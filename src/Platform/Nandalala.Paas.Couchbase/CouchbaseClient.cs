using System;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core.Serialization;


namespace Nandalala.Framework.Couchbase
{
    public class CouchbaseClient : ICouchbaseClient
    {

        /// <summary>
        /// Client Configuration
        /// </summary>
        private ClientConfiguration _config;


        /// <summary>
        /// CouchbaseClient
        /// </summary>
        public CouchbaseClient(ClientConfiguration config)
        {
            ClusterHelper.Initialize(config);
            Initialize();

        }

        /// <summary>
        /// CouchbaseClient
        /// </summary>
        public CouchbaseClient(string config)
        {
            ////TODO: Need to move to couchbase Core implementation
            //ClusterHelper.Initialize(config);
            Initialize();

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CouchbaseClient"/> class.
        /// </summary>
        /// <param name="configSection">The configuration section.</param>
        /// <param name="serializer">The serializer.</param>
        public CouchbaseClient(string configSection, ITypeSerializer serializer)
        {
            ////TODO: Need to move to couchbase Core implementation
            //ClusterHelper.Initialize(configSection);
            Initialize(serializer);
        }

        public CouchbaseClient(ClientConfiguration clientConfiguration, PasswordAuthenticator passwordAuthenticator)
        {
            ////TODO: Need to move to couchbase Core implementation
            ClusterHelper.Initialize(clientConfiguration, passwordAuthenticator);
        }



        /// <summary>
        /// Get/Set the base class property
        /// </summary>
        private ClientConfiguration Config
        {
            get { return _config as ClientConfiguration; }
            set { _config = value; }
        }


        /// <summary>
        /// Initializes the specified serializer.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        private void Initialize(ITypeSerializer serializer = null)
        {
            if (serializer != null)
            {
                Config.Serializer = (() => serializer);
            }

        }

        public ICouchbaseBucket GetBucket(string name)
        {
            try
            {
                var bucket = ClusterHelper.GetBucket(name, "");
                return new CouchbaseBucket(this, bucket);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            ClusterHelper.Close();
        }
    }
}
