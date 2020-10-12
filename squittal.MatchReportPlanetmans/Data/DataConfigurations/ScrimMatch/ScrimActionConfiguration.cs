using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.ScrimMatch.Models;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class ScrimActionConfiguration : IEntityTypeConfiguration<ScrimAction>
    {
        public void Configure(EntityTypeBuilder<ScrimAction> builder)
        {
            builder.ToTable("ScrimAction");

            builder.HasKey(e => e.Action);
        }
    }
}
