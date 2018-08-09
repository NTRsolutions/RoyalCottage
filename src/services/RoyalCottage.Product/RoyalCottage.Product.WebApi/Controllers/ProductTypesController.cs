using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.WebApi;

namespace RoyalCottage.Product.WebApi.Controllers
{
    public class ProductTypesController : BaseController
    {
        private IProductTypeService _service;

        public ProductTypesController(IProductTypeService service)
        {
            _service = service;
        }

        // GET: api/ProductTypes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Respond(await _service.GetAllAsync(Context.TenantId));
        }

        // GET: api/ProductTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Respond(await _service.GetAsync<Guid>(Context.TenantId, id));
        }

        // POST: api/ProductTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductType data)
        {
            data.TenantId = Context.TenantId;
            data.CreatedOn = DateTime.Now;
            return Respond(await _service.CreateAsync(data));

        }

        // PUT: api/ProductTypes/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ProductType data)
        {
            data.UpdatedOn = DateTime.Now;
            return Respond(await _service.UpdateAsync(data));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Respond(await _service.DeleteAsync<Guid>(Context.TenantId, id));
        }
    }
}
