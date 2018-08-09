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
    public class ProductRepository : CouchbaseRepository<ProductDetail>, IProductRepository
    {
        private ICouchbaseBucket _bucket;
        public ProductRepository(ICouchbaseBucket bucket) : base(bucket)
        {
            _bucket = bucket;
        }
        //public new async Task<BusinessResponse<Product>> GetAllAsync(Guid tenantId, Guid typeId)
        //{
        //    var response = new BusinessResponse<Product>();
        //    List<Product> Products = new List<Product>();
        //    try
        //    {
        //        var queryStatement = $"SELECT id,ProductTypeId, name, description, createdBy,createdOn,updatedOn,updatedBy from {_bucket.BucketName} Where tenantId=$tenantId";
        //        var query = new QueryRequest()
        //            .Statement(queryStatement)
        //            .AddNamedParameter(new KeyValuePair<string, object>[] {
        //            new KeyValuePair<string, object>("tenantId", tenantId)
        //            });

        //        var result = await _bucket.QueryAsync<Product>(query);
        //        foreach (var row in result.Rows)
        //        {
        //            Products.Add(JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(row)));
        //        }
        //        var resultProductName = (from n in Products
        //                             join m in Products on n.ProductTypeId equals m.Id
        //                             select new Product() {
        //                                 Id = n.Id, ProductTypeId = n.ProductTypeId, Name = n.Name, Description = n.Description, CreatedBy = n.CreatedBy, CreatedOn = n.CreatedOn,
        //                                 UpdatedBy = n.UpdatedBy, UpdatedOn = n.UpdatedOn, ProductName = m.Name
        //                             }).ToList();
        //        if (result.Success)
        //        {
        //            response.Status = BusinessStatus.Ok;
        //            response.DataList = resultProductName;
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
