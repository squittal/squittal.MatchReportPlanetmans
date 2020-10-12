using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using squittal.MatchReportPlanetmans.Models.Planetside;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.ToTable("ItemCategory");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}
