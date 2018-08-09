using Couchbase.Collections;
using Couchbase.Core;
using Couchbase.N1QL;
using RoyalCottage.MasterData.Business.Interfaces;
using RoyalCottage.MasterData.Models;
using RoyalCottage.Framework.Core.Models;
using RoyalCottage.Framework.Couchbase;
using RoyalCottage.Framework.Couchbase.Models;
using RoyalCottage.Framework.Couchbase.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoyalCottage.MasterData.Business.Repositories
{
    public class MasterDataRepository<T> : CouchbaseRepository<T>, IMasterDataRepository<T>
        where T : CouchbaseTenantEntityBase
    {
        public MasterDataRepository(ICouchbaseBucket bucket) : base(bucket)
        {
        }
    }

}
