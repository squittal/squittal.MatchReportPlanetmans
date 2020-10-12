using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.Models.Planetside
{
    public class ItemCategory
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsWeaponCategory { get; set; }

        public ItemCategoryDomain Domain { get; set; }
    }
}
