﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using squittal.ScrimPlanetmans.Data.Models;

namespace squittal.ScrimPlanetmans.Data.DataConfigurations
{
    public class ScrimReviveConfiguration : IEntityTypeConfiguration<ScrimRevive>
    {
        public void Configure(EntityTypeBuilder<ScrimRevive> builder)
        {
            builder.ToTable("ScrimRevive");

            builder.HasKey(e => new
            {
                e.ScrimMatchId,
                e.Timestamp,
                e.MedicCharacterId,
                e.RevivedCharacterId
            });

            builder.Property(e => e.ExperienceGainAmount).HasDefaultValue(0);
            builder.Property(e => e.Points).HasDefaultValue(0);

            builder.Ignore(e => e.ScrimMatch);
            builder.Ignore(e => e.MedicParticipatingPlayer);
            builder.Ignore(e => e.RevivedParticipatingPlayer);
            //builder.Ignore(e => e.MedicFaction);
            //builder.Ignore(e => e.RevivedFaction);
            builder.Ignore(e => e.World);
            builder.Ignore(e => e.Zone);
        }
    }
}
