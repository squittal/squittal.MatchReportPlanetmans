﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.Models.Planetside;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Character");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.PrestigeLevel).HasDefaultValue(0);

            builder
                .Ignore(e => e.World)
                .Ignore(e => e.Faction);
        }
    }
}
