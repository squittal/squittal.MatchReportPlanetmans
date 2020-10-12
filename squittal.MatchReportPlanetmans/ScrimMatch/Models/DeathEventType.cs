using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.ScrimMatch.Models
{
    public class DeathType
    {
        [Required]
        public DeathEventType Type { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public enum DeathEventType
    {
        Kill = 0,
        Teamkill = 1,
        Suicide = 2
    }
}
