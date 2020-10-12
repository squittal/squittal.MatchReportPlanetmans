using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using squittal.MatchReportPlanetmans.ScrimMatch.Models;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class VehicleClassConfiguration : IEntityTypeConfiguration<VehicleClass>
    {
        public void Configure(EntityTypeBuilder<VehicleClass> builder)
        {
            builder.ToTable("VehicleClass");

            builder.HasKey(e => e.Class);
        }
    }
}
