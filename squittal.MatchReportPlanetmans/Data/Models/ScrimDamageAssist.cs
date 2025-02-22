﻿using squittal.MatchReportPlanetmans.Models.Planetside;
using squittal.MatchReportPlanetmans.ScrimMatch.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.Data.Models
{
    public class ScrimDamageAssist
    {
        [Required]
        public string ScrimMatchId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public string AttackerCharacterId { get; set; }

        [Required]
        public string VictimCharacterId { get; set; }

        [Required]
        public int ScrimMatchRound { get; set; }

        public ScrimActionType ActionType { get; set; }
        //public DeathEventType DeathType { get; set; }

        public int AttackerTeamOrdinal { get; set; }
        public int VictimTeamOrdinal { get; set; }

        //public string AttackerNameFull { get; set; }
        //public int AttackerFactionId { get; set; }
        public int? AttackerLoadoutId { get; set; }
        //public string AttackerOutfitId { get; set; }
        //public string AttackerOutfitAlias { get; set; }
        //public bool AttackerIsOutfitless { get; set; }
        // public int AttackerConstructedTeamID { get; set; }
        // public bool IsAttackerFromConstructedTeam { get; set; }

        //public string VictimNameFull { get; set; }
        //public int VictimFactionId { get; set; }
        public int? VictimLoadoutId { get; set; }
        //public string VictimOutfitId { get; set; }
        //public string VictimOutfitAlias { get; set; }
        //public bool VictimIsOutfitless { get; set; }
        // public int VictimConstructedTeamID { get; set; }
        // public bool IsVictimFromConstructedTeam { get; set; }

        public int ExperienceGainId { get; set; }
        public int ExperienceGainAmount { get; set; }

        public int? ZoneId { get; set; }
        public int WorldId { get; set; }

        public int Points { get; set; }
        //public int? AttackerResultingPoints { get; set; }
        //public int? AttackerResultingNetScore { get; set; }
        //public int? VictimResultingPoints { get; set; }
        //public int? VictimResultingNetScore { get; set; }

        #region Navigation Properties
        public ScrimMatch ScrimMatch { get; set; }
        public ScrimMatchParticipatingPlayer AttackerParticipatingPlayer { get; set; }
        public ScrimMatchParticipatingPlayer VictimParticipatingPlayer { get; set; }
        //public Faction AttackerFaction { get; set; }
        //public Faction VictimFaction { get; set; }
        public Zone Zone { get; set; }
        public World World { get; set; }
        #endregion Navigation Properties
    }
}
