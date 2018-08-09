using RoyalCottage.MasterData.Models;
using System.Collections.Generic;

namespace RoyalCottage.MasterData.WebApi.ViewModel
{
    public class MasterDataViewModel
    {
        public List<Company> Companies { get; set; }
        public List<Location> Locations { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Role> Roles { get; set; }
        public List<Level> Levels { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Status> Statuses { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<ProficiencyLevel> ProficiencyLevels { get; set; }
    }
}
