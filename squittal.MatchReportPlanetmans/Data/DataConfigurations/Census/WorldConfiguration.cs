using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.Models.Planetside;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class WorldConfiguration : IEntityTypeConfiguration<World>
    {
        public void Configure(EntityTypeBuilder<World> builder)
        {
            builder.ToTable("World");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}
