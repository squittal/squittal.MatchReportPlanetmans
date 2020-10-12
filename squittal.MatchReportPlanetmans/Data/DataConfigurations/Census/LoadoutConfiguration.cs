using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.Models.Planetside;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class LoadoutConfiguration : IEntityTypeConfiguration<Loadout>
    {
        public void Configure(EntityTypeBuilder<Loadout> builder)
        {
            builder.ToTable("Loadout");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Ignore(e => e.Profile);
        }
    }
}
