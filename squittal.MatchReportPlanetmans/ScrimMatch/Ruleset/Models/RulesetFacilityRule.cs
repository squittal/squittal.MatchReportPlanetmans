using squittal.MatchReportPlanetmans.Models.Planetside;
using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.ScrimMatch.Models
{
    public class RulesetFacilityRule
    {
        [Required]
        public int RulesetId { get; set; }
        [Required]
        public int FacilityId { get; set; }
        [Required]
        public int MapRegionId { get; set; }

        public Ruleset Ruleset { get; set; }
        public MapRegion MapRegion { get; set; }
    }
}
