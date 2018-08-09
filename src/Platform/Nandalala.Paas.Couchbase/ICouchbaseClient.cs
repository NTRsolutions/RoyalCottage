using System;

namespace Nandalala.Framework.Couchbase
{
    /// <summary>
    /// ICouchbase client
    /// </summary>
    public interface ICouchbaseClient: IDisposable
    {
        ICouchbaseBucket GetBucket(string name);
    }
}
