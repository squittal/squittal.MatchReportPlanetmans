﻿using squittal.ScrimPlanetmans.ScrimMatch.Models;
using System;

namespace squittal.ScrimPlanetmans.Models.ScrimMatchReports
{
    public class ScrimMatchReportInfantryDeath
    {
        public string ScrimMatchId { get; set; }
        public DateTime Timestamp { get; set; }
        public string AttackerCharacterId { get; set; }
        public string VictimCharacterId { get; set; }
        public int ScrimMatchRound { get; set; }
        public int Points { get; set; }
        public ScrimActionType ActionType { get; set; }
        public DeathEventType DeathType { get; set; }
        public int AttackerTeamOrdinal { get; set; }
        public int VictimTeamOrdinal { get; set; }
        public string AttackerNameDisplay { get; set; }
        public string VictimNameDisplay { get; set; }
        public string AttackerNameFull { get; set; }
        public string VictimNameFull { get; set; }
        public int AttackerFactionId { get; set; }
        public int VictimFactionId { get; set; }
        public int AttackerLoadoutId { get; set; }
        public int VictimLoadoutId { get; set; }
        public int IsHeadshot { get; set; }
        public int WeaponId { get; set; }
        public string WeaponName { get; set; }
        public int ZoneId { get; set; }
        public int WorldId { get; set; }
        public int DamageAssists { get; set; }
        public int GrenadeAssists { get; set; }
        public int ConcussionGrenadeAssists { get; set; }
        public int EmpGrenadeAssists { get; set; }
        public int FlashGrenadeAssists { get; set; }
        public int SpotAssists { get; set; }
        public bool IsTrickleDeath { get; set; }
        public int? SecondsToNextDeathEvent { get; set; }
        public int? SecondsFromPreviousDeathEvent { get; set; }
    }
}
