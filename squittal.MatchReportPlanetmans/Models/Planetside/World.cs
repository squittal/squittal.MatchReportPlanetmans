using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.Models.Planetside
{
    public class World
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
