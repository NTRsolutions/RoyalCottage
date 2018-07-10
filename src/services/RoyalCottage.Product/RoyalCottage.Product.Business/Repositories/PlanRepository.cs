using RoyalCottage.Product.Models;
using RoyalCottage.Framework.Couchbase;
using RoyalCottage.Framework.Couchbase.Repositories;
using RoyalCottage.Product.Business.Interfaces;
using System.Threading.Tasks;
using RoyalCottage.Framework.Core.Models;
using System;
using Couchbase.N1QL;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace RoyalCottage.Product.Business.Repositories
{
    public class PlanRepository : CouchbaseRepository<Plan>, IPlanRepository
    {
        private ICouchbaseBucket _bucket;
        public PlanRepository(ICouchbaseBucket bucket) : base(bucket)
        {
            _bucket = bucket;
        }
        //public new async Task<BusinessResponse<Plan>> GetAllAsync(Guid tenantId, Guid typeId)
        //{
        //    var response = new BusinessResponse<Plan>();
        //    List<Plan> plans = new List<Plan>();
        //    try
        //    {
        //        var queryStatement = $"SELECT id,planTypeId, name, description, createdBy,createdOn,updatedOn,updatedBy from {_bucket.BucketName} Where tenantId=$tenantId";
        //        var query = new QueryRequest()
        //            .Statement(queryStatement)
        //            .AddNamedParameter(new KeyValuePair<string, object>[] {
        //            new KeyValuePair<string, object>("tenantId", tenantId)
        //            });

        //        var result = await _bucket.QueryAsync<Plan>(query);
        //        foreach (var row in result.Rows)
        //        {
        //            plans.Add(JsonConvert.DeserializeObject<Plan>(JsonConvert.SerializeObject(row)));
        //        }
        //        var resultplanName = (from n in plans
        //                             join m in plans on n.PlanTypeId equals m.Id
        //                             select new Plan() {
        //                                 Id = n.Id, PlanTypeId = n.PlanTypeId, Name = n.Name, Description = n.Description, CreatedBy = n.CreatedBy, CreatedOn = n.CreatedOn,
        //                                 UpdatedBy = n.UpdatedBy, UpdatedOn = n.UpdatedOn, PlanName = m.Name
        //                             }).ToList();
        //        if (result.Success)
        //        {
        //            response.Status = BusinessStatus.Ok;
        //            response.DataList = resultplanName;
        //        }
        //        else
        //        {
        //            response.Status = BusinessStatus.Error;
        //            response.Errors = new List<ErrorInfo> { new ErrorInfo { ErrorMessage = result.Message } };
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //    return response;
            
        //}

    }
}
