using Microsoft.AspNetCore.Mvc;
using RoyalCottage.MasterData.Business.Interfaces;
using RoyalCottage.MasterData.Models;
using RoyalCottage.Framework.Couchbase.Models;
using RoyalCottage.Framework.WebApi;
using System.Threading.Tasks;

namespace RoyalCottage.MasterData.WebApi.Controllers
{
    public class MasterDataController<T> : BaseController
        where T : CouchbaseTenantEntityBase
    {
        private IMasterDataService<T> _service;

        public MasterDataController(IMasterDataService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Respond(await _service.GetAllAsync(TypeConstants.TenantId));
        }
    }

    public class CompaniesController : MasterDataController<Company>
    {
        public CompaniesController(IMasterDataService<Company> service) : base(service) {
        }
    }

    public class GendersController : MasterDataController<Gender>
    {//Gender
        public GendersController(IMasterDataService<Gender> service) : base(service)
        {
        }
    }
    public class GradesController : MasterDataController<Grade>
    {
        public GradesController(IMasterDataService<Grade> service) : base(service)
        {
        }
    }
    public class MenusController : MasterDataController<Menu>
    {
        public MenusController(IMasterDataService<Menu> service) : base(service)
        {
        }
    }
    public class LevelsController : MasterDataController<Level>
    {
        public LevelsController(IMasterDataService<Level> service) : base(service)
        {
        }
    }
    public class LocationsController : MasterDataController<Location>
    {
        public LocationsController(IMasterDataService<Location> service) : base(service)
        {
        }
    }
    public class ProficiencyLevelsController : MasterDataController<ProficiencyLevel>
    {
        public ProficiencyLevelsController(IMasterDataService<ProficiencyLevel> service) : base(service)
        {
        }
    }
    public class RolesController : MasterDataController<Role>
    {
        public RolesController(IMasterDataService<Role> service) : base(service)
        {
        }
    }
    public class StatusesController : MasterDataController<Status>
    {
        public StatusesController(IMasterDataService<Status> service) : base(service)
        {
        }
    }
    public class MenuItemsController : MasterDataController<MenuItem>
    {
        public MenuItemsController(IMasterDataService<MenuItem> service) : base(service)
        {
        }

        //[HttpGet("/api/MenuItems/GetAllMenuItems")]
        //public async Task<IActionResult> GetAllMenuItems()
        //{
        //    //var response=""
        //    return Respond(await _service.GetAllAsync(TypeConstants.TenantId));
        //}
    }
}