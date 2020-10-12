﻿namespace squittal.ScrimPlanetmans.Models.ScrimMatchReports
{
    public class ScrimMatchReportInfantryTeamRoundStats : ScrimMatchReportStats
    {
        public string ScrimMatchId { get; set; }
        public int ScrimMatchRound { get; set; }
        public int TeamOrdinal { get; set; }
        public int FacilityCapturePoints { get; set; }

        public int GrenadeAssists { get; set; }
        public int SpotAssists { get; set; }

        public int GrenadeTeamAssists { get; set; }
    }
}
