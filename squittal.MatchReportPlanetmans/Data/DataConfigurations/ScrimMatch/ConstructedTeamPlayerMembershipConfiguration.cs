using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using squittal.MatchReportPlanetmans.Data.Models;

namespace squittal.MatchReportPlanetmans.Data.DataConfigurations
{
    public class ConstructedTeamPlayerMembershipConfiguration : IEntityTypeConfiguration<ConstructedTeamPlayerMembership>
    {
        public void Configure(EntityTypeBuilder<ConstructedTeamPlayerMembership> builder)
        {
            builder.ToTable("ConstructedTeamPlayerMembership");

            builder.HasKey(e => new
            {
                e.ConstructedTeamId,
                e.CharacterId
            });

            builder.HasOne(member => member.ConstructedTeam)
                .WithMany(team => team.PlayerMemberships)
                .HasForeignKey(member => member.ConstructedTeamId);
        }
    }
}
