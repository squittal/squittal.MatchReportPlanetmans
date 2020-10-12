using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using squittal.MatchReportPlanetmans.Data.Models;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class ConstructedTeamConfiguration : IEntityTypeConfiguration<ConstructedTeam>
    {
        public void Configure(EntityTypeBuilder<ConstructedTeam> builder)
        {
            builder.ToTable("ConstructedTeam");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsHiddenFromSelection).HasDefaultValue(false);
        }
    }
}
