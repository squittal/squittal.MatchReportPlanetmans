﻿using System;
using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.Models.Planetside.Events
{
    public class PlayerLogin
    {
        [Required]
        public string CharacterId { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        public int WorldId { get; set; }
    }
}
