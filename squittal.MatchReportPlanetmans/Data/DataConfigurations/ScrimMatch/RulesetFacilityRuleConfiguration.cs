using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.Models.Planetside;
using squittal.MatchReportPlanetmans.ScrimMatch.Models;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class RulesetFacilityRuleConfiguration : IEntityTypeConfiguration<RulesetFacilityRule>
    {
        public void Configure(EntityTypeBuilder<RulesetFacilityRule> builder)
        {
            builder.ToTable("RulesetFacilityRule");

            builder.HasKey(e => new { e.RulesetId, e.FacilityId });

            builder.Ignore(e => e.MapRegion);

            builder.HasOne(e => e.MapRegion)
                .WithOne()
                .HasForeignKey<RulesetFacilityRule>(e => new { e.MapRegionId, e.FacilityId });

            builder.HasOne(e => e.Ruleset)
                .WithMany(r => r.RulesetFacilityRules)
                .HasForeignKey(e => e.RulesetId);
        }
    }
}
