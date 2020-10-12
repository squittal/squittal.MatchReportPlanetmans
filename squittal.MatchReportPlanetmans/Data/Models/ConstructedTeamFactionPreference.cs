using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.Data.Models
{
    public class ConstructedTeamFactionPreference
    {
        [Required]
        public int ConstructedTeamId { get; set; }

        [Required]
        public int PreferenceOrdinalValue { get; set; }

        [Required]
        public int FactionId { get; set; }

        public ConstructedTeam ConstructedTeam { get; set; }
    }
}
