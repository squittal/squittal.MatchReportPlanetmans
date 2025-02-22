﻿using squittal.MatchReportPlanetmans.Models.Planetside;
using System.ComponentModel.DataAnnotations;

namespace squittal.MatchReportPlanetmans.ScrimMatch.Models
{
    public class RulesetItemCategoryRule
    {
        [Required]
        public int RulesetId { get; set; }

        [Required]
        public int ItemCategoryId { get; set; }
        
        public int Points { get; set; }

        public Ruleset Ruleset { get; set; }
        public ItemCategory ItemCategory { get; set; }

    }
}
