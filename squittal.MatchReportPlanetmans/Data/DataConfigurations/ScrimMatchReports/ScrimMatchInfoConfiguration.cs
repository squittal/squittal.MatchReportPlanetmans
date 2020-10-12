using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.Models.ScrimMatchReports;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class ScrimMatchInfoConfiguration : IEntityTypeConfiguration<ScrimMatchInfo>
    {
        public void Configure(EntityTypeBuilder<ScrimMatchInfo> builder)
        {
            builder.ToView("View_ScrimMatchInfo");

            builder.HasNoKey();

            builder.Ignore(e => e.TeamAliases);
        }
    }
}
