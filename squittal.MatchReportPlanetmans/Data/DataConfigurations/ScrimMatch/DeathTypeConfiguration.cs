using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using squittal.MatchReportPlanetmans.ScrimMatch.Models;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class DeathTypeConfiguration : IEntityTypeConfiguration<DeathType>
    {
        public void Configure(EntityTypeBuilder<DeathType> builder)
        {
            builder.ToTable("DeathType");

            builder.HasKey(e => e.Type);
        }
    }
}
