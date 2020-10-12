using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.Models.Planetside
{
    public class FacilityType
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
