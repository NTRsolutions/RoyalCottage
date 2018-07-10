using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoyalCottage.Product.Business.Interfaces;
using RoyalCottage.Product.Models;
using RoyalCottage.Framework.WebApi;

namespace RoyalCottage.Product.WebApi.Controllers
{
    public class PlansController : BaseController
    {
        private IPlanService _service;

        public PlansController(IPlanService service)
        {
            _service = service;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Respond(await _service.GetAllAsync(Context.TenantId));
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Respond(await _service.GetAsync<Guid>(Context.TenantId, id));
        }
        
        // POST: api/Plans
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Plan data)
        {
            data.TenantId = Context.TenantId;
            return Respond(await _service.CreateAsync(data));

        }
        
        // PUT: api/Plans/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Plan data)
        {
            return Respond(await _service.UpdateAsync(data));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Respond(await _service.DeleteAsync<Guid>(Context.TenantId, id));
        }

        [HttpGet("{id}/PlanType")]
        public async Task<IActionResult> GetPlanTypeForPlan(Guid id)
        {
            return Respond(await _service.GetChildAsync<Guid, PlanPlanType>(Context.TenantId, id, "planType"));
        }

        [HttpGet("{id}/ExcludedEmployees")]
        public async Task<IActionResult> GetExcludedEmployeesForPlan(Guid id)
        {
            return Respond(await _service.GetChildAllAsync<Guid, ExcludedEmployee>(Context.TenantId, id, "ExcludedEmployees"));
        }

        [HttpPost("{id}/ExcludedEmployees")]
        public async Task<IActionResult> AddExcludedEmployeeToPlan(Guid id, [FromBody]List<ExcludedEmployee> excludedEmployees)
        {
            //var response = await _service.DeleteChildAsync<ExcludedEmployee>(Context.TenantId, id, "ExcludedEmployees");
            //if (response.Status != Framework.Core.Models.BusinessStatus.Deleted)
            //{
            //    return Respond(response);
            //}
            //return Respond(await _service.CreateChildAsync<ExcludedEmployee>(Context.TenantId, id, "ExcludedEmployees", excludedEmployees));
            return Respond(await _service.UpdateChildAsync<ExcludedEmployee>(Context.TenantId, id, "ExcludedEmployees", excludedEmployees));
        }
        [HttpPost("{id}/BusinessRules")]
        public async Task<IActionResult> AddBusinessRulesToPlan(Guid id, [FromBody]List<BusinessRules> saveBusinesRules)
        {
            if (saveBusinesRules.Count>0 && saveBusinesRules!=null)
            {
                return Respond(await _service.UpdateChildAsync<BusinessRules>(Context.TenantId, id, "BusinessRules", saveBusinesRules));
            }
            else
            {
                throw new Exception("No Bussines Rules found to save");
            }
        }
    }
}
