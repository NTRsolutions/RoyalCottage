using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.WebApi;

namespace RoyalCottage.Product.WebApi.Controllers
{
    public class RatingsController : BaseController
    {
        private IRatingService _service;

        public RatingsController(IRatingService service)
        {
            _service = service;
        }

        // GET: api/Rating
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Respond(await _service.GetAllAsync(Context.TenantId));
        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Respond(await _service.GetAsync<Guid>(Context.TenantId, id));
        }

        // POST: api/Rating
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Rating data)
        {
            data.TenantId = Context.TenantId;
            data.CreatedOn = DateTime.Now;
            return Respond(await _service.CreateAsync(data));

        }

        // PUT: api/Rating/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Rating data)
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
