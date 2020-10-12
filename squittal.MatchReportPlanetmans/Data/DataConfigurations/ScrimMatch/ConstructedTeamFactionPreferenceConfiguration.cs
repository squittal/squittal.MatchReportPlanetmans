using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using squittal.MatchReportPlanetmans.Data.Models;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class ConstructedTeamFactionPreferenceConfiguration : IEntityTypeConfiguration<ConstructedTeamFactionPreference>
    {
        public void Configure(EntityTypeBuilder<ConstructedTeamFactionPreference> builder)
        {
            builder.ToTable("ConstructedTeamFactionPreference");

            builder.HasKey(e => new
            {
                e.ConstructedTeamId,
                e.PreferenceOrdinalValue
            });

            //builder.HasOne(faction => faction.ConstructedTeam)
            //    .WithMany(team => team.FactionPreferences)
            //    .HasForeignKey(faction => faction.ConstructedTeamId);
        }
    }
}
