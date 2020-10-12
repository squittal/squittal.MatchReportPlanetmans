using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.Models.Planetside;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}
